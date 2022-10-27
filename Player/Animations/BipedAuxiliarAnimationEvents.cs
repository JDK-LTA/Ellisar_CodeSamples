using Ellisar.EllisarAssets.Scripts.Audio;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Animations
{
    public class BipedAuxiliarAnimationEvents : MonoBehaviour
    {
        [SerializeField] private SoundEmitter footLeft, footRight;
        [SerializeField] private ParticleSystem poofLeft, poofRight;
        private PlayerAnimationController _animationController;
        // Start is called before the first frame update
        void Start()
        {
            _animationController = GetComponentInParent<PlayerAnimationController>();
        }

        public void ResetJumpLandBool()
        {
            _animationController.ResetJumpLandBool();
        }

        public void StepAudioL()
        {
            if (footLeft) footLeft.Post();
            if (poofLeft) poofLeft.Play();
        }
        public void StepAudioR()
        {
            if (footRight) footRight.Post();
            if (poofRight) poofRight.Play();
        }

    }
}
