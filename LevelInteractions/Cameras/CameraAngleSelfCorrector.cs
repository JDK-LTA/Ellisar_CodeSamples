using Cinemachine;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Cameras
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class CameraAngleSelfCorrector : MonoBehaviour
    {
        [SerializeField] private float startAngle;
    
        private void Start()
        {
            GetComponent<CinemachineFreeLook>().m_XAxis.Value = startAngle;
        }
    }
}
