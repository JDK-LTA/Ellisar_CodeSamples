using System.Collections.Generic;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Animations
{
    /// <summary>
    /// DEPRECATED
    /// </summary>
    public class AnimationTriggerNotPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject objectToTriggerWith;
        [SerializeField] private List<Animator> animators;
        [SerializeField] private string enterTriggerName, exitTriggerName;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == objectToTriggerWith)
            {
                foreach (var an in animators)
                {
                    an.SetTrigger(enterTriggerName);    
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == objectToTriggerWith)
            {
                foreach (var an in animators)
                {
                    an.SetTrigger(exitTriggerName);    
                }
            }
        }
    }
}
