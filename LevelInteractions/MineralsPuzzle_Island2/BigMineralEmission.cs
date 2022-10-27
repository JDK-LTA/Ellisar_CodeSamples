using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.MineralsPuzzle_Island2
{
    public class BigMineralEmission : MonoBehaviour
    {
        //[SerializeField, ColorUsage(true, true)] private Color glowColor;
        [SerializeField] private float minIntensityLevel = -4;
        [SerializeField] private float maxIntensityLevel;

        [FormerlySerializedAs("speedOfIntensityChange")] [SerializeField]
        private float timeToFullyGlow = 5f;

        [SerializeField, ReadOnly] private float actualIntensity;
        [SerializeField] private bool onlyOnce = true;
        [SerializeField] private bool canTurnOff = false;
        
        private MaterialPropertyBlock _propBlock;
        private MeshRenderer _renderer;
        private static readonly int EmissionMultiplier = Shader.PropertyToID("_EmissionMultiplier");

        private bool _glow;
        private float _tGlow;
        private bool _canGlow = true;
        private bool _turnOff;
        private bool _pingPongGlow, _pingPongOff;
        
        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            _propBlock = new MaterialPropertyBlock();

            _renderer.GetPropertyBlock(_propBlock);
            actualIntensity = minIntensityLevel;
            _propBlock.SetFloat(EmissionMultiplier, actualIntensity);
            _renderer.SetPropertyBlock(_propBlock);
        }

        private void Update()
        {
            if (_glow)
            {
                _tGlow += Time.deltaTime;

                _renderer.GetPropertyBlock(_propBlock);
                actualIntensity = Mathf.Lerp(minIntensityLevel, maxIntensityLevel, _tGlow / timeToFullyGlow);
                _propBlock.SetFloat(EmissionMultiplier, actualIntensity);
                _renderer.SetPropertyBlock(_propBlock);

                if (_tGlow >= timeToFullyGlow)
                {
                    _tGlow = timeToFullyGlow;
                    _glow = false;

                    if (_pingPongGlow)
                        _turnOff = true;
                }
            }
            else if (_turnOff)
            {
                _tGlow -= Time.deltaTime;

                _renderer.GetPropertyBlock(_propBlock);
                actualIntensity = Mathf.Lerp(minIntensityLevel, maxIntensityLevel, _tGlow / timeToFullyGlow);
                _propBlock.SetFloat(EmissionMultiplier, actualIntensity);
                _renderer.SetPropertyBlock(_propBlock);

                if (_tGlow <= 0)
                {
                    _tGlow = 0;
                    _turnOff = false;

                    if (_pingPongOff)
                        _glow = true;
                }
            }
        }

        [Button(Name = "Glow")]
        public void Glow()
        {
            if (_canGlow)
            {
                _glow = true;
                _turnOff = false;
                
                if (onlyOnce)
                {
                    _canGlow = false;
                }
            }
        }

        [Button()]
        public void TurnOff()
        {
            if (canTurnOff)
            {
                _glow = false;
                _turnOff = true;
            }
        }

        [Button(Name = "PingPong")]
        public void PingPong()
        {
            _pingPongGlow = true;
            _pingPongOff = true;
            _glow = true;
        }

        [Button()]
        public void KeepGlowingStopPong()
        {
            _pingPongGlow = false;
        }
    }
}