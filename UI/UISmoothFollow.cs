using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class UISmoothFollow : MonoBehaviour
    {
        public Camera Camera2Follow;
        public float CameraDistance = 3.0F;
        public float smoothTime = 0.3F;
        private Vector3 velocity = Vector3.zero;
        private Transform target;
     
        void Awake()
        {
            target = Camera2Follow.transform;
        }
     
     
        void Update()
        {
            Vector3 targetPosition = Camera2Follow.transform.TransformPoint(new Vector3(0, 0, CameraDistance));
       
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            var lookAtPos = new Vector3(Camera2Follow.transform.position.x, transform.position.y, Camera2Follow.transform.position.z);
            transform.LookAt(lookAtPos);  
        }

    }
}
