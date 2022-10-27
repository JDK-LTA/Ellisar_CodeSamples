using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Audio
{
    [RequireComponent(typeof(SoundEmitter))]
    public class EmitOnEnable : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<SoundEmitter>().Post();       
        }
    }
}
