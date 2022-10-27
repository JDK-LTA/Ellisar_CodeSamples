using System;
using System.Collections.Generic;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Serializables;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem; //using Ellisar.EllisarAssets.Scripts.Utilities;
using Debug = UnityEngine.Debug;

namespace Ellisar.EllisarAssets.Scripts.Player.Main
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private bool debugMessages;

        [InfoBox("YOU NEED TO SET AN INPUT ACTION ASSET", InfoMessageType.Error, "@inputActionAsset == null")] [SerializeField]
        private InputActionAsset inputActionAsset;

        
        [SerializeField, OnValueChanged("PlayerConditions", true), ShowIf("@inputActionAsset != null")]
        private List<string> playerConditions;
        
        [SerializeField, ReadOnly] private PlayerModeState targetPlayerState;
        [SerializeField, ReadOnly] private PlayerModeState currentPlayerState;
        
        [SerializeField, ReadOnly, ShowIf("currentPlayerState", PlayerModeState.Biped)] private BipedState _currentBipedState;
        [SerializeField, ReadOnly, ShowIf("currentPlayerState", PlayerModeState.Biped)] private BipedMovementState _currentBipedMovementState = BipedMovementState.Walking;

        [SerializeField, ReadOnly, ShowIf("currentPlayerState", PlayerModeState.Fly)] private FlyState _currentFlyState;
        [SerializeField, ReadOnly, ShowIf("currentPlayerState", PlayerModeState.Fly)] private FlyModeState _currentFlyModeState;
        

        [SerializeField, ListDrawerSettings(CustomAddFunction = "SetInputAsset"), ShowIf("@inputActionAsset != null")]
        private List<PlayerSkill> playerSkills;

        [SerializeField] [ReadOnly] private bool canBeControlled = true;
        [SerializeField] [ReadOnly] private bool updatePlayerPhysics = true;

        #region Properties
        
        public List<string> Conditions => playerConditions;

        public List<PlayerSkill> PlayerSkills => playerSkills;
        
        // ReSharper disable once MemberCanBePrivate.Global
        public bool CanBeControlled
        {
            get => canBeControlled;
            set => canBeControlled = value;
        }
        
        public PlayerModeState TargetPlayerState
        {
            get => targetPlayerState;
            set => targetPlayerState = value;
        }
        
        public PlayerModeState CurrentPlayerState
        {
            get => currentPlayerState;
            set => currentPlayerState = value;
        }
        
        public BipedState CurrentBipedState
        {
            get => _currentBipedState;
            set => _currentBipedState = value;
        }

        public BipedMovementState CurrentBipedMovementState
        {
            get => _currentBipedMovementState;
            set => _currentBipedMovementState = value;
        }

        public FlyState CurrentFlyState
        {
            get => _currentFlyState;
            set => _currentFlyState = value;
        }

        public FlyModeState CurrentFlyModeState
        {
            get => _currentFlyModeState;
            set => _currentFlyModeState = value;
        }

        public bool YInvertedOnFlight { get; set; }
        
        public bool UpdatePlayerPhysics
        {
            get => updatePlayerPhysics;
            set => updatePlayerPhysics = value;
        }
        
        #endregion

        #region ODIN_METHODS
        
        // ReSharper disable once UnusedMember.Local
        private void SetInputAsset()
        {
            var playerSkill = new PlayerSkill {ActionAsset = inputActionAsset};
            playerSkills.Add(playerSkill);
            playerSkill.Initialize();
            playerSkill.InitializeSkillData();
        }

        // ReSharper disable once UnusedMember.Local
        private void PlayerConditions()
        {
            foreach (var skill in playerSkills.FindAll(value => value.Data is SkillMovementData {UsesCondition: true}))
            {
                ((SkillMovementData) skill.Data).SetConditionByIndex();
            }
        }
        
        #endregion
        private void Awake()
        {
            playerConditions ??= new List<string>();
            
            //TODO: THIS SHOULD BE CONTROLLED BY THE MAIN MENU
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }


        public void InitializeSkill(PlayerSkill skill, bool enable = true)
        {
            skill.Data.Skill = skill;
            skill.SetAction = inputActionAsset.FindActionMap(skill.CurrentActionMap).FindAction(skill.CurrentAction);

            //Debugger.MessageDebugger(skill.SetAction);
            if (enable)
                EnableSkill(skill);
        }

        public void InitializeSkill(PlayerSkill skill, string newActionMap, bool enable = true)
        {
            skill.Data.Skill = skill;
            skill.SetAction = inputActionAsset.FindActionMap(newActionMap).FindAction(skill.CurrentAction);

            //Debugger.MessageDebugger(skill.SetAction);
            if (enable)
                EnableSkill(skill);
        }

        public void ResetSkillsToNewMap(string newActionMap)
        {
            foreach (var skill in playerSkills)
            {
                DisableSkill(skill);
            }
            foreach (var skill in playerSkills)
            {
                InitializeSkill(skill, newActionMap, skill.Equip == default);
            }
        }
        
        private void OnEnable()
        {
            foreach (var skill in playerSkills)
            {
                InitializeSkill(skill, skill.Equip == default);
            }
        }
        
        private void OnDisable()
        {
            foreach (var skill in playerSkills)
            {
                DisableSkill(skill);
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void EnableSkill(PlayerSkill skill)
        {
            skill.SetAction.Enable();
            skill.SetAction.performed += context => DoSkill(context, skill.Data);
            skill.SetAction.canceled += context => DoSkill(context, skill.Data);
            //Debugger.MessageDebugger("Enabled skill " + skill.Name, debugMessages);
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public void DisableSkill(PlayerSkill skill)
        {
            skill.SetAction.Disable();
            skill.SetAction.performed -= context => DoSkill(context, skill.Data);
            skill.SetAction.canceled -= context => DoSkill(context, skill.Data);
            //Debugger.MessageDebugger("Disabled skill " + skill.Name, debugMessages);
        }

        private void DoSkill(InputAction.CallbackContext context, SkillData skillData)
        {
            switch (skillData)
            {
                case SkillCameraControlData skill:
                    CameraControl(context, skill);
                    break;
                case SkillInteractionData skill:
                    Interaction(context, skill);
                    break;
                case SkillMovementData skill:
                    Movement(context, skill);
                    break;
                case SkillTransformationData skill:
                    Transformation(context, skill);
                    break;
            }
        }
        
        private void Movement(InputAction.CallbackContext ctx, SkillMovementData skillData)
        {
            if (!CanBeControlled) return;
            
            //Debugger.MessageDebugger("Move", debugMessages);

            if (skillData.PlayerMode != CurrentPlayerState) return;
            var direction = new DirectionInput(
                skillData.MovementType, skillData.CompositeType, skillData.CompositeTwoAxisType, skillData.OneAxisType);

            if (skillData.UsesCondition)
            {
                if (!playerConditions.Contains(skillData.ConditionToSet))
                {
                    playerConditions.Add(skillData.ConditionToSet);
                }

                var conditionalInputMovement = PlayerSetup.PhysicsController.ConditionalInputMovements.Find(movement => movement.Condition.ConditionKey == skillData.ConditionToSet);
                if (conditionalInputMovement == null)
                    PlayerSetup.PhysicsController.ConditionalInputMovements.Add(new ConditionalInputMovement(
                        new Condition(skillData.ConditionToSet, true), direction, skillData.ActionDuration, skillData.Force));
                else
                {
                    conditionalInputMovement.Condition.ConditionValue = true;
                    conditionalInputMovement.Direction = direction;
                    conditionalInputMovement.Force = skillData.Force;
                    conditionalInputMovement.ActionDuration = skillData.ActionDuration;
                }
                
                PlayerSetup.PhysicsController.UpdateConditionals();
            }
            else
            {
                Vector3 input;
                switch (skillData.MovementType)
                {
                    case MovementTypeEnum.Composite:
                        
                        
                        input = new Vector3(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y, ctx.ReadValue<Vector2>().y);
                        SetPhysicsInputVector(DirectionInput.DirectionInputToVector(direction) ,input, skillData);
                        break;
                    
                    case MovementTypeEnum.OneAxis:

                        input = new Vector3(ctx.ReadValue<float>(), ctx.ReadValue<float>(), ctx.ReadValue<float>());
                        SetPhysicsInputVector(DirectionInput.DirectionInputToVector(direction) ,input, skillData);
                        break;
                    
                    case MovementTypeEnum.Modifier:

                        PlayerSetup.PhysicsController.Modifier = ctx.ReadValue<float>();

                        PlayerSetup.PhysicsController.UpdateProperties();

                        if (CheckNotContinuousPressButton(skillData)) PlayerSetup.PhysicsController.Modifier = 0f;
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        // ReSharper disable once MemberCanBeMadeStatic.Local
        private void SetPhysicsInputVector(Vector3 vectorInput, Vector3 input, SkillData skillData)
        {
            if (vectorInput.x > 0) PlayerSetup.PhysicsController.Right = vectorInput.x * input.x;
            if (vectorInput.y > 0) PlayerSetup.PhysicsController.Up = vectorInput.y * input.y;
            if (vectorInput.z > 0) PlayerSetup.PhysicsController.Forward = vectorInput.z * input.z;

            if (PlayerSetup.PlayerAnimationController)
                PlayerSetup.PlayerAnimationController.XInput = input.x * vectorInput.x;

            PlayerSetup.PhysicsController.UpdateProperties();

            if (CheckNotContinuousPressButton(skillData) && vectorInput.x > 0) PlayerSetup.PhysicsController.Right = 0f;
            if (CheckNotContinuousPressButton(skillData) && vectorInput.y > 0) PlayerSetup.PhysicsController.Up = 0f;
            if (CheckNotContinuousPressButton(skillData) && vectorInput.z > 0) PlayerSetup.PhysicsController.Forward = 0f;
        }

        /// <summary>
        /// DEPRECATED
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="skillData"></param>
        private void CameraControl(InputAction.CallbackContext ctx, SkillCameraControlData skillData)
        {
            if (debugMessages)
                Debug.Log("CameraControl");
        }

        private void Interaction(InputAction.CallbackContext ctx, SkillInteractionData skillData)
        {
            if (!CanBeControlled) return;

            if (debugMessages)
                Debug.Log("Interaction");
            if (ctx.performed)
            {
                skillData.InteractionEnterEvent.Invoke();
            }
            else
            {
                skillData.InteractionExitEvent.Invoke();
            }
        }

        private void Transformation(InputAction.CallbackContext ctx, SkillTransformationData skillData)
        {
            if (!CanBeControlled) return;

            if (debugMessages)
                Debug.Log("Transformation from " + currentPlayerState + " to " + skillData.PlayerModeStateToSet);

            //GameplayManager.ResetTimeScale();

            SkillMovementData.IsTransforming = true;

            targetPlayerState = skillData.PlayerModeStateToSet;
            PlayerSetup.CharController.radius = skillData.CharacterControllerRadius;

            if (skillData.UseEvent)
                skillData.OnTransformationEvent.Invoke();
        }

        private static bool CheckNotContinuousPressButton(SkillData skillData)
        {
            return (skillData.Skill.SetAction.expectedControlType == "Button" && !skillData.Skill.ContinuousPressButton);
        }
    }
}