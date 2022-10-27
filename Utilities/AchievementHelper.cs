using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Utilities
{
    public class AchievementHelper : MonoBehaviour
    {
        public void EnableAchievement(string refName)
        {
            if (SteamManager.Instance)
                SteamManager.Instance.UnlockAchievement(refName);
        }
    }
}
