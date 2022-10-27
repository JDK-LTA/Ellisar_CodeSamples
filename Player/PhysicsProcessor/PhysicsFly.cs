using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.PhysicsProcessor
{
    public static class PhysicsFly
    {

        public static void SetFlySpeedAndAcceleration(FlyData flyData)
        {
            if (!flyData.hasFlapped) //we are not holding fly, slow down
            {
                flyData.targetSpeed = flyData.flyingMinSpeed;
                if (SkillMovementData.ActualBodySpeed > flyData.flyingMinSpeed)
                    flyData.actualAcceleration = flyData.slowDownAcceleration * flyData.flyingAdjustmentLerp;
                else
                    flyData.actualAcceleration = flyData.movementAcceleration * flyData.flyingAdjustmentLerp;
            }
            else
            {
                flyData.targetSpeed = flyData.maxForwardSpeed;
                flyData.actualAcceleration = flyData.flapSlowdown * flyData.flyingAdjustmentLerp;
            }

            if (SkillMovementData.ActualBodySpeed > flyData.maxForwardSpeed) //we are over out max speed, slow down slower
            {
                flyData.actualAcceleration *= 0.8f;
            }

            if (SkillMovementData.ActualBodyVelocity.y < flyData.flyingLowerLimit) //we are flying down! boost speed
            {
                flyData.targetSpeed += (flyData.flyingVelocityGain * (SkillMovementData.ActualBodyVelocity.y * -0.5f));
            }
            else if (SkillMovementData.ActualBodyVelocity.y > flyData.flyingUpperLimit) //we are flying up! reduce speed
            {
                flyData.targetSpeed -= (flyData.flyingVelocityLoss * SkillMovementData.ActualBodyVelocity.y);
                SkillMovementData.ActualBodySpeed -= (flyData.flyingVelocityLoss * SkillMovementData.ActualBodyVelocity.y) * Time.fixedDeltaTime;
            }

            flyData.targetSpeed = Mathf.Clamp(flyData.targetSpeed, -flyData.speedClamp, flyData.speedClamp);

            float targetTurnForce;
            // if (transform.eulerAngles.x > 270)
            //     targetTurnForce = Mathf.Lerp(flyData.turnForceByVelocityMin, flyData.turnForceByVelocityMax, flyData.actualSpeed);
            // else
            if (!flyData.confusion)
            {
                targetTurnForce = Mathf.Lerp(flyData.turnForceByVelocityMin, flyData.turnForceByVelocityMax, 1 - SkillMovementData.ActualBodyVelocity.magnitude / flyData.targetSpeed);
                flyData.actualTurnForce = Mathf.Lerp(flyData.actualTurnForce, targetTurnForce, flyData.turnForceAdjustmentSpeed * Time.fixedDeltaTime);
            }
            else
                flyData.actualTurnForce = flyData.turnForceByVelocityMin;

            SkillMovementData.ActualBodySpeed = Mathf.Lerp(SkillMovementData.ActualBodySpeed, flyData.targetSpeed, flyData.actualAcceleration * Time.fixedDeltaTime);
        }

        public static void SetForwardDirectionFly(FlyData flyData, Transform transform)
        {
            var invertY = PlayerSetup.PlayerController.YInvertedOnFlight ? -1 : 1;

            var xMove = PlayerPhysicsController.MovementInputVector3.x;
            var zMove = PlayerPhysicsController.MovementInputVector3.z * invertY;

            if (flyData.confusion && flyData.isConfused)
            {
                xMove = flyData.confusionAffectsBothAxis ? 0 : xMove / 2;
                zMove = 0;
            }

            flyData.moveDirection = new Vector3(xMove, 0f, zMove);

            var targetSpeedUpDown = Mathf.Lerp(-flyData.turnSpeedUpDown, flyData.turnSpeedUpDown, (flyData.moveDirection.z + 1) / 2);
            var targetSpeedSides = Mathf.Lerp(-flyData.turnSpeedSides, flyData.turnSpeedSides, (flyData.moveDirection.x + 1) / 2);
            var eul = transform.eulerAngles;

            flyData.actualTurnSpeedUpDown = Mathf.Lerp(flyData.actualTurnSpeedUpDown, targetSpeedUpDown, flyData.turnAccelerationUpDown * Time.fixedDeltaTime);
            if ((flyData.actualTurnSpeedUpDown < 0.1f && flyData.actualTurnSpeedUpDown > -0.1f) || 
                flyData.lockXRotation && ((eul.x > flyData.turnUpMaxAngle && eul.x < 180) ||  (eul.x < 360 + flyData.turnDownMinAngle && eul.x > 180)))
                flyData.actualTurnSpeedUpDown = 0;

            flyData.actualTurnSpeedSides = Mathf.Lerp(flyData.actualTurnSpeedSides, targetSpeedSides, flyData.turnAccelerationSides * Time.fixedDeltaTime);
            if (flyData.actualTurnSpeedSides < 0.1f && flyData.actualTurnSpeedSides > -0.1f)
                flyData.actualTurnSpeedSides = 0;

            flyData.forwardAngle += flyData.actualTurnSpeedSides * Time.fixedDeltaTime;
            flyData.upDownAngle -= flyData.actualTurnSpeedUpDown * Time.fixedDeltaTime;
            flyData.upDownAngle = Mathf.Clamp(flyData.upDownAngle, -75,75);
            Vector3 newForward = Quaternion.AngleAxis(flyData.forwardAngle, Vector3.up) * Vector3.forward;
            newForward = Quaternion.AngleAxis(flyData.upDownAngle, Vector3.Cross(newForward, Vector3.up)) * newForward;
            transform.rotation = Quaternion.LookRotation(newForward, Vector3.up);
            /*
            transform.Rotate(new Vector3(
                flyData.actualTurnSpeedUpDown * Time.fixedDeltaTime,
                flyData.actualTurnSpeedSides * Time.fixedDeltaTime,
                flyData.actualTurnSpeedSides * Time.fixedDeltaTime / 10));*/

            // if (flyData.lockXRotation)
            // {
            //     flyData.eulerRot = eul;
            //     if (eul.x > 89 && eul.x < 180)
            //         transform.eulerAngles = new Vector3(89, eul.y, eul.z);
            //     if (eul.x < 271 && eul.x > 180)
            //         transform.eulerAngles = new Vector3(271, eul.y, eul.z);
            // }
        }

        public static void SetFlyVelocity(FlyData flyData, Transform transform)
        {
            var flyLerpSpd = flyData.flyingAdjustmentSpeed * flyData.flyingAdjustmentLerp;

            if (flyData.flyingTimer < flyData.glideTime * 0.7f)
            {
                var slerpRot = Quaternion.LookRotation(SkillMovementData.ActualBodyVelocity.normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, slerpRot, flyData.actualTurnForce * 0.05f * Time.fixedDeltaTime);
            }

            flyData.playerVelocityTarget = transform.forward * SkillMovementData.ActualBodySpeed;

            if (flyData.confusion && !flyData.isConfused)
                flyData.actualGravityAmt = Mathf.Lerp(flyData.actualGravityAmt, flyData.standardGravityAmt, flyData.gravityAdjustmentSpeed * Time.fixedDeltaTime);
            else
                flyData.actualGravityAmt = Mathf.Lerp(flyData.actualGravityAmt, flyData.confusedGravityAmt, flyData.gravityAdjustmentSpeed * Time.fixedDeltaTime);

            flyData.playerVelocityTarget -= Vector3.up * flyData.actualGravityAmt;
            SkillMovementData.ActualBodyVelocity = Vector3.Lerp(SkillMovementData.ActualBodyVelocity, flyData.playerVelocityTarget, Time.fixedDeltaTime * flyLerpSpd);
        }

        public static void FlyConfusionTimer(FlyData flyData)
        {
            if (flyData.confusion)
            {
                if (!flyData.isConfused)
                {
                    if (SkillMovementData.ActualBodyVelocity.magnitude < flyData.confuseVelocityMagnitudeCut)
                    {
                        flyData.confuseT += Time.deltaTime;
                        if (flyData.confuseT >= flyData.timeToConfuse)
                        {
                            flyData.isConfused = true;
                        }
                    }
                    else
                    {
                        flyData.confuseT = 0;
                    }
                }
                else
                {
                    flyData.confuseControlT += Time.deltaTime;
                    if (flyData.confuseControlT >= flyData.timeOfConfusion)
                    {
                        flyData.isConfused = false;
                        flyData.confuseControlT = 0;
                        flyData.confuseT = 0;
                    }
                }
            }
        }

        public static void FlyZRecentering(FlyData flyData, float xInput, Transform transform)
        {
            if (!flyData.zAxisRecentering) return;
            
            if (Mathf.Abs(xInput) <= flyData.minRotationInputThreshold && transform.eulerAngles.z != 0)
            {
                if (!flyData.recentering)
                {
                    flyData.waitToRecenterT += Time.fixedDeltaTime;
                    if (flyData.waitToRecenterT >= flyData.waitTime)
                    {
                        flyData.waitToRecenterT = 0;
                        flyData.recentering = true;
                        flyData.recenterOriginalRot = transform.eulerAngles;
                    }
                }
                else
                {
                    flyData.recenterT += Time.fixedDeltaTime;

                    var rot = transform.eulerAngles;
                    var targetZ = rot.z > 180 ? 360 : 0;

                    var tLerp = flyData.recenterCurve.Evaluate(flyData.recenterT / flyData.timeToRecenter);

                    transform.rotation = Quaternion.SlerpUnclamped(Quaternion.Euler(flyData.recenterOriginalRot), 
                        Quaternion.Euler(new Vector3(rot.x, rot.y, targetZ)), tLerp);

                    if (flyData.recenterT >= flyData.timeToRecenter)
                    {
                        flyData.recenterT = 0;
                        flyData.recentering = false;
                        transform.eulerAngles = new Vector3(rot.x, rot.y, 0);
                    }
                }
            }
            else
            {
                flyData.recentering = false;
                flyData.waitToRecenterT = 0;
                flyData.recenterT = 0;
            }
        }

        public static void FlyPushback(FlyData flyData, Vector3 normalDir)
        {
            if(!flyData.canBeStunned) return;
            
            //TODO: Guardar vector velocidad (V). Coger normal del muro (N). V_actual a 0. Vector a pasar: (N + dirV).normalize * pushBackForce
            
            flyData.isConfused = SkillMovementData.ActualBodyVelocity.magnitude > flyData.minSpeedToStun;

            var dirV = SkillMovementData.ActualBodyVelocity.normalized;
            var newDir = (dirV + normalDir).normalized;
            var mag = SkillMovementData.ActualBodyVelocity.magnitude;

            var incidenceAngle = Vector3.Angle(SkillMovementData.ActualBodyVelocity, normalDir);

            SkillMovementData.ActualBodyVelocity = newDir * Mathf.Lerp(
                flyData.minMaxPushbackForce.x,flyData.minMaxPushbackForce.y,
                mag / flyData.maxSpeedToStun);
        }
        
        public static void Flap(FlyData flyData)
        {
            if (flyData.hasFlapped || PlayerPhysicsController.ActualActionsAmount <= 0) return;
            
            SkillMovementData.ActualBodySpeed += flyData.flapForce;
            // SkillMovementData.ActualBodyVelocity += transform.up * flyData.flapUpForce;
            
            flyData.hasFlapped = true;
            PlayerPhysicsController.ActualActionsAmount--;
            PlayerSetup.PlayerAnimationController.TriggerFlap();
        }

        public static void FlapTimer(FlyData flyData)
        {
            if (PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Fly)
            {
                if (!flyData.hasFlapped) return;
                flyData.flapT += Time.deltaTime;
                if (!(flyData.flapT >= flyData.flapTime)) return;
                flyData.flapT = 0;
                flyData.hasFlapped = false;
            }
            else
            {
                flyData.flapT = 0;
                flyData.hasFlapped = false;
            }
        }
    }
}
