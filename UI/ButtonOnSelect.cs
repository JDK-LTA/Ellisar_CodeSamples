using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonOnSelect : MonoBehaviour, ISelectHandler
    {
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void OnSelect(BaseEventData eventData)
        {
            _button.onClick?.Invoke();
        }
    }
}
