using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Cameras
{
	public class ShadowPostprocessChanger : MonoBehaviour
	{
		[SerializeField] private VolumeProfile volume;
		[SerializeField] private Vector3 initValue;
		[SerializeField] private float timeToLerp = 2.5f;
		[SerializeField, ReadOnly] private bool initializedOnStart = false;

		private bool _startLerping = false;
		private float _tLerp = 0;
		private bool _hasLerped = false;
		private ShadowsMidtonesHighlights _smh;
		private Vector4 _initValue, _target;

		private void Start()
		{
			volume.TryGet(out _smh);
			if (_smh)
			{
				_target = _smh.shadows.value;
				_initValue = new Vector4(initValue.x, initValue.y, initValue.z, _target.w);

				_smh.shadows.value = _initValue;
			}
			
			if(initializedOnStart)
				LerpToEndValues();
		}

		public void LerpToEndValues()
		{
			if (!_hasLerped)
			{
				_hasLerped = true;
				_startLerping = true;
				initializedOnStart = true;
			}
		}

		private void Update()
		{
			if (_startLerping && _smh)
			{
				_tLerp += Time.deltaTime;
				_smh.shadows.Interp(_initValue, _target, Mathf.Clamp01(_tLerp / timeToLerp));

				if (_tLerp >= timeToLerp)
				{
					_startLerping = false;
				}
			}
		}
	}
}