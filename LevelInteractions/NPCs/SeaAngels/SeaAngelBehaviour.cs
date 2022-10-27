using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs.SeaAngels
{
    public class SeaAngelBehaviour : MonoBehaviour
    {
        [SerializeField] private float goingBackSpeed = 5f;
        [SerializeField] private float goingBackDistanceThreshold = 0.1f;
        [SerializeField] private float minFollowSpeed = 1.5f;
        [SerializeField] private float maxFollowSpeed = 20f;
        [SerializeField] private Vector2 distanceBracket = new Vector2(1, 30);
        [SerializeField] private float followRotationSpeed = 5f;
        [SerializeField, Required] private Transform followTargetOnPlayer;
        [Title("Seek behaviour")] [SerializeField] private float maxVelocity = 3f;
        [SerializeField] protected float maxSteeringForce = 1f;
        [SerializeField] protected float mass = 15f;

        [Title("Visual stuff")] [SerializeField] private float maxEmissive = 5;
        [SerializeField] private float minEmissive = -2;
        [SerializeField] private float timeToEmissiveOn = 0.5f, timeToEmissiveOff = 0.5f;
        [SerializeField] private Renderer mainRenderer;

        private Vector3 _startPos;
        
        private bool _goingPlace;
        private bool _goingBack;
        private bool _stopFollow;
        
        private bool _emissionToOn, _emissionToOff;
        private MaterialPropertyBlock _propBlock;
        private float _tEmissive = 0;
        private float _intensity;
        private static readonly int EmissionMult = Shader.PropertyToID("_EmissionMultiplier");

        private Transform _target;
        private float _speed, _stdSpeed = .5f;
        private float _distanceThreshold, _stdDistanceThreshold = 0.2f;
        
        private Vector3 _velocity = Vector3.zero;

        public bool EmissionToOn
        {
            get => _emissionToOn;
            set
            {
                _emissionToOn = value;
                if (_emissionToOn)
                {
                    _tEmissive = _intensity / maxEmissive;
                    _emissionToOff = false;
                }
            }
        }

        public bool EmissionToOff
        {
            get => _emissionToOff;
            set
            {
                _emissionToOff = value;
                if (_emissionToOff)
                {
                    _tEmissive = 1 - _intensity /maxEmissive;
                    _emissionToOn = false;
                }
            }
        }

        private void Start()
        {
            _startPos = followTargetOnPlayer.position;

            _propBlock = new MaterialPropertyBlock();
            
            mainRenderer.GetPropertyBlock(_propBlock);
            _intensity = maxEmissive;
            _propBlock.SetFloat(EmissionMult, _intensity);
            mainRenderer.SetPropertyBlock(_propBlock);

            _target = followTargetOnPlayer;
        }

        private void Update()
        {
            EmissiveChanging();
            Movement();
        }

        private void Movement()
        {
            var actualSpeed = Mathf.Lerp(minFollowSpeed, maxFollowSpeed, (Vector3.Distance(transform.position, _target.position) - distanceBracket.x) / (distanceBracket.y - distanceBracket.x));

            if (_goingPlace)
            {
                // // var t = 1 - Mathf.Exp(-_speed * Time.deltaTime);
                // // transform.position = Vector3.Lerp(transform.position, _target.position, t);
                // // transform.rotation = Quaternion.Slerp(transform.rotation, _target.rotation, 1 - Mathf.Exp(-followRotationSpeed * Time.deltaTime));
                //
                // MoveTowards(_target, _speed, followRotationSpeed);
                // // Seek(_target.position, _target.rotation, _speed);
                
                MoveTowards(_target, actualSpeed, followRotationSpeed);
                
                if (Vector3.Distance(transform.position, _target.position) <= _distanceThreshold)
                {
                    _goingPlace = false;
                    _target = followTargetOnPlayer;
                }
            }
            else if (_goingBack)
            {
                // var t = 1 - Mathf.Exp(-goingBackSpeed * Time.deltaTime);
                // transform.position = Vector3.Lerp(transform.position, _startPos, t);
                // transform.rotation = Quaternion.Slerp(transform.rotation, followTargetOnPlayer.rotation, 1 - Mathf.Exp(-followRotationSpeed * Time.deltaTime));
                
                MoveTowards(_target, actualSpeed, followRotationSpeed);
                // Seek(followTargetOnPlayer.position, followTargetOnPlayer.rotation, goingBackSpeed);
                
                if (Vector3.Distance(transform.localPosition, _startPos) <= goingBackDistanceThreshold)
                {
                    _goingBack = false;
                    _stopFollow = false;
                    //RESUME STANDARD ANIMATION STUFF
                }
            }
            else if (!_stopFollow)
            {
                // transform.position = Vector3.Lerp(transform.position, followTargetOnPlayer.position, 1 - Mathf.Exp(-followSpeed * Time.deltaTime));
                // transform.rotation = Quaternion.Slerp(transform.rotation, followTargetOnPlayer.rotation, 1 - Mathf.Exp(-followRotationSpeed * Time.deltaTime));
                
                MoveTowards(_target, actualSpeed, followRotationSpeed);
                // Seek(followTargetOnPlayer.position, followTargetOnPlayer.rotation, followSpeed);
            }
        }

        private void EmissiveChanging()
        {
            if (EmissionToOn)
            {
                _tEmissive += Time.deltaTime;

                mainRenderer.GetPropertyBlock(_propBlock);
                _intensity =Mathf.Lerp(minEmissive, maxEmissive, _tEmissive / timeToEmissiveOn);
                _propBlock.SetFloat(EmissionMult, _intensity);
                mainRenderer.SetPropertyBlock(_propBlock);

                if (_tEmissive >= timeToEmissiveOn)
                {
                    _tEmissive = 0;
                    _emissionToOn = false;
                }
            }
            else if (EmissionToOff)
            {
                _tEmissive += Time.deltaTime;

                mainRenderer.GetPropertyBlock(_propBlock);
                _intensity = Mathf.Lerp(maxEmissive, minEmissive, _tEmissive / timeToEmissiveOff);
                _propBlock.SetFloat(EmissionMult, _intensity);
                mainRenderer.SetPropertyBlock(_propBlock);

                if (_tEmissive >= timeToEmissiveOff)
                {
                    _tEmissive = 0;
                    _emissionToOff = false;
                }
            }
        }

        public void GoToPlace(Transform target, float speed, float distanceThreshold, bool stopFollow = true)
        {
            _goingPlace = true;
            _target = target;
            _speed = speed;
            _distanceThreshold = distanceThreshold;

            _stopFollow = stopFollow;

            //CUT STANDARD ANIMATION STUFF
        }

        public void GoToPlace(Transform target)
        {  
            GoToPlace(target, _stdSpeed, _stdDistanceThreshold);
        }

        private void Seek(Vector3 targetPos, Quaternion targetRot, float speed)
        {
            // Calculamos la velocidad deseada al objetivo
            Vector3 dVelocity = (targetPos - transform.position).normalized * speed;
            
            // Calculamos la fuerza de giro
            Vector3 steering = Vector3.ClampMagnitude(dVelocity - _velocity, maxSteeringForce) / mass;

            _velocity = Vector3.ClampMagnitude(_velocity + steering, speed);
            
            // Sensors(ref _velocity);
            Move(_velocity, targetRot);
            
            Debug.DrawRay(transform.position, _velocity.normalized * 2, Color.green);
            Debug.DrawRay(transform.position, dVelocity.normalized * 2, Color.magenta);
        }
        private void Move (Vector3 velocity, Quaternion targetRot)
        {
            transform.position += velocity * Time.deltaTime;
            transform.forward = velocity.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 1 - Mathf.Exp(-followRotationSpeed * Time.deltaTime));
        }
        private void Sensors(ref Vector3 velocity)
        {
            if (Physics.Raycast(transform.position, -transform.right, 0.5f, (1 << 0) | (1 << 3)))
            {
                float newX = Mathf.Clamp(velocity.x, 0, Mathf.Infinity);
                velocity = new Vector3(newX, velocity.y, velocity.z);
            }

            if (Physics.Raycast(transform.position, transform.right, 0.5f, (1 << 0) | (1 << 3)))
            {
                float newX = Mathf.Clamp(velocity.x, Mathf.NegativeInfinity, 0);
                velocity = new Vector3(newX, velocity.y, velocity.z);
            }
            
            if (Physics.Raycast(transform.position, transform.forward, 0.5f, (1 << 0) | (1 << 3)))
            {
                float newZ = Mathf.Clamp(velocity.z, 0, Mathf.Infinity);
                velocity = new Vector3(velocity.x, velocity.y, newZ);
            }
            
            if (Physics.Raycast(transform.position, -transform.forward, 0.5f, (1 << 0) | (1 << 3)))
            {
                float newZ = Mathf.Clamp(velocity.z, Mathf.NegativeInfinity, 0);
                velocity = new Vector3(velocity.x, velocity.y, newZ);
            }
            
            if (Physics.Raycast(transform.position, transform.up, 0.5f, (1 << 0) | (1 << 3)))
            {
                float newY = Mathf.Clamp(velocity.y, 0, Mathf.Infinity);
                velocity = new Vector3(velocity.x, newY, velocity.z);
            }
            
            if (Physics.Raycast(transform.position, -transform.up, 0.5f, (1 << 0) | (1 << 3)))
            {
                float newY = Mathf.Clamp(velocity.y, Mathf.NegativeInfinity, 0);
                velocity = new Vector3(velocity.x, newY, velocity.z);
            }
        }

        private void MoveTowards(Transform target, float speed, float rotSpeed)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, rotSpeed * Time.deltaTime);
        }

        public void GoBack()
        {
            _goingBack = true;
        }

        public void SetEmissive(bool value)
        {
            if (value)
            {
                EmissionToOn = true;
            }
            else
            {
                EmissionToOff = true;
            }
        }
    }
}
