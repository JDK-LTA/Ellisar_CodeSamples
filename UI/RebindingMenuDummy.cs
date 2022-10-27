using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class RebindingMenuDummy : MonoBehaviour
    {
        [SerializeField] private UnityEvent enable, disable;
        [SerializeField] private InputAction Iaction;
        private bool state = false;
        private void OnEnable()
        {
            Iaction.Enable();
        }

        private void OnDisable()
        {
            Iaction.Disable();
        }

        private void Start()
        {
            Iaction.performed += _ => Pause();
        }

        public void Pause()
        {
            state = !state;
            if (state)
            {
                enable?.Invoke();
            }
            else
            {
                disable?.Invoke();
            }
        }
    }
}
