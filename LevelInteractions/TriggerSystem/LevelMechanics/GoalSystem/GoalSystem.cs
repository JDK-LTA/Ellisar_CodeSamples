using System.Collections;
using Ellisar.EllisarAssets.Scripts.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.LevelMechanics.GoalSystem
{
    public class GoalSystem : TriggerEnter
    {
        [Title("Goals Specific")]
        //[SerializeField] private GameObject goal;
        [SerializeField] private GameObject goalCanvas;
        [SerializeField] private GameObject soundEmitter;
        [SerializeField] private GameObject bag;
        [SerializeField] private ParticleSystem particles;
        [Space(10), SerializeField] private bool achievement = true;
        [SerializeField, ShowIf("achievement")] private string achievementName = "FishBag_0";
        [SerializeField, ShowIf("achievement")] private int achievementIndex = 0;

        protected override void TriggerAction()
        {
            if(bag) 
                bag.SetActive(false);
            if(particles)
                particles.Play();
                
            GetComponent<Collider>().enabled = false;
            
            if(soundEmitter)
            {
                var transform1 = transform;
                Instantiate(soundEmitter, transform1.position, transform1.rotation);
            }

            if (achievement && SteamManager.Instance)
            {
                SteamManager.Instance.UnlockAchievement(achievementName);
                SteamManager.Instance.AddToGoldfish(achievementIndex);
            }
            //StartCoroutine(TextGoal());
        }

        IEnumerator TextGoal()
        {
            if(goalCanvas)
                goalCanvas.SetActive(true);

            yield return new WaitForSeconds(5f);
        
            if(goalCanvas)
                goalCanvas.SetActive(false);
            // Destroy(gameObject);
        }
    }
}
