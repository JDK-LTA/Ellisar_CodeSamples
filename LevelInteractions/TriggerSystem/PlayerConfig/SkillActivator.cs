using System.Collections;
using System.Linq;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.PlayerConfig
{
    public class SkillActivator : MonoBehaviour
    {
        [SerializeField, ValueDropdown("GetSkillIndex", HideChildProperties = true, CopyValues = true)] private string skillToActivate;
        
        private IEnumerable GetSkillIndex()
        {
            var playerController = (PlayerController) FindObjectOfType(typeof (PlayerController));
            if (playerController == null) return null;
            var playerSkillsList = playerController.PlayerSkills;
            var aux = playerSkillsList.ToArray().Select(value => new ValueDropdownItem(value.Name, value.Name));
            return aux;
        }

        public void SetSkillActive()
        {
            var playerController = PlayerSetup.PlayerController;
            var playerSkill = playerController.PlayerSkills.Find(x => x.Name == skillToActivate);
            if (playerSkill == null || playerSkill.State != SkillState.Disabled) return;
            playerSkill.State = SkillState.Enabled;
            playerSkill.Equip = SkillEquip.Default;
            playerController.InitializeSkill(playerSkill);
        }
    }
}
