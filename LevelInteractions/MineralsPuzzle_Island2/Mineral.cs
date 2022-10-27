using Ellisar.EllisarAssets.Scripts.LevelInteractions.Interactables;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.MineralsPuzzle_Island2
{
    public class Mineral : Interactable
    {
        [Title("Mineral Specific"), SerializeField, ReadOnly] private bool isActivated;
        [SerializeField] private GameObject mineralTrail;
        [SerializeField] private UnityEvent activationEvent;

        public bool IsActivated => isActivated;
        
        protected override void Act()
        {
            base.Act();
            isActivated = true;
            IsInteractable = false;
            mineralTrail.SetActive(true);
            MineralsPuzzleManager.Instance.CheckToEnd();
            MineralsPuzzleManager.Instance.NextSmallMineralGlow();
            activationEvent?.Invoke();
        }
    }
}