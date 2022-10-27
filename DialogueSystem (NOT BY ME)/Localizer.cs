using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.DialogueSystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Localizer : MonoBehaviour
    {
        [SerializeField] private List<LocalizedText> localizationList;

        public TextMeshProUGUI Tmp { get; private set; }

        public List<LocalizedText> LocalizationList => localizationList;

        private void Start()
        {
            Tmp = GetComponent<TextMeshProUGUI>();
            LocalizationManager.Instance.Localizers.Add(this);

            UpdateLanguage();
        }

        public void UpdateLanguage()
        {
            var aux = localizationList.Find(x => x.language == LocalizationManager.Instance.ActualLanguage);
            if (aux != null)
            {
                Tmp.text = aux.text;

                Tmp.font = LocalizationManager.Instance.ActualLanguage == Language.日本語
                    ? LocalizationManager.Instance.JapaneseFont
                    : LocalizationManager.Instance.StdFont;
            }
        }
    }
}
