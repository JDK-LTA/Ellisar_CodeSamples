using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Ellisar.EllisarAssets.Scripts.Player
{
    public class CamerasManager : MonoBehaviour
    {
        public static CamerasManager Instance;

        public List<CameraData> cameraDatas;
        public int standardPriority;
        [SerializeField] private int topPriority;

        [SerializeField] private List<PlayCameras> _allCineCameras;
        [InfoBox("0 == Standard, 1 == OneHand Left, 2 == OneHand Right"),SerializeField, MinValue(0), MaxValue(2)] private int controlTypeIndex = 0;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField, ReadOnly] private string[] actionMapNames = {"Player", "1HandL", "1HandR"};
        private int _lastCTI = 0;

        public int ControlTypeIndex
        {
            get => controlTypeIndex;
            set
            {
                if (value > 2)
                    value = 0;
                if (value < 0)
                    value = 2;
                
                controlTypeIndex = value;

                MainMenuManager.Instance.ControlType = controlTypeIndex;

                UpdateControlType();
            }
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            foreach (var cams in cameraDatas)
            {
                cams.originalPriority = cams.cameraInfo.Priority;
            }
        }

        public void SetCameraActive(CameraData cam, bool active, CameraData oldCamRef = null, bool customXValue = false, int xValue = 0)
        {
            // if (oldCamRef == null) oldCamRef = new CameraData((CinemachineFreeLook)Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera);
            cam.cameraInfo.Priority = active ? topPriority : cam.originalPriority;
            // cam.cameraInfo.GetComponent<CinemachineCollider>().enabled = active;

            if (oldCamRef?.cameraInfo != null)
            {
                oldCamRef.cameraInfo.Priority = !active ? topPriority : cam.originalPriority;
                if (!customXValue)
                    cam.cameraInfo.m_XAxis.Value = oldCamRef.cameraInfo.m_XAxis.Value;
                // oldCamRef.cameraInfo.GetComponent<CinemachineCollider>().enabled = !active;
            }

            if (customXValue)
                cam.cameraInfo.m_XAxis.Value = xValue;
        }

        public void SetCameraActive(CinemachineFreeLook newCam, bool active, bool customXValue = false, int xValue = 0, CinemachineFreeLook stdCam = null)
        {
            newCam.gameObject.SetActive(active);

            if (customXValue)
            {
                if (stdCam) stdCam.m_XAxis.Value = xValue;
                else newCam.m_XAxis.Value = xValue;
            }
        }

        public void SetCamerasFollow(bool active)
        {
            foreach (var cam in _allCineCameras)
            {
                cam.camInfo.Follow = active ? transform : null;
            }
        }

        public void SetCameraInput(bool value)
        {
            if (_allCineCameras.Count > 0)
            {
                foreach (var cam in _allCineCameras)
                {
                    var ccip = cam.camInfo.GetComponent<CustomCinemachineInputProvider>(); 
    
                    if(ccip)
                        ccip.InputEnabled = value;
                }
            }
        }

        public void ToggleInvertAllCameras(bool value)
        {
            foreach (var cam in _allCineCameras)
            {
                cam.camInfo.m_YAxis.m_InvertInput = !value;
            }
        }

        public void CameraXSensitivitySlider(float value)
        {
            foreach (var cam in _allCineCameras)
            {
                cam.camInfo.m_XAxis.m_MaxSpeed = value;
            }
        }
        
        public void CameraYSensitivitySlider(float value)
        {
            foreach (var cam in _allCineCameras)
            {
                cam.camInfo.m_YAxis.m_MaxSpeed = value;
            }
        }

        public void SetCamerasRotationX(float value)
        {
            foreach (var cam in _allCineCameras)
            {
                if (cam.camInfo.m_BindingMode == CinemachineTransposer.BindingMode.WorldSpace)
                {
                    cam.camInfo.m_XAxis.Value = value;
                }
            }
        }

        public void SetFlyCameraBinding(bool lockToTarget)
        {
            _allCineCameras.First(x => x.typeFly == true).camInfo.m_BindingMode = 
                lockToTarget ? CinemachineTransposer.BindingMode.LockToTargetWithWorldUp : CinemachineTransposer.BindingMode.WorldSpace;
        }

        public void SetCameraOneHandInput(bool value)
        {
            foreach (var cam in _allCineCameras)
            {
                if (!cam.typeFly)
                {
                    if (value)
                    {
                        cam.camInfo.m_XAxis.Value = 0;
                        cam.camInfo.m_YAxis.Value = 0.45f;
                    }

                    cam.camInfo.m_BindingMode = value ? CinemachineTransposer.BindingMode.LockToTargetWithWorldUp : CinemachineTransposer.BindingMode.WorldSpace;
                    cam.camInfo.m_Heading.m_Definition = value ? 
                        CinemachineOrbitalTransposer.Heading.HeadingDefinition.TargetForward : CinemachineOrbitalTransposer.Heading.HeadingDefinition.Velocity;
                    cam.camInfo.GetRig(1).GetCinemachineComponent<CinemachineOrbitalTransposer>().m_YawDamping = value ? 2.5f : 0;
                }

                cam.camInfo.m_RecenterToTargetHeading.m_enabled = value;
                cam.camInfo.m_RecenterToTargetHeading.m_RecenteringTime = 0;
                cam.camInfo.m_RecenterToTargetHeading.m_WaitTime = 0;
                cam.camInfo.m_YAxisRecentering.m_enabled = value;
                cam.camInfo.m_YAxisRecentering.m_RecenteringTime = 0;
                cam.camInfo.m_YAxisRecentering.m_WaitTime = 0;
            }
        }

        public void ControlTypePlus()
        {
            ControlTypeIndex++;
        }

        public void ControlTypeMinus()
        {
            ControlTypeIndex--;
        }

        public void UpdateControlType()
        {
            SetCameraOneHandInput(ControlTypeIndex > 0);
        }

        public void RecordLastControlType()
        {
            _lastCTI = ControlTypeIndex;
        }
        public void UpdateActionMap()
        {
            _playerInput.SwitchCurrentActionMap(actionMapNames[ControlTypeIndex]);
            if(_lastCTI != ControlTypeIndex)
                PlayerSetup.PlayerController.ResetSkillsToNewMap(actionMapNames[ControlTypeIndex]);
        }
        
        [Serializable]
        public class PlayCameras
        {
            [FormerlySerializedAs("camera")] public CinemachineFreeLook camInfo;
            public bool typeFly;
        }
    }
    
    [Serializable]
    public class CameraData
    {
        public CinemachineFreeLook cameraInfo;

        // public bool targetGrouping = false;
        // [HideIf("@targetGrouping == false")] public CinemachineTargetGroup targetGroup;
        [Unity.Collections.ReadOnly] public int originalPriority;

        public CameraData(CinemachineFreeLook cfl)
        {
            cameraInfo = cfl;
        }
    }
}