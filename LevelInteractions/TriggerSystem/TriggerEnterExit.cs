using System;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem
{
    public abstract class TriggerEnterExit : TriggerEnter
    {
        protected void OnTriggerExit(Collider other)
        {
            Checker = checkForPlayer ? other.gameObject.layer == 3 : other == objectToCheckWith;

            if (Checker && Activated)
            {
                TriggerExitAction();    
            }
        }

        protected abstract void TriggerExitAction();
    }
}
