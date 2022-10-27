using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.DialogueSystem
{
    public class LocalizationManager : MonoBehaviour
    {
        public static LocalizationManager Instance;
        
        [SerializeField] private Language actualLanguage = Language.English;
        [SerializeField] private TextMeshProUGUI menuTextLanguage;
        [SerializeField] private TMP_FontAsset japaneseFont, stdFont;
        [SerializeField, ReadOnly] private List<Localizer> localizers;
        [SerializeField, ReadOnly] private List<AnimatedDialogueSelector> localizedDialogues;

        public delegate void MyLocalizationDelegate(Language lang);

        public static event MyLocalizationDelegate UpdateTexts;

        public Language ActualLanguage
        {
            get => actualLanguage;
            set
            {
                if (value > Language.Galego)
                    value = Language.English;
                else if (value < Language.English)
                    value = Language.Galego;
                
                actualLanguage = value;
                UpdateLocalization();
            }
        }

        public List<Localizer> Localizers => localizers;
        public List<AnimatedDialogueSelector> LocalizedDialogues => localizedDialogues;

        public TMP_FontAsset JapaneseFont => japaneseFont;
        public TMP_FontAsset StdFont => stdFont;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            // UpdateLocalization();
            StartCoroutine(LateLocalizationStart());
        }

        private IEnumerator LateLocalizationStart()
        {
            yield return new WaitForEndOfFrame();

            var aux = Application.systemLanguage switch
            {
                SystemLanguage.English => Language.English,
                SystemLanguage.Spanish => Language.Español,
                SystemLanguage.French => Language.Français,
                SystemLanguage.German => Language.Deutch,
                SystemLanguage.Danish => Language.Dansk,
                SystemLanguage.Russian => Language.Pусский,
                SystemLanguage.Portuguese => Language.Português,
                SystemLanguage.Swedish => Language.Svenska,
                SystemLanguage.Italian => Language.Italiano,
                SystemLanguage.Japanese => Language.日本語,
                SystemLanguage.Basque => Language.Euskera,
                SystemLanguage.Catalan => Language.Català,
                _ => Language.English
            };

            ActualLanguage = aux;
        }

        public void UpdateLocalization()
        {
            if(localizers.Count > 0)
                foreach (var loc in localizers)
                {
                    loc.UpdateLanguage();
                }
            
            if(localizedDialogues.Count > 0)
                foreach (var locDia in LocalizedDialogues)
                {
                    locDia.UpdateLanguage();
                }

            if(menuTextLanguage)
                menuTextLanguage.text = actualLanguage.ToString();

            UpdateTexts?.Invoke(actualLanguage);
        }

        public void NextLanguage()
        {
            ActualLanguage++;
        }

        public void PreviousLanguage()
        {
            ActualLanguage--;
        }
    }

    [Serializable]
    public class LocalizedText
    {
        public Language language;
        public string text;
    }

    [Serializable]
    public enum Language
    {
        English,
        Español,
        Català,
        Euskera,
        Français,
        Deutch,
        Italiano,
        Português,
        Dansk,
        Svenska,
        Pусский,
        日本語,
        Galego
    }
}
