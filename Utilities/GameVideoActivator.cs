using Ellisar.EllisarAssets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ellisar.Assets.EllisarAssets.Scripts.Utilities
{
    public class GameVideoActivator : MonoBehaviour
    {
        public void PlayToVillage()
        {
            GameVideosManager.Instance.PlayCaveToVillage();
        }
        public void PlayToSpyro()
        {
            GameVideosManager.Instance.PlayGraveyardToSpyro();
        }
        public void PlayTowerExplosion()
        {
            GameVideosManager.Instance.PlayTowerExplosion();
        }

        public void PlayCaveOut()
        {
            GameVideosManager.Instance.PlayCaveOut();
        }

        public void PlayFinal()
        {
            GameVideosManager.Instance.PlayFinal();
        }
    }
}
