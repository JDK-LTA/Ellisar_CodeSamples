using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.RuneStar_Puzzle
{
    public class RunePuzzleManager : MonoBehaviour
    {
        public static RunePuzzleManager Instance;

        private void Awake()
        {
            Instance = this;
        }


        [SerializeField] private GameObject triggerOfNoActionSpending;
        [SerializeField] private GameObject triggerComboKiller;
        [SerializeField] private Animator shellAnimator;
        [SerializeField] private List<RuneCombinationPiece> combinationPieces;
        [SerializeField] private List<Rune> runes;
        [SerializeField] private List<char> letterCombination;
        [SerializeField, ReadOnly] private List<char> letterInput;
        [SerializeField, ReadOnly] private bool canEndPuzzle = true;

        [ReadOnly, SerializeField] private float t = 0;

        public delegate void RuneMessages();

        public event RuneMessages ResetPieces;

        private int _activeIndex = -1;

        private void Start()
        {
            runes[0].canBeActivated = true;

            for (var i = 0; i < letterCombination.Count; i++)
            {
                letterCombination[i] = Char.ToUpper(letterCombination[i]);
            }
        }

        private void Update()
        {
            if (_activeIndex != -1)
            {
                var r = runes[_activeIndex];

                if (!r.full)
                {
                    t += Time.deltaTime;

                    if (t >= r.timeToPulse)
                    {
                        if (!r.balls[0].matChanger.Pulsating)
                            foreach (var ball in r.balls)
                            {
                                ball.matChanger.Pulsating = true;
                            }

                        if (t >= r.timeToDisappear)
                        {
                            foreach (var ball in r.balls)
                            {
                                ball.transform.position = ball.initPos;
                                ball.matChanger.Pulsating = false;
                                ball.Attracting = false;
                            }

                            if (r.pathParent) r.pathParent.SetActive(false);
                            _activeIndex = -1;
                            t = 0;
                        }
                    }
                }
                else
                {
                    _activeIndex = -1;
                }
            }
        }

        public void AddLetterInput(char let)
        {
            if (canEndPuzzle)
            {
                letterInput.Add(let);
                //Add VFX highlighting

                if (letterInput.Count == letterCombination.Count && letterCombination.SequenceEqual(letterInput))
                {
                    triggerOfNoActionSpending.SetActive(false);
                    triggerComboKiller.SetActive(false);
                    shellAnimator.SetTrigger("Activate");
                }
            }
        }

        public void ResetLetterInput()
        {
            if (canEndPuzzle)
            {
                letterInput.Clear();
                ResetPieces?.Invoke();
                //Remove VFX highlighting
            }
        }


        public void ActivateRune(int index)
        {
            var r = runes[index];
            if (index < runes.Count - 1)
            {
                if (!r.full && r.canBeActivated)
                {
                    if (r.pathParent) r.pathParent.SetActive(true);
                    _activeIndex = index;
                }
            }
            else
            {
                if (!r.full && r.canBeActivated)
                {
                    //ACTIVATE CENTRAL AREA
                    // foreach (var piece in combinationPieces)
                    // {
                    //     piece.CanBeActivated = true;
                    // }
                    // triggerOfNoActionSpending.SetActive(true);
                    // triggerComboKiller.SetActive(true);
 
                    canEndPuzzle = true;
                    r.full = true;
                    _activeIndex = -1;
                
                    shellAnimator.SetTrigger("Activate");
                }
            }
        }

        public void RemoveBallFromList(BallAttractionBehaviour ball)
        {
            var r = runes[ball.RuneIndex];

            r.balls.Remove(ball);

            if (r.balls.Count == 0)
            {
                r.full = true;
                t = 0;

                if (ball.RuneIndex < runes.Count - 1)
                {
                    runes[ball.RuneIndex + 1].canBeActivated = true;
                    foreach (var run in runes[ball.RuneIndex + 1].runes)
                    {
                        run.Pulsating = true;
                    }
                    runes[ball.RuneIndex + 1].runeSpheres.SetTrigger("Activate");
                }
            }
        }

        public void CheckAndSetPathFalse(int index)
        {
            if (index > 0 && runes[index - 1].full)
            {
                if (runes[index - 1].pathParent) runes[index - 1].pathParent.SetActive(false);
            }
        }
    }

    [Serializable]
    public class Rune
    {
        public List<MaterialChanger> runes = new List<MaterialChanger>();
        public Animator runeSpheres;
        public List<BallAttractionBehaviour> balls = new List<BallAttractionBehaviour>();
        public GameObject pathParent;

        public float timeToDisappear = 15f;
        public float timeToPulse = 12f;

        [ReadOnly] public bool canBeActivated;
        [ReadOnly] public bool full;
    }
}