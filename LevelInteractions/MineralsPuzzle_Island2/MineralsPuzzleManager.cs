using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.MineralsPuzzle_Island2
{
    public class MineralsPuzzleManager : MonoBehaviour
    {
        public static MineralsPuzzleManager Instance;

        [SerializeField] private List<Mineral> minerals;
        [SerializeField] private List<VisualEffect> corruptions;
        [SerializeField] private ParticleSystem towerVfx;
        [SerializeField] private UnityEvent endEvent;
        [SerializeField] private List<GameObject> smallMineralsTower;

        private int _smallMinIndex = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void NextSmallMineralGlow()
        {
            if (smallMineralsTower.Count > _smallMinIndex)
            {

                smallMineralsTower[_smallMinIndex].gameObject.SetActive(true);

                if (_smallMinIndex < smallMineralsTower.Count)
                    _smallMinIndex++;
            }
        }

        public void CheckToEnd()
        {
            bool checker = true;
            foreach (var min in minerals)
            {
                if (!min.IsActivated)
                {
                    checker = false;
                    break;
                }
            }

            if (checker)
            {
                //OPEN CLAM
                //TODO: END THE MINERAL ZONE
                if (corruptions.Count > 0)
                    foreach (var corruption in corruptions)
                    {
                        corruption.Stop();
                    }

                if (towerVfx)
                    towerVfx.Play();
                
                endEvent?.Invoke();
                // clamAnimator.SetTrigger(clamOpenTriggerName);
            }
        }
    }
}