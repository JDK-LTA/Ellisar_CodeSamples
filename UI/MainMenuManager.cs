using System;
using System.Collections.Generic;
using Ellisar.EllisarAssets.Scripts.DialogueSystem;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Samples.RebindUI;
using UnityEngine.UI;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager Instance;

        [SerializeField] private GameObject optionsMenu, mainMenuButtons, backButton, playButton, continueButton, jumpRemapController, jumpRemapKeyboard;
        [SerializeField] private UnityEvent enable, disable, firstDisable, firstEnable, changeControlSchemeToKeyboard, changeControlSchemeToGamepad, setEventSystemToControlRemapButton,
            standardControl, oneHandControlL, oneHandControlR;
        [SerializeField] private CanvasGroup controlChangerPanel;
        [SerializeField, ReadOnly] private List<SerializedResolutions> serializedResolutions;
        [SerializeField, ReadOnly] private FullscreenMode fullscreenMode = FullscreenMode.Fullscreen;
        [SerializeField] private TextMeshProUGUI resolutionText, screenmodeText;
        [SerializeField] private List<LocalizedText> screenmodeFullscreen, screenmodeBorderless, screenmodeWindowed;
        [SerializeField] private TextMeshProUGUI controlTypeText;
        [SerializeField] private List<LocalizedText> standardControlType, oneHandLControlType, oneHandRControlType;
        [SerializeField, ReadOnly] private int qualityIndex;
        [SerializeField] private TextMeshProUGUI qualityText;
        [SerializeField] private List<LocalizedText> highText, mediumText, lowText;
        private string _fullscreenActText, _borderlessActText, _windowedActText;
        private string _standardCTActText, _1handLActText, _1handRActText;
        private string _highActText, _mediumActText, _lowActText;
        private Resolution[] _resolutions;
        private int _resolutionIndex = 0;
        private bool _first = true;
        private GameObject _sel;
        private GameObject _playSelect;
        private GameObject _actJumpRemap;
        private string _lastControlScheme = "";


        public bool GameStarted { get; set; } = false;

        private int _controlType = 0;

        public int ControlType
        {
            get => _controlType;
            set
            {
                _controlType = value;
                UpdateControlTypeText(LocalizationManager.Instance.ActualLanguage);
            }
        }

        public int ResolutionIndex
        {
            get => _resolutionIndex;
            set
            {
                if (value >= serializedResolutions.Count)
                    value = 0;
                else if (value < 0)
                    value = serializedResolutions.Count - 1;

                _resolutionIndex = value;
                UpdateScreen();
            }
        }

        public int QualityIndex
        {
            get => qualityIndex;
            set
            {
                if (value > 2)
                    value = 0;
                if (value < 0)
                    value = 2;

                qualityIndex = value;

                QualitySettings.SetQualityLevel(qualityIndex);

                qualityText.text = QualityIndex switch
                {
                    0 => _lowActText,
                    1 => _mediumActText,
                    2 => _highActText,
                    _ => throw new ArgumentOutOfRangeException(nameof(QualityIndex), QualityIndex, null)
                };
            }
        }

        public void QualityMinus() { QualityIndex--; }
        public void QualityPlus() { QualityIndex++; }

        public void UpdateQualityText(Language lang)
        {
            var hi = highText.Find(x => x.language == lang);
            if (hi != null)
                _highActText = hi.text;

            var me = mediumText.Find(x => x.language == lang);
            if (me != null)
                _mediumActText = me.text;

            var lo = lowText.Find(x => x.language == lang);
            if (lo != null)
                _lowActText = lo.text;

            qualityText.text = QualityIndex switch
            {
                0 => _lowActText,
                1 => _mediumActText,
                2 => _highActText,
                _ => throw new ArgumentOutOfRangeException(nameof(QualityIndex), QualityIndex, null)
            };
        }

        public void UpdateControlTypeText(Language lang)
        {
            var st = standardControlType.Find(x => x.language == lang);
            if (st != null)
                _standardCTActText = st.text;

            var hl = oneHandLControlType.Find(x => x.language == lang);
            if (hl != null)
                _1handLActText = hl.text;

            var hr = oneHandRControlType.Find(x => x.language == lang);
            if (hr != null)
                _1handRActText = hr.text;

            controlTypeText.text = ControlType switch
            {
                0 => _standardCTActText,
                1 => _1handLActText,
                2 => _1handRActText,
                _ => throw new ArgumentOutOfRangeException(nameof(ControlType), ControlType, null)
            };

            switch (ControlType)
            {
                case 0:
                    standardControl?.Invoke();
                    break;
                case 1:
                    oneHandControlL?.Invoke();
                    break;
                case 2:
                    oneHandControlR?.Invoke();
                    break;
                default:
                    break;
            }
        }

        public void UpdateScreenmodeTexts(Language lang)
        {
            var fs = screenmodeFullscreen.Find(x => x.language == lang);
            if (fs != null)
                _fullscreenActText = fs.text;

            var bl = screenmodeBorderless.Find(x => x.language == lang);
            if (bl != null)
                _borderlessActText = bl.text;

            var wi = screenmodeWindowed.Find(x => x.language == lang);
            if (wi != null)
                _windowedActText = wi.text;

            screenmodeText.text = fullscreenMode switch
            {
                FullscreenMode.Fullscreen => _fullscreenActText,
                FullscreenMode.Borderless => _borderlessActText,
                FullscreenMode.Window => _windowedActText,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void Start()
        {
            _resolutions = Screen.resolutions;
            serializedResolutions = new List<SerializedResolutions>();
            foreach (var res in _resolutions)
            {
                var aux = new SerializedResolutions();
                aux.height = res.height;
                aux.width = res.width;
                if (aux.height >= 720 && aux.width >= 1280)
                    serializedResolutions.Add(aux);
            }

            serializedResolutions.Reverse();

            resolutionText.text = $"{serializedResolutions[_resolutionIndex].width}x{serializedResolutions[_resolutionIndex].height}";

            UpdateScreenmodeTexts(LocalizationManager.Instance.ActualLanguage);
            UpdateControlTypeText(LocalizationManager.Instance.ActualLanguage);
            UpdateQualityText(LocalizationManager.Instance.ActualLanguage);

            qualityIndex = QualitySettings.GetQualityLevel();

            LocalizationManager.UpdateTexts += UpdateScreenmodeTexts;
            LocalizationManager.UpdateTexts += UpdateControlTypeText;
            LocalizationManager.UpdateTexts += UpdateQualityText;

            _playSelect = playButton;
        }

        public void CancelAllRebindings()
        {
            var rebi = GetComponentsInChildren<RebindActionUI>(true);

            foreach (var rb in rebi)
            {
                rb.CancelRebind();
            }
        }

        [Serializable]
        private class SerializedResolutions
        {
            public int width, height;
        }

        [Serializable]
        private enum FullscreenMode
        {
            Fullscreen, Borderless, Window
        }

        private void UpdateScreen()
        {
            FullScreenMode mode;
            switch (fullscreenMode)
            {
                case FullscreenMode.Fullscreen:
                    mode = FullScreenMode.ExclusiveFullScreen;
                    screenmodeText.text = _fullscreenActText;
                    break;
                case FullscreenMode.Borderless:
                    mode = FullScreenMode.FullScreenWindow;
                    screenmodeText.text = _borderlessActText;
                    break;
                case FullscreenMode.Window:
                    mode = FullScreenMode.Windowed;
                    screenmodeText.text = _windowedActText;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Screen.SetResolution(serializedResolutions[_resolutionIndex].width, serializedResolutions[_resolutionIndex].height, mode);
            resolutionText.text = $"{serializedResolutions[_resolutionIndex].width}x{serializedResolutions[_resolutionIndex].height}";
        }

        public void ResolutionDown()
        {
            ResolutionIndex++;
        }

        public void ResolutionUp()
        {
            ResolutionIndex--;
        }

        public void FullscreenModeNext()
        {
            switch (fullscreenMode)
            {
                case FullscreenMode.Fullscreen:
                    fullscreenMode = FullscreenMode.Borderless;
                    break;
                case FullscreenMode.Borderless:
                    fullscreenMode = FullscreenMode.Window;
                    break;
                case FullscreenMode.Window:
                    fullscreenMode = FullscreenMode.Fullscreen;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            UpdateScreen();
        }

        public void FullscreenModePrevious()
        {
            switch (fullscreenMode)
            {
                case FullscreenMode.Fullscreen:
                    fullscreenMode = FullscreenMode.Window;
                    break;
                case FullscreenMode.Borderless:
                    fullscreenMode = FullscreenMode.Fullscreen;
                    break;
                case FullscreenMode.Window:
                    fullscreenMode = FullscreenMode.Borderless;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            UpdateScreen();
        }

        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            enable?.Invoke();
        }

        private void OnDisable()
        {
            if (_first)
            {
                _first = false;
                firstDisable?.Invoke();
                _playSelect = continueButton;
            }
            disable?.Invoke();
        }


        public void ChangeControlSchemeUI(PlayerInput playerInput)
        {
            if (playerInput.currentControlScheme == "Keyboard&Mouse")
            {
                changeControlSchemeToKeyboard?.Invoke();
                _actJumpRemap = jumpRemapKeyboard;
            }
            else if (playerInput.currentControlScheme == "Gamepad")
            {
                if (Gamepad.current == DualShockGamepad.current)
                {

                }
                else
                {

                }

                changeControlSchemeToGamepad?.Invoke();
                _actJumpRemap = jumpRemapController;
            }

            if (controlChangerPanel.interactable && _lastControlScheme != playerInput.currentControlScheme)
            {
                CancelAllRebindings();
                setEventSystemToControlRemapButton?.Invoke();
            }

            _lastControlScheme = playerInput.currentControlScheme;

            UIManager.Instance.UpdateButtonIndicators();
        }

        public void SelectCorrectRemapper()
        {
            EventSystem.current.SetSelectedGameObject(_actJumpRemap);
        }

        public void SelectPlayButton()
        {
            EventSystem.current.SetSelectedGameObject(_playSelect);
        }

        private void Update()
        {
            var evt = EventSystem.current;

            if (evt.currentSelectedGameObject != null && evt.currentSelectedGameObject != _sel)
                _sel = evt.currentSelectedGameObject;
            else if (_sel != null && evt.currentSelectedGameObject == null)
                evt.SetSelectedGameObject(_sel);
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            Debug.Break();
            return;
#endif
            Application.Quit();
        }

        public void NavigateUpdater(InputAction.CallbackContext cxt)
        {
            if (!cxt.performed) return;

            if (EventSystem.current.currentSelectedGameObject || !optionsMenu) return;

            if (optionsMenu.activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(backButton);
            }
            else
            {
                SelectPlayButton();
            }
        }

        public void CancelAction(InputAction.CallbackContext cxt)
        {
            if (!cxt.performed) return;

            if (!optionsMenu || !mainMenuButtons) return;

            if (optionsMenu.activeSelf)
            {
                if(!controlChangerPanel.interactable)
                    backButton.GetComponent<Button>().onClick?.Invoke();
                // mainMenuButtons.SetActive(true);
                // optionsMenu.SetActive(false);
                // EventSystem.current.SetSelectedGameObject(playButton);
            }
            else
            {
                if (GameStarted)
                {
                    var contBut = continueButton.GetComponent<Button>();
                    if (contBut.interactable)
                        contBut.onClick?.Invoke();
                }
            }
            // else
            // {
            //     gameObject.SetActive(false);
            // }
        }
    }
}
