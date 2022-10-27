using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    [RequireComponent(typeof(Image))]
    public class IndicatorSubscriber : MonoBehaviour
    {
        [SerializeField] private int indicatorIndex = 0;

        private void OnEnable()
        {
            switch (indicatorIndex)
            {
                default:
                case 0:
                    UIManager.Instance.Buttons.Add(GetComponent<Image>());
                    break;
                case 1:
                    UIManager.Instance.TransfButton.Add(GetComponent<Image>());
                    break;
                case 2:
                    UIManager.Instance.TransfBackButton.Add(GetComponent<Image>());
                    break;
                case 3:
                    UIManager.Instance.FlapButton.Add(GetComponent<Image>());
                    break;
            }

            UIManager.Instance.UpdateButtonIndicators();
        }

        private void OnDisable()
        {
            switch (indicatorIndex)
            {
                default:
                case 0:
                    UIManager.Instance.Buttons.Remove(GetComponent<Image>());
                    break;
                case 1:
                    UIManager.Instance.TransfButton.Remove(GetComponent<Image>());
                    break;
                case 2:
                    UIManager.Instance.TransfBackButton.Remove(GetComponent<Image>());
                    break;
                case 3:
                    UIManager.Instance.FlapButton.Remove(GetComponent<Image>());
                    break;
            }
        }
    }
}
