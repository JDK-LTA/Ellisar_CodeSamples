using Ellisar.EllisarAssets.Scripts.Player.Main;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.PlayerConfig
{
    public class NoEnergySpendingTrigger : TriggerEnterExit
    {
        protected override void TriggerAction()
        {
            PlayerPhysicsController.CanSpendActions = false;
        }

        protected override void TriggerExitAction()
        {
            PlayerPhysicsController.CanSpendActions = true;
        }

        private void OnDisable()
        {
            PlayerPhysicsController.CanSpendActions = true;
        }
    }
}