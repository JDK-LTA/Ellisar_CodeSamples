using Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs.SeaAngels;
using Ellisar.EllisarAssets.Scripts.Player.Main;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.PlayerConfig
{
    public class AddActionAmount : TriggerEnter
    {
        protected override void TriggerAction()
        {
            PlayerPhysicsController.MaxActionsAmount++;
            SeaAngelManager.Instance.SetNewAngelActive();
            Destroy(gameObject);
        }
    }
}
