using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ellisar.EllisarAssets.Scripts.Flocks
{
	public class FlockUnit : MonoBehaviour
	{
		[FormerlySerializedAs("FOVAngle")] [SerializeField] private float fovAngle;
		[SerializeField] private float smoothDamp;
		[SerializeField] private LayerMask obstacleMask;
		[SerializeField] private Vector3[] directionsToCheckWhenAvoidingObstacles;

		private readonly List<FlockUnit> _cohesionNeighbours = new List<FlockUnit>();
		private readonly List<FlockUnit> _avoidanceNeighbours = new List<FlockUnit>();
		private readonly List<FlockUnit> _aligementNeighbours = new List<FlockUnit>();
		private Flock _assignedFlock;
		private Vector3 _currentVelocity;
		private Vector3 _currentObstacleAvoidanceVector;
		private float _speed;

		private Transform MyTransform { get; set; }

		private void Awake()
		{
			MyTransform = transform;
		}

		public void AssignFlock(Flock flock)
		{
			_assignedFlock = flock;
		}

		public void InitializeSpeed(float speed)
		{
			_speed = speed;
		}

		public void MoveUnit()
		{
			FindNeighbours();
			CalculateSpeed();

			var cohesionVector = CalculateCohesionVector() * _assignedFlock.cohesionWeight;
			var avoidanceVector = CalculateAvoidanceVector() * _assignedFlock.avoidanceWeight;
			var aligementVector = CalculateAligementVector() * _assignedFlock.aligementWeight;
			var boundsVector = CalculateBoundsVector() * _assignedFlock.boundsWeight;
			var obstacleVector = CalculateObstacleVector() * _assignedFlock.obstacleWeight;

			var moveVector = cohesionVector + avoidanceVector + aligementVector + boundsVector + obstacleVector;
			moveVector = Vector3.SmoothDamp(MyTransform.forward, moveVector, ref _currentVelocity, smoothDamp);
			moveVector = moveVector.normalized * _speed;
			if (moveVector == Vector3.zero)
				moveVector = transform.forward;

			MyTransform.forward = moveVector;
			MyTransform.position += moveVector * Time.deltaTime;
		}

	

		private void FindNeighbours()
		{
			_cohesionNeighbours.Clear();
			_avoidanceNeighbours.Clear();
			_aligementNeighbours.Clear();
			var allUnits = _assignedFlock.allUnits;
			for (int i = 0; i < allUnits.Length; i++)
			{
				var currentUnit = allUnits[i];
				if (currentUnit != this)
				{
					float currentNeighbourDistanceSqr = Vector3.SqrMagnitude(currentUnit.MyTransform.position - MyTransform.position);
					if(currentNeighbourDistanceSqr <= _assignedFlock.cohesionDistance * _assignedFlock.cohesionDistance)
					{
						_cohesionNeighbours.Add(currentUnit);
					}
					if (currentNeighbourDistanceSqr <= _assignedFlock.avoidanceDistance * _assignedFlock.avoidanceDistance)
					{
						_avoidanceNeighbours.Add(currentUnit);
					}
					if (currentNeighbourDistanceSqr <= _assignedFlock.aligementDistance * _assignedFlock.aligementDistance)
					{
						_aligementNeighbours.Add(currentUnit);
					}
				}
			}
		}

		private void CalculateSpeed()
		{
			if (_cohesionNeighbours.Count == 0)
				return;
			_speed = 0;
			for (int i = 0; i < _cohesionNeighbours.Count; i++)
			{
				_speed += _cohesionNeighbours[i]._speed;
			}

			_speed /= _cohesionNeighbours.Count;
			_speed = Mathf.Clamp(_speed, _assignedFlock.minSpeed, _assignedFlock.maxSpeed);
		}

		private Vector3 CalculateCohesionVector()
		{
			var cohesionVector = Vector3.zero;
			if (_cohesionNeighbours.Count == 0)
				return Vector3.zero;
			int neighboursInFOV = 0;
			for (int i = 0; i < _cohesionNeighbours.Count; i++)
			{
				if (IsInFOV(_cohesionNeighbours[i].MyTransform.position))
				{
					neighboursInFOV++;
					cohesionVector += _cohesionNeighbours[i].MyTransform.position;
				}
			}

			cohesionVector /= neighboursInFOV;
			cohesionVector -= MyTransform.position;
			cohesionVector = cohesionVector.normalized;
			return cohesionVector;
		}

		private Vector3 CalculateAligementVector()
		{
			var aligementVector = MyTransform.forward;
			if (_aligementNeighbours.Count == 0)
				return MyTransform.forward;
			int neighboursInFOV = 0;
			for (int i = 0; i < _aligementNeighbours.Count; i++)
			{
				if (IsInFOV(_aligementNeighbours[i].MyTransform.position))
				{
					neighboursInFOV++;
					aligementVector += _aligementNeighbours[i].MyTransform.forward;
				}
			}

			aligementVector /= neighboursInFOV;
			aligementVector = aligementVector.normalized;
			return aligementVector;
		}

		private Vector3 CalculateAvoidanceVector()
		{
			var avoidanceVector = Vector3.zero;
			if (_aligementNeighbours.Count == 0)
				return Vector3.zero;
			int neighboursInFOV = 0;
			for (int i = 0; i < _avoidanceNeighbours.Count; i++)
			{
				if (IsInFOV(_avoidanceNeighbours[i].MyTransform.position))
				{
					neighboursInFOV++;
					avoidanceVector += (MyTransform.position - _avoidanceNeighbours[i].MyTransform.position);
				}
			}

			avoidanceVector /= neighboursInFOV;
			avoidanceVector = avoidanceVector.normalized;
			return avoidanceVector;
		}

		private Vector3 CalculateBoundsVector()
		{
			var offsetToCenter = _assignedFlock.transform.position - MyTransform.position;
			var isNearCenter = (offsetToCenter.magnitude >= _assignedFlock.boundsDistance * 0.9f);
			return isNearCenter ? offsetToCenter.normalized : Vector3.zero;
		}

		private Vector3 CalculateObstacleVector()
		{
			var obstacleVector = Vector3.zero;
			RaycastHit hit;
			if (Physics.Raycast(MyTransform.position, MyTransform.forward, out hit, _assignedFlock.obstacleDistance, obstacleMask))
			{
				obstacleVector = FindBestDirectionToAvoidObstacle();
			}
			else
			{
				_currentObstacleAvoidanceVector = Vector3.zero;
			}
			return obstacleVector;
		}

		private Vector3 FindBestDirectionToAvoidObstacle()
		{
			if(_currentObstacleAvoidanceVector != Vector3.zero)
			{
				if(!Physics.Raycast(MyTransform.position, MyTransform.forward, out _, _assignedFlock.obstacleDistance, obstacleMask))
				{
					return _currentObstacleAvoidanceVector;
				}
			}
			
			float maxDistance = int.MinValue;
			var selectedDirection = Vector3.zero;
			for (int i = 0; i < directionsToCheckWhenAvoidingObstacles.Length; i++)
			{
				var currentDirection = MyTransform.TransformDirection(directionsToCheckWhenAvoidingObstacles[i].normalized);
				
				if(Physics.Raycast(MyTransform.position, currentDirection, out var hit, _assignedFlock.obstacleDistance, obstacleMask))
				{

					float currentDistance = (hit.point - MyTransform.position).sqrMagnitude;
					if(currentDistance > maxDistance)
					{
						maxDistance = currentDistance;
						selectedDirection = currentDirection;
					}
				}
				else
				{
					selectedDirection = currentDirection;
					_currentObstacleAvoidanceVector = currentDirection.normalized;
					return selectedDirection.normalized;
				}
			}
			return selectedDirection.normalized;
		}

		private bool IsInFOV(Vector3 position)
		{
			return Vector3.Angle(MyTransform.forward, position - MyTransform.position) <= fovAngle;
		}
	}
}