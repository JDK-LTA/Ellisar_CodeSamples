using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Animations
{
    public class JumpLandingBehaviour : StateMachineBehaviour
    {
        [SerializeField] private float timeDisabling = 0.35f;
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayerSetup.PlayerAnimationController.DisableOnAirForSecs(timeDisabling);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayerSetup.PlayerAnimationController.ResetJumpTrigger();
        }
    }
}
