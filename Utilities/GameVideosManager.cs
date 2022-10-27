using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Ellisar.EllisarAssets.Scripts.Utilities
{
    public class GameVideosManager : MonoBehaviour
    {
        public static GameVideosManager Instance;

        [SerializeField] private PlayableDirector caveToVillage, graveyardToSpyro, towerExplosion, caveOut, final;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayCaveToVillage()
        {
            caveToVillage.Play();
        }

        public void PlayGraveyardToSpyro()
        {
            graveyardToSpyro.Play();
        }

        public void PlayTowerExplosion()
        {
            towerExplosion.Play();
        }

        public void PlayCaveOut()
        {
            caveOut.Play();
        }

        public void PlayFinal()
        {
            final.Play();
        }
    }
}
