using System;
using System.Collections.Generic;
using Ellisar.EllisarAssets.Scripts.Audio;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Animations;
using Ellisar.EllisarAssets.Scripts.Player.PhysicsProcessor;
using Ellisar.EllisarAssets.Scripts.Player.Serializables;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using Ellisar.EllisarAssets.Scripts.Player.Statics;
using Ellisar.EllisarAssets.Scripts.Player.VFX;
using Ellisar.EllisarAssets.Scripts.UI;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;


namespace Ellisar.EllisarAssets.Scripts.Player.Main
{
	public class PlayerPhysicsController : MonoBehaviour
	{
		private CharacterController _controller;
		private PlayerAnimationController _animationController;
		private List<string> _conditions;
		private Transform _cam;
		public static Vector3 MovementInputVector3;
		[HideInInspector] public UnityEvent<bool> actionChanged;

		[SerializeField, ReadOnly] Vector3 smoothedInput;

		#region VARIABLES

		#region Debug

		// ReSharper disable once NotAccessedField.Local
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private float actualVelMagnitude;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private Vector3 slopeNormal;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private float slopeAngle;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private Vector3 slopeVector3;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private Vector3 normalizedSlopeVector3;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private float forwardAndSlopeDelta;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private Vector3 forwardWithY;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private float auxAngle;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private bool collided;
		// [FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private bool lastFrameAgileModifier;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private bool lastFrameFlyModifier;
		// [FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private BipedState lastFrameAgileState = BipedState.Grounded;
		[FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private List<ConditionalInputMovement> conditionalInputMovements;
		// [FoldoutGroup("DEBUG"), SerializeField, ReadOnly] private bool ;

		#endregion

		#region BipedData

		[FoldoutGroup("BIPED"), SerializeField] private CameraData bipedStandardCam;

		[FoldoutGroup("BIPED"), MinValue(0), MaxValue("@bipedDatas.Count - 1")] [SerializeField]
		private int bipedIndex;

		[FoldoutGroup("BIPED"), InfoBox("NO BIPED DATAS IN THE LIST", InfoMessageType.Error, "@bipedDatas.Count == 0")]
		[SerializeField] private List<BipedData> bipedDatas;

		[FoldoutGroup("BIPED"), SerializeField, ReadOnly] private BipedData bipedData;

		[FoldoutGroup("BIPED"), Button(Name = "Set current biped data", DirtyOnClick = true),
		 ShowIf("@UnityEngine.Application.isPlaying")]
		public void SetBipedData()
		{
			bipedData = bipedIndex < bipedDatas.Count ? bipedDatas[bipedIndex] : bipedDatas[0];
		}

		#endregion

		#region FlyData

		[FoldoutGroup("FLY"), SerializeField] private MMFeedbacks flapFeedback;

		[FoldoutGroup("FLY"), SerializeField] private CameraData flyStandardCam;

		[Space(5f)] [FoldoutGroup("FLY"), MinValue(0), MaxValue("@flyDatas.Count - 1")] [SerializeField]
		private int flyIndex;

		[FoldoutGroup("FLY"), InfoBox("NO FLY DATAS IN THE LIST", InfoMessageType.Error, "@flyDatas.Count == 0")]
		[SerializeField] private List<FlyData> flyDatas;

		[FoldoutGroup("FLY"), SerializeField, ReadOnly] private FlyData flyData;

		[FoldoutGroup("FLY"), Button(Name = "Set current fly data", DirtyOnClick = true),
		 ShowIf("@UnityEngine.Application.isPlaying")]
		private void SetFlyData()
		{
			flyData = flyIndex < flyDatas.Count ? flyDatas[flyIndex] : flyDatas[0];
		}

		#endregion

		#region Actions

		[FoldoutGroup("ACTIONS"), SerializeField] private bool debugInfiniteActions = false;
		[FoldoutGroup("ACTIONS")] private static int _actualActionsAmount = 2;
		[FoldoutGroup("ACTIONS")] private static int _maxActionsAmount = 2;
		[FoldoutGroup("ACTIONS"), SerializeField, MinValue(0)] private int initialActionsAmount = 2;
		[FoldoutGroup("ACTIONS"), SerializeField] private float timeToRegenActionOnGround = 2.5f;
		[FoldoutGroup("ACTIONS"), SerializeField] private float timeToRegenActionOnAir = 8f;
		[FoldoutGroup("ACTIONS"), SerializeField, ReadOnly] private float regenT;

		#endregion

		#region Transformations

		[FoldoutGroup("TRANSFORMATIONS"), SerializeField] private SoundEmitter transformationSfx;
		[FoldoutGroup("TRANSFORMATIONS"), SerializeField] private SoundEmitter transformationBackSfx;
		[FoldoutGroup("TRANSFORMATIONS"), SerializeField, MaxValue("@cooldownTransformation")] private float sfxDelayTime = 0.5f;
		[FoldoutGroup("TRANSFORMATIONS"), SerializeField] private float cooldownTransformation = 3f;
		[FoldoutGroup("TRANSFORMATIONS"), SerializeField, ReadOnly] private float cdTransfT = 0;
		[FoldoutGroup("TRANSFORMATIONS"), SerializeField, ReadOnly] private bool cooldownTransf = false;
		[Space(5)] [FoldoutGroup("TRANSFORMATIONS"), SerializeField] private float timeScaleLowValue = 0.7f;
		[FoldoutGroup("TRANSFORMATIONS"), SerializeField] private float timeScaleTimerToLow = 0.15f;
		[FoldoutGroup("TRANSFORMATIONS"), SerializeField] private float timeScaleTimerStayLow = 0.25f;
		[FoldoutGroup("TRANSFORMATIONS"), SerializeField] private float timeScaleTimerToNormal = 0.25f;
		[FoldoutGroup("TRANSFORMATIONS"), SerializeField, ReadOnly] private bool tsLerping = false;

		private float _tsLerpT = 0;
		private bool _tsLerpToLow = false;
		private bool _tsStay = false;
		private bool _tsLerpToNormal = false;

		[Space(5)] [FoldoutGroup("TRANSFORMATIONS"), MinValue("@bufferRefresh"), SerializeField]
		private float bufferInputTime = 0.3f;

		[FoldoutGroup("TRANSFORMATIONS"), MaxValue("@bufferInputTime"), SerializeField]
		private float bufferRefresh = 0.1f;

		private Queue<Vector3> _previousInput = new Queue<Vector3>();
		private int _bufferQueueSize;
		private float _bufferT = 0;

		[FoldoutGroup("TRANSFORMATIONS"), SerializeField, Tooltip("This only works for flight")]
		private float timerForNoInputTransforming = 0.45f;

		private bool _noInput = false;
		private float _noInputT = 0;

		[Space(5)] [FoldoutGroup("TRANSFORMATIONS"), SerializeField]
		private float flightTransformationExtraAngle = 25;

		[FoldoutGroup("TRANSFORMATIONS"), SerializeField] private float jumpToFlyTime = 0.3f;

		[FoldoutGroup("TRANSFORMATIONS"), SerializeField, ReadOnly] private bool isAutoTransforming = false;

		private float _jumpToFlyT = 0;
		private bool _jumpToFlyTimer = false;

		private bool _sfxDelaying = false;
		private float _sfxDelayT = 0;

		#endregion

		#endregion

		#region PROPERTIES

		public float Forward { get; set; }

		public float Right { get; set; }

		public float Up { get; set; }

		public float Modifier { get; set; }

		public List<ConditionalInputMovement> ConditionalInputMovements
		{
			get => conditionalInputMovements;
			private set => conditionalInputMovements = value;
		}

		public bool UsingConditional { get; set; }

		public static int MaxActionsAmount
		{
			get => _maxActionsAmount;
			set
			{
				if (_maxActionsAmount < value)
					_actualActionsAmount++;
				else if (_maxActionsAmount > value)
					_actualActionsAmount = value;

				_maxActionsAmount = Mathf.Clamp(value, 0, 4);

				if (UIManager.Instance)
				{
                    switch (_maxActionsAmount)
                    {
                        case 2:
                            UIManager.Instance.TwoActions = true;
                            break;
                        case 3:
                            UIManager.Instance.ThreeActions = true;
                            break;
                        case 4:
                            UIManager.Instance.FourActions = true;
                            break;
                    }

                    UIManager.Instance.UpdateFeathers(_actualActionsAmount);
					UIManager.Instance.ShowNewFlap = true;
				}
			}
		}

		public static int ActualActionsAmount
		{
			get => _actualActionsAmount;
			set
			{
				if (value < _actualActionsAmount && !CanSpendActions) return;

				_actualActionsAmount = Mathf.Clamp(value, 0, 100);
				if (UIManager.Instance)
				{
					UIManager.Instance.UpdateFeathers(_actualActionsAmount);
					if (_actualActionsAmount == MaxActionsAmount)
					{
						UIManager.Instance.RegenToAlphaZero();
					}
				}
			}
		}

		public static bool CanSpendActions { get; set; } = true;

		public bool HasEel { get; set; } = true;

		public bool HasKnife { get; set; }

		public FlyData FlyData => flyData;
		
		public int BipedIndex
		{
			get => bipedIndex;
			set => bipedIndex = value;
		}

		public CharacterController CharController => _controller;

		#endregion

		#region METHODS

		#region Unity Methods

		private void Awake()
		{
			ConditionalInputMovements = new List<ConditionalInputMovement>();
			if (bipedDatas.Count != 0)
			{
				bipedData = bipedIndex < bipedDatas.Count ? bipedDatas[bipedIndex] : bipedDatas[0];
			}
			else
			{
				//Adds new biped data if count = 0
				bipedDatas.Add(new BipedData());
				bipedData = bipedDatas[0];
			}

			if (flyDatas.Count != 0)
			{
				flyData = flyIndex < flyDatas.Count ? flyDatas[flyIndex] : flyDatas[0];
			}
			else
			{
				//Adds new fly data if count = 0
				flyDatas.Add(new FlyData());
				flyData = flyDatas[0];
			}

			forwardWithY = transform.forward;
			_bufferQueueSize = (int) (bufferInputTime / bufferRefresh);

			_maxActionsAmount = initialActionsAmount;
			_actualActionsAmount = initialActionsAmount;
		}

		private void Start()
		{
			_controller = PlayerSetup.CharController;
			_animationController = PlayerSetup.PlayerAnimationController;
			_conditions = PlayerSetup.PlayerController.Conditions;
			_cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
		}

		private void FixedUpdate()
		{
			if (!PlayerSetup.PlayerController.UpdatePlayerPhysics) return;

			MovementInputVector3 = new Vector3(Right, Up, Forward);
			actualVelMagnitude = SkillMovementData.ActualBodyVelocity.magnitude;

			//get our direction of input based on camera position
			var screenMovementForward = _cam.forward;
			var screenMovementRight = _cam.right;
			screenMovementForward.y = 0;
			screenMovementRight.y = 0;

			var h = screenMovementRight * MovementInputVector3.x;
			var v = screenMovementForward * MovementInputVector3.z;

			switch (PlayerSetup.PlayerController.CurrentPlayerState)
			{
				case PlayerModeState.Biped:

					if (SkillMovementData.IsTransforming)
					{
						switch (PlayerSetup.PlayerController.TargetPlayerState)
						{
							case PlayerModeState.Biped:
								SkillMovementData.IsTransforming = false;
								break;
							case PlayerModeState.Fly:
								JumpToFly();
								StartFlightTransformation();
								return;
								break;
							default:
								throw new ArgumentOutOfRangeException();
						}
					}

					forwardWithY = transform.forward;

					bipedData.actualSpeed = SkillMovementData.ActualBodySpeed;
					bipedData.playerVelocity = SkillMovementData.ActualBodyVelocity;

					bipedData.moveDirectionTarget = (v + h).normalized;

					var lastState = PlayerSetup.PlayerController.CurrentBipedState;

					PlayerSetup.PlayerController.CurrentBipedState = bipedData.onGround ? BipedState.Grounded : BipedState.OnAir;

					if (lastState == BipedState.OnAir && PlayerSetup.PlayerController.CurrentBipedState == BipedState.Grounded)
					{
						PlayerVFXManager.Instance.Poof.PlayAll();
						_animationController.ResetLandTrigger();
					}

					if (PlayerSetup.PlayerController.CurrentBipedState == BipedState.OnAir && !PhysicsBiped.JumpControl && SkillMovementData.ActualBodyVelocity.y <= 0)
					{
						PhysicsBiped.CheckGroundForAnim(bipedData, new Vector3(transform.position.x, transform.position.y - (CharController.height / 2) + bipedData.startDistanceFromBottom, transform.position.z));
					}

					var temp = Vector3.Cross(slopeNormal, Vector3.down);
					slopeVector3 = Vector3.Cross(temp, slopeNormal);
					normalizedSlopeVector3 = slopeVector3.normalized;

					switch (PlayerSetup.PlayerController.CurrentBipedMovementState)
					{
						case BipedMovementState.Static:
							break;

						case BipedMovementState.Walking:

							bipedData.onGround = _controller.isGrounded;

							if (bipedData.moveDirectionTarget.magnitude != 0f)
							{
								collided = false;
								PhysicsBiped.RotateBipedData(bipedData, transform);
							}

							bipedData.moveDirection = transform.forward;

							if (!UsingConditional)
							{
								PhysicsBiped.SetBipedDataSpeedAndAcceleration(bipedData);

								PhysicsBiped.SetBipedDataVelocity(bipedData);

								if (SkillMovementData.ActualBodySpeed < 0.1f && bipedData.targetSpeed == 0)
								{
									SkillMovementData.ActualBodySpeed = 0f;
									bipedData.actualAcceleration = 0f;
									SkillMovementData.ActualBodyVelocity.x = 0;
									SkillMovementData.ActualBodyVelocity.z = 0;
								}

								if (bipedData.onGround)
								{
									PhysicsBiped.CheckGround(bipedData, new Vector3(transform.position.x, transform.position.y - (CharController.height / 2) + bipedData.startDistanceFromBottom, transform.position.z), transform);
									bipedData.slopeDown = bipedData.groundSlopeAngle > _controller.slopeLimit;
								}

								if (!bipedData.slopeDown)
									PhysicsBiped.JumpBiped(bipedData);

								if (bipedData.onGround && bipedData.slopeDown)
								{
									PhysicsBiped.SlopeSliding(slopeNormal, bipedData.wallRejectForce, bipedData);
								}

								PhysicsBiped.UpdateFallingBiped(bipedData.fallingGravityAmt, transform.position,
									bipedData);
							}

							PhysicsBiped.ConditionalsBiped(this);


							break;
						
						default:
							throw new ArgumentOutOfRangeException();
					}
					
					_animationController.SpeedNormalizedBiped = SkillMovementData.ActualBodySpeed / bipedData.maxSpeed;

					break;

				case PlayerModeState.Fly:

					if (SkillMovementData.IsTransforming)
					{
						switch (PlayerSetup.PlayerController.TargetPlayerState)
						{
							case PlayerModeState.Biped:
								PlayerVFXManager.Instance.Trail.FadeIn = false;
								PlayerVFXManager.Instance.Trail.FadeOut = true;
								SetTransformations();
								AkSoundEngine.SetRTPCValue("WaterFlowIntensity", 0);
								return;
								break;
							case PlayerModeState.Fly:
								SkillMovementData.IsTransforming = false;
								break;
							default:
								throw new ArgumentOutOfRangeException();
						}
					}

					flyData.actualSpeed = SkillMovementData.ActualBodySpeed;
					flyData.playerVelocity = SkillMovementData.ActualBodyVelocity;
					flyData.onGround = _controller.isGrounded;

					if (flyData.onGround)
					{
						TransformFlyToBipedOnGround();
						return;
					}


					if (!flyData.hasFlapped)
					{
						if (flyData.flyingTimer > 0)
							flyData.flyingTimer -= Time.fixedDeltaTime;
					}
					else if (flyData.flyingTimer < flyData.glideTime)
					{
						flyData.flyingTimer = flyData.glideTime;
					}

					if (flyData.actionAirTimer > 0)
						flyData.actionAirTimer -= Time.fixedDeltaTime;


					if (flyData.flyingAdjustmentLerp < 1.1)
						flyData.flyingAdjustmentLerp += Time.fixedDeltaTime * flyData.flyingAdjustmentSpeed;

					PhysicsFly.SetFlySpeedAndAcceleration(flyData);

					PhysicsFly.SetForwardDirectionFly(flyData, transform);

					PhysicsFly.FlyZRecentering(flyData, MovementInputVector3.x, transform);

					PhysicsFly.SetFlyVelocity(flyData, transform);

					break;

				default:
					throw new ArgumentOutOfRangeException();
			}

			_controller.Move(SkillMovementData.ActualBodyVelocity * Time.fixedDeltaTime);
			UpdateContinuedPress();
		}

		public void TransformFlyToBipedOnGround()
		{
			transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
			PlayerSetup.PlayerController.TargetPlayerState = PlayerModeState.Biped;
			SkillMovementData.IsTransforming = true;
			cooldownTransf = false;
			cdTransfT = 0;

			PlayerVFXManager.Instance.Poof.PlayAll();
		}

		private void Update()
		{
			if (!PlayerSetup.PlayerController.UpdatePlayerPhysics) return;

			PhysicsFly.FlapTimer(flyData);

			ActionRegenerationTimer();

			PhysicsFly.FlyConfusionTimer(flyData);

			LerpTimeScale();

			NoInputTimer();

			JumpToFlyTimer();

			TransformationCooldownTimer();

			MarkerRaycast();

			PreInputBufferTimer();

			SfxDelayTimer();
		}
		
		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			if (_controller.collisionFlags == CollisionFlags.None)
				return;
			collided = true;
			slopeNormal = hit.normal;
			slopeAngle = Vector3.Angle(slopeNormal, Vector3.up);


		}

