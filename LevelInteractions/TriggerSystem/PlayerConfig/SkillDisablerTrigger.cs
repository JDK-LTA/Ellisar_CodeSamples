using System.Collections;
using System.Linq;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.PlayerConfig
{
    public class SkillDisablerTrigger : TriggerEnterExit
    {
        [SerializeField] private bool enableOnExit;
        [SerializeField, ValueDropdown("GetSkillIndex", HideChildProperties = true, CopyValues = true)] private string skillToActivate;
        
        private IEnumerable GetSkillIndex()
        {
            if (PlayerSetup.PlayerController == null) 
                PlayerSetup.PlayerController = (PlayerController) FindObjectOfType(typeof (PlayerController));
            if (PlayerSetup.PlayerController == null) return null;
            var playerController = PlayerSetup.PlayerController;
            var playerSkillsList = playerController.PlayerSkills;
            return playerSkillsList.ToArray().Select(value => new ValueDropdownItem(value.Name, value.Name));
        }

        protected override void TriggerAction()
        {
            var playerController = PlayerSetup.PlayerController;
            var playerSkill = playerController.PlayerSkills.Find(x => x.Name == skillToActivate);
            if (playerSkill == null || playerSkill.State != SkillState.Enabled) return;
            playerSkill.State = SkillState.Disabled;
            playerController.DisableSkill(playerSkill);
        }

        protected override void TriggerExitAction()
        {
            if(!enableOnExit) return;
            
            var playerController = PlayerSetup.PlayerController;
            var playerSkill = playerController.PlayerSkills.Find(x => x.Name == skillToActivate);
            if (playerSkill == null || playerSkill.State != SkillState.Disabled) return;
            playerSkill.State = SkillState.Enabled;
            playerController.InitializeSkill(playerSkill);
        }
    }
}