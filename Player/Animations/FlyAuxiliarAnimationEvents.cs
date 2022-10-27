using Ellisar.EllisarAssets.Scripts.Audio;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Animations
{
    public class FlyAuxiliarAnimationEvents : MonoBehaviour
    {
        [SerializeField] private SoundEmitter flapEmitter;
        [SerializeField] private MMFeedbacks haptic;
        [SerializeField] private float delayBetweenSounds = 0.5f;
        private bool _posted = false;
        private float _postedT = 0;

    
        public void FlapSound()
        {
            if (flapEmitter && !_posted)
            {
                _posted = true;
                flapEmitter.Post();
                haptic.PlayFeedbacks();
            }
        }

        private void Update()
        {
            if (_posted)
            {
                _postedT += Time.deltaTime;
                if (_postedT >= delayBetweenSounds)
                {
                    _posted = false;
                    _postedT = 0;
                }
            }
        }
    }
}
