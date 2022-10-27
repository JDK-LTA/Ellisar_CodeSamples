using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Audio
{
    public class SelfDestroyingSoundEmitter : SoundEmitter
    {
        [SerializeField] private bool emitOnSpawn = true;
        [SerializeField] private float timeToDestroy = 10f;
        private bool _selfDestroy = false;
        private float _sdT = 0;

        private void Start()
        {
            if (emitOnSpawn) Post();
        }

        public override void Post()
        {
            base.Post();
            _selfDestroy = true;
        }

        private void Update()
        {
            if (_selfDestroy)
            {
                _sdT += Time.deltaTime;
                if (_sdT >= timeToDestroy)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
