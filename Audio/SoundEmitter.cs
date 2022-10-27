using UnityEngine;
using Event = AK.Wwise.Event;

namespace Ellisar.EllisarAssets.Scripts.Audio
{
    public class SoundEmitter : MonoBehaviour
    {
        [SerializeField] private Event audioEvent;
        
        public virtual void Post()
        {
            // Debug.Log(gameObject.name + " Play");
            audioEvent?.Post(gameObject);
        }

        public void Stop()
        {
            // Debug.Log(gameObject.name + " Stop");
            audioEvent?.Stop(gameObject);
        }
    }
}