		private void OnDrawGizmosSelected()
		{
			// Visualize SphereCast with two spheres and a line
			Vector3 startPoint = new Vector3(transform.position.x, transform.position.y - (GetComponent<CharacterController>().height / 2) + bipedData.startDistanceFromBottom, transform.position.z);
			Vector3 endPoint = new Vector3(transform.position.x, transform.position.y - (GetComponent<CharacterController>().height / 2) + bipedData.startDistanceFromBottom - bipedData.sphereCastDistance, transform.position.z);

			Gizmos.color = Color.white;
			Gizmos.DrawWireSphere(startPoint, bipedData.sphereCastRadius);

			Gizmos.color = Color.gray;
			Gizmos.DrawWireSphere(endPoint, bipedData.sphereCastRadius);

			Gizmos.DrawLine(startPoint, endPoint);
		}

		#endregion

		#region General Methods

		public void NextDataSet(bool next)
		{
			switch (PlayerSetup.PlayerController.CurrentPlayerState)
			{
				case PlayerModeState.Biped:
					bipedIndex += next ? 1 : -1;
					if (bipedIndex < 0) bipedIndex = bipedDatas.Count - 1;
					if (bipedIndex >= bipedDatas.Count) bipedIndex = 0;
					bipedData = bipedDatas[bipedIndex];
					break;
				case PlayerModeState.Fly:
					flyIndex += next ? 1 : -1;
					if (flyIndex < 0) flyIndex = flyDatas.Count - 1;
					if (flyIndex >= flyDatas.Count) flyIndex = 0;
					flyData = flyDatas[flyIndex];
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void NextDataSet(PlayerModeState playerMode, int index)
		{
			switch (playerMode)
			{
				case PlayerModeState.Biped:
					if (index < bipedDatas.Count)
					{
						bipedData = bipedDatas[index];
					}
					else
					{
						throw new IndexOutOfRangeException("The index in the trigger is too high");
					}

					break;
				case PlayerModeState.Fly:
					if (index < flyDatas.Count)
					{
						flyData = flyDatas[index];
					}
					else
					{
						throw new IndexOutOfRangeException("The index in the trigger is too high");
					}
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(playerMode), playerMode, null);
			}
		}

		private void MarkerRaycast()
		{
			if (PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Fly ||
			    (PlayerSetup.PlayerController.CurrentBipedState == BipedState.OnAir &&
			     PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Biped))
			{
				if (Physics.Raycast(transform.position, Vector3.down, out var hit,
					PlayerVFXManager.Instance.MarkerMaxDistance))
				{
					if (hit.distance >= PlayerVFXManager.Instance.MarkerMinDistance)
						PlayerVFXManager.Instance.Marker.PlayOnPosition(hit.point,
							PlayerVFXManager.Instance.MarkerYOffset);
				}
				else
				{
					PlayerVFXManager.Instance.Marker.StopAll();
				}
			}
			else
			{
				PlayerVFXManager.Instance.Marker.StopAll();
			}
		}

		private void ActionRegenerationTimer()
		{
			if (ActualActionsAmount < MaxActionsAmount)
			{
				var sum = _controller.isGrounded && !bipedData.slopeDown
					? Time.deltaTime
					: 0/*Time.deltaTime * timeToRegenActionOnGround / timeToRegenActionOnAir*/;
				regenT += sum;

				UIManager.Instance.UpdateActionRegenBar((float)ActualActionsAmount / MaxActionsAmount + regenT / MaxActionsAmount / timeToRegenActionOnGround);

				var timeChecker = debugInfiniteActions ? 0 : timeToRegenActionOnGround;
				if (regenT >= timeChecker)
				{
					regenT = 0;
					ActualActionsAmount++;
					actionChanged?.Invoke(true);
					if(ActualActionsAmount == MaxActionsAmount)
						UIManager.Instance.UpdateActionRegenBar(1);
				}
			}
		}

		public void UpdateProperties()
		{
			switch (PlayerSetup.PlayerController.CurrentPlayerState)
			{
				case PlayerModeState.Biped:
					bipedData.hasJumped = Up != 0;

					if (bipedData.hasJumped && !PhysicsBiped.JumpControl)
					{
						PhysicsBiped.JumpControl = true;
						bipedData.jumpInputBufferT = bipedData.jumpInputBufferTime;
					}

					break;
				case PlayerModeState.Fly:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void UpdateContinuedPress()
		{
			switch (PlayerSetup.PlayerController.CurrentPlayerState)
			{
				case PlayerModeState.Biped:
					bipedData.hasJumped = Up != 0;
					break;

				case PlayerModeState.Fly:
					if (Modifier != 0)
					{
						if (!lastFrameFlyModifier)
						{
							lastFrameFlyModifier = true;
							PhysicsFly.Flap(flyData);
							actionChanged?.Invoke(false);
							// if(flapFeedback)
							// 	flapFeedback.PlayFeedbacks();
						}
					}
					else
					{
						if(lastFrameFlyModifier)
							lastFrameFlyModifier = false;
					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void UpdateConditionals()
		{
			foreach (var conditionalInput in ConditionalInputMovements)
			{
				if (conditionalInput.ActionT > 0 && conditionalInput.ActionT < conditionalInput.ActionDuration) return;
				
				MovementInputVector3 = Vector3.zero;
				SkillMovementData.ActualBodyVelocity = Vector3.zero;

				var playerTransform = transform;
				var right = playerTransform.right;
				var up = playerTransform.up;
				var forward = playerTransform.forward;

				conditionalInput.ConditionalInputVector3 = conditionalInput.Direction.MovementType switch
				{
					MovementTypeEnum.Composite => conditionalInput.Direction.CompositeType switch
					{
						CompositeTypeEnum.TwoAxis => conditionalInput.Direction.CompositeTwoAxisType switch
						{
							CompositeTwoAxisTypeEnum.RightForward => right + forward,
							CompositeTwoAxisTypeEnum.RightUp => right + up,
							CompositeTwoAxisTypeEnum.UpForward => up + forward,
							_ => throw new ArgumentOutOfRangeException()
						},
						CompositeTypeEnum.AllAxis => right + up + forward,
						_ => throw new ArgumentOutOfRangeException()
					},
					MovementTypeEnum.OneAxis => conditionalInput.Direction.OneAxisType switch
					{
						OneAxisTypeEnum.Right => right,
						OneAxisTypeEnum.Up => up,
						OneAxisTypeEnum.Forward => forward,
						_ => throw new ArgumentOutOfRangeException()
					},
					MovementTypeEnum.Modifier => Vector3.zero,
					_ => throw new ArgumentOutOfRangeException()
				};

				UsingConditional = true;
				conditionalInput.ActionT = conditionalInput.ActionDuration;
			}
		}

		private void PreInputBufferTimer()
		{
			if (_bufferT >= bufferRefresh)
			{
				_previousInput.Enqueue(MovementInputVector3);
				if (_previousInput.Count > _bufferQueueSize)
					_previousInput.Dequeue();
				_bufferT = 0;
			}
			else
			{
				_bufferT += Time.deltaTime;
			}
		}
		
		#endregion

		#region Transformation

		private void SetTransformations()
		{
			if (cooldownTransf) return;

			ChangeCam(PlayerSetup.PlayerController.TargetPlayerState);
			PlayerSetup.PlayerController.CurrentPlayerState = PlayerSetup.PlayerController.TargetPlayerState;

			_animationController.SetTransformationModel(PlayerSetup.PlayerController.CurrentPlayerState);
			AudioManager.Instance.SetPlayerLayer(PlayerSetup.PlayerController.CurrentPlayerState);
			SkillMovementData.IsTransforming = false;

			ResetTransformationVariables(PlayerSetup.PlayerController.CurrentPlayerState);

			PlayerVFXManager.Instance.ExplosionTransformation.PlayAll();
			if (!_sfxDelaying)
			{
				if(PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Fly)
					transformationSfx.Post();
				else
					transformationBackSfx.Post();
				_sfxDelaying = true;
			}

			cooldownTransf = true;
		}

		private void SetTransformations(float angle)
		{
			if (cooldownTransf) return;

			SetTransformations();
			// var actualRot = transform.eulerAngles;
			// transform.rotation = Quaternion.Euler(actualRot.x - angle, actualRot.y, actualRot.z);
			// flyData.forwardAngle = Vector3.SignedAngle(Vector3.ProjectOnPlane(transform.forward,Vector3.up), Vector3.forward,Vector3.up);
			flyData.upDownAngle = angle;

			SkillMovementData.ActualBodySpeed += flyData.initialImpulse;
		}

		private void StartFlightTransformation()
		{
			_animationController.LerpedXInput = 0;

			_tsLerpT = 0;
			tsLerping = true;
			_tsLerpToLow = true;
			_noInput = true;

			PlayerVFXManager.Instance.Trail.FadeOut = false;			
			PlayerVFXManager.Instance.Trail.FadeIn = true;

			AkSoundEngine.SetRTPCValue("WaterFlowIntensity", 100);
		}

		private void TransformationCooldownTimer()
		{
			if (cooldownTransf)
			{
				if (SkillMovementData.IsTransforming) SkillMovementData.IsTransforming = false;

				cdTransfT += Time.deltaTime;
				if (cdTransfT >= cooldownTransformation)
				{
					cdTransfT = 0;
					cooldownTransf = false;
				}
			}
		}

		private void LerpTimeScale()
		{
			if (!tsLerping) return;

			if (Time.timeScale > 0)
				_tsLerpT += Time.unscaledDeltaTime;

			if (_tsLerpToLow)
			{
				Time.timeScale = Mathf.Lerp(1, timeScaleLowValue, _tsLerpT / timeScaleTimerToLow);
				if (_tsLerpT >= timeScaleTimerToLow)
				{
					_tsLerpT = 0;
					_tsStay = true;
					_tsLerpToLow = false;
					Time.timeScale = timeScaleLowValue;
				}
			}

			if (_tsStay)
			{
				if (_tsLerpT >= timeScaleTimerStayLow)
				{
					_tsLerpT = 0;
					_tsLerpToNormal = true;
					_tsStay = false;
				}
			}

			if (_tsLerpToNormal)
			{
				Time.timeScale = Mathf.Lerp(timeScaleLowValue, 1, _tsLerpT / timeScaleTimerToNormal);
				if (_tsLerpT >= timeScaleTimerToNormal)
				{
					_tsLerpT = 0;
					_tsLerpToNormal = false;
					tsLerping = false;
					Time.timeScale = 1;
				}
			}
		}

		private void NoInputTimer()
		{
			if (_noInput)
			{
				if (Time.timeScale > 0)
					_noInputT += Time.unscaledDeltaTime;

				if (_noInputT >= timerForNoInputTransforming)
				{
					_noInputT = 0;
					_noInput = false;
					PlayerSetup.PlayerController.CanBeControlled = true;
				}
			}
		}

		private void ChangeCam(PlayerModeState nextPlayerModeState)
		{
			float xValue = 0;
			var comingFromLockCam = false;

			switch (PlayerSetup.PlayerController.CurrentPlayerState)
			{
				case PlayerModeState.Biped:
					xValue = bipedStandardCam.cameraInfo.m_XAxis.Value;
					break;
				case PlayerModeState.Fly:
					xValue = flyStandardCam.cameraInfo.m_XAxis.Value;
					comingFromLockCam = true;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			switch (nextPlayerModeState)
			{
				case PlayerModeState.Biped:
					bipedStandardCam.cameraInfo.Priority = CamerasManager.Instance.standardPriority;
					flyStandardCam.cameraInfo.Priority = CamerasManager.Instance.standardPriority - 1;
					flyStandardCam.cameraInfo.m_RecenterToTargetHeading.m_enabled = false;

					bipedStandardCam.cameraInfo.m_XAxis.Value =
						comingFromLockCam ? transform.eulerAngles.y + xValue : xValue;
					break;
				case PlayerModeState.Fly:
					bipedStandardCam.cameraInfo.Priority = CamerasManager.Instance.standardPriority - 1;
					flyStandardCam.cameraInfo.Priority = CamerasManager.Instance.standardPriority;
					flyStandardCam.cameraInfo.m_RecenterToTargetHeading.m_enabled = true;

					flyStandardCam.cameraInfo.m_XAxis.Value = xValue;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(nextPlayerModeState), nextPlayerModeState, null);
			}
		}

		private void JumpToFly()
		{
			if (cooldownTransf) return;

			MovementInputVector3 = _previousInput.Peek();
			if (MovementInputVector3 == Vector3.zero)
			{
				MovementInputVector3 = Vector3.forward;
			}

			var h = _cam.right * MovementInputVector3.x;
			var v = _cam.forward * MovementInputVector3.z;

			flyData.forwardAngle = PhysicsMaths.AngleOffAroundAxis((v + h).normalized, Vector3.forward, Vector3.up);

			if (PlayerSetup.PlayerController.CurrentBipedState == BipedState.Grounded)
			{
				PhysicsBiped.JumpControl = true;
				PhysicsBiped.JumpBiped(bipedData, true);
				SkillMovementData.IsTransforming = false;
				isAutoTransforming = true;

				_jumpToFlyTimer = true;
			}
			else
			{
				if (!isAutoTransforming)
				{
					SetTransformations(flightTransformationExtraAngle);
					_jumpToFlyT = 0;
				}
			}
		}

		private void JumpToFlyTimer()
		{
			if (_jumpToFlyTimer)
			{
				if (Time.timeScale > 0)
					_jumpToFlyT += Time.unscaledDeltaTime;
				if (_jumpToFlyT >= jumpToFlyTime)
				{
					_jumpToFlyT = 0;
					_jumpToFlyTimer = false;
					isAutoTransforming = false;
					SetTransformations(flightTransformationExtraAngle);
				}
			}
		}

		private void ResetTransformationVariables(PlayerModeState nextMode)
		{
			switch (nextMode)
			{
				case PlayerModeState.Biped:
					transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
					Physics.SyncTransforms();
					break;
				case PlayerModeState.Fly:
					flyData.recentering = false;
					flyData.recenterT = 0;
					flyData.waitToRecenterT = 0;

					flyData.flapT = 0;
					flyData.hasFlapped = false;

					flyData.confuseT = 0;
					flyData.confuseControlT = 0;
					flyData.isConfused = false;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(nextMode), nextMode, null);
			}
		}

		private void SfxDelayTimer()
		{
			if (_sfxDelaying)
			{
				_sfxDelayT += Time.deltaTime;
				if (_sfxDelayT >= sfxDelayTime)
				{
					_sfxDelaying = false;
					_sfxDelayT = 0;
				}
			}
		}

		#endregion

		#endregion
	}
	
}