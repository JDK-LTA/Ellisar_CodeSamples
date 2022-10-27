using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Animations
{
    public class AnimatorBoolHelper : MonoBehaviour
    {
        [SerializeField, Required] private Animator animator;

        public void SetBoolTrue(string boolName)
        {
            animator.SetBool(boolName, true);
        }

        public void SetBoolFalse(string boolName)
        {
            animator.SetBool(boolName, false);
        }
    }
}
