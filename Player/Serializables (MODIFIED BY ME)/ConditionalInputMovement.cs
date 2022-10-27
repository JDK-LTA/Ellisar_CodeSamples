using System;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Serializables
{
    [Serializable]
    public class ConditionalInputMovement
    {
        [SerializeField] private Condition condition;
        [SerializeField] private DirectionInput direction;
        [SerializeField] private float actionDuration;
        [SerializeField] private float actionT;
        [SerializeField] private float force;
        [SerializeField] private Vector3 conditionalInputVector3;

        public Condition Condition
        {
            get => condition;
            set => condition = value;
        }

        public DirectionInput Direction
        {
            get => direction;
            set => direction = value;
        }

        public float ActionDuration
        {
            get => actionDuration;
            set => actionDuration = value;
        }

        public float ActionT
        {
            get => actionT;
            set => actionT = value;
        }

        public float Force
        {
            get => force;
            set => force = value;
        }

        public Vector3 ConditionalInputVector3
        {
            get => conditionalInputVector3;
            set => conditionalInputVector3 = value;
        }

        public ConditionalInputMovement(Condition condition, DirectionInput directionInput, float actionDuration, float force)
        {
            Condition = condition;
            Direction = directionInput;
            ActionDuration = actionDuration;
            Force = force;
        }
    }
}