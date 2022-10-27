using System;
using System.Collections.Generic;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using UnityEngine;
using Event = AK.Wwise.Event;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Interactables
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField, ReadOnly] protected bool canActivate = false;
        [SerializeField] protected bool isInteractable = true;
        [SerializeField] private GameObject indicator;

        [Title("Delay"), SerializeField] protected bool delayBetweenInteractions = false;

        [SerializeField, HideIf("@delayBetweenInteractions == false")]
        protected float delayTime = 2f;
        
        [InfoBox("Please add component AkGameObj manually to have better performance", InfoMessageType.Info, 
            VisibleIf = "soundOnInteraction")]
        [Title("SFX"), SerializeField] protected bool soundOnInteraction = false;
        [SerializeField, HideIf("@!soundOnInteraction")] protected Event soundEvent;

        [Title("VFX"), SerializeField] protected bool particlesOnInteraction = false;
        [SerializeField, HideIf("@!particlesOnInteraction")] protected List<ParticleSystem> particleSystems;

        [Title("Feedbacks"), SerializeField] protected bool faderFeedbacks = false;
        [SerializeField, HideIf("@!faderFeedbacks")] protected MMFeedbacks fader;

        private float _delayT = 0;
        private bool _delay = false;

        public bool IsInteractable
        {
            get => isInteractable;
            set => isInteractable = value;
        }

        public void SetInteractableTrue()
        {
            IsInteractable = true;

            if (indicator) indicator.SetActive(true);
        }

        protected virtual void Start()
        {
            var skill = (SkillInteractionData) PlayerSetup.PlayerController.PlayerSkills.Find(x => 
                x.SkillType == SkillType.Interaction && x.Name == "Interaction")?.Data;
            if (skill != null)
                skill.InteractionEnterEvent.AddListener(Interact);
            else
                throw new NullReferenceException("INTERACTION INPUT HAS TO BE NAMED Interaction");
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 3)
                CanActivateTrue();
        }

        protected void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == 3)
                CanActivateFalse();
        }

        protected virtual void CanActivateTrue()
        {
            canActivate = true;
            
            if (faderFeedbacks)
                fader.Feedbacks[0].Play(transform.position);
        }

        protected virtual void CanActivateFalse()
        {
            canActivate = false;
            
            if (faderFeedbacks)
                fader.Feedbacks[1].Play(transform.position);
        }

        public void Interact()
        {
            if (canActivate && IsInteractable)
            {
                Act();
            }
        }

        protected virtual void Act()
        {
            if (delayBetweenInteractions)
            {
                if (_delay) return;
                ActionWhenStartingDelay();
            }

            if (particlesOnInteraction && particleSystems.Count > 0)
            {
                foreach (var ps in particleSystems)
                {
                    if (ps)
                    {
                        ps.Play();
                    }
                }
            }

            if (soundOnInteraction)
            {
                soundEvent.Post(gameObject);
            }

            PlayerSetup.PlayerAnimationController.TriggerInteractionAnim();
        }

        protected void Update()
        {
            if (_delay)
            {
                _delayT += Time.deltaTime;
                if (_delayT >= delayTime)
                {
                    ActionWhenFinishingDelay();
                }
            }
        }

        protected virtual void ActionWhenStartingDelay()
        {
            _delay = true;

            if (faderFeedbacks)
                fader.Feedbacks[1].Play(transform.position);
        }

        protected virtual void ActionWhenFinishingDelay()
        {
            _delayT = 0;
            _delay = false;

            if (faderFeedbacks && canActivate)
                fader.Feedbacks[0].Play(transform.position);
        }
    }
}