using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.LevelInteractions.Cameras;
using Ellisar.EllisarAssets.Scripts.Utilities.Visuals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.LevelMechanics
{
    public class ImpulseForward : TriggerEnter
    {
        [Title("Impulse Specific")] [SerializeField] private float force = 5;
        [SerializeField] private bool onlyFlying = true;

        protected override void TriggerAction()
        {
            if (onlyFlying && PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Fly || !onlyFlying)
            {
                var f = force;
                if (PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Fly)
                    f *= 2;
                SkillMovementData.ActualBodySpeed += f;
            }

            if (PostprocessingFeedbackManager.Instance)
                PostprocessingFeedbackManager.Instance.DistortLens(force);
        }
    }
}