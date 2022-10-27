using System;
using System.Collections.Generic;
using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Checkpoints;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.PlayerConfig
{
    public class TriggerTeleport : TriggerEnter
    {
        [SerializeField] private Transform newTransform;
        [SerializeField] private float delay = 3f;
        [SerializeField] private List<int> scenesToLoad;
        [SerializeField] private List<int> scenesToUnload;
        [SerializeField] private ScenesManager.SceneState nextSceneState;
        private bool _del;
        private float _t = 0;
        
        protected override void TriggerAction()
        {
            _del = true;
            CheckpointManager.Instance.PlayDeathFader();

            Activated = false;

            ScenesManager.Instance.ScenesState = nextSceneState;
            
            foreach (var sc in scenesToLoad)
            {
                ScenesManager.Instance.LoadAdditiveScene(sc);
            }
        }

        private void Update()
        {
            if (_del)
            {
                _t += Time.deltaTime;

                if (_t >= delay)
                {
                    PlayerSetup.CharController.transform.position = newTransform.position;
                    PlayerSetup.CharController.transform.rotation = newTransform.rotation;
                    Physics.SyncTransforms();

                    foreach (var sc in scenesToUnload)
                    {
                        ScenesManager.Instance.UnloadAdditiveScene(sc);
                    }
                    
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
