using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Interactables
{
    public class CallbackInteractable : Interactable
    {
        [Title("Callbacks")]
        [SerializeField] private UnityEvent interact;
        [SerializeField] private UnityEvent enterTrigger, exitTrigger;
    
        protected override void Act()
        {
            base.Act();
            interact?.Invoke();
        }

        protected override void CanActivateTrue()
        {
            base.CanActivateTrue();
            if(isInteractable)
                enterTrigger?.Invoke();
        }

        protected override void CanActivateFalse()
        {
            base.CanActivateFalse();
            if(isInteractable)
                exitTrigger?.Invoke();
        }

        public void ForceInteractionEvent()
        {
            interact?.Invoke();
        }
    }
}
