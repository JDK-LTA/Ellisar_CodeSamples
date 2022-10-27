using System;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs
{
    [RequireComponent(typeof(Renderer))]
    public class Hologram : MonoBehaviour
    {
        [SerializeField] private Vector2 distanceMinMax = new Vector2(3, 15);
        [SerializeField] private Vector2 alphaMinMax = new Vector2(0, 0.7f);
        [SerializeField] private AnimationCurve lerpCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] private ParticleSystem spiralPs;

        private Transform _playerTr;
        private Material _mat;
        private Renderer _renderer;
        private float _alpha;
        private ParticleSystemRenderer psRenderer;

        private static readonly int Alpha = Shader.PropertyToID("_Opacity");

        private void Start()
        {
            _playerTr = PlayerSetup.CharController.transform;
            _renderer = GetComponent<Renderer>();
            if(spiralPs)
                psRenderer = spiralPs.GetComponent<ParticleSystemRenderer>();

            _mat = _renderer.material;
            _alpha = alphaMinMax.x;
            _mat.SetFloat(Alpha, _alpha);
            if(psRenderer)
                psRenderer.material.SetFloat(Alpha, _alpha);
        }

        private void Update()
        {
            var dist = Vector3.Distance(transform.position, _playerTr.position);

            if (!(dist <= distanceMinMax.y)) return;

            dist = Mathf.Clamp(dist, distanceMinMax.x, distanceMinMax.y);

            _alpha = Mathf.Lerp(alphaMinMax.x, alphaMinMax.y,
                lerpCurve.Evaluate((distanceMinMax.y - dist) / (distanceMinMax.y - distanceMinMax.x)));

            _mat.SetFloat(Alpha, _alpha);
            if(psRenderer)
                psRenderer.material.SetFloat(Alpha, _alpha);
        }
    }
}
