using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.LevelMechanics
{
    public class GeiserUp : MonoBehaviour
    {
        [Title("Geiser Specific")]
        [SerializeField] private float geiserForce = 15f;

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == 3)
            {
                var f = geiserForce;
                if (PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Fly)
                    f *= 2;
                SkillMovementData.ActualBodyVelocity += transform.up * (f * Time.fixedDeltaTime);
            }
        }
    }
}