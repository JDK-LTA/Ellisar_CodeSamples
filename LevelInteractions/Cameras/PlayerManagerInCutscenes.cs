using System;
using System.Collections.Generic;
using Cinemachine;
using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Checkpoints;
using Ellisar.EllisarAssets.Scripts.Player;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using Ellisar.EllisarAssets.Scripts.UI;
using Ellisar.EllisarAssets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Cameras
{
    public class PlayerManagerInCutscenes : MonoBehaviour
    {
        [SerializeField] private List<GameObject> seaAngelsIfNeeded;
        [SerializeField] private CinemachineFreeLook stdCam;

        private PlayerController _player;
        private CinemachineFreeLook _cam;

        private void Start()
        {
            _player = PlayerSetup.PlayerController;
        }

        public void SetPlayerInput(bool value)
        {
            _player.CanBeControlled = value;
            SetCanOpenMenu(value);

            if (!value)
            {
                PlayerSetup.PhysicsController.Forward = 0;
                PlayerSetup.PhysicsController.Right = 0;
                PlayerSetup.PhysicsController.Up = 0;
                SkillMovementData.ActualBodyVelocity = Vector3.zero;
            }
        }

        public void SetPlayerPositionAndRotation(Transform targetPlace)
        {
            _player.transform.position = targetPlace.position;
            _player.transform.rotation = targetPlace.rotation;

            if (seaAngelsIfNeeded.Count > 0)
            {
                foreach (var sa in seaAngelsIfNeeded)
                {
                    sa.transform.position = targetPlace.position;
                    sa.transform.rotation = targetPlace.rotation;
                }
            }

            Physics.SyncTransforms();
        }

        public void SetCameraInput(bool value)
        {
            CamerasManager.Instance.SetCameraInput(value);
        }

        public void SetCamRotationX(float value)
        {
            if (stdCam)
                _cam = stdCam;
            else
                _cam = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineFreeLook>();

            if (_cam)
                _cam.m_XAxis.Value = value;
        }

        public void SetCamRotationY(float value)
        {
            if (stdCam)
                _cam = stdCam;
            else
                _cam = _cam = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineFreeLook>();

            if (_cam)
                _cam.m_YAxis.Value = value;
        }

        public void ForceTransformToBiped()
        {
            CheckpointManager.Instance.ForceTransformation(true);
        }

        public void SwapToUIEventSystem(GameObject go)
        {
            UIManager.Instance.PlayerInput1.SwitchCurrentActionMap("UI");
            EventSystem.current.SetSelectedGameObject(go);
        }

        public void GoBackToPlayerMap()
        {
            CamerasManager.Instance.UpdateActionMap();
        }

        public void SetCanOpenMenu(bool value)
        {
            MenuOpener.CanOpenMenu = value;
        }

        public void SetPlayerSurprisedAnim()
        {
            PlayerSetup.PlayerAnimationController.SetSurprised();
        }

        public void SetPlayerInactive()
        {
            PlayerSetup.PlayerController.UpdatePlayerPhysics = false;
        }
    }
}
