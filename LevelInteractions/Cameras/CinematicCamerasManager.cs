using System;
using System.Collections.Generic;
using Cinemachine;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Cameras
{
    public class CinematicCamerasManager : MonoBehaviour
    {
        public static CinematicCamerasManager Instance;
    
        [SerializeField] private List<CinematicCamera> cinematicCameras;
        private float _timer;
        private float _t = 0;
        private bool _camActive = false;
        private int _currentIndex = -1;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            foreach (var ccam in cinematicCameras)
            {
                ccam.vcam.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (!PlayerSetup.PlayerController.UpdatePlayerPhysics) return;

            if (_camActive)
            {
                _t += Time.deltaTime;
                if (_t >= _timer)
                {
                    SetCurrentCameraInactive();
                }
            }
        }

        public void SetCameraActive(int indexOfCam)
        {
            _currentIndex = indexOfCam;
            var cam = cinematicCameras[_currentIndex];
            cam.vcam.gameObject.SetActive(true);

            if (cam.selfDeactivate)
            {
                _timer = cam.time;
                _camActive = true;
            }
        }

        public void SetCameraInactive(int indexOfCam)
        {
            var cam = cinematicCameras[indexOfCam];
            cam.vcam.gameObject.SetActive(false);

            _camActive = false;
            _t = 0;
        }

        public void SetCurrentCameraInactive()
        {
            SetCameraInactive(_currentIndex);
        }
    }

    [Serializable]
    public class CinematicCamera
    {
        public CinemachineVirtualCamera vcam;
        public bool selfDeactivate = true;
        [HideIf("@selfDeactivate == false")] public float time;
    }
}