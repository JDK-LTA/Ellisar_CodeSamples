using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.OnDestroyOrDisable
{
    public class ActivateTriggerOnDestroy : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string triggerName;
        private void OnDestroy()
        {
            if (animator && triggerName != "")
            {
                animator.SetTrigger(triggerName);
            }
            else
            {
                throw new UnassignedReferenceException("One of the references is missing");
            }
        }
    }
}
