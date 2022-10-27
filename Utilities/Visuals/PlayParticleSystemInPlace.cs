using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Utilities.Visuals
{
    public static class PlayParticleSystemInPlace
    {
        public static void PlayParticlesInPlace(ParticleSystem particleSystem)
        {
            var particleSystemMain = particleSystem.main;
            particleSystemMain.playOnAwake = true;
            Object.Instantiate(particleSystem.gameObject);
        }
    
        public static void PlayParticlesInPlace(ParticleSystem particleSystem, Transform transform)
        {
            var particleSystemMain = particleSystem.main;
            particleSystemMain.playOnAwake = true;
            Object.Instantiate(particleSystem.gameObject, transform.position, transform.rotation);
        }

        public static void PlayParticlesInPlace(ParticleSystem particleSystem, Vector3 position)
        {
            var particleSystemMain = particleSystem.main;
            particleSystemMain.playOnAwake = true;
            Object.Instantiate(particleSystem.gameObject, position, Quaternion.identity);
        }
    
        public static void PlayParticlesInPlace(ParticleSystem particleSystem, Vector3 position, Quaternion rotation)
        {
            var particleSystemMain = particleSystem.main;
            particleSystemMain.playOnAwake = true;
            Object.Instantiate(particleSystem.gameObject, position, rotation);
        }
    }
}
