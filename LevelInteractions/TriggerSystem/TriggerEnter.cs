using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem
{
    [RequireComponent(typeof(Collider))]
    public abstract class TriggerEnter : MonoBehaviour
    {
        [SerializeField] protected bool activated = true;
        [SerializeField] protected bool checkForPlayer = true;
        [SerializeField, HideIf("checkForPlayer"), InfoBox("Fill this reference!!", InfoMessageType.Error, VisibleIf = "@objectToCheckWith == null")] protected Collider objectToCheckWith;

        protected bool Checker;

        public bool Activated
        {
            get => activated;
            set => activated = value;
        }

#if UNITY_EDITOR
        [InfoBox("Collider is not trigger. Check the trigger box!", InfoMessageType.Error, VisibleIf = "ColliderIsNotTrigger")] 
        [InfoBox("The layer is not on Ignore Collider. It's likely you need it to be", InfoMessageType.Warning, VisibleIf = "LayerIsNotTwo")]

        private bool ColliderIsNotTrigger()
        {
            return !GetComponent<Collider>().isTrigger;
        }

        private bool LayerIsNotTwo()
        {
            return gameObject.layer != 2;
        }
#endif

        protected void OnTriggerEnter(Collider other)
        {
            Checker = checkForPlayer ? other.gameObject.layer == 3 : other == objectToCheckWith;

            if (Checker && Activated)
            {
                TriggerAction();    
            }
        }

        protected abstract void TriggerAction();
    }
}