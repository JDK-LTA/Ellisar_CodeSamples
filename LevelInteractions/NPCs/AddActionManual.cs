using Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs.SeaAngels;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs
{
    public class AddActionManual : MonoBehaviour
    {
        [SerializeField] private int amount = 3;

        public void AddAction()
        {
            PlayerPhysicsController.MaxActionsAmount = amount;
            SeaAngelManager.Instance.SetNewAngelActive();
        }

        public void SetNewAngelActive()
        {
            SeaAngelManager.Instance.SetNewAngelActive();
        }
    }
}
