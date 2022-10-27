using System;
using System.Linq;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Utilities
{
    public class SteamManager : MonoBehaviour
    {
        public static SteamManager Instance;
        [SerializeField] private bool initializeSteam = true;
        private int spyroHoops = 0;
        private int goldfish = 0;


        private void Awake()
        {
            if (!initializeSteam) return;

            Instance = this;

            try
            {
                SteamClient.Init(1940310);
            }
            catch (Exception e)
            {
                // Something went wrong - it's one of these:
                //
                //     Steam is closed?
                //     Can't find steam_api dll?
                //     Don't have permission to play app?
                //
                throw new Exception("Steam stuff is not working");
            }

            SteamUserStats.OnAchievementProgress += AchievementChanged;

            print(SteamClient.Name);

            SteamUserStats.RequestCurrentStats();
        }

        private void AchievementChanged(Achievement achievement, int i, int arg3)
        {
            if (achievement.State)
            {
                Debug.Log($"{achievement.Name} WAS UNLOCKED!");
            }
        }

        public void UnlockAchievement(string achName)
        {
            var ach = new Achievement(achName);
            if (initializeSteam && SteamUserStats.Achievements.Contains(ach))
            {
#if UNITY_EDITOR
                ach.Clear();
#endif
                ach.Trigger();
            }
            else
            {
                print($"False Achievement. Name: {achName}");
            }
        }

        private void OnDisable()
        {
            if (initializeSteam)
                SteamClient.Shutdown();
        }

        public void AddToSpyroHoops(int amount)
        {
            spyroHoops += amount;

            if (spyroHoops >= 28)
            {
                //UnlockAchievement("WaterHoops");
            }
        }

        public void AddToGoldfish(int index)
        {
            if (!ScenesManager.Instance.Goldfishes[index])
            {
                ScenesManager.Instance.Goldfishes[index] = true;
                SteamUserStats.AddStat("FishBags", 1);
                SteamUserStats.StoreStats();
            }
        }
    }
}
