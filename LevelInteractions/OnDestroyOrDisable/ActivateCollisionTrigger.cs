using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.OnDestroyOrDisable
{
    public class ActivateCollisionTrigger : MonoBehaviour
    {
        [SerializeField] private Collider triggerToActivate;
        private void OnDestroy()
        {
            triggerToActivate.enabled = true;
        }
    }
}
