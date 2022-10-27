using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas
{
    [Serializable]
    public class SkillInteractionData : SkillData
    {
        public SkillInteractionData() : base()
        {
        }

        public SkillInteractionData(InputAction inputAction) : base(inputAction)
        {
        }

        [SerializeField] private UnityEvent interactionEnterEvent;

        public UnityEvent InteractionEnterEvent
        {
            get => interactionEnterEvent;
            set => interactionEnterEvent = value;
        }


        [SerializeField] private UnityEvent interactionExitEvent;

        public UnityEvent InteractionExitEvent => interactionExitEvent;
    }
}