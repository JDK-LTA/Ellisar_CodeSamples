using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem
{
    public class TriggerEnterExitCallbacks : TriggerEnterExit
    {
        [SerializeField] private UnityEvent enterEvent, exitEvent; 
        
        protected override void TriggerAction()
        {
            enterEvent?.Invoke();
        }

        protected override void TriggerExitAction()
        {
            exitEvent?.Invoke();
        }
    }
}
