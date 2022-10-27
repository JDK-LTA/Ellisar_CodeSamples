using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ellisar.EllisarAssets.Scripts.Utilities;
using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Checkpoints;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions
{
    public class SpyroNoDeath : MonoBehaviour
    {
        public void SetNoDeathAchievement()
        {
            if (!CheckpointManager.Instance.StopSpyroAchievement)
                SteamManager.Instance.UnlockAchievement("Spyro");
        }
    }
}
