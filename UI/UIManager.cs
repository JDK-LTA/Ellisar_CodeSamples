using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using System.Linq;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] private PlayerInput playerInput;
        [SerializeField, ReadOnly] private List<Image> buttons;
        [SerializeField]
        private InputActionReference standardInteract, oneHandLInteract, oneHandRInteract,
            transformFlightStd, transformFlightOHL, transformFlightOHR,
            transformBipedStd, transformBipedOHL, transformBipedOHR,
            flapStd, flapOHL, flapOHR;
        [SerializeField] private UnityEngine.InputSystem.Samples.RebindUI.GamepadIconsExample.GamepadIcons ps4, xbox;
        [SerializeField] private TextMeshProUGUI featherText;
        [SerializeField] private CanvasGroup actionsCanvasGroup;
        [FormerlySerializedAs("actionRegenBarFill"), SerializeField] private Image actionRegenFill;
        [SerializeField] private Image actionRegenFillOptions;
        [SerializeField] private List<Color> possibleColorList;
        [SerializeField] private int colorSelectedIndex = 0;

        [SerializeField] private CanvasGroup twoActionsGroup, threeActionsGroup, fourActionsGroup;

        [Space(10)]
        [SerializeField] private float alphaLerpTimeRegenToZero = 1f;
        [SerializeField] private float alphaLerpTimeRegenToOne = 0.15f;
        [SerializeField, MinMaxSlider(0, 1, true)] private Vector2 minMaxAlphaRegen = new Vector2(0, 0.75f);
        [SerializeField] private AnimationCurve getOneActionAlphaCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] private float getOneTime = 3;
        private float _tAlpha = 0;
        private bool _regenFillToOne = false;
        private bool _regenFillToZero = false;
        private bool _showNewFlap = false;

        private bool _threeActions, _fourActions, _twoActions;
        private List<Image> transfButton = new List<Image>(), 
            transfBackButton = new List<Image>(), 
            flapButton = new List<Image>();

        public bool ThreeActions
        {
            get => _threeActions;
            set
            {
                if (value)
                {
                    twoActionsGroup.gameObject.SetActive(false);
                    threeActionsGroup.gameObject.SetActive(true);
                    
                    _twoActions = false;
                    _fourActions = false;
                }

                _threeActions = value;
            }
        }

        public bool FourActions
        {
            get => _fourActions;
            set
            {
                if (value)
                {
                    twoActionsGroup.gameObject.SetActive(false);
                    threeActionsGroup.gameObject.SetActive(false);
                    fourActionsGroup.gameObject.SetActive(true);

                    _twoActions = false;
                    _threeActions = false;
                }

                _fourActions = value;
            }
        }

        public bool TwoActions
        {
            get => _twoActions;
            set
            {
                if (value)
                {
                    twoActionsGroup.gameObject.SetActive(true);
                    threeActionsGroup.gameObject.SetActive(false);
                    fourActionsGroup.gameObject.SetActive(false);
                   
                    _threeActions = false;
                    _fourActions = false;
                }

                _twoActions = value;
            }
        }

        public int ColorSelectedIndex
        {
            get => colorSelectedIndex;
            set
            {
                if (value < 0)
                    value = possibleColorList.Count - 1;
                else if (value >= possibleColorList.Count)
                    value = 0;

                colorSelectedIndex = value;
                UpdateActionCircleColor();
            }
        }

        public void ColorIndexPlus() { ColorSelectedIndex++; }
        public void ColorIndexMinus() { ColorSelectedIndex--; }

        public List<Image> Buttons
        {
            get => buttons;
            set => buttons = value;
        }

        public PlayerInput PlayerInput1
        {
            get => playerInput;
            set => playerInput = value;
        }
        public List<Image> TransfButton { get => transfButton; set => transfButton = value; }
        public List<Image> TransfBackButton { get => transfBackButton; set => transfBackButton = value; }
        public List<Image> FlapButton { get => flapButton; set => flapButton = value; }
        public bool ShowNewFlap
        {
            get => _showNewFlap; set
            {
                if(value)
                    _tAlpha = 0;
                _showNewFlap = value;
            }
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            UpdateActionCircleColor();
            PlayerInput1.controlsChangedEvent?.Invoke(PlayerInput1);
        }

        private void Update()
        {
            if (_showNewFlap)
            {
                _tAlpha += Time.deltaTime;
                actionsCanvasGroup.alpha = getOneActionAlphaCurve.Evaluate(Mathf.Lerp(0, 1, _tAlpha / getOneTime));

                if (_tAlpha >= getOneTime)
                {
                    _tAlpha = 0;
                    _showNewFlap = false;
                }
            }
            else if (_regenFillToOne)
            {
                _tAlpha += Time.deltaTime;
                actionsCanvasGroup.alpha = Mathf.Lerp(0, 1, _tAlpha / alphaLerpTimeRegenToOne);

                if (_tAlpha >= alphaLerpTimeRegenToOne)
                {
                    _tAlpha = 0;
                    _regenFillToOne = false;
                }
            }
            else if (_regenFillToZero)
            {
                _tAlpha += Time.deltaTime;

                actionsCanvasGroup.alpha = Mathf.Lerp(1, 0, _tAlpha / alphaLerpTimeRegenToOne);

                if (_tAlpha >= alphaLerpTimeRegenToZero)
                {
                    _tAlpha = 0;
                    _regenFillToZero = false;
                }
            }
        }

        public void UpdateFeathers(int actualActions)
        {
            if (featherText)
                featherText.text = actualActions.ToString();
        }

        public void RegenToAlphaZero()
        {
            _regenFillToZero = true;
        }

        public void UpdateButtonIndicators()
        {
            string auxUseless, path, trPath, trbPath, flaPath;
            bool gamepad = false;

            switch (MainMenuManager.Instance.ControlType)
            {
                case 0:
                    if (PlayerInput1.currentControlScheme == "Keyboard&Mouse")
                    {
                        standardInteract.action.GetBindingDisplayString(0, out auxUseless, out path);
                        transformFlightStd.action.GetBindingDisplayString(0, out auxUseless, out trPath);
                        transformBipedStd.action.GetBindingDisplayString(0, out auxUseless, out trbPath);
                        flapStd.action.GetBindingDisplayString(1, out auxUseless, out flaPath);
                    }
                    else
                    {
                        standardInteract.action.GetBindingDisplayString(1, out auxUseless, out path);
                        transformFlightStd.action.GetBindingDisplayString(1, out auxUseless, out trPath);
                        transformBipedStd.action.GetBindingDisplayString(1, out auxUseless, out trbPath);
                        flapStd.action.GetBindingDisplayString(0, out auxUseless, out flaPath);
                        gamepad = true;
                    }

                    break;
                case 1:
                    oneHandLInteract.action.GetBindingDisplayString(1, out auxUseless, out path);
                    transformFlightOHL.action.GetBindingDisplayString(1, out auxUseless, out trPath);
                    transformBipedOHL.action.GetBindingDisplayString(1, out auxUseless, out trbPath);
                    flapOHL.action.GetBindingDisplayString(0, out auxUseless, out flaPath);
                    gamepad = true;
                    break;
                case 2:
                    oneHandRInteract.action.GetBindingDisplayString(1, out auxUseless, out path);
                    transformFlightOHR.action.GetBindingDisplayString(1, out auxUseless, out trPath);
                    transformBipedOHR.action.GetBindingDisplayString(1, out auxUseless, out trbPath);
                    flapOHR.action.GetBindingDisplayString(0, out auxUseless, out flaPath);
                    gamepad = true;
                    break;
                default:
                    path = "buttonWest";
                    trPath = "buttonNorth";
                    trbPath = "buttonSouth";
                    flaPath = "rightTriggerButton";
                    break;
            }

            if (gamepad)
            {
                if (DualShockGamepad.current == Gamepad.current)
                {
                    foreach (var but in Buttons)
                    {
                        var tx = but.GetComponentInChildren<TextMeshProUGUI>(true);
                        if(tx) tx.gameObject.SetActive(false);
                        but.enabled = true;
                        but.sprite = ps4.GetSprite(path);
                    }

                    foreach (var but in transfButton)
                    {
                        var tx = but.GetComponentInChildren<TextMeshProUGUI>(true);
                        if(tx) tx.gameObject.SetActive(false);            
                        but.enabled = true;
                        but.sprite = ps4.GetSprite(trPath);
                    }
                    foreach (var but in transfBackButton)
                    {
                        var tx = but.GetComponentInChildren<TextMeshProUGUI>(true);
                        if (tx) tx.gameObject.SetActive(false);
                        but.enabled = true;
                        but.sprite = ps4.GetSprite(trbPath);
                    }
                    foreach (var but in flapButton)
                    {
                        var tx = but.GetComponentInChildren<TextMeshProUGUI>(true);
                        if (tx) tx.gameObject.SetActive(false);
                        but.enabled = true;
                        but.sprite = ps4.GetSprite(flaPath);
                    }

                }
                else
                {
                    foreach (var but in Buttons)
                    {
                        var tx = but.GetComponentInChildren<TextMeshProUGUI>(true);
                        if (tx) tx.gameObject.SetActive(false);
                        but.enabled = true;
                        but.sprite = xbox.GetSprite(path);
                    }

                    foreach (var but in transfButton)
                    {
                        var tx = but.GetComponentInChildren<TextMeshProUGUI>(true);
                        if (tx) tx.gameObject.SetActive(false);
                        but.enabled = true;
                        but.sprite = xbox.GetSprite(trPath);
                    }
                    foreach (var but in transfBackButton)
                    {
                        var tx = but.GetComponentInChildren<TextMeshProUGUI>(true);
                        if (tx) tx.gameObject.SetActive(false);
                        but.enabled = true;
                        but.sprite = xbox.GetSprite(trbPath);
                    }
                    foreach (var but in flapButton)
                    {
                        var tx = but.GetComponentInChildren<TextMeshProUGUI>(true);
                        if (tx) tx.gameObject.SetActive(false);
                        but.enabled = true;
                        but.sprite = xbox.GetSprite(flaPath);
                    }
                }
            }
            else
            {
                foreach (var but in Buttons)
                {
                    var txt = but.GetComponentInChildren<TextMeshProUGUI>(true);
                    if (txt)
                    {
                        txt.gameObject.SetActive(true);
                        txt.text = path;
                        but.enabled = false;
                    }
                }

                foreach (var but in transfButton)
                {
                    var txt = but.GetComponentInChildren<TextMeshProUGUI>(true);
                    if (txt)
                    {
                        txt.gameObject.SetActive(true);
                        txt.text = trPath;
                        but.enabled = false;
                    }
                }
                foreach (var but in transfBackButton)
                {
                    var txt = but.GetComponentInChildren<TextMeshProUGUI>(true);
                    if (txt)
                    {
                        txt.gameObject.SetActive(true);
                        txt.text = trbPath;
                        but.enabled = false;
                    }
                }
                foreach (var but in flapButton)
                {
                    var txt = but.GetComponentInChildren<TextMeshProUGUI>(true);
                    if (txt)
                    {
                        txt.gameObject.SetActive(true);
                        txt.text = flaPath;
                        but.enabled = false;
                    }
                }
            }
        }

        public void UpdateActionRegenBar(float fillAmount)
        {
            if (!actionRegenFill) return;

            if (actionRegenFill.fillAmount >= 1 && fillAmount < 1)
            {
                ResetAlphaToOne();
            }

            actionRegenFill.fillAmount = fillAmount;
        }

        public void UpdateActionCircleColor()
        {
            actionRegenFill.color = possibleColorList[ColorSelectedIndex];
            actionRegenFillOptions.color = possibleColorList[ColorSelectedIndex];
        }

        public void ResetAlphaToOne()
        {
            _regenFillToOne = true;
            _regenFillToZero = false;
            if(!ShowNewFlap)
                _tAlpha = actionsCanvasGroup.alpha * alphaLerpTimeRegenToOne;
        }

        public void UpdateButtonUI(PlayerInput input)
        {
            if (buttons.Count == 0) return;

            //if (Gamepad.current == DualShockGamepad.current)
            //{
            //    foreach (var bt in buttons)
            //    {
            //        bt.sprite = ps4;
            //    }
            //}
            //else
            //{
            //    foreach (var bt in buttons)
            //    {
            //        bt.sprite = xbox;
            //    }
            //}
        }
    }
}