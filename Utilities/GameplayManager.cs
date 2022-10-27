using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Utilities
{
    public static class GameplayManager
    {
        private static void ChangeTimeScale(float newTimeScale)
        {
            Time.timeScale = newTimeScale;
        }

        public static void ResetTimeScale()
        {
            ChangeTimeScale(1);
        }
    }
}