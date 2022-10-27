using System;
using Ellisar.EllisarAssets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas
{
    [Serializable]
    public class SkillTransformationData : SkillData
    {
        [SerializeField] private PlayerModeState playerModeStateToSet;
        [SerializeField] private float characterControllerRadius;
        [SerializeField] private bool useEvent;
        [SerializeField, ShowIf("useEvent")] private UnityEvent onTransformationEvent;
        
        public SkillTransformationData() : base()
        {
            
        }

        public SkillTransformationData(InputAction inputAction) : base(inputAction)
        {
            
        }
        
        #region Properties
        
        public PlayerModeState PlayerModeStateToSet => playerModeStateToSet;
        public float CharacterControllerRadius => characterControllerRadius;
        public UnityEvent OnTransformationEvent => onTransformationEvent;

        public bool UseEvent => useEvent;

        #endregion
    }
}
