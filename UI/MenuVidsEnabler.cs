using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class MenuVidsEnabler : MonoBehaviour
    {
        [SerializeField] private List<VidsAndBool> indexAndValues;
        
        public void SetVids()
        {
            foreach (var iav in indexAndValues)
            {
                if (iav.value)
                    MenuCamerasManager.Instance.SetLevelCameraAvailable(iav.index);
                else
                    MenuCamerasManager.Instance.SetLevelCameraUnavailable(iav.index);
            }
        }
        
    }

    [System.Serializable]
    public struct VidsAndBool
    {
        public int index;
        public bool value;
    }
}
