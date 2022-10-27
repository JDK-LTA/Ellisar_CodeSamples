using System;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.LevelMechanics
{
    public class RotateAroundAxis : MonoBehaviour
    {
        [SerializeField] private float rotatingSpeed = 90;
        [SerializeField] private Axis axis;
        [SerializeField] private bool worldSpace = false;
    
        // Update is called once per frame
        void Update()
        {
            Vector3 ax;
            switch (axis)
            {
                case Axis.XAxis:
                    ax = worldSpace ? Vector3.right : transform.right;
                    break;
                case Axis.YAxis:
                    ax = worldSpace ? Vector3.up : transform.up;
                    break;
                case Axis.ZAxis:
                    ax = worldSpace ? Vector3.forward : transform.forward;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        
            transform.Rotate(ax, rotatingSpeed * Time.deltaTime);
        }
    }

    [Serializable]
    public enum Axis
    {
        XAxis,
        YAxis,
        ZAxis
    }
}