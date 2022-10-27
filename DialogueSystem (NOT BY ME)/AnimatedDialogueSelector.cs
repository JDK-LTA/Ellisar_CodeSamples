using Febucci.UI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.DialogueSystem
{
    [RequireComponent(typeof(TextAnimatorPlayer), typeof(TextAnimator), typeof(TextMeshProUGUI))]
    public class AnimatedDialogueSelector : DialogueSelector
    {
        private TextAnimatorPlayer _textAnimatorPlayer;

        protected override void Awake()
        {
            base.Awake();
            _textAnimatorPlayer = GetComponent<TextAnimatorPlayer>();
            ResetText();
        }

        protected override void Start()
        {
            LocalizationManager.Instance.LocalizedDialogues.Add(this);
            base.Start();
            ResetText();
        }

        public void ResetText()
        {
            _textAnimatorPlayer.ShowText("");
        }

        public override void UpdateLanguage()
        {
            base.UpdateLanguage();

            if (TextMeshProUGUI.text != "")
            {
                if (!isVariant && !_textAnimatorPlayer.textAnimator.allLettersShown)
                {
                    _textAnimatorPlayer.SkipTypewriter();
                    ResetText();
                    UpdateText();
                    _textAnimatorPlayer.SkipTypewriter();
                }
                else if (!isVariant)
                {
                    ResetText();
                    UpdateText();
                    _textAnimatorPlayer.SkipTypewriter();
                }
            }
        }

        [Button("Play text"), ShowIf("@UnityEngine.Application.isPlaying && _textAnimatorPlayer != null && TextMeshProUGUI != null")]
        public override void UpdateText()
        {
            if (!isVariant || !database[DialogueIndex].useVariant)
            {
                while (true)
                {
                    if (!ConditionsForNull())
                        _textAnimatorPlayer.ShowText(database[DialogueIndex].dialogueText);
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
                        _textAnimatorPlayer.ShowText(database[DialogueIndex].dialogueTextVariant);
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
    }
}
