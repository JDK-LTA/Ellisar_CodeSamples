using System;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.MineralsPuzzle_Island2
{
    public class CaveMiniMinerals : MonoBehaviour
    {
        [SerializeField] private bool selfDisable = true;
        [SerializeField] private float startGlowDistance = 35f, maxGlowDistance = 15f;
        [SerializeField, ColorUsage(true, true)] private Color glowColor;
        [SerializeField] private float minIntensityLevel = -4;
        [SerializeField] private float maxIntensityLevel;
        [SerializeField] private float speedOfIntensityChange = 5f;
        [SerializeField, ReadOnly] private float actualIntensity;
        private Transform _playerTransform;
        private MaterialPropertyBlock _propBlock;
        private MeshRenderer _renderer;
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");


        private void Start()
        {
            _playerTransform = PlayerSetup.CharController.transform;
            _renderer = GetComponent<MeshRenderer>();
            _propBlock = new MaterialPropertyBlock();

            _renderer.GetPropertyBlock(_propBlock);
            actualIntensity = Mathf.LinearToGammaSpace(minIntensityLevel);
            _propBlock.SetVector(EmissionColor, glowColor * actualIntensity);
            _renderer.SetPropertyBlock(_propBlock);

            if(selfDisable)
                enabled = false;
        }

        public void ChangeFromPlayerToCamera(bool value)
        {
            if (Camera.main != null) _playerTransform = value ? Camera.main.transform : PlayerSetup.CharController.transform;
        }

        public void ChangeFromPlayerToEmptyTransform(bool value, Transform transform)
        {
            _playerTransform = value ? transform : PlayerSetup.CharController.transform;
        }

        private void Update()
        {
            var dist = Vector3.Distance(transform.position, _playerTransform.position);
            
            //this first check causes the colors not to change properly because it exits while it still lerping
            //if (dist > startGlowDistance) return;
            //if (dist < maxGlowDistance) dist = maxGlowDistance;
            
            //if its too far away we ignore it
            if (dist > startGlowDistance * 4) return;
            
            Mathf.Clamp(dist, maxGlowDistance, startGlowDistance);

            // Get the current value of the material properties in the renderer.
            _renderer.GetPropertyBlock(_propBlock);
            // Assign our new value.
            var intensity = Mathf.LinearToGammaSpace(Mathf.Lerp(minIntensityLevel, maxIntensityLevel, (startGlowDistance - dist) * (1 / (startGlowDistance - maxGlowDistance))));
            // intensity = Mathf.LinearToGammaSpace(minIntensityLevel + (maxGlowDistance - dist) * (maxIntensityLevel / (maxGlowDistance - startGlowDistance)));
            actualIntensity = Mathf.Lerp(actualIntensity, intensity, 1 - Mathf.Exp(-speedOfIntensityChange * Time.deltaTime));
            
            _propBlock.SetVector(EmissionColor, glowColor * actualIntensity);
            // Apply the edited values to the renderer.
            _renderer.SetPropertyBlock(_propBlock);
        }
    }
}