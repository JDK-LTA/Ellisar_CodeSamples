using Ellisar.EllisarAssets.Scripts.Player.Main;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.LevelMechanics.KnifeSickle
{
    public class UseKnifeTrigger : TriggerEnter
    {
        [Title("Knife Specific")]
        [SerializeField] private GameObject objectToDestroy;
        
        protected override void TriggerAction()
        {
            if (!PlayerSetup.PhysicsController.HasKnife) return;
            
            PlayerSetup.PhysicsController.HasKnife = false;
            // UI.UIManager.Instance.SetKnifeUI(false);
            Destroy(objectToDestroy);
            Destroy(gameObject);
        }
    }
}
