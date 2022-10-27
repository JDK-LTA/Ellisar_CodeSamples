using Ellisar.EllisarAssets.Scripts.LevelInteractions.Interactables;
using Ellisar.EllisarAssets.Scripts.Player.Main;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.PlayerConfig
{
    public class UseEelTrigger : Interactable
    {
        protected override void CanActivateTrue()
        {
            if(PlayerSetup.PhysicsController.HasEel)
                base.CanActivateTrue();
        }

        protected override void Act()
        {
            base.Act();        
            PlayerSetup.PlayerAnimationController.TriggerInteractionAnim();
            Destroy(gameObject);
        }
    }
}
