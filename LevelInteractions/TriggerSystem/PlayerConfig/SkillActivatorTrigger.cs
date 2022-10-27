using System.Collections;
using System.Linq;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.PlayerConfig
{
    public class SkillActivatorTrigger : TriggerEnterExit
    {
        [SerializeField] private bool disableOnExit;
        [SerializeField, ValueDropdown("GetSkillIndex", HideChildProperties = true, CopyValues = true)] private string skillToActivate;
        
        private IEnumerable GetSkillIndex()
        {
            var playerController = (PlayerController) FindObjectOfType(typeof (PlayerController));
            if (playerController == null) return null;
            var playerSkillsList = playerController.PlayerSkills;
            var aux = playerSkillsList.ToArray().Select(value => new ValueDropdownItem(value.Name, value.Name));
            return aux;
        }

        protected override void TriggerAction()
        {
            var playerController = PlayerSetup.PlayerController;
            var playerSkill = playerController.PlayerSkills.Find(x => x.Name == skillToActivate);
            if (playerSkill == null || playerSkill.State != SkillState.Disabled) return;
            playerSkill.State = SkillState.Enabled;
            playerController.InitializeSkill(playerSkill);
        }

        protected override void TriggerExitAction()
        {
            if(!disableOnExit) return;

            var playerController = PlayerSetup.PlayerController;
            var playerSkill = playerController.PlayerSkills.Find(x => x.Name == skillToActivate);
            if (playerSkill == null || playerSkill.State != SkillState.Enabled) return;
            playerSkill.State = SkillState.Disabled;
            playerController.DisableSkill(playerSkill);
            
        }
    }
}