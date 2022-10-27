using System;
using Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs.SeaAngels;
using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.SpyroRingSystem
{
    public class RingObject : TriggerEnter
    {
        private enum SelectionEnum { Platform, Event, Both }

        [SerializeField, MinValue(0.1)] private float distanceToOuterThreshold = 20f;
        [SerializeField, MinValue(0.1), MaxValue("distanceToOuterThreshold")] private float distanceToInnerThreshold = 10f;
        [SerializeField, MinValue(0)] private float speedToWaiting = 2.5f, speedToIn = 0.5f;
        [SerializeField] private Color activatedColor;
        [SerializeField] private ParticleSystem ringPs, interiorPs;
        [SerializeField] private Transform waitingPosition, inPosition;
        [SerializeField] private float timeToDestroyAfterGoingIn = 1f;
        [SerializeField] private float timeToStartFollowingAfterGoingIn = 0.25f;
        [EnumToggleButtons, SerializeField, HideLabel, Space(10)] private SelectionEnum selection = SelectionEnum.Platform;
        [SerializeField, HideIf("@selection == SelectionEnum.Event")] private GameObject platformToAppear;
        [SerializeField, HideIf("@selection == SelectionEnum.Platform")] private UnityEvent activationEvent;
            
        private bool _onFirstTh, _onSecondTh, _stopChecking = false;
            
        private Transform _playerTransform;

        private bool _destroying, _isFollowing;
        private float _tDestroy;

        //PLACEHOLDER
        private SeaAngelBehaviour _seaAngelPlaceholder;

        private void Start()
        {
            _playerTransform = PlayerSetup.CharController.transform;
            _seaAngelPlaceholder = FindObjectOfType<SeaAngelBehaviour>();
        }

        private void Update()
        {
            if (!_stopChecking)
            {
                var distance = DetectDistanceWithPlayer();

                if (distance <= distanceToOuterThreshold)
                {
                    if (!_onFirstTh)
                    {
                        _onFirstTh = true;
                        SeaAngelToPlace();
                    }
                    else
                    {
                        if (distance <= distanceToInnerThreshold)
                        {
                            if (!_onSecondTh)
                            {
                                _onSecondTh = true;
                                SeaAngelIn();
                                ActivateRing();
                            }
                        }
                    }
                }
                else if (_onFirstTh)
                {
                    _onFirstTh = false;
                    SeaAngelBack();
                }
            }

            if (_destroying)
            {
                _tDestroy += Time.deltaTime;

                if (!_isFollowing && _tDestroy >= timeToStartFollowingAfterGoingIn)
                {
                    interiorPs.transform.parent = _playerTransform;
                    interiorPs.transform.localScale = Vector3.one;
                    ringPs.transform.parent = null;
                    ringPs.Stop();
                    _isFollowing = true;
                }
                
                if (_tDestroy >= timeToDestroyAfterGoingIn)
                {
                    interiorPs.Stop();
                    gameObject.SetActive(false);
                }
            }
        }

        private void SeaAngelToPlace()
        {
            _seaAngelPlaceholder.GoToPlace(waitingPosition, speedToWaiting, 0.25f);
        }

        private void SeaAngelIn()
        {
            _seaAngelPlaceholder.GoToPlace(inPosition, speedToIn, 0.2f);
        }

        private void ActivateRing()
        {
            var config = ringPs.main;
            config.startColor = new ParticleSystem.MinMaxGradient(activatedColor);

            config = interiorPs.main;
            config.startColor = new ParticleSystem.MinMaxGradient(activatedColor);
        }

        private void SeaAngelBack()
        {
            _seaAngelPlaceholder.GoBack();
        }

        private float DetectDistanceWithPlayer()
        {
            return Vector3.Distance(_playerTransform.position, transform.position);
        }

        protected override void TriggerAction()
        {
            _stopChecking = true;
            SeaAngelBack();
            if(selection != SelectionEnum.Event && platformToAppear)
                platformToAppear.SetActive(true);
            if(selection != SelectionEnum.Platform)
                activationEvent?.Invoke();
            _destroying = true;
        }
    }
}
