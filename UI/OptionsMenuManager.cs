using System.Globalization;
using TMPro;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class OptionsMenuManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI masterHandleNumber, musicHandleNumber, sfxHandleNumber;
    
        public void SetMasterVolume(float value)
        {
            AkSoundEngine.SetRTPCValue("MasterVolume", value);
            if(masterHandleNumber) masterHandleNumber.text = value.ToString(CultureInfo.InvariantCulture);
        }
        public void SetMusicVolume(float value)
        {
            AkSoundEngine.SetRTPCValue("MusicVolume", value);
            if(musicHandleNumber) musicHandleNumber.text = value.ToString(CultureInfo.InvariantCulture);
        }
        public void SetSfxVolume(float value)
        {
            AkSoundEngine.SetRTPCValue("SFXVolume", value);
            if(sfxHandleNumber) sfxHandleNumber.text = value.ToString(CultureInfo.InvariantCulture);
        }
    
    }
}