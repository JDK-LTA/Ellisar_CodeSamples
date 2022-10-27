using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Storytelling
{
    public class UiText : TriggerEnterExit
    {
        [Title("UI Text Specific")]
        [SerializeField] private GameObject text;
        [SerializeField] private TextMeshProUGUI textMP;
        [SerializeField] private float timeToFullAlpha = 1f;
        private bool alpha = false;
        private float alphaT = 0;
        private bool toOn = false;
        
        protected override void TriggerAction()
        {
            text.SetActive(true);
            alpha = true;
            toOn = true;
        }

        protected override void TriggerExitAction()
        {
            alpha = true;
            toOn = false;
        }

        private void Update()
        {
            if (alpha)
            {
                alphaT += Time.deltaTime;
                var lerp = toOn ? Mathf.Lerp(0, 1, alphaT / timeToFullAlpha) :Mathf.Lerp(1, 0, alphaT / timeToFullAlpha);
                if (alphaT >= timeToFullAlpha)
                {
                    lerp = 1;
                    alphaT = 0;
                    alpha = false;
                    if(!toOn) text.SetActive(false);
                }
                var color = new Color(textMP.color.r, textMP.color.g, textMP.color.b, lerp);

                textMP.color = color;
            }
        }
    }
}