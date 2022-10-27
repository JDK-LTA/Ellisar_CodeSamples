using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Animations
{
    public class AnimationTriggerEnterExit : TriggerEnterExit
    {
        [Title("Animation Specific")]
        [SerializeField] protected Animator animator;
        [SerializeField] protected string triggerName;
        [SerializeField] private string exitTriggerName;

        protected override void TriggerExitAction()
        {
            if (animator)
                animator.SetTrigger(exitTriggerName);
        }

        protected override void TriggerAction()
        {
            if (animator)
                animator.SetTrigger(triggerName);
        }
    }
}