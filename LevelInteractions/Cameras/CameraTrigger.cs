using System;
using Cinemachine;
using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem;
using Ellisar.EllisarAssets.Scripts.Player;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Cameras
{
    public class CameraTrigger : TriggerEnterExit
    {
        [SerializeField] private bool customXValue = false;
        [SerializeField, HideIf("@customXValue == false"), MinValue(-180), MaxValue(180)] private int xValue = 0;
        // [EnumToggleButtons, SerializeField, HideLabel] private IndexOrRef indexOrRef;
        //
        // [SerializeField, HideIf("@indexOrRef != IndexOrRef.Index"), MinValue(0)]
        // private int cameraIndex;
        //
        // [SerializeField, HideIf("@indexOrRef != IndexOrRef.Ref")] private CameraData cameraRef;
        // [SerializeField] private bool goBackWhenExit = true;
        // [SerializeField, HideIf("@goBackWhenExit == true")] private CameraData oldCameraRef;

        [SerializeField] private CinemachineFreeLook newCam;
        [SerializeField] private bool newCamActive = true;
        [SerializeField, HideIf("newCamActive")] private CinemachineFreeLook stdCam;
        
        private void Start()
        {
            // if (indexOrRef == IndexOrRef.Index)
            // {
            //     if (cameraIndex < CamerasManager.Instance.cameraDatas.Count)
            //         cameraRef = CamerasManager.Instance.cameraDatas[cameraIndex];
            //     else
            //     {
            //         throw new IndexOutOfRangeException(gameObject.name + ": this cameraIndex value is out of range");
            //     }
            // }
            if (newCamActive) stdCam = null;
        }

        protected override void TriggerAction()
        {
            // if (!goBackWhenExit && oldCameraRef != null)
            // {
            // CamerasManager.Instance.SetCameraActive(cameraRef, true, oldCameraRef, customXValue, xValue);
            // }
            SetCam();
        }

        public void SetCam()
        {
            CamerasManager.Instance.SetCameraActive(newCam, newCamActive, customXValue, xValue, stdCam);
        }

        protected override void TriggerExitAction()
        {
            // CamerasManager.Instance.SetCameraActive(cameraRef, false);
        }
    }

    // public enum IndexOrRef
    // {
    //     Index,
    //     Ref
    // }
    
    
}