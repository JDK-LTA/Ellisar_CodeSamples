using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Animations
{
    [RequireComponent(typeof(Collider))]
    public class AnimationTrigger : TriggerEnter
    {
        [Title("Animation Specific")]
        [SerializeField] protected Animator animator;
        [SerializeField] protected bool autoDestroy = false;
        [SerializeField] protected string triggerName;

        protected override void TriggerAction()
        {
            animator.SetTrigger(triggerName);

            if (autoDestroy) Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class AnimatorInfo
    {
        public Animator animator;
        public string triggerName;
    }
}