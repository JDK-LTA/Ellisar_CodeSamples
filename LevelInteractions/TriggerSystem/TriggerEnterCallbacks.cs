using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem
{
    public class TriggerEnterCallbacks : TriggerEnter
    {
        [SerializeField] private UnityEvent enterEvent; 
        
        protected override void TriggerAction()
        {
            enterEvent?.Invoke();
        }
    }
}
