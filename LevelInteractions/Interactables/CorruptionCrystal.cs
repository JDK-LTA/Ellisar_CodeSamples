using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Interactables
{
    public class CorruptionCrystal : MonoBehaviour
    {
        [SerializeField] private Vector2 initAndFinalValues = new Vector2(-20, -37);
        [SerializeField, MinValue(1)] private int amountOfHits = 1;
        [SerializeField] private float timeToDissolve = 1f;
        [SerializeField] private UnityEvent initEvent, hitEvent, endEvent, goBackEvent;

        private Vector2 _actualValue;
        private int _hit;

        private bool _dissolving = false;
        private bool _goingBack = false;
        private float _tDissolve = 0;

        private MaterialPropertyBlock _matBlock;
        private Renderer _renderer;
        private static readonly int Cutoff = Shader.PropertyToID("_Cutoff");

        private void Start()
        {
            _matBlock = new MaterialPropertyBlock();
            _renderer = GetComponent<Renderer>();
            
            _renderer.GetPropertyBlock(_matBlock);
            _matBlock.SetFloat(Cutoff, initAndFinalValues.x);
            _renderer.SetPropertyBlock(_matBlock);
        }

        private void Update()
        {
            if (_dissolving)
            {
                _tDissolve += Time.deltaTime;

                _renderer.GetPropertyBlock(_matBlock);
                var cutoffValue = Mathf.Lerp(_actualValue.x, _actualValue.y, _tDissolve / timeToDissolve);
                _matBlock.SetFloat(Cutoff, cutoffValue);
                _renderer.SetPropertyBlock(_matBlock);

                if (_tDissolve >= timeToDissolve)
                {
                    _tDissolve = 0;
                    _dissolving = false;

                    if (!_goingBack)
                    {
                        if (_hit < amountOfHits && amountOfHits > 1)
                            hitEvent?.Invoke();
                        else
                            endEvent?.Invoke();
                    }
                }
            }
        }

        [Button(ButtonSizes.Small), DisableInEditorMode, HorizontalGroup(0.33f)]
        public void Dissolve()
        {
            _goingBack = false;
            _actualValue = initAndFinalValues;
            _dissolving = true;
            initEvent?.Invoke();
        }

        [Button(ButtonSizes.Small), DisableInEditorMode, HorizontalGroup(0.33f)]
        public void DissolvePartially()
        {
            if (_hit < amountOfHits)
            {
                _hit++;
                _actualValue = new Vector2(Mathf.Lerp(initAndFinalValues.x, initAndFinalValues.y, (float)(_hit - 1) / amountOfHits),
                    Mathf.Lerp(initAndFinalValues.x, initAndFinalValues.y, (float)_hit / amountOfHits));
                _dissolving = true;
                _goingBack = false;
            }
        }

        [Button(ButtonSizes.Small), HorizontalGroup(0.33f)]
        public void GoBack()
        {
            _goingBack = true;
            _actualValue = new Vector2(initAndFinalValues.y, initAndFinalValues.x);
            _dissolving = true;
            goBackEvent?.Invoke();
        }
    }
}
