using System;
using Ellisar.EllisarAssets.Scripts.Enums;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Serializables
{
    [Serializable]
    public class DirectionInput
    {
        public readonly MovementTypeEnum MovementType = MovementTypeEnum.OneAxis;
        public readonly CompositeTypeEnum CompositeType = CompositeTypeEnum.TwoAxis;
        public readonly CompositeTwoAxisTypeEnum CompositeTwoAxisType = CompositeTwoAxisTypeEnum.RightForward;
        public readonly OneAxisTypeEnum OneAxisType = OneAxisTypeEnum.Forward;
        
        public DirectionInput()
        {
        }

        public DirectionInput(MovementTypeEnum movementType, CompositeTypeEnum compositeType,
            CompositeTwoAxisTypeEnum compositeTwoAxisType, OneAxisTypeEnum oneAxisType)
        {
            MovementType = movementType;
            CompositeType = compositeType;
            CompositeTwoAxisType = compositeTwoAxisType;
            OneAxisType = oneAxisType;
        }

        public static Vector3 DirectionInputToVector(DirectionInput directionInput)
        {
            var vector = directionInput.MovementType switch
            {
                MovementTypeEnum.Composite => directionInput.CompositeType switch
                {
                    CompositeTypeEnum.TwoAxis => directionInput.CompositeTwoAxisType switch
                    {
                        CompositeTwoAxisTypeEnum.RightForward => Vector3.right + Vector3.forward,
                        CompositeTwoAxisTypeEnum.RightUp => Vector3.right + Vector3.up,
                        _ => throw new ArgumentOutOfRangeException()
                    },
                    CompositeTypeEnum.AllAxis => Vector3.right + Vector3.up + Vector3.forward,
                    _ => throw new ArgumentOutOfRangeException()
                },
                MovementTypeEnum.OneAxis => directionInput.OneAxisType switch
                {
                    OneAxisTypeEnum.Right => Vector3.right,
                    OneAxisTypeEnum.Up => Vector3.up,
                    OneAxisTypeEnum.Forward => Vector3.forward,
                    _ => throw new ArgumentOutOfRangeException()
                },
                MovementTypeEnum.Modifier => Vector3.zero,
                _ => throw new ArgumentOutOfRangeException()
            };

            return vector;
        }

        public static Vector3 DirectionInputToVector(DirectionInput directionInput, Vector3 additiveVector)
        {
            return additiveVector + DirectionInputToVector(directionInput);
        }
    }
}