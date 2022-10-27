using System;
using System.Collections;
using System.Collections.Generic;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas
{
    [Serializable]
    public class SkillMovementData : SkillData
    {
        public SkillMovementData()
        {
        }

        public SkillMovementData(InputAction inputAction) : base(inputAction)
        {
            InputAction = inputAction;
            SetMovementTypeDefault(inputAction);
        }

        public void SetMovementTypeDefault(InputAction inputAction)
        {
            switch (inputAction.expectedControlType)
            {
                case "Vector2":
                    movementType = MovementTypeEnum.Composite;
                    compositeType = CompositeTypeEnum.TwoAxis;
                    break;
                case "Vector3":
                    movementType = MovementTypeEnum.Composite;
                    compositeType = CompositeTypeEnum.AllAxis;
                    break;
                case "Button":
                    movementType = MovementTypeEnum.OneAxis;
                    break;
            }
        }
        
        [SerializeField] private PlayerModeState playerMode;
        [SerializeField] private bool usesCondition;
        [SerializeField] private MovementTypeEnum movementType;

        [SerializeField, ShowIf("movementType", MovementTypeEnum.Composite)]
        private CompositeTypeEnum compositeType = CompositeTypeEnum.TwoAxis;

        [SerializeField, ShowIf("@movementType == MovementTypeEnum.Composite && compositeType == CompositeTypeEnum.TwoAxis")]
        private CompositeTwoAxisTypeEnum compositeTwoAxisType = CompositeTwoAxisTypeEnum.RightForward;

        [SerializeField, ShowIf("movementType", MovementTypeEnum.OneAxis)]
        private OneAxisTypeEnum oneAxisType = OneAxisTypeEnum.Up;

        [ReadOnly, SerializeField, ShowIf("movementType", MovementTypeEnum.Modifier)]
        private ModifierTypeEnum modifierType = ModifierTypeEnum.Modifier;

        [SerializeField, ShowIf("usesCondition"), OnValueChanged("SetDefaultCondition")]
        private PlayerController conditionsReference;

        private int _conditionIndex;
        
        [InfoBox("YOU NEED TO SET A CONDITION", InfoMessageType.Error, "@usesCondition && (conditionsReference == null || conditionToSet == null || string.IsNullOrWhiteSpace(conditionToSet) || string.IsNullOrEmpty(conditionToSet))")]
        [SerializeField, ShowIf("@usesCondition && conditionsReference != null"), ValueDropdown("GetConditionValue", HideChildProperties = true, CopyValues = true), OnValueChanged("GetConditionIndex")]
        private string conditionToSet;
     
        [SerializeField, ShowIf("@usesCondition && conditionsReference != null && conditionToSet != null && !string.IsNullOrWhiteSpace(conditionToSet) && !string.IsNullOrEmpty(conditionToSet)")]
        private float actionDuration = 1f;

        [SerializeField, ShowIf("@usesCondition && conditionsReference != null && conditionToSet != null && !string.IsNullOrWhiteSpace(conditionToSet) && !string.IsNullOrEmpty(conditionToSet)")]
        private float force = 100f;


        #region Global Movement Variables
        
        public static float ActualBodySpeed;
        public static Vector3 ActualBodyVelocity;
        public static bool IsTransforming;
        
        #endregion
        
        #region Properties

        public PlayerModeState PlayerMode => playerMode;

        public MovementTypeEnum MovementType => movementType;

        public CompositeTypeEnum CompositeType => compositeType;

        public CompositeTwoAxisTypeEnum CompositeTwoAxisType => compositeTwoAxisType;

        public OneAxisTypeEnum OneAxisType => oneAxisType;

        public string ConditionToSet => conditionToSet;

        public bool UsesCondition => usesCondition;

        public float ActionDuration => actionDuration;

        public float Force => force;

        public ModifierTypeEnum ModifierType => modifierType;

        #endregion
        
        private IEnumerable GetConditionValue()
        {
            if(conditionsReference == null) return null;
            var list = (conditionsReference.GetType().GetProperty("Conditions")?.GetValue(conditionsReference) as List<string>) ?? new List<string>();
            return list.ToArray();
        }
        
        private void SetDefaultCondition()
        {
            _conditionIndex = 0;
            SetConditionByIndex();
        }

        public void SetConditionByIndex()
        {
            var conditions = conditionsReference.GetType().GetProperty("Conditions")?.GetValue(conditionsReference) as List<string>;
            if(_conditionIndex < conditions?.Count)
                conditionToSet = conditions?[_conditionIndex];
            else if(conditions?.Count > 0)
            {
                _conditionIndex = 0;
                conditionToSet = conditions?[_conditionIndex];
            }
            else
            {
                conditionToSet = "";
            }
        }

        private void GetConditionIndex()
        {
            // ReSharper disable once PossibleInvalidOperationException
            _conditionIndex = (int) (conditionsReference.GetType().GetProperty("Conditions")?.GetValue(conditionsReference) as List<string>)?.IndexOf(conditionToSet);
        }
    }

    [Serializable]
    public class BipedData
    {
        [Button(Name = "Save Values", DirtyOnClick = true), FoldoutGroup("@configName")]
        private void SetData()
        {
            _setData = new BipedData
            {
                maxSpeed = maxSpeed,
                accelerationIncrementInTime = accelerationIncrementInTime,
                movementAcceleration = movementAcceleration,
                slowDownAcceleration = slowDownAcceleration,
                turnSpeed = turnSpeed,
                airAcceleration = airAcceleration,
                turnSpeedInAir = turnSpeedInAir,
                fallingGravityAmt = fallingGravityAmt,
                jumpAmt = jumpAmt
            };
        }

        [Button(Name = "Reset Values", DirtyOnClick = true), HideIf("@_setData == null"), FoldoutGroup("@configName")]
        private void ResetData()
        {
            maxSpeed = _setData.maxSpeed;
            accelerationIncrementInTime = _setData.accelerationIncrementInTime;
            movementAcceleration = _setData.movementAcceleration;
            slowDownAcceleration = _setData.slowDownAcceleration;
            turnSpeed = _setData.turnSpeed;
            airAcceleration = _setData.airAcceleration;
            turnSpeedInAir = _setData.turnSpeedInAir;
            fallingGravityAmt = _setData.fallingGravityAmt;
            jumpAmt = _setData.jumpAmt;
        }

        [FoldoutGroup("@configName")] public string configName = "New biped data";
        
        [FoldoutGroup("@configName/Debug"), ReadOnly] public Vector3 moveDirection = Vector3.zero;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public Vector3 moveDirectionTarget = Vector3.zero;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public bool onGround; //the bool for if we are on ground (this is used for the animator
        [FoldoutGroup("@configName/Debug"), ReadOnly] public Vector3 playerVelocity = Vector3.zero;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public Vector3 playerVelocityTarget = Vector3.zero;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float actualSpeed; //our actual speed
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float targetSpeed; //our target speed
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float actualAcceleration; //our actual acceleration
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float targetAcceleration; //our actual acceleration
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float actualGravity;
        
        [FoldoutGroup("@configName/Speed & Accel")] public float maxSpeed = 15f; //max speed for basic movement
        [FoldoutGroup("@configName/Speed & Accel")] public float accelerationIncrementInTime = 4f; //how quickly we build speed //our actual speed
        [FoldoutGroup("@configName/Speed & Accel")] public float movementAcceleration = 20f; //how quickly we adjust to new speeds
        [FoldoutGroup("@configName/Speed & Accel")] public float slowDownAcceleration = 2f; //how quickly we slow down
        [FoldoutGroup("@configName/Speed & Accel")] public float turnSpeed = 2f; //how quickly we turn on the ground

        [FoldoutGroup("@configName/On Air & Jump")] public float jumpGravityBoost = 6f;
        [FoldoutGroup("@configName/On Air & Jump")] public float jumpAmt = 2f; //how much we jump upwards 
        [FoldoutGroup("@configName/On Air & Jump"), ReadOnly] public bool hasJumped; //if we have pressed jump
        [FoldoutGroup("@configName/On Air & Jump")] public float jumpInputBufferTime = 0.2f;
        [FoldoutGroup("@configName/On Air & Jump"), ReadOnly] public float jumpInputBufferT;
        [FoldoutGroup("@configName/On Air & Jump")] public float autoJumpAmplifier = 1.2f;
        [FoldoutGroup("@configName/On Air & Jump")] public float autoJumpGravAmplifier = 1.1f;
        [FoldoutGroup("@configName/On Air & Jump")] public LayerMask layerToJumpLand = 0;
        [Space(5)]
        [FoldoutGroup("@configName/On Air & Jump")] public float airAcceleration = 5f; //how quickly we adjust to new speeds when in air
        [FoldoutGroup("@configName/On Air & Jump")] public float turnSpeedInAir = 2f;
        [FoldoutGroup("@configName/On Air & Jump")] public float fallingGravityAmt = -9.81f;

        [FoldoutGroup("@configName/Slopes"), ReadOnly] public bool slopeDown;
        [FoldoutGroup("@configName/Slopes"), ReadOnly] public float groundSlopeAngle = 0f;            // Angle of the slope in degrees
        [FoldoutGroup("@configName/Slopes"), ReadOnly] public Vector3 groundSlopeDir = Vector3.zero;  // The calculated slope as a vector
        [FoldoutGroup("@configName/Slopes")] public float wallRejectForce = 0.15f;
        [FoldoutGroup("@configName/Slopes")] public bool showDebug = false;                  // Show debug gizmos and lines
        [FoldoutGroup("@configName/Slopes")] public LayerMask castingMask;                  // Layer mask for casts. You'll want to ignore the player.
        [FoldoutGroup("@configName/Slopes")] public float startDistanceFromBottom = 0.2f;   // Should probably be higher than skin width
        [FoldoutGroup("@configName/Slopes")] public float sphereCastRadius = 0.25f;
        [FoldoutGroup("@configName/Slopes")] public float sphereCastDistance = 0.75f;       // How far spherecast moves down from origin point

        [FoldoutGroup("@configName/Slopes")] public float raycastLength = 0.75f;
        [FoldoutGroup("@configName/Slopes")] public Vector3 rayOriginOffset1 = new Vector3(-0.2f, 0f, 0.16f);
        [FoldoutGroup("@configName/Slopes")] public Vector3 rayOriginOffset2 = new Vector3(0.2f, 0f, -0.16f);

        
        
        private BipedData _setData;
    }

    [Serializable]
    public class FlyData
    {
        [Button(Name = "Save Values", DirtyOnClick = true), FoldoutGroup("@configName")]
        private void SetData()
        {
            _setData = new FlyData
            {
                maxForwardSpeed = maxForwardSpeed,
                maxGlobalSpeed = maxGlobalSpeed,
                accelerationIncrementInTime = accelerationIncrementInTime,
                movementAcceleration = movementAcceleration,
                slowDownAcceleration = slowDownAcceleration,
                turnSpeedSides = turnSpeedSides,
                turnAccelerationSides = turnAccelerationSides,
                turnSpeedUpDown = turnSpeedUpDown,
                turnAccelerationUpDown = turnAccelerationUpDown,
                standardGravityAmt = standardGravityAmt
            };
        }

        [Button(Name = "Reset Values", DirtyOnClick = true), HideIf("@_setData == null"), FoldoutGroup("@configName")]
        private void ResetData()
        {
            maxForwardSpeed = _setData.maxForwardSpeed;
            maxGlobalSpeed = _setData.maxGlobalSpeed;
            accelerationIncrementInTime = _setData.accelerationIncrementInTime;
            movementAcceleration = _setData.movementAcceleration;
            slowDownAcceleration = _setData.slowDownAcceleration;
            turnSpeedSides = _setData.turnSpeedSides;
            turnAccelerationSides = _setData.turnAccelerationSides;
            turnSpeedUpDown = _setData.turnSpeedUpDown;
            turnAccelerationUpDown = _setData.turnAccelerationUpDown;
            standardGravityAmt = _setData.standardGravityAmt;
        }
        
        [FoldoutGroup("@configName")] public string configName = "New fly data";

        [FoldoutGroup("@configName/Debug"), ReadOnly] public float forwardAngle;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float upDownAngle;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public Vector3 moveDirection = Vector3.zero;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public Vector3 eulerRot;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public bool onGround; //the bool for if we are on ground (this is used for the animator
        [FoldoutGroup("@configName/Debug"), ReadOnly] public Vector3 playerVelocity = Vector3.zero;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public Vector3 playerVelocityTarget = Vector3.zero;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float actualSpeed; //our actual speed
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float targetSpeed; //our terget speed
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float actualAcceleration;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float actionAirTimer;
        [FoldoutGroup("@configName/Debug"), ReadOnly] public float flyingTimer;
        [FoldoutGroup("@configName/Debug")] public float glideTime = 4f;
        [FoldoutGroup("@configName/Debug")] public bool confusion;
        [FoldoutGroup("@configName/Debug"), ShowIf("@confusion == true")] public bool confusionAffectsBothAxis = true;
        
        [FoldoutGroup("@configName/Speed & Accel")] public float maxForwardSpeed = 18f; //max speed for basic movement
        [FoldoutGroup("@configName/Speed & Accel")] public float maxGlobalSpeed = 15f; //max speed for basic movement
        [FoldoutGroup("@configName/Speed & Accel")] public float accelerationIncrementInTime = 4f; //how quickly we build speed //our actual speed
        [FoldoutGroup("@configName/Speed & Accel")] public float movementAcceleration = 6f; //how quickly we adjust to new speeds
        [FoldoutGroup("@configName/Speed & Accel")] public float slowDownAcceleration = 3.5f; //how quickly we slow down
        [FoldoutGroup("@configName/Speed & Accel")] public float flyingAdjustmentSpeed = 1.5f;
        [FoldoutGroup("@configName/Speed & Accel"), ReadOnly] public float flyingAdjustmentLerp;
        [FoldoutGroup("@configName/Speed & Accel")] public float flyingLowerLimit = -6f;
        [FoldoutGroup("@configName/Speed & Accel")] public float flyingUpperLimit = 5f;
        [FoldoutGroup("@configName/Speed & Accel")] public float flyingVelocityGain = 0.7f;
        [FoldoutGroup("@configName/Speed & Accel")] public float flyingVelocityLoss = 1.2f;
        [FoldoutGroup("@configName/Speed & Accel")] public float speedClamp = 60f;
        [FoldoutGroup("@configName/Speed & Accel")] public float flyingMinSpeed = 8.5f;
        
        [FoldoutGroup("@configName/Flaps")] public float flapTime = 1.5f;
        [FoldoutGroup("@configName/Flaps"), ReadOnly] public float flapT;
        [FoldoutGroup("@configName/Flaps")] public float flapSlowdown = 150f;
        [FoldoutGroup("@configName/Flaps"), ReadOnly] public bool hasFlapped;
        [FoldoutGroup("@configName/Flaps")] public float flapForce = 40;
        [FoldoutGroup("@configName/Flaps")] public float initialImpulse = 15;

        [FoldoutGroup("@configName/Rotation")] public bool lockXRotation;
        [FoldoutGroup("@configName/Rotation")] public float turnUpMaxAngle = 87f;
        [FoldoutGroup("@configName/Rotation")] public float turnDownMinAngle = -87f;
        [FoldoutGroup("@configName/Rotation")] public float turnForceByVelocityMin = 5f;
        [FoldoutGroup("@configName/Rotation")] public float turnForceByVelocityMax = 60f;
        [FoldoutGroup("@configName/Rotation")] public float turnForceAdjustmentSpeed = .3f;
        [FoldoutGroup("@configName/Rotation"), ReadOnly] public float actualTurnForce;
        [FoldoutGroup("@configName/Rotation")] public float turnSpeedSides = 8f;
        [FoldoutGroup("@configName/Rotation")] public float turnAccelerationSides = 1f;
        [FoldoutGroup("@configName/Rotation"), ReadOnly] public float actualTurnSpeedSides;
        [FoldoutGroup("@configName/Rotation")] public float turnSpeedUpDown = 10f;
        [FoldoutGroup("@configName/Rotation")] public float turnAccelerationUpDown = 1f;
        [FoldoutGroup("@configName/Rotation"), ReadOnly] public float actualTurnSpeedUpDown;

        [FoldoutGroup("@configName/Recentering")] public bool zAxisRecentering = true;
        [FoldoutGroup("@configName/Recentering"), ShowIf("@zAxisRecentering == true")] public float waitTime = 3f;
        [FoldoutGroup("@configName/Recentering"), ShowIf("@zAxisRecentering == true")] public float timeToRecenter = 1.5f;
        [FoldoutGroup("@configName/Recentering"), ShowIf("@zAxisRecentering == true"), MinValue(0), MaxValue(1)] 
        [FoldoutGroup("@configName/Recentering")] public float minRotationInputThreshold = 0.1f;
        [FoldoutGroup("@configName/Recentering")] public AnimationCurve recenterCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [FoldoutGroup("@configName/Recentering"), ReadOnly] public float recenterT;
        [FoldoutGroup("@configName/Recentering"), ReadOnly] public float waitToRecenterT;
        [FoldoutGroup("@configName/Recentering"), ReadOnly] public bool recentering;
        [FoldoutGroup("@configName/Recentering"), ReadOnly] public Vector3 recenterOriginalRot;

        [FoldoutGroup("@configName/Gravity")] public float standardGravityAmt = 8f;
        [FoldoutGroup("@configName/Gravity")] public float gravityAdjustmentSpeed = 4f;
        [FoldoutGroup("@configName/Gravity"), ReadOnly] public float actualGravityAmt;
        
        [FoldoutGroup("@configName/Stun")] public bool canBeStunned = true;
        [FoldoutGroup("@configName/Stun"), ShowIf("@canBeStunned == true")] public float minSpeedToStun = 7f;
        [FoldoutGroup("@configName/Stun"), ShowIf("@canBeStunned == true")] public float maxSpeedToStun = 16f;
        [FoldoutGroup("@configName/Stun"), ShowIf("@canBeStunned == true"), MinMaxSlider(0f, 45f, true)] 
        public Vector2 minMaxPushbackForce = new Vector2(10, 35);

        [FoldoutGroup("@configName/Confusion", VisibleIf = "@confusion == true"), ReadOnly]
        public bool isConfused;
        [FoldoutGroup("@configName/Confusion", VisibleIf = "@confusion == true")]
        public float timeToConfuse = 3f;
        [FoldoutGroup("@configName/Confusion", VisibleIf = "@confusion == true")]
        public float confuseVelocityMagnitudeCut = 3f;
        [FoldoutGroup("@configName/Confusion", VisibleIf = "@confusion == true")]
        public float timeOfConfusion = 2.5f;
        [FoldoutGroup("@configName/Gravity"), ShowIf("@confusion == true")]
        public float confusedGravityAmt = 14f;
        [FoldoutGroup("@configName/Confusion", VisibleIf = "@confusion == true"), ReadOnly]
        public float confuseT;        
        [FoldoutGroup("@configName/Confusion", VisibleIf = "@confusion == true"), ReadOnly]
        public float confuseControlT;

        private FlyData _setData;
    }
}