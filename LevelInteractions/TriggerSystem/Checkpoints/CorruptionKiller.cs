using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Checkpoints
{
    public class CorruptionKiller : TriggerEnterExit
    {
        [SerializeField] private float timeToKill = 1f;
        // [SerializeField] private Volume ppVolume;
        // [SerializeField] private Vector2 minMaxVignetteIntensity = new Vector2(100, -100);
        // [FormerlySerializedAs("corruptPlayerModel")] [SerializeField] private SkinnedMeshRenderer corruptBipedModel;
        // [FormerlySerializedAs("minMaxCutoff")] [SerializeField] private Vector2 minMaxCutoffBiped = new Vector2(-.5f, 4f);
        // [SerializeField] private SkinnedMeshRenderer corruptFlyModel;
        // [SerializeField] private Vector2 minMaxCutoffFly = new Vector2(-1.5f, 4.2f);
        //
        // private VolumeProfile _ppProfile;
        // private SplitToning _splitToning;
        //
        // private bool _kill, _goBack;
        // private float _tKill;
        //
        // private MaterialPropertyBlock _matBlock;
        // private static readonly int Cutoff = Shader.PropertyToID("_Cutoff");
        //
        // private void Start()
        // {
        //     _ppProfile = ppVolume.profile;
        //
        //     _matBlock = new MaterialPropertyBlock();
        //     corruptBipedModel.GetPropertyBlock(_matBlock);
        //     _matBlock.SetFloat(Cutoff, minMaxCutoffBiped.x);
        //     corruptBipedModel.SetPropertyBlock(_matBlock);
        //     corruptFlyModel.GetPropertyBlock(_matBlock);
        //     _matBlock.SetFloat(Cutoff, minMaxCutoffFly.x);
        //     corruptFlyModel.SetPropertyBlock(_matBlock);
        // }
        //
        // private void Update()
        // {
        //     if (_kill)
        //     {
        //         _tKill += Time.deltaTime;
        //
        //         _splitToning.balance.value = Mathf.Lerp(minMaxVignetteIntensity.x, minMaxVignetteIntensity.y, _tKill / timeToKill);
        //         
        //         corruptBipedModel.GetPropertyBlock(_matBlock);
        //         var cutoffValue = Mathf.Lerp(minMaxCutoffBiped.x, minMaxCutoffBiped.y, _tKill / timeToKill);
        //         _matBlock.SetFloat(Cutoff, cutoffValue);
        //         corruptBipedModel.SetPropertyBlock(_matBlock);
        //         
        //         corruptFlyModel.GetPropertyBlock(_matBlock);
        //         cutoffValue = Mathf.Lerp(minMaxCutoffFly.x, minMaxCutoffFly.y, _tKill / timeToKill);
        //         _matBlock.SetFloat(Cutoff, cutoffValue);
        //         corruptFlyModel.SetPropertyBlock(_matBlock);
        //         
        //         
        //         if (_tKill >= timeToKill)
        //         {
        //             _tKill = 0;
        //             _kill = false;
        //             CheckpointManager.Instance.DelayedRespawn(1);
        //         }
        //     }
        //     else if (_goBack)
        //     {
        //         _tKill -= Time.deltaTime;
        //         
        //         _splitToning.balance.value = Mathf.Lerp(minMaxVignetteIntensity.x, minMaxVignetteIntensity.y, _tKill / timeToKill);
        //
        //         corruptBipedModel.GetPropertyBlock(_matBlock);
        //         var cutoffValue = Mathf.Lerp(minMaxCutoffBiped.x, minMaxCutoffBiped.y, _tKill / timeToKill);
        //         _matBlock.SetFloat(Cutoff, cutoffValue);
        //         corruptBipedModel.SetPropertyBlock(_matBlock);
        //         
        //         corruptFlyModel.GetPropertyBlock(_matBlock);
        //         cutoffValue = Mathf.Lerp(minMaxCutoffFly.x, minMaxCutoffFly.y, _tKill / timeToKill);
        //         _matBlock.SetFloat(Cutoff, cutoffValue);
        //         corruptFlyModel.SetPropertyBlock(_matBlock);
        //         
        //         if (_tKill <= 0)
        //         {
        //             _tKill = 0;
        //             _goBack = false;
        //         }
        //     }
        // }

        protected override void TriggerAction()
        {
            CorruptionKillingManager.Instance.StartKillingPlayer(timeToKill);
        }

        protected override void TriggerExitAction()
        {
            CorruptionKillingManager.Instance.StopKillingPlayer();
        }
    }
}
