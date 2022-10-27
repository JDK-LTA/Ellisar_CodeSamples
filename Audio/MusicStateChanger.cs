using AK.Wwise;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Audio
{
    public class MusicStateChanger : MonoBehaviour
    {
        [SerializeField] private State state;

        public void StateChange()
        {
            AudioManager.Instance.SetAreaLayer(state);
            // AudioManager.Instance.StartStopMusic(true);
        }
    }
}
