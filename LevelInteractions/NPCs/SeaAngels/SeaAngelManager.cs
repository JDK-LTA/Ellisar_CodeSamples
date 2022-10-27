using System.Collections.Generic;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs.SeaAngels
{
    public class SeaAngelManager : MonoBehaviour
    {
        public static SeaAngelManager Instance;
        [SerializeField] private List<SeaAngelBehaviour> seaAngels;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            PlayerSetup.PhysicsController.actionChanged.AddListener(SetEmissive);
            // _bools = new bool[seaAngels.Count];
            // _offBools = new bool[seaAngels.Count];
            // _ts = new float[seaAngels.Count];
     
        }

        public void SetNewAngelActive()
        {
            seaAngels[PlayerPhysicsController.MaxActionsAmount - 1].transform.gameObject.SetActive(true);
            // seaAngels[PlayerPhysicsController.MaxActionsAmount - 1].transform.position = seaAngels[PlayerPhysicsController.MaxActionsAmount - 2].transform.position;
            seaAngels[PlayerPhysicsController.MaxActionsAmount - 1].enabled = true;
        }

        private void SetEmissive(bool value)
        {
            if(value)
                seaAngels[PlayerPhysicsController.ActualActionsAmount - 1].SetEmissive(true);
            else
                seaAngels[PlayerPhysicsController.ActualActionsAmount].SetEmissive(false);
        }
    }
}
