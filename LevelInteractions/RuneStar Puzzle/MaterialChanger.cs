using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.RuneStar_Puzzle
{
    public class MaterialChanger : MonoBehaviour
    {
        private MeshRenderer _renderer;
        [MinValue(0), SerializeField] private float minEmissionIntensity = 100;
        [MinValue("@minEmissionIntensity"), SerializeField] private float maxEmissionIntensity = 3f;
        [SerializeField] private float timeToGoUp = 1.5f;
        private float intensity = 100;
        private bool up = true;
        private float t = 0;

        public bool Pulsating { get; set; }

        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            _renderer.material.SetVector("_EmissionColor", Color.white * minEmissionIntensity);
        }

        private void Update()
        {
            if (Pulsating)
            {
                t += Time.deltaTime;
                intensity = up ? Mathf.Lerp(minEmissionIntensity, maxEmissionIntensity, t / timeToGoUp) : Mathf.Lerp(maxEmissionIntensity, minEmissionIntensity, t / timeToGoUp);

                if (t >= timeToGoUp)
                {
                    up = !up;
                    t = 0;
                }
            
                _renderer.material.SetVector("_EmissionColor", Color.white * intensity);
            }
        }
    }
}
