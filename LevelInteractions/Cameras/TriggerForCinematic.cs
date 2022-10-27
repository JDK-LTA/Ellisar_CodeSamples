using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Cameras
{
    [RequireComponent(typeof(Collider))]
    public class TriggerForCinematic : TriggerEnter
    {
        [SerializeField] private MMFeedbacks feedbacksSystem;
        [SerializeField] private bool selfDisable = true;
        private Collider _collider;
    
        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        protected override void TriggerAction()
        {
            feedbacksSystem.PlayFeedbacks();
            if(selfDisable) _collider.enabled = false;
        }
    }
}
