using System.Collections.Generic;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.MineralsPuzzle_Island2
{
    public class MiniMineralManager : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        private CaveMiniMinerals[] _miniminerals;

        private void Start()
        {
            _miniminerals = FindObjectsOfType<CaveMiniMinerals>(true);
        }

        public void ActivateMiniMinerals()
        {
            foreach (var mm in _miniminerals)
            {
                mm.enabled = true;
            }
        }

        public void SetGlowersToCam(bool value)
        {
            foreach (var mm in _miniminerals)
            {
                mm.ChangeFromPlayerToCamera(value);
            }
        }

        public void SetGlowersToTargetTransform(bool value)
        {
            if (!targetTransform) return;
            
            foreach (var mm in _miniminerals)
            {
                mm.ChangeFromPlayerToEmptyTransform(value, targetTransform);
            }
        }
    }
}
