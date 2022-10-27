using System;
using UnityEngine.InputSystem;

namespace Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas
{
    [Serializable]
    public class SkillData
    {
        public PlayerSkill Skill { get; set; }
        public InputAction InputAction { get; set; }

        public SkillData()
        {
        }

        public SkillData(InputAction inputAction)
        {
            InputAction = inputAction;
        }
    }
}