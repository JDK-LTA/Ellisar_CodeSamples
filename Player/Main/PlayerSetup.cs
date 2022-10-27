using System;
using Ellisar.EllisarAssets.Scripts.Player.Animations;
using JetBrains.Annotations;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Main
{
    [RequireComponent(typeof(PlayerController), typeof(PlayerPhysicsController), typeof(PlayerAnimationController))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerSetup : MonoBehaviour
    {

        [SerializeField] private Transform lowestPosition;
        private static object _charController;
        private static object _playerController;
        private static object _playerAnimationController;
        private static object _playerPhysicsController;

        public static CharacterController CharController => (CharacterController) _charController;

        public static PlayerController PlayerController
        {
            get => (PlayerController) _playerController;
            set => throw new NotImplementedException();
        }

        public static PlayerAnimationController PlayerAnimationController => (PlayerAnimationController) _playerAnimationController;
        
        public static PlayerPhysicsController PhysicsController => (PlayerPhysicsController) _playerPhysicsController;

        public Transform LowestPosition
        {
            get => lowestPosition;
            set => lowestPosition = value;
        }

        private void Awake()
        {
            SetVariable(ref _charController, typeof(CharacterController));
            SetVariable(ref _playerController, typeof(PlayerController));
            SetVariable(ref _playerAnimationController, typeof(PlayerAnimationController));
            SetVariable(ref _playerPhysicsController, typeof(PlayerPhysicsController));
        }

        private void SetVariable(ref object objectToSet, [NotNull] Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            objectToSet = GetComponentInChildren(type);
            objectToSet ??= gameObject.AddComponent(type);
        }
    }
}