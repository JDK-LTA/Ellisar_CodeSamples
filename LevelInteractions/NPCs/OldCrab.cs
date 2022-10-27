using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs
{
    public class OldCrab : TriggerEnterExit
    {
        [SerializeField] private bool checkKnife = true;
        [SerializeField] private UnityEvent firstInteraction, lastInteraction, exitInteraction;

        protected override void TriggerAction()
        {
            if (checkKnife)
            {
                if (!PlayerSetup.PhysicsController.HasKnife)
                {
                    firstInteraction?.Invoke();
                }
                else
                {
                    lastInteraction?.Invoke();
                }
            }
            else
            {
                firstInteraction?.Invoke();
            }
            
        }

        protected override void TriggerExitAction()
        {
            exitInteraction?.Invoke();
        }
    }
}
