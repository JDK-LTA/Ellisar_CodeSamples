using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Flocks
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Flock : MonoBehaviour
    {
        [Header("Spawn Setup")]
        [SerializeField] private FlockUnit flockUnitPrefab;
        [SerializeField] private int flockSize;
        [SerializeField] private Vector3 spawnBounds;

        [Header("Speed Setup")]
        [Range(0, 10)]
        [SerializeField] private float _minSpeed;
        public float minSpeed => _minSpeed;

        [Range(0, 10)]
        [SerializeField] private float _maxSpeed;
        public float maxSpeed => _maxSpeed;


        [Header("Detection Distances")]

        [Range(0, 10)]
        [SerializeField] private float _cohesionDistance;
        public float cohesionDistance => _cohesionDistance;

        [Range(0, 10)]
        [SerializeField] private float _avoidanceDistance;
        public float avoidanceDistance => _avoidanceDistance;

        [Range(0, 10)]
        [SerializeField] private float _aligementDistance;
        public float aligementDistance => _aligementDistance;

        [Range(0, 10)]
        [SerializeField] private float _obstacleDistance;
        public float obstacleDistance => _obstacleDistance;

        [Range(0, 100)]
        [SerializeField] private float _boundsDistance;
        public float boundsDistance => _boundsDistance;


        [Header("Behaviour Weights")]

        [Range(0, 10)]
        [SerializeField] private float _cohesionWeight;
        public float cohesionWeight => _cohesionWeight;

        [Range(0, 10)]
        [SerializeField] private float _avoidanceWeight;
        public float avoidanceWeight => _avoidanceWeight;

        [Range(0, 10)]
        [SerializeField] private float _aligementWeight;
        public float aligementWeight => _aligementWeight;

        [Range(0, 10)]
        [SerializeField] private float _boundsWeight;
        public float boundsWeight => _boundsWeight;

        [Range(0, 100)]
        [SerializeField] private float _obstacleWeight;
        public float obstacleWeight => _obstacleWeight;

        public FlockUnit[] allUnits { get; private set; }

        private void Start()
        {
            GenerateUnits();
        }

        private void Update()
        {
            for (int i = 0; i < allUnits.Length; i++)
            {
                allUnits[i].MoveUnit();
            }
        }

        private void GenerateUnits()
        {
            allUnits = new FlockUnit[flockSize];
            for (int i = 0; i < flockSize; i++)
            {
                var randomVector = Random.insideUnitSphere;
                randomVector = new Vector3(randomVector.x * spawnBounds.x, randomVector.y * spawnBounds.y, randomVector.z * spawnBounds.z);
                var spawnPosition = transform.position + randomVector;
                var rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                allUnits[i] = Instantiate(flockUnitPrefab, spawnPosition, rotation, transform);
                allUnits[i].AssignFlock(this);
                allUnits[i].InitializeSpeed(Random.Range(minSpeed, maxSpeed));
            }
        }
    }
}