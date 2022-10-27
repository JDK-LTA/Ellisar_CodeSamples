using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Checkpoints
{
    public class KillPlayer : TriggerEnter
    {
        [SerializeField] private float killDelay = 3f;

        protected override void TriggerAction()
        {
            CheckpointManager.Instance.DelayedRespawn(killDelay);
        }
    }
}
