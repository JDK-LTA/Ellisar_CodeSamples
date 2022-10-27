using System;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Animations
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [BoxGroup("References"), SerializeField, InfoBox("Needs this reference!!", InfoMessageType.Warning, VisibleIf = "@bipedModelRef == null")]
        private GameObject bipedModelRef;

        [BoxGroup("References"), SerializeField, InfoBox("Needs this reference!!", InfoMessageType.Warning, VisibleIf = "@flyModelRef == null")]
        private GameObject flyModelRef;

        [BoxGroup("Variables"), SerializeField, ReadOnly] private bool walkOnlyBiped = false;
        [BoxGroup("Variables"), SerializeField, ReadOnly] private bool jumpLandTriggered = false;
        [BoxGroup("Variables"), SerializeField, ReadOnly] private bool jumpMirror = false;
        [BoxGroup("Variables"), SerializeField, ReadOnly] private float speedNormalizedBiped;
        [BoxGroup("Variables"), SerializeField, ReadOnly] private float jumpInitialY;
        [BoxGroup("Variables"), SerializeField] private bool startInWalkOnly = true;
        [BoxGroup("Variables"), SerializeField] private float jumpLandRaycastDistance = 0.3f;
        [BoxGroup("Variables"), SerializeField] private float jumpLandingMinDistanceDivisor = 2f;
        [BoxGroup("Variables"), SerializeField, Min(0.01f)] private float flightXBlendSpeed = 4f;

        private bool _onAirDisable = false;
        private float _tOnAir = 0, _timeOnAirDisable;
        
        public float XInput { get; set; }

        public float SpeedNormalizedBiped
        {
            get => speedNormalizedBiped;
            set => speedNormalizedBiped = value;
        }

        public bool WalkOnlyBiped
        {
            get => walkOnlyBiped;
            set => walkOnlyBiped = value;
        }

        public bool StartInWalkOnly
        {
            get => startInWalkOnly;
            set => startInWalkOnly = value;
        }

        public float JumpLandRaycastDistance => jumpLandRaycastDistance;

        public float JumpInitialY => jumpInitialY;

        public bool JumpLandTriggered
        {
            get => jumpLandTriggered;
            set => jumpLandTriggered = value;
        }
        public float LerpedXInput { get; set; }


        private Animator bipedAnimator, flyAnimator;

        private void Awake()
        {
            bipedAnimator = bipedModelRef != null ? bipedModelRef.GetComponent<Animator>() : null;
            flyAnimator = flyModelRef != null ? flyModelRef.GetComponent<Animator>() : null;
        }

        private void Start()
        {
            WalkOnly();
        }

        public void WalkOnly()
        {
            bipedAnimator.SetBool("WalkOnly", startInWalkOnly);
        }

        private void Update()
        {
            if (bipedAnimator && PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Biped)
            {
                bipedAnimator.SetFloat("Speed", SpeedNormalizedBiped);
            }
            else if (flyAnimator && PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Fly)
            {
                LerpedXInput = Mathf.Lerp(LerpedXInput, XInput, Time.deltaTime * flightXBlendSpeed);
                flyAnimator.SetFloat("X Input", LerpedXInput);
                flyAnimator.SetFloat("Forward Rotation", SkillMovementData.ActualBodyVelocity.y);
            }

            if (_onAirDisable)
            {
                _tOnAir += Time.deltaTime;
                if (_tOnAir >= _timeOnAirDisable)
                {
                    _tOnAir = 0;
                    _onAirDisable = false;
                }
            }
        }

        public void TriggerInteractionAnim()
        {
            if(bipedAnimator)
                bipedAnimator.SetTrigger("Interact");
        }

        public void SetBipedAnimBool(string boolName, bool value)
        {
            if (bipedAnimator)
            {
                bipedAnimator.SetBool(boolName, value);
            }
        }

        public void TriggerBipedJump()
        {
            if (bipedAnimator && PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Biped)
            {
                bipedAnimator.SetTrigger("Jump");
                jumpMirror = !jumpMirror;
                bipedAnimator.SetBool("Mirror", jumpMirror);
            }

            jumpInitialY = transform.position.y;
        }

        public void TriggerBipedLand()
        {
            if (bipedAnimator && PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Biped)
            {
                // if (transform.position.y - jumpInitialY < jumpAmount / jumpLandingMinDistanceDivisor)
                // {
                    jumpLandTriggered = true;
                    OnAirTrigger(false);
                    bipedAnimator.SetBool("JumpLand", jumpLandTriggered);
                // }
                // else
                // {
                    // bipedAnimator.SetTrigger("JumpInstantLand");
                // }
            }
        }

        public void ResetJumpLandBool()
        {
            jumpLandTriggered = false;
            bipedAnimator.SetBool("JumpLand", jumpLandTriggered);
        }

        public void ResetLandTrigger()
        {
            // bipedAnimator.ResetTrigger("JumpInstantLand");
            OnAirTrigger(false);
            bipedAnimator.SetBool("JumpLand", true);
        }
        
        public void OnAirTrigger(bool value)
        {
            if(!_onAirDisable && value || !value)
                bipedAnimator.SetBool("OnAir", value);
            
            // bipedAnimator.ResetTrigger("JumpInstantLand");
        }

        public void DisableOnAirForSecs(float time)
        {
            _timeOnAirDisable = time;
            _onAirDisable = true;
        }

        public void ResetJumpTrigger()
        {
            bipedAnimator.ResetTrigger("Jump");
        }

        public void SetSurprised()
        {
            bipedAnimator.SetTrigger("Surprised");
        }

        public void TriggerFlap()
        {
            if (flyAnimator && PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Fly)
            {
                flyAnimator.SetTrigger("Flap");
            }
        }

        public void SetTransformationModel(PlayerModeState nextTransformation)
        {
            switch (nextTransformation)
            {
                case PlayerModeState.Biped:
                    SetBipedModel();
                    break;
                case PlayerModeState.Fly:
                    SetFlyModel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(nextTransformation), nextTransformation, null);
            }
            
            // transformationVFX.Play(true);
        }

        public void SetBipedModel()
        {
            bipedModelRef.SetActive(true);
            flyModelRef.SetActive(false);

            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }

        public void SetFlyModel()
        {
            bipedModelRef.SetActive(false);
            flyModelRef.SetActive(true);
        }

        public void SetAgileModel()
        {
            bipedModelRef.SetActive(false);
            flyModelRef.SetActive(false);
        }
    }
}