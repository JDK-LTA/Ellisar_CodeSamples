using System;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.OnDestroyOrDisable
{
    public class EventOnEnable : MonoBehaviour
    {
        [SerializeField] private bool onlyOnce = true;
        [SerializeField] private UnityEvent onEnable;

        private bool _done;

        private void OnEnable()
        {
            if (onlyOnce)
            {
                if (!_done)
                {
                    _done = true;
                    onEnable?.Invoke();
                }
            }
            else
            {
                onEnable?.Invoke();
            }
        }
    }
}
