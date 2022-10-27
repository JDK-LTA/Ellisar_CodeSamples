using System;
using MoreMountains.Feedbacks;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Cameras
{
    public class PostprocessingFeedbackManager : MonoBehaviour
    {
        public static PostprocessingFeedbackManager Instance;
        
        [SerializeField] private MMLensDistortionShaker_URP lensDistortionFeedback;
        [SerializeField] private Vector2 minMaxLensDistIntensity = new Vector2(0.25f, 0.5f);
        [SerializeField] private Vector2 minMaxLensDistTime = new Vector2(1, 2.5f);
        [SerializeField] private Vector2 minMaxImpulseForce = new Vector2(40, 200);
        [SerializeField] private AnimationCurve lensDistCurve;

        private void Awake()
        {
            Instance = this;
        }

        public void DistortLens(float force)
        {
            var t = Mathf.Lerp(0, 1, (force - minMaxImpulseForce.x) / (minMaxImpulseForce.y - minMaxImpulseForce.x));
            
            var intensity = Mathf.Lerp(minMaxLensDistIntensity.x, minMaxLensDistIntensity.y, t);
            var time = Mathf.Lerp(minMaxLensDistTime.x, minMaxLensDistTime.y, t);
            
            lensDistortionFeedback.RemapIntensityOne = intensity;
            lensDistortionFeedback.ShakeDuration = time;
            lensDistortionFeedback.ShakeIntensity = lensDistCurve;
            
            lensDistortionFeedback.Play();
        }
    }
}
