using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Interactables
{
    public class InteractableSetTrigger : Interactable
    {
        [Space(10), Title("Animation"), SerializeField] private Animator animator;
        [SerializeField] private string triggerName;
        
        protected override void Act()
        {
            base.Act();
            if (animator)
            {
                animator.SetTrigger(triggerName);
            }
        }
    }
}
