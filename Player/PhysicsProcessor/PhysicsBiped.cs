using System;
using System.Collections.Generic;
using System.Linq;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using Ellisar.EllisarAssets.Scripts.Player.Statics;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.PhysicsProcessor
{
    public static class PhysicsBiped
    {
        private static RaycastHit slopeHit;
        public static bool JumpControl { get; set; }

        public static void RotateBipedData(BipedData bData, Transform transform)
        {
            var slerpRot = Quaternion.LookRotation(bData.moveDirectionTarget, Vector3.up);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, slerpRot, bData.turnSpeed * Time.fixedDeltaTime);
        }

        public static void SetBipedDataSpeedAndAcceleration(BipedData bData)
        {
            if (bData.moveDirectionTarget.magnitude == 0f)
            {
                bData.targetSpeed = 0f;
                bData.targetAcceleration = bData.slowDownAcceleration;
            }
            else
            {
                bData.targetSpeed = bData.maxSpeed *
                                    new Vector3(PlayerPhysicsController.MovementInputVector3.x, 0,
                                        PlayerPhysicsController.MovementInputVector3.z).magnitude;
                bData.targetAcceleration = bData.movementAcceleration;
            }

            PhysicsMaths.LerpSpeed(
                ref SkillMovementData.ActualBodySpeed,
                bData.targetSpeed,
                ref bData.actualAcceleration,
                bData.targetAcceleration,
                bData.accelerationIncrementInTime,
                Time.fixedDeltaTime);
        }

        public static void SetBipedDataVelocity(BipedData bData)
        {
            bData.playerVelocityTarget.x = bData.moveDirection.x * SkillMovementData.ActualBodySpeed;
            bData.playerVelocityTarget.z = bData.moveDirection.z * SkillMovementData.ActualBodySpeed;

            var yVel0 = 0f;
            PhysicsMaths.LerpVelocity(
                ref SkillMovementData.ActualBodyVelocity.x,
                ref yVel0,
                ref SkillMovementData.ActualBodyVelocity.z,
                bData.playerVelocityTarget.x,
                yVel0,
                bData.playerVelocityTarget.z,
                bData.actualAcceleration,
                Time.fixedDeltaTime);
        }

        // public static bool OnSteepSlope(BipedData bData, Transform transform, CharacterController contr)
        // {
        //     if (!bData.onGround) return false;
        //
        //     if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 1f))
        //     {
        //         var slopeAngle = Vector3.Angle(slopeHit.normal, Vector3.up);
        //         if (slopeAngle > contr.slopeLimit) return true;
        //     }
        //
        //     return false;
        // }
        //
        // public static void SteepSlopeMovement()
        // {
        //     Vector3 slopeDirection = Vector3.up - slopeHit.normal * Vector3.Dot(Vector3.up, slopeHit.normal);
        //     float slideSpeed = 
        // }

        public static void JumpBiped(BipedData bipedData, bool autoJump = false)
        {
            if (PlayerSetup.PlayerController.CurrentBipedState == BipedState.Grounded)
            {
                if (JumpControl)
                {
                    var jumpAmount = autoJump ? bipedData.jumpAmt * bipedData.autoJumpAmplifier : bipedData.jumpAmt;
                    var jumpGravBoost = autoJump ? bipedData.jumpGravityBoost * bipedData.autoJumpGravAmplifier : bipedData.jumpGravityBoost;

                    bipedData.actualGravity = bipedData.fallingGravityAmt * jumpGravBoost;
                    SkillMovementData.ActualBodyVelocity.y = Mathf.Sqrt(jumpAmount * -2.0f * bipedData.actualGravity);
                    bipedData.jumpInputBufferT = 0f;

                    PlayerSetup.PlayerAnimationController.TriggerBipedJump();
                }
            }


            if (bipedData.jumpInputBufferT <= 0f)
            {
                if (!bipedData.hasJumped)
                {
                    JumpControl = false;
                }

                bipedData.jumpInputBufferT = 0f;
            }
            else
            {
                bipedData.jumpInputBufferT -= Time.fixedDeltaTime;
            }
        }

        public static void UpdateFallingBiped(float gravAmt, Vector3 actualPosition, BipedData bipedData)
        {
            if (PlayerSetup.PlayerController.CurrentBipedState != BipedState.OnAir) return;

            if (SkillMovementData.ActualBodyVelocity.y <= 0)
            {
                bipedData.actualGravity = gravAmt;
            }

            if (UnityEngine.Physics.Raycast(actualPosition, Vector3.down, out RaycastHit hitInfo, PlayerSetup.PlayerAnimationController.JumpLandRaycastDistance, bipedData.layerToJumpLand))
            {
                // PlayerSetup.PlayerAnimationController.TriggerBipedLand(bipedData.jumpAmt);
            }

            SkillMovementData.ActualBodyVelocity.y += bipedData.actualGravity * Time.fixedDeltaTime;
        }

        public static void UpdateFallingBipedData(float gravAmt)
        {
            // if (PlayerController.CurrentBipedState != BipedState.OnAir) return;
            SkillMovementData.ActualBodyVelocity.y += gravAmt * Time.fixedDeltaTime;
        }

        public static void SlopeSliding(Vector3 slopeVector, float slideSpeed, BipedData bData)
        {
            // SkillMovementData.ActualBodyVelocity.x += slopeVector.normalized.x * slideSpeed * Time.fixedDeltaTime;
            // SkillMovementData.ActualBodyVelocity.z += slopeVector.normalized.z * slideSpeed * Time.fixedDeltaTime;
            
            // var dirV = SkillMovementData.ActualBodyVelocity.normalized;
            // var newDir = (dirV + slopeVector.normalized).normalized;
            // var mag = SkillMovementData.ActualBodyVelocity.magnitude;
            //
            // var incidenceAngle = Vector3.Angle(SkillMovementData.ActualBodyVelocity, slopeVector);

            SkillMovementData.ActualBodyVelocity = new Vector3(bData.groundSlopeDir.normalized.x, bData.groundSlopeDir.normalized.y, bData.groundSlopeDir.normalized.z) * slideSpeed;
        }

        public static void CheckGroundForAnim(BipedData bData, Vector3 origin)
        {
            PlayerSetup.PlayerAnimationController.OnAirTrigger(!Physics.SphereCast(origin, bData.sphereCastRadius, Vector3.down, out RaycastHit hit, bData.sphereCastDistance, bData.castingMask));
        }
        
        /// <summary>
        /// Checks for ground underneath, to determine some info about it, including the slope angle.
        /// </summary>
        /// <param name="origin">Point to start checking downwards from</param>
        public static void CheckGround(BipedData bData, Vector3 origin, Transform tr)
        {
            // Out hit point from our cast(s)
            RaycastHit hit;

            // SPHERECAST
            // "Casts a sphere along a ray and returns detailed information on what was hit."
            if (Physics.SphereCast(origin, bData.sphereCastRadius, Vector3.down, out hit, bData.sphereCastDistance, bData.castingMask))
            {
                // PlayerSetup.PlayerAnimationController.TriggerBipedLand();

                // Angle of our slope (between these two vectors). 
                // A hit normal is at a 90 degree angle from the surface that is collided with (at the point of collision).
                // e.g. On a flat surface, both vectors are facing straight up, so the angle is 0.
                bData.groundSlopeAngle = Vector3.Angle(hit.normal, Vector3.up);

                // Find the vector that represents our slope as well. 
                //  temp: basically, finds vector moving across hit surface 
                Vector3 temp = Vector3.Cross(hit.normal, Vector3.down);
                //  Now use this vector and the hit normal, to find the other vector moving up and down the hit surface
                bData.groundSlopeDir = Vector3.Cross(temp, hit.normal);

                // Now that's all fine and dandy, but on edges, corners, etc, we get angle values that we don't want.
                // To correct for this, let's do some raycasts. You could do more raycasts, and check for more
                // edge cases here. There are lots of situations that could pop up, so test and see what gives you trouble.

                // FIRST RAYCAST
                if (Physics.Raycast(origin + bData.rayOriginOffset1, Vector3.down, out var slopeHit1, bData.raycastLength))
                {
                    // Get angle of slope on hit normal
                    float angleOne = Vector3.Angle(slopeHit1.normal, Vector3.up);
                    //
                    // // 2ND RAYCAST
                    if (Physics.Raycast(origin + bData.rayOriginOffset2, Vector3.down, out var slopeHit2, bData.raycastLength))
                    {
                        // Get angle of slope of these two hit points.
                        float angleTwo = Vector3.Angle(slopeHit2.normal, Vector3.up);
                        // 3 collision points: Take the MEDIAN by sorting array and grabbing middle.
                        float[] tempArray = {bData.groundSlopeAngle, angleOne, angleTwo};
                        Array.Sort(tempArray);
                        bData.groundSlopeAngle = tempArray[1];
                    }
                    else
                    {
                        // 2 collision points (sphere and first raycast): AVERAGE the two
                        float average = (bData.groundSlopeAngle + angleOne) / 2;
                        bData.groundSlopeAngle = average;
                    }
                }
            }
            else
            {
                bData.groundSlopeAngle = 90;
                // bData.onGround = false;
                //TODO: CAST RAYS HERE FORWARD, BACKWARDS AND TO THE SIDES TO CHECK THE ACTUAL GROUND SLOPE DIR
                int raysHit = 0;
                Vector3 sum = Vector3.zero;

                if (Physics.Raycast(origin, tr.forward, out var slopeHitFwd, bData.raycastLength))
                {
                    sum += Vector3.Cross(Vector3.Cross(slopeHitFwd.normal, Vector3.down), slopeHitFwd.normal);
                    raysHit++;
                }
                if (Physics.Raycast(origin, -tr.forward, out var slopeHitBck, bData.raycastLength))
                {
                    sum += Vector3.Cross(Vector3.Cross(slopeHitBck.normal, Vector3.down), slopeHitFwd.normal);
                    raysHit++;
                }
                if (Physics.Raycast(origin, tr.right, out var slopeHitR, bData.raycastLength))
                {
                    sum += Vector3.Cross(Vector3.Cross(slopeHitR.normal, Vector3.down), slopeHitFwd.normal);
                    raysHit++;
                }
                if (Physics.Raycast(origin, -tr.right, out var slopeHitL, bData.raycastLength))
                {
                    sum += Vector3.Cross(Vector3.Cross(slopeHitL.normal, Vector3.down), slopeHitFwd.normal);
                    raysHit++;
                }

                if (raysHit > 0)
                    bData.groundSlopeDir = sum / raysHit;
                else
                    bData.onGround = false;
            }
        }
        
        

        public static void ConditionalsBiped(PlayerPhysicsController physicsController)
        {
            if (physicsController.ConditionalInputMovements == null) return;
            foreach (var conditionalInput in physicsController.ConditionalInputMovements.Where(conditionalInput => conditionalInput.Condition.ConditionValue))
            {
                SkillMovementData.ActualBodyVelocity += conditionalInput.ConditionalInputVector3 * ((conditionalInput.Force * (conditionalInput.ActionT / conditionalInput.ActionDuration)) * Time.fixedDeltaTime);

                if (conditionalInput.ActionT <= 0)
                {
                    conditionalInput.ActionT = 0;
                    physicsController.UsingConditional = false;
                    conditionalInput.Condition.ConditionValue = false;
                }
                else
                {
                    physicsController.UsingConditional = true;
                    conditionalInput.ActionT -= Time.fixedDeltaTime;
                }
            }
        }
    }
}