// using Ellisar.EllisarAssets.Scripts.Player.Main;

using System;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs
{
    public class WhaleTurtleLookAt : MonoBehaviour
    {
        [SerializeField] private float minXAngle, maxXAngle, minYAngle, maxYAngle, minZAngle = -25, maxZAngle = 25;
        [SerializeField] private Vector3 offset;
        [SerializeField] private Transform player;
        private Vector3 actualTarget;
    
        private void Start()
        {
            if (!player) player = PlayerSetup.CharController.transform;
            actualTarget = player.position + offset;
        }

        private void LateUpdate()
        {
            var target = player.position + offset;
            actualTarget = Vector3.Slerp(actualTarget, target, Time.deltaTime * 1.5f);
        
            transform.LookAt(actualTarget);
            transform.Rotate(0, 90, 0);

            var rot = transform.localEulerAngles;

            rot.x = ClampAngle(rot.x, minXAngle, maxXAngle);
            rot.y = ClampAngle(rot.y, minYAngle, maxYAngle);
            rot.z = ClampAngle(rot.z, minZAngle, maxZAngle);

            transform.localEulerAngles = rot;
        }
        public static float ClampAngle(float angle, float min, float max)
        {
            angle = Mathf.Repeat(angle, 360);
            min = Mathf.Repeat(min, 360);
            max = Mathf.Repeat(max, 360);
            bool inverse = false;
            var tmin = min;
            var tangle = angle;
            if(min > 180)
            {
                inverse = !inverse;
                tmin -= 180;
            }
            if(angle > 180)
            {
                inverse = !inverse;
                tangle -= 180;
            }
            var result = !inverse ? tangle > tmin : tangle < tmin;
            if(!result)
                angle = min;

            inverse = false;
            tangle = angle;
            var tmax = max;
            if(angle > 180)
            {
                inverse = !inverse;
                tangle -= 180;
            }
            if(max > 180)
            {
                inverse = !inverse;
                tmax -= 180;
            }
 
            result = !inverse ? tangle < tmax : tangle > tmax;
            if(!result)
                angle = max;
            return angle;
        }
    }
}