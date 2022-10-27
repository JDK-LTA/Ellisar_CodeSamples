using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Animations
{
    public class AnimationIntChanger : TriggerEnter
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string intName;
        [SerializeField] private int value;

        protected override void TriggerAction()
        {
            if (animator)
            {
                animator.SetInteger(intName, value); 
            }
        }
    }
}
