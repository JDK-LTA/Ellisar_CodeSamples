using Ellisar.EllisarAssets.Scripts.Player.Main;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.RuneStar_Puzzle
{
    [RequireComponent(typeof(MaterialChanger))]
    public class BallAttractionBehaviour : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float minDistance = 0.5f;
        [SerializeField] private Vector3 targetOffset = Vector3.up;
        [SerializeField, MinValue(0.01f)] private float timeToReach = 4f;
        [Space(10)] [SerializeField] private int runeIndex = 0;
        [HideInInspector] public MaterialChanger matChanger;

        [HideInInspector] public Vector3 initPos;
        private Vector3 _vel = Vector3.zero;
        private float t = 0;

        public bool Attracting { get; set; }

        public int RuneIndex => runeIndex;

        private void Start()
        {
            initPos = transform.position;
            matChanger = GetComponent<MaterialChanger>();
        }

        private void Update()
        {
            if (Attracting)
            {
                var target = PlayerSetup.PlayerController.transform.position;
                target += targetOffset;

                // transform.position = Vector3.SmoothDamp(transform.position, target,ref _vel, smoothTime, maxSpeed);
                t += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, maxSpeed * (t / timeToReach));

                if (Vector3.Distance(transform.position, target) <= minDistance)
                {
                    //VFX
                    if (runeIndex >= 0)
                        RunePuzzleManager.Instance.RemoveBallFromList(this);
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 3)
            {
                Attracting = true;
            }
        }
    }
}