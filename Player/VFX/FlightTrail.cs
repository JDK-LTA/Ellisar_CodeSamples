using System;
using UnityEngine;
using UnityEngine.VFX;

namespace Ellisar.EllisarAssets.Scripts.Player.VFX
{
    public class FlightTrail : MonoBehaviour
    {
        [SerializeField] private Transform fakeParent;
        [SerializeField] private float timeToFade = 0.5f;
        [SerializeField] private float maxNParticles = 1000f;
        [SerializeField] private VisualEffect vfx;

        private bool _fadeIn;
        private bool _fadeOut;
        private float _t = 0;

        public bool FadeIn
        {
            get => _fadeIn;
            set
            {
                _fadeIn = value;

                if (_fadeIn)
                {
                    vfx.Play();
                    _t = vfx.GetFloat("N_Particles") / maxNParticles;
                }
            }
        }

        public bool FadeOut
        {
            get => _fadeOut;
            set
            {
                _fadeOut = value;
                
                if (_fadeOut)
                    _t = 1 - vfx.GetFloat("N_Particles") / maxNParticles;
            }
        }

        private void Update()
        {
            transform.localPosition = fakeParent.localPosition;
            transform.localRotation = fakeParent.localRotation;

            if (FadeIn)
            {
                _t += Time.deltaTime;
                
                vfx.SetFloat("N_Particles", Mathf.Lerp(0, maxNParticles, _t / timeToFade));

                if (_t >= timeToFade)
                {
                    _t = 0;
                    FadeIn = false;
                }
            }
            else if (FadeOut)
            {
                _t += Time.deltaTime;
                
                vfx.SetFloat("N_Particles", Mathf.Lerp(maxNParticles, 0, _t / timeToFade));

                if (_t >= timeToFade)
                {
                    _t = 0;
                    FadeOut = false;
                    vfx.Stop();
                }
            }
        }
    }
}
