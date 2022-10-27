using System;
using UnityEngine.InputSystem;

namespace Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas
{
    [Serializable]
    public class SkillCameraControlData : SkillData
    {
        public SkillCameraControlData() : base()
        {
        }

        public SkillCameraControlData(InputAction inputAction) : base(inputAction)
        {
        }
    }
}
