using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.DialogueSystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DialogueSelector : MonoBehaviour
    {
        protected TextMeshProUGUI TextMeshProUGUI;

        [SerializeField] protected List<LocalizedDialog> localizedDialogs;
        [SerializeField, ReadOnly] protected DialogueDatabaseScriptableObject dialogueDatabase;
        [SerializeField, ReadOnly] protected DialogueData[] database;

        [SerializeField] private int dialogueIndex;

        [SerializeField] protected bool isVariant = false;
        [SerializeField] private bool selfUpdate = true;
        [SerializeField] protected bool nextIfNotAvailable = true;

        public int DialogueIndex
        {
            get
            {
                if (dialogueIndex >= dialogueDatabase.database.Count)
                {
                    Debug.LogError("Dialogue index on " + gameObject.name + " was out of range. Defaulted to " + (dialogueDatabase.database.Count - 1));
                    dialogueIndex = dialogueDatabase.database.Count - 1;
                }
                else if (dialogueIndex < 0)
                {
                    Debug.LogError("Dialogue index on " + gameObject.name + " was out of range. Defaulted to 0");
                    dialogueIndex = 0;
                }
                return dialogueIndex;
            }

            set
            {
                dialogueIndex = value;
                if (dialogueIndex >= dialogueDatabase.database.Count)
                {
                    Debug.LogError("Dialogue index on " + gameObject.name + " was out of range. Defaulted to 0");
                    dialogueIndex = 0;
                }
                else if (dialogueIndex < 0)
                {
                    Debug.LogError("Dialogue index on " + gameObject.name + " was out of range. Defaulted to " + (dialogueDatabase.database.Count - 1));
                    dialogueIndex = dialogueDatabase.database.Count - 1;
                }

                if (selfUpdate) UpdateText();
            }
        }

        protected virtual void Awake()
        {
            StartDatabase();
        }

        private void StartDatabase()
        {
            database = new DialogueData[dialogueDatabase.database.Count];
            for (var i = 0; i < dialogueDatabase.database.Count; i++)
            {
                var t = dialogueDatabase.database[i];
                database[i] = new DialogueData
                {
                    availableByDefault = t.availableByDefault,
                    showVariant = isVariant,
                    useVariant = t.useVariant,
                    dialogueText = t.dialogueText,
                    dialogueTextVariant = t.dialogueTextVariant
                };
            }
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
            TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
            UpdateLanguage();
        }

        public virtual void UpdateLanguage()
        {
            if (localizedDialogs.Count > 0)
            {
                var aux = localizedDialogs.Find(x => x.language == LocalizationManager.Instance.ActualLanguage);

                if (aux != null)
                {
                    dialogueDatabase = aux.database;

                    if (!isVariant)
                        TextMeshProUGUI.font = LocalizationManager.Instance.ActualLanguage == Language.日本語
                             ? LocalizationManager.Instance.JapaneseFont
                             : LocalizationManager.Instance.StdFont;
                }

                StartDatabase();
            }
        }

        public void SetDialogueIndexNoUpdate(int value)
        {
            dialogueIndex = value;
        }

        [Button("Set text"), ShowIf("@UnityEngine.Application.isPlaying && TextMeshProUGUI != null")]
        public virtual void UpdateText()
        {
            if (!isVariant || !database[DialogueIndex].useVariant)
            {
                while (true)
                {
                    if (!ConditionsForNull())
                        TextMeshProUGUI.text = database[DialogueIndex].dialogueText;
                    else if (database.Length > 1 && nextIfNotAvailable)
                    {
                        DialogueIndexPlusPlus();
                        continue;
                    }
                    else
                        TextMeshProUGUI.text = "";

                    break;
                }
            }

            else
            {
                while (true)
                {
                    if (!ConditionsForNull())
                        TextMeshProUGUI.text = database[DialogueIndex].dialogueTextVariant;
                    else if (database.Length > 1 && nextIfNotAvailable)
                    {
                        DialogueIndexPlusPlus();
                        continue;
                    }
                    else
                        TextMeshProUGUI.text = "";

                    break;
                }
            }
        }

        protected bool ConditionsForNull()
        {
            return (TextMeshProUGUI == null || dialogueDatabase == null || database == null ||
                    database.Length <= DialogueIndex || DialogueIndex < 0 ||
                    !database.Any() || !database[DialogueIndex].availableByDefault);
        }

        public void DialogueIndexPlusPlus(bool plusPlus = true)
        {
            if (plusPlus) DialogueIndex++;
            else DialogueIndex--;
        }

    }

    [Serializable]
    public class LocalizedDialog
    {
        public Language language;
        public DialogueDatabaseScriptableObject database;
    }
}
