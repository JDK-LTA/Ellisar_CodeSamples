using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Enums;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Animations
{
    public class AnimationTriggerSpecificTransformation : AnimationTrigger
    {
        [SerializeField] private PlayerModeState transformation;
    
        protected override void TriggerAction()
        {
            if (PlayerSetup.PlayerController.CurrentPlayerState == transformation)
            {
                SpecificTriggerAction();
            }
        }

        protected virtual void SpecificTriggerAction()
        {
            base.TriggerAction();
        }
    }
}
