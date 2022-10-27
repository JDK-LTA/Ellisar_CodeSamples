using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs.SeaAngels
{
    public class SeaAngelCaveBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject dialogCollider;
        [SerializeField, Required] private Transform followTargetOnPlayer;
        [SerializeField] private float minFollowSpeed = 1.5f;
        [SerializeField] private float maxFollowSpeed = 20f;
        [SerializeField] private Vector2 distanceBracket = new Vector2(1, 30);
        [SerializeField] private float followRotationSpeed = 5f;
        [SerializeField] private float maxDistanceToFollow = 15f;
        [SerializeField] private float timeToStartFollow = .75f;

        [Title("Visual stuff")] [SerializeField] private float maxEmissive = 5;
        [SerializeField] private float minEmissive = 0;
        [SerializeField] private float timeToEmissiveOn = 1.5f;
        [SerializeField] private Renderer mainRenderer;

        private Vector3 _startPos;
        private Quaternion _startRot;

        private bool _moving;

        private bool _delayFollow;
        private float _tDelay;

        private bool _emissionToOn, _canGlow = true;
        private MaterialPropertyBlock _propBlock;
        private float _tEmissive = 0;
        private float _intensity;
        private static readonly int EmissionMult = Shader.PropertyToID("_EmissionMultiplier");

        private Transform _target;

        private static int _angelsActivated = 0;
        private bool _hasActivated = false;

        private void Start()
        {
            _startPos = transform.position;
            _startRot = transform.rotation;

            _propBlock = new MaterialPropertyBlock();

            mainRenderer.GetPropertyBlock(_propBlock);
            _intensity = minEmissive;
            _propBlock.SetFloat(EmissionMult, _intensity);
            mainRenderer.SetPropertyBlock(_propBlock);

            _target = followTargetOnPlayer;
        }

        private void Update()
        {
            if(_moving)
                DistanceChecker();
            
            var actualSpeed = Mathf.Lerp(minFollowSpeed, maxFollowSpeed, (Vector3.Distance(transform.position, _target.position) - distanceBracket.x) / (distanceBracket.y - distanceBracket.x));

            if (_moving)
                MoveTowards(_target, actualSpeed, followRotationSpeed);
            else
                MoveTowards(_startPos, _startRot, actualSpeed, followRotationSpeed);

            if (_emissionToOn && _canGlow)
            {
                _tEmissive += Time.deltaTime;

                mainRenderer.GetPropertyBlock(_propBlock);
                _intensity = Mathf.Lerp(minEmissive, maxEmissive, _tEmissive / timeToEmissiveOn);
                _propBlock.SetFloat(EmissionMult, _intensity);
                mainRenderer.SetPropertyBlock(_propBlock);

                if (_tEmissive >= timeToEmissiveOn)
                {
                    _tEmissive = 0;
                    _emissionToOn = false;
                    _canGlow = false;
                }
            }

            if (_delayFollow)
            {
                _tDelay += Time.deltaTime;
                
                if (_tDelay >= timeToStartFollow)
                {
                    _tDelay = 0;
                    _delayFollow = false;
                    _moving = true;
                }
            }
        }

        private void MoveTowards(Vector3 targetPos, Quaternion targetRot, float speed, float rotSpeed)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }

        private void MoveTowards(Transform targetTransform, float speed, float rotSpeed)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetTransform.rotation, rotSpeed * Time.deltaTime);
        }

        public void StartFollow()
        {
            _emissionToOn = true;
            _target = followTargetOnPlayer;
            _delayFollow = true;

            if (!_hasActivated)
            {
                _hasActivated = true;
                _angelsActivated++;

                if (_angelsActivated >= 8)
                {
                    dialogCollider.SetActive(true);
                }
            }
        }

        private void DistanceChecker()
        {
            if (Vector3.Distance(transform.position, _startPos) >= maxDistanceToFollow)
            {
                _moving = false;
            }
        }
    }
}