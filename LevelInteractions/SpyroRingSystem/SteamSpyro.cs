using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ellisar.EllisarAssets.Scripts.Utilities;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions
{
    public class SteamSpyro : MonoBehaviour
    {
        [SerializeField] private int amount;

        public void AddStat()
        {
            SteamManager.Instance.AddToSpyroHoops(amount);
        }
    }
}
