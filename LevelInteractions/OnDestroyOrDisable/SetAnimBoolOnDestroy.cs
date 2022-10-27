using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.OnDestroyOrDisable
{
    public class SetAnimBoolOnDestroy : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string boolName;
        [SerializeField] private bool value;

        private void OnDestroy()
        {
            if (animator && boolName != "")
            {
                animator.SetBool(boolName, value);
            }
            else
            {
                throw new UnassignedReferenceException("One of the references is missing");
            }
        }
    }
}
