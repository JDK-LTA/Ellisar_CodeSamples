using System;
using Ellisar.EllisarAssets.Scripts.Player.Animations;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Animations
{
    public class AnimationBoolChanger : TriggerEnterExit
    {
        [Title("Animation Specific")]
        [SerializeField] private string animatorBoolName;
        [SerializeField] private bool toggleBackWhenExit = true;
        [SerializeField] private bool value = true;

        private PlayerAnimationController _animationController;
        private void Start()
        {
            _animationController = PlayerSetup.PlayerAnimationController;
            
        }

        protected override void TriggerAction()
        {
            SetAnimBool();
        }

        public void SetAnimBool()
        {
            _animationController.SetBipedAnimBool(animatorBoolName, value);
        }

        protected override void TriggerExitAction()
        {
            if (toggleBackWhenExit)
                _animationController.SetBipedAnimBool(animatorBoolName, !value);
        }
    }
}
