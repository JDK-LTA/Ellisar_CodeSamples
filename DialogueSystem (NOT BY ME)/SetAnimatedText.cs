using Febucci.UI;
using TMPro;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.DialogueSystem
{
    [RequireComponent(typeof(TextAnimatorPlayer), typeof(TextAnimator), typeof(TextMeshProUGUI))]
    public class SetAnimatedText : MonoBehaviour
    {
        private TextAnimatorPlayer _textAnimatorPlayer;
        private TextMeshProUGUI _text;
    
        private void Start()
        {
            _textAnimatorPlayer = GetComponent<TextAnimatorPlayer>();
            _text = GetComponent<TextMeshProUGUI>();
        
            _textAnimatorPlayer.ShowText("");
        }

        public void SetText()
        {
            _textAnimatorPlayer.ShowText(_text.text);
        }
    }
}
