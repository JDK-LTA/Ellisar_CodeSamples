using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.LevelMechanics
{
    public class PlatformTrigger : TriggerEnterExit
    {
        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = PlayerSetup.CharController.transform;
        }


        protected override void TriggerAction()
        {
            _playerTransform.SetParent(transform, true);
        }

        protected override void TriggerExitAction()
        {
            _playerTransform.SetParent(null, true);
        }
    }
}
