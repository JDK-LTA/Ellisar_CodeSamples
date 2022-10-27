using AK.Wwise;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Audio
{
    public class CaveMusicStateManager : MonoBehaviour
    {
        [SerializeField] private State deactivated, activated, none;
        private bool _activated;

        public bool Activated
        {
            get => _activated;
            set
            {
                _activated = value;
                InCave();
            }
        }

        public void InCave()
        {
            var st = Activated ? activated : deactivated;

            AkSoundEngine.SetState(st.GroupId, st.Id);
        }

        public void OutOfCave()
        {
            AkSoundEngine.SetState(none.GroupId, none.Id);
        }
    }
}
