using Ellisar.EllisarAssets.Scripts.Player.Main;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.PlayerConfig
{
    public class GetEel : TriggerEnter
    {
        protected override void TriggerAction()
        {
            PlayerSetup.PhysicsController.HasEel = true;
            Destroy(gameObject);
        }
    }
}
