using Ellisar.EllisarAssets.Scripts.Audio;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem
{
    public class AudioTrigger : TriggerEnter
    {
        [SerializeField] private bool autoDestroy = true;
        [SerializeField] private bool startTrueStopFalse;
        [SerializeField, HideIf("@startTrueStopFalse == false")] private string newAreaName;

        protected override void TriggerAction()
        {
            Action();
        }

        private void Action()
        {
            AudioManager.Instance.SetAreaLayer(newAreaName);
            AudioManager.Instance.StartStopMusic(startTrueStopFalse);
            if (autoDestroy)
                Destroy(gameObject);
        }

        public void ForceTriggerAction()
        {
            Action();
        }
    }
}