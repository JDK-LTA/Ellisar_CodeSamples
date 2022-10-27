using System;
using System.Collections.Generic;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.UI;
// using Ellisar.EllisarAssets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.Player
{
    // public class SaveAndLoadManager : MonoBehaviour
    // {
    //     public static SaveAndLoadManager Instance;
    //     private SaveData _saveData;
    //     
    //     private void OnEnable()
    //     {
    //         Instance = this;
    //         
    //         if (_saveData != null)
    //         {
    //             Load();
    //         }
    //         else
    //         {
    //         }
    //     }
    //
    //     private void Load()
    //     {
    //         PlayerPhysicsController.MaxActionsAmount = _saveData.actions;
    //         PlayerSetup.CharController.transform.position = _saveData.position;
    //         PlayerSetup.CharController.transform.rotation = _saveData.rotation;
    //
    //         switch (_saveData.stage)
    //         {
    //             case Stage.CaveIn:
    //                 ScenesManager.Instance.LoadAdditiveScene(1);
    //                 break;
    //             case Stage.CaveOut:
    //                 ScenesManager.Instance.LoadAdditiveScene(1);
    //                 break;
    //             case Stage.Village:
    //                 ScenesManager.Instance.LoadAdditiveScene(1);
    //                 ScenesManager.Instance.LoadAdditiveScene(2);
    //                 break;
    //             case Stage.FlyTutorial:
    //                 ScenesManager.Instance.LoadAdditiveScene(1);
    //                 ScenesManager.Instance.LoadAdditiveScene(2);
    //                 break;
    //             case Stage.JellyIsland:
    //                 ScenesManager.Instance.LoadAdditiveScene(2);
    //                 break;
    //             case Stage.WaterTunnel:
    //                 ScenesManager.Instance.LoadAdditiveScene(2);
    //                 ScenesManager.Instance.LoadAdditiveScene(3);
    //                 break;
    //             case Stage.Exploration:
    //                 ScenesManager.Instance.LoadAdditiveScene(2);
    //                 ScenesManager.Instance.LoadAdditiveScene(3);
    //                 break;
    //             case Stage.Spyro:
    //                 ScenesManager.Instance.LoadAdditiveScene(4);
    //                 break;
    //             case Stage.End:
    //                 ScenesManager.Instance.LoadAdditiveScene(4);
    //                 ScenesManager.Instance.LoadAdditiveScene(5);
    //                 break;
    //             default:
    //                 throw new ArgumentOutOfRangeException();
    //         }
    //
    //         MenuCamerasManager.Instance.LevelCameras = _saveData.levelCameras;
    //     }
    // }

    [Serializable]
    public class SaveData
    {
        public Stage stage;
        public Vector3 position;
        public Quaternion rotation;
        public int actions;
        public List<AnimationData> animators;
        // public UnityEvent
    }

    [Serializable]
    public class AnimationData
    {
        public Animator animator;
        public string boolName;
    }
}
