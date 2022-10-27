using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Checkpoints
{
    public class CorruptionKillingManager : MonoBehaviour
    {
        public static CorruptionKillingManager Instance;

        [SerializeField] private Volume ppVolume;
        [SerializeField] private Vector2 minMaxVignetteIntensity = new Vector2(100, -100);

        [SerializeField] private SkinnedMeshRenderer corruptBipedModel;
        [SerializeField] private Vector2 minMaxCutoffBiped = new Vector2(-.5f, 4f);
        [SerializeField] private SkinnedMeshRenderer corruptFlyModel;
        [SerializeField] private Vector2 minMaxCutoffFly = new Vector2(-1.5f, 4.2f);

        private VolumeProfile _ppProfile;
        private SplitToning _splitToning;

        private bool _kill, _goBack;
        private float _tKill, _timeToKill = 1f;

        private MaterialPropertyBlock _matBlock;
        private static readonly int Cutoff = Shader.PropertyToID("_Cutoff");

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _ppProfile = ppVolume.profile;

            _matBlock = new MaterialPropertyBlock();
            corruptBipedModel.GetPropertyBlock(_matBlock);
            _matBlock.SetFloat(Cutoff, minMaxCutoffBiped.x);
            corruptBipedModel.SetPropertyBlock(_matBlock);
            corruptFlyModel.GetPropertyBlock(_matBlock);
            _matBlock.SetFloat(Cutoff, minMaxCutoffFly.x);
            corruptFlyModel.SetPropertyBlock(_matBlock);
        }

        private void Update()
        {
            if (_kill)
            {
                _tKill += Time.deltaTime;

                _splitToning.balance.value = Mathf.Lerp(minMaxVignetteIntensity.x, minMaxVignetteIntensity.y, _tKill / _timeToKill);

                corruptBipedModel.GetPropertyBlock(_matBlock);
                var cutoffValue = Mathf.Lerp(minMaxCutoffBiped.x, minMaxCutoffBiped.y, _tKill / _timeToKill);
                _matBlock.SetFloat(Cutoff, cutoffValue);
                corruptBipedModel.SetPropertyBlock(_matBlock);

                corruptFlyModel.GetPropertyBlock(_matBlock);
                cutoffValue = Mathf.Lerp(minMaxCutoffFly.x, minMaxCutoffFly.y, _tKill / _timeToKill);
                _matBlock.SetFloat(Cutoff, cutoffValue);
                corruptFlyModel.SetPropertyBlock(_matBlock);


                if (_tKill >= _timeToKill)
                {
                    _tKill = 0;
                    _kill = false;
                    CheckpointManager.Instance.DelayedRespawn(1);
                }
            }
            else if (_goBack)
            {
                _tKill -= Time.deltaTime;

                if(_splitToning)
                    _splitToning.balance.value = Mathf.Lerp(minMaxVignetteIntensity.x, minMaxVignetteIntensity.y, _tKill / _timeToKill);

                corruptBipedModel.GetPropertyBlock(_matBlock);
                var cutoffValue = Mathf.Lerp(minMaxCutoffBiped.x, minMaxCutoffBiped.y, _tKill / _timeToKill);
                _matBlock.SetFloat(Cutoff, cutoffValue);
                corruptBipedModel.SetPropertyBlock(_matBlock);

                corruptFlyModel.GetPropertyBlock(_matBlock);
                cutoffValue = Mathf.Lerp(minMaxCutoffFly.x, minMaxCutoffFly.y, _tKill / _timeToKill);
                _matBlock.SetFloat(Cutoff, cutoffValue);
                corruptFlyModel.SetPropertyBlock(_matBlock);

                if (_tKill <= 0)
                {
                    _tKill = 0;
                    _goBack = false;
                }
            }
        }

        public void StartKillingPlayer(float timeToKill)
        {
            _timeToKill = timeToKill;
            _kill = true;
            _goBack = false;
            _ppProfile.TryGet(out _splitToning);
        }

        public void StopKillingPlayer()
        {
            _kill = false;
            _goBack = true;
        }

        public void ForceResetCorruptionPlayer()
        {
            _tKill = 0;
            StopKillingPlayer();
        }
    }
}
