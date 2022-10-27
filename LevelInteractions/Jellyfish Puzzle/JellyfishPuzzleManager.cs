using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Jellyfish_Puzzle
{
    public class JellyfishPuzzleManager : MonoBehaviour
    {
        public static JellyfishPuzzleManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        [SerializeField] private bool _spot1Visited;
        [SerializeField] private bool _spot2Visited;
        [SerializeField] private Animator jellyfishAnimator;
        [SerializeField] private List<GameObject> triggersAfterCompleted;
        [SerializeField] private UnityEvent changeTextEvent;
        [SerializeField] private GameObject mineral0Indicator;
        private bool completed = false;
        private bool textIsChanged = false;

        public bool Spot1Visited
        {
            get => _spot1Visited;
            set
            {
                _spot1Visited = value;
                jellyfishAnimator.SetInteger("NextSpot", 1);
                if (_spot1Visited && _spot2Visited && !completed)
                {
                    Complete();
                }

                mineral0Indicator.SetActive(true);

                //if (!textIsChanged)
                //{
                //    textIsChanged = true;
                //    changeTextEvent?.Invoke();
                //}
            }
        }

        private void Complete()
        {
            jellyfishAnimator.SetBool("Completed", true);
            completed = true;
            foreach (var tr in triggersAfterCompleted)
            {
                tr.SetActive(true);
            }
        }

        public bool Spot2Visited
        {
            get => _spot2Visited;
            set
            {
                _spot2Visited = value;
                jellyfishAnimator.SetInteger("NextSpot", 2);
                if (_spot1Visited && _spot2Visited && !completed)
                {
                    Complete();
                }

                mineral0Indicator.SetActive(true);

                //if (!textIsChanged)
                //{
                //    textIsChanged = true;
                //    changeTextEvent?.Invoke();
                //}
            }
        }
    }
}