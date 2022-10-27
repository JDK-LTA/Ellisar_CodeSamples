using System;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Animations
{
    public class RootMotionFix : MonoBehaviour
    {
        [SerializeField] private float maxDistance = 0.15f;
        
        private void OnEnable()
        {
            ResetPos();
        }

        private void LateUpdate()
        {
            if (Vector3.Distance(transform.localPosition, Vector3.zero) >= maxDistance)
            {
                ResetPos();
            }
        }

        private void ResetPos()
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
