using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class ButtonColorChanger : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField] private bool selfGoBack = true;
        [SerializeField] private Color selectColor;
        [SerializeField, ShowIf("@selfGoBack == false")] private Color selectSecondaryColor;

        private Color _startColor;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _startColor = _image.color;
        }

        public void OnSelect(BaseEventData eventData)
        {
            SelectColor();
        }

        public void SelectColor()
        {
            _image.color = selectColor;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (selfGoBack)
                DeselectColor();
            else
                _image.color = selectSecondaryColor;
        }

        public void DeselectColor()
        {
            _image.color = _startColor;
        }
    }
}
