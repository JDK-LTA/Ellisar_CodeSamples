using System;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class UILookAt : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private bool noX = false;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void FixedUpdate()
        {
            transform.LookAt(_camera.transform);

            if (noX)
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
