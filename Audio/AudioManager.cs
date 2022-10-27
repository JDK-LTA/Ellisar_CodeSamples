using System;
using AK.Wwise;
using Ellisar.EllisarAssets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;
using Event = AK.Wwise.Event;

namespace Ellisar.EllisarAssets.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
    
        [SerializeField] private Event _event;
        [SerializeField] private State firstState;
        [SerializeField, ReadOnly] private State _state;
        [SerializeField, ReadOnly] private State _playerState;
    
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            // _event.Post(gameObject);
            // _state.SetValue();
            // _playerState.SetValue();

            AkSoundEngine.SetState("Area3", "None");
            AkSoundEngine.SetState(firstState.GroupId, firstState.Id);
            StartStopMusic(true);
            SetPlayerLayer(PlayerModeState.Biped);
        }

        public void PauseMusic()
        {
            AkSoundEngine.Suspend();
        }
        public void ResumeMusic()
        {
            AkSoundEngine.WakeupFromSuspend();
        }

        public void StartStopMusic(bool start)
        {
            if (start)
                _event.Post(gameObject);
            else
                _event.Stop(gameObject);
        }

        public void SetPlayerLayer(PlayerModeState mode)
        {
            switch (mode)
            {
                case PlayerModeState.Biped:
                    AkSoundEngine.SetState("ActiveAbility", "Bipedo");
                    break;
                case PlayerModeState.Fly:
                    AkSoundEngine.SetState("ActiveAbility", "Volador");
                    break;
                case PlayerModeState.Agile:
                    AkSoundEngine.SetState("ActiveAbility", "Agil");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        public void SetAreaLayer(string areaName)
        {
            AkSoundEngine.SetState("AreaLoops", areaName);
        }

        public void SetAreaLayer(State state)
        {
            AkSoundEngine.SetState(state.GroupId, state.Id);
        }

        public void FirstState()
        {
            AkSoundEngine.SetState("AreaLoops", firstState.Name);
        }
    }
}
