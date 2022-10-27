using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.PlayerConfig
{
    public class SkillDataSwapper : TriggerEnterExit
    {
        [SerializeField] private PlayerModeState playerState;
        [SerializeField] private int indexOfSkillDataEnter;
        [SerializeField] private bool changeWhenExit = true;
        [SerializeField, HideIf("@changeWhenExit == false")] private int indexOfSkillDataExit;

        protected override void TriggerAction()
        {
            SetData();
        }

        public void SetData()
        {
            PlayerSetup.PhysicsController.NextDataSet(playerState, indexOfSkillDataEnter);
        }

        protected override void TriggerExitAction()
        {
            if (!changeWhenExit) return;
            PlayerSetup.PhysicsController.NextDataSet(playerState, indexOfSkillDataExit);
        }
    }
}
