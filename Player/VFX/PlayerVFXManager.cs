using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ellisar.EllisarAssets.Scripts.Player.VFX
{
    public class PlayerVFXManager : MonoBehaviour
    {
        public static PlayerVFXManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        [FoldoutGroup("REFERENCES"), SerializeField] private VFX poof;
        [FoldoutGroup("REFERENCES"), SerializeField] private VFX glowTransformation;
        [FoldoutGroup("REFERENCES"), SerializeField] private VFX explosionTransformation;
        [FoldoutGroup("REFERENCES"), SerializeField] private VFX_OnPosition marker;
        [FoldoutGroup("REFERENCES"), SerializeField] private VFX wind;
        [FoldoutGroup("REFERENCES"), SerializeField] private FlightTrail flightTrail;

        [FormerlySerializedAs("markerDistance")] [SerializeField] private float markerMaxDistance = 50f;
        [SerializeField] private float markerMinDistance = 0.35f;
        [SerializeField] private float markerYOffset = 0.15f;

        public VFX Poof => poof;

        public VFX GlowTransformation => glowTransformation;

        public VFX ExplosionTransformation => explosionTransformation;

        public VFX_OnPosition Marker => marker;

        public VFX Wind => wind;

        public float MarkerMaxDistance => markerMaxDistance;

        public float MarkerYOffset => markerYOffset;

        public float MarkerMinDistance => markerMinDistance;

        public FlightTrail Trail
        {
            get => flightTrail;
            set => flightTrail = value;
        }
    }

    [Serializable]
    public class VFX
    {
        public List<ParticleSystem> particleSystems;

        public void PlayAll()
        {
            foreach (var ps in particleSystems)
            {
                ps.Play(true);
            }
        }

        public virtual void StopAll()
        {
            foreach (var ps in particleSystems)
            {
                ps.Stop(true);
            }
        }
    }

    [Serializable]
    public class VFX_OnPosition : VFX
    {
        private bool _isPlaying = false;

        public void PlayOnPosition(Vector3 pos, float yOffset = 0)
        {
            foreach (var ps in particleSystems)
            {
                ps.transform.position = pos + Vector3.up * yOffset;
                ps.transform.rotation = Quaternion.identity;
                if (!_isPlaying)
                {
                    ps.Play(true);
                    _isPlaying = true;
                }
            }
        }

        public override void StopAll()
        {
            if (!_isPlaying) return;

            base.StopAll();
            _isPlaying = false;
        }
    }
}