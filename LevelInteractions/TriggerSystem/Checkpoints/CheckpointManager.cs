using Cinemachine;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Player.Serializables.SkillDatas;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Checkpoints
{
    public class CheckpointManager : MonoBehaviour
    {
        public static CheckpointManager Instance;

        [SerializeField] private Vector3 checkPos;
        [SerializeField] private MMFeedbacks deathFeedback;
        [Sirenix.OdinInspector.ShowInInspector]
        public Transform ActualCheckpoint { get; set; }
        public bool BipedRespawn { get; set; } = true;

        private bool _delayUp = false;
        private float _delayComparer;
        private float _delayT = 0;

        public bool StopSpyroAchievement { get; set; } = false;

        private CinemachineBrain _cmBrain;
        private CinemachineFreeLook[] cfls;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _cmBrain = FindObjectOfType<CinemachineBrain>();
            //InitiateCheckpoint();
            cfls = FindObjectsOfType<CinemachineFreeLook>();
        }

        private void LateUpdate()
        {
            if (ActualCheckpoint)
                checkPos = ActualCheckpoint.position;
            if (_delayUp)
            {
                _delayT += Time.deltaTime;
                if (_delayT >= _delayComparer)
                {
                    _delayT = 0;
                    _delayUp = false;
                    RespawnPlayer();
                }
            }
        }

        private void RespawnPlayer()
        {
            CamerasManager.Instance.SetCamerasFollow(true);
            CamerasManager.Instance.SetCamerasRotationX(ActualCheckpoint.rotation.y);

            var _cam = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineFreeLook>();

            if (_cam)
                _cam.m_XAxis.Value = ActualCheckpoint.rotation.y;
            var tr = PlayerSetup.PlayerController.transform;
            tr.position = ActualCheckpoint.position;
            tr.rotation = ActualCheckpoint.rotation;
            Physics.SyncTransforms();
            SkillMovementData.ActualBodyVelocity = Vector3.zero;
            PlayerSetup.PlayerController.CanBeControlled = true;
            ForceTransformation(BipedRespawn);
            _cmBrain.ActiveVirtualCamera.Follow = tr;
        }

        public void InitiateCheckpoint()
        {
            var auxGO = new GameObject
            {
                transform =
                {
                    position = PlayerSetup.PlayerController.transform.position,
                    rotation = PlayerSetup.PlayerController.transform.rotation
                }
            };
            // ActualCheckpoint = Instantiate(null,  PlayerController.Instance.transform.position, PlayerController.Instance.transform.rotation).transform;
            ActualCheckpoint = auxGO.transform;
        }

        public void ForceTransformation(bool biped)
        {
            PlayerSetup.PlayerController.TargetPlayerState = biped ? PlayerModeState.Biped : PlayerModeState.Fly;
            SkillMovementData.IsTransforming = true;
        }

        public void DelayedRespawn(float delay)
        {
            CamerasManager.Instance.SetCamerasFollow(false);

            _delayComparer = delay;
            _delayUp = true;
            _delayT = 0;
            PlayerSetup.PlayerController.CanBeControlled = false;

            if (deathFeedback) deathFeedback.PlayFeedbacks();
        }

        public void PlayDeathFader()
        {
            if (deathFeedback) deathFeedback.PlayFeedbacks();
        }
    }
}
