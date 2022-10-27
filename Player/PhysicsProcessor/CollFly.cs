using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.PhysicsProcessor
{
    public class CollFly : MonoBehaviour
    {
        [SerializeField] private LayerMask layersToCollideWith = -1;
        private void OnCollisionEnter(Collision other)
        {
            if ((layersToCollideWith.value & (1 << other.transform.gameObject.layer)) > 0)
            {
                if(Vector3.Angle( other.contacts[0].normal, Vector3.up) > PlayerSetup.PhysicsController.CharController.slopeLimit)
                    PhysicsFly.FlyPushback(PlayerSetup.PhysicsController.FlyData, other.contacts[0].normal);
                else
                    PlayerSetup.PhysicsController.TransformFlyToBipedOnGround();
            }
        }
    }
}
