using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ellisar.EllisarAssets.Scripts.Utilities;

namespace Ellisar
{
    public class SaveGame : MonoBehaviour
    {
        [SerializeField] private ScenesManager.SceneState scene;

        public void SaveSceneState()
        {
            ScenesManager.Instance.ScenesState = scene;
        }
    }
}
