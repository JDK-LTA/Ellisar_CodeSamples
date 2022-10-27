using System;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs
{
    [RequireComponent(typeof(Renderer))]
    public class HologramBasic : MonoBehaviour
    {
        [SerializeField] private Vector2 distanceMinMax = new Vector2(1, 10);
        [SerializeField] private Vector2 alphaMinMax = new Vector2(0, 0.8f);
        [SerializeField] private AnimationCurve lerpCurve = AnimationCurve.Linear(0, 0, 1, 1);

        private Transform _playerTr;
        private Material[] _mats;
        private Renderer _renderer;
        private float _alpha;


        private void Start()
        {
            _playerTr = PlayerSetup.CharController.transform;
            _renderer = GetComponent<Renderer>();

            _mats = _renderer.materials;
            _alpha = alphaMinMax.x;
            foreach (var mat in _mats)
            {
                mat.color = new Color(1, 1, 1, _alpha);
            }
        }

        private void Update()
        {
            var dist = Vector3.Distance(transform.position, _playerTr.position);

            if (!(dist <= distanceMinMax.y)) return;

            dist = Mathf.Clamp(dist, distanceMinMax.x, distanceMinMax.y);

            _alpha = Mathf.Lerp(alphaMinMax.x, alphaMinMax.y,
                lerpCurve.Evaluate((distanceMinMax.y - dist) / (distanceMinMax.y - distanceMinMax.x)));

            foreach (var mat in _mats)
            {
                mat.color = new Color(1, 1, 1, _alpha);
            }
        }
    }
}
