using System;
using System.Collections;
using System.Linq;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ellisar.EllisarAssets.Scripts.Player.Serializables
{
    [Serializable]
    public class PlayerSkill
    {
        [FoldoutGroup("@name")][SerializeField]
        private string name = "New PlayerSkill";

        private bool _createdFromPlayerController = true;
        
        
        [FoldoutGroup("@name")][Space(5f)]
        
        #region InputSystem

        [FoldoutGroup("@name")][SerializeField, HideIf("@_createdFromPlayerController"), OnValueChanged("Initialize")]
        private InputActionAsset inputActionAsset;
        
        [FoldoutGroup("@name")][SerializeField, ShowIf("@inputActionAsset != null"), ValueDropdown("GetActionMapIndex", HideChildProperties = true, CopyValues = true),
                                OnValueChanged("ChangeActionMap")]
        private string actionMap;
        
        [FoldoutGroup("@name")][SerializeField, ShowIf("@inputActionAsset != null"), ValueDropdown("GetActionIndex", HideChildProperties = true, CopyValues = true),
                                OnValueChanged("ChangeAction")]
        private string action;

        [FoldoutGroup("@name")][SerializeField, ShowIf("CheckIsButtonInput")]
        private bool continuousPressButton = false;
        
        #endregion

        [FoldoutGroup("@name")][Space(10f)]
        
        [FoldoutGroup("@name")][SerializeField, OnValueChanged("InitializeSkillData")]
        private SkillType skillType;
        
        
        [FoldoutGroup("@name")][SerializeField, OnValueChanged("SetDefaultState")]
        private SkillEquip skillEquip;
        
        
        [FoldoutGroup("@name")][SerializeField, ReadOnly]
        private SkillState skillState;

        [FoldoutGroup("@name")][Space(10f)]
        
        [FoldoutGroup("@name")][SerializeReference, OdinSerialize]
        private SkillData skillData;

        #region Properties

        public string Name => name;
        public SkillType SkillType => skillType;

        public SkillState State
        {
            get => skillState;
            set => skillState = value;
        }

        public SkillEquip Equip
        {
            get => skillEquip;
            set => skillEquip = value;
        }

        public string CurrentAction => action;

        public InputAction SetAction { get; set; }
        
        public string CurrentActionMap => actionMap;

        public InputActionAsset ActionAsset
        {
            get => inputActionAsset;
            set => inputActionAsset = value;
        }

        public SkillData Data => skillData;

        public bool CreatedFromPlayerController
        {
            get => _createdFromPlayerController;
            set => _createdFromPlayerController = value;
        }

        public bool ContinuousPressButton => continuousPressButton;

        #endregion

        private bool CheckIsButtonInput()
        {
            SetAction = inputActionAsset.FindActionMap(actionMap).FindAction(action);
            return SetAction.type == InputActionType.Button && skillType != SkillType.Interaction;
        }

        private void SetDefaultState()
        {
            skillState = skillEquip switch
            {
                SkillEquip.Default => SkillState.Enabled,
                SkillEquip.PowerUp => SkillState.Disabled,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        public void InitializeSkillData()
        {
            SetAction = inputActionAsset.FindActionMap(actionMap).FindAction(action);
            skillData = skillType switch
            {
                SkillType.Movement => new SkillMovementData(SetAction),
                SkillType.Interaction => new SkillInteractionData(SetAction),
                SkillType.CameraControl => new SkillData(SetAction),
                SkillType.Transformation => new SkillTransformationData(SetAction),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        public void Initialize()
        {
            if (inputActionAsset == null) return;
            actionMap = "";
            action = "";
                
            actionMap = inputActionAsset.actionMaps[0].name;
            action = inputActionAsset.FindActionMap(actionMap).actions[0].name;
            SetAction = inputActionAsset.FindActionMap(actionMap).FindAction(action);
        }
        
        private void ChangeActionMap()
        {
            action = null;
            action = inputActionAsset.FindActionMap(actionMap).actions[0].name;
            SetAction = inputActionAsset.FindActionMap(actionMap).FindAction(action);
        }
        
        private void ChangeAction()
        {
            skillData.InputAction = SetAction = inputActionAsset.FindActionMap(actionMap).FindAction(action);
            Debug.Log("SetAction = " + SetAction);
            if(SetAction != null)
                (skillData as SkillMovementData)?.SetMovementTypeDefault(SetAction);
        }
        
        private IEnumerable GetActionMapIndex()
        {
            return inputActionAsset.actionMaps.ToArray().Select(value => new ValueDropdownItem(value.name, value.name));
        }

        private IEnumerable GetActionIndex()
        {
            return inputActionAsset.FindActionMap(actionMap).actions.ToArray().Select(value => new ValueDropdownItem(value.name, value.name));
        }

    }
}
