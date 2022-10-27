using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Checkpoints
{ 
    public class Checkpoint : TriggerEnter
    {
        [Title("Checkpoint Specific")]
        [SerializeField] private bool respawnInBipedMode = true;
        [SerializeField] private bool takeSelfTransform;
        [SerializeField] private bool spyro = false;
        [SerializeField, HideIf("@takeSelfTransform == true"), 
         InfoBox("Fill this reference!!", InfoMessageType.Warning, VisibleIf = "@respawner == null")] private Transform respawner;
        [SerializeField, HideIf("@spyro == false")] private bool noDeath = false;

        protected override void TriggerAction()
        {
            ForceCheckpoint();
        }

        public void ForceCheckpoint()
        {
            if (takeSelfTransform)
            {
                CheckpointManager.Instance.ActualCheckpoint = transform;
            }
            else
            {
                if (respawner)
                    CheckpointManager.Instance.ActualCheckpoint = respawner;
            }

            CheckpointManager.Instance.BipedRespawn = respawnInBipedMode;

            if (spyro)
            {
                CheckpointManager.Instance.StopSpyroAchievement = !noDeath;
            }
        }
    }
}