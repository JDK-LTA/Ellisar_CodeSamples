using System;
using Ellisar.EllisarAssets.Scripts.Enums;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Statics
{
    public static class PhysicsMaths
    {
        // Start is called before the first frame update
        
        public static void LerpSpeed(ref float actualSpeed, float targetSpeed, ref float actualAcceleration, float targetAcceleration, float accelerationIncrementInTime, float deltaTime)
        {
            actualAcceleration = Mathf.Lerp(actualAcceleration, targetAcceleration, accelerationIncrementInTime * deltaTime);
            actualSpeed =  Mathf.Lerp(actualSpeed, targetSpeed, actualAcceleration * deltaTime);
        }
        
        public static void LerpVelocity(ref float actualVelocityX, ref float actualVelocityY, ref float actualVelocityZ, float targetVelocityX, float targetVelocityY, float targetVelocityZ, float acceleration, float deltaTime)
        {
            actualVelocityX = Mathf.Lerp(actualVelocityX, targetVelocityX, acceleration * deltaTime);
            actualVelocityY = Mathf.Lerp(actualVelocityY, targetVelocityY, acceleration * deltaTime);
            actualVelocityZ = Mathf.Lerp(actualVelocityZ, targetVelocityZ, acceleration * deltaTime);
        }
        
        public static void LerpVelocity(ref Vector3 actualVelocity, Vector3 targetVelocity, float acceleration, float deltaTime)
        {
            actualVelocity = Vector3.Lerp(actualVelocity, targetVelocity, acceleration * deltaTime);
        }

        public static void LerpVelocity(ref Vector3 actualVelocity, Vector3 targetVelocity, Coord coord, float acceleration, float deltaTime)
        {
            float y = actualVelocity.y;
            actualVelocity = PhysicsMaths.NegateVector3Coordinate(actualVelocity, coord);
            actualVelocity = Vector3.Lerp(actualVelocity, PhysicsMaths.NegateVector3Coordinate(targetVelocity, coord), acceleration * deltaTime);
            actualVelocity.y = y;
        }
        


        public static Vector3 NegateVector3Coordinate(Vector3 vector, Coord coord)
        {
            return coord switch
            {
                Coord.x => new Vector3(0, vector.y, vector.z),
                Coord.y => new Vector3(vector.x, 0, vector.z),
                Coord.z => new Vector3(vector.x, vector.y, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(coord), coord, null)
            };
        }
        
        public static bool CheckVectorDifference(Vector3 a, Vector3 b, float minDifference)
        {
            var dx = a.x - b.x;
            var dy = a.y - b.y;
            var dz = a.z - b.z;
            return Mathf.Abs(dx) >= minDifference || Mathf.Abs(dy) >= minDifference || Mathf.Abs(dz) >= minDifference;
        }

        /// <summary>
        /// Find some projected angle measure off some forward around some axis.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="forward"></param>
        /// <param name="axis"></param>
        /// <param name="clockwise"></param>
        /// <returns>Angle in degrees</returns>
        public static float AngleOffAroundAxis(Vector3 v, Vector3 forward, Vector3 axis, bool clockwise = false)
        {
            Vector3 right;
            if(clockwise)
            {
                right = Vector3.Cross(forward, axis);
                forward = Vector3.Cross(axis, right);
            }
            else
            {
                right = Vector3.Cross(axis, forward);
                forward = Vector3.Cross(right, axis);
            }
            return Mathf.Atan2(Vector3.Dot(v, right), Vector3.Dot(v, forward)) * Mathf.Rad2Deg;
        }
    }
}
