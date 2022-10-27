using Ellisar.EllisarAssets.Scripts.Player.Main;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs.SeaAngels
{
    public class PlayerFollower : MonoBehaviour
    {
        private Transform _player;
        
        // Start is called before the first frame update
        void Start()
        {
            _player = PlayerSetup.CharController.transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = _player.position;
            transform.rotation = _player.rotation;
        }
    }
}
