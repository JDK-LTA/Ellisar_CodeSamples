using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs
{
    public class EnterExitInteractionCallbacks : TriggerEnterExit
    {
        [SerializeField] private UnityEvent enterInteraction, exitInteraction;

        protected override void TriggerAction()
        {
            enterInteraction?.Invoke();
        }
        
        protected override void TriggerExitAction()
        {
            exitInteraction?.Invoke();
        }
    }
}
