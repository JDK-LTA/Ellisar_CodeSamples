using System.Collections;
using Ellisar.EllisarAssets.Scripts.Utilities.Visuals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.LevelMechanics.GoalSystem
{
    public class GoalSystemBigOrb : TriggerEnter
    {
        [Title("Goal Big Orb Specific")]
        [SerializeField] private GameObject bigOrbCanvas;
        [SerializeField] private ParticleSystem particles;
        [SerializeField] private GameObject soundEmitter;

        protected override void TriggerAction()
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            StartCoroutine(TextGoal());

            var transform1 = transform;
            Instantiate(soundEmitter, transform1.position, transform1.rotation);
            
            if (particles)
                PlayParticleSystemInPlace.PlayParticlesInPlace(particles, transform);            
        }

        IEnumerator TextGoal()
        {
            if(bigOrbCanvas)
                bigOrbCanvas.SetActive(true);

            yield return new WaitForSeconds(5f);

            if (bigOrbCanvas) 
                bigOrbCanvas.SetActive(false);
            Destroy(gameObject);
        }
    }
}