using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ellisar
{
    public class InteractBehaviour : StateMachineBehaviour
    {
        [SerializeField] private float normFadeIn = 0.25f, normFadeOut = 0.35f;

        private bool fading;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            animator.SetLayerWeight(layerIndex, 0);
            fading = true;
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            animator.SetLayerWeight(layerIndex, 0);
            fading = false;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float normalizedTime = stateInfo.normalizedTime;

            if (normalizedTime <= normFadeIn)
            {
                animator.SetLayerWeight(layerIndex, Mathf.Lerp(0, 1, normalizedTime / normFadeIn));
            }
            else if (normalizedTime >= 1 - normFadeOut)
            {
                animator.SetLayerWeight(layerIndex, Mathf.Lerp(1, 0, normalizedTime / 1 - normFadeOut));
            }
            else
            {
                if (fading)
                {
                    animator.SetLayerWeight(layerIndex, 1);
                    fading = false;
                }
            }
        }
    }
}
