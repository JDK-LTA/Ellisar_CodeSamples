using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem;
using Ellisar.EllisarAssets.Scripts.UI;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Cameras
{
    public class MenuCameraActivator : TriggerEnter
    {
        [SerializeField] private bool selfDeactivate = true;
        [SerializeField] private bool activate = true;
        [SerializeField, ShowIf("activate")] private int index;
        [SerializeField] private bool deactivate = false;
        [SerializeField, ShowIf("deactivate")] private int deactIndex;

        protected override void TriggerAction()
        {
            ChangeVideos();
        }

        public void ChangeVideos()
        {
            if (activate)
                MenuCamerasManager.Instance.SetLevelCameraAvailable(index);
            if (deactivate)
                MenuCamerasManager.Instance.SetLevelCameraUnavailable(deactIndex);

            if(selfDeactivate)
                gameObject.SetActive(false);

        }
    }
}
