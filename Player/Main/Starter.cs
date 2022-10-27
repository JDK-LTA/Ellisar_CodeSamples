using System.Collections;
using System.Linq;
using Cinemachine;
using Ellisar.EllisarAssets.Scripts.Enums;
using Ellisar.EllisarAssets.Scripts.Player.Animations;
using Ellisar.EllisarAssets.Scripts.UI;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Main
{
    public class Starter : MonoBehaviour
    {
        [InfoBox("Enable this to start the game properly.")]
        [SerializeField] private PlayerPhysicsController player;
        [SerializeField, HorizontalGroup("inputFly", 0.1f), HideLabel] private bool inputFly = true;
        [SerializeField, HorizontalGroup("inputFly", 0.9f, -25), ValueDropdown("GetSkillIndex", HideChildProperties = true, CopyValues = true)] private string transformToFly;
        [SerializeField, HorizontalGroup("anim", 0.1f), HideLabel] private bool starterAnim = true;
        [SerializeField, HorizontalGroup("anim", 0.9f, -25)] private PlayerAnimationController playerAnimation;
        [SerializeField, HorizontalGroup("menu", 0.1f), HideLabel] private bool starterMenu = true;
        [SerializeField, HorizontalGroup("menu", 0.9f, -25)] private MainMenuManager menu; 
        [SerializeField, HorizontalGroup("menuCams", 0.1f), HideLabel] private bool starterMenuCams = true;
        [SerializeField, HorizontalGroup("menuCams", 0.9f, -25)] private MenuCamerasManager menuCams;
        [SerializeField, HorizontalGroup("cinem", 0.1f), HideLabel] private bool starterCinematic = true;
        [SerializeField, HorizontalGroup("cinem", 0.9f, -25)] private MMFeedbacks initialCinematic;
        [SerializeField, HorizontalGroup("houseCam", 0.1f), HideLabel] private bool starterHouseCam = true;
        [SerializeField, HorizontalGroup("houseCam", 0.9f, -25)] private CinemachineFreeLook houseCam;
        
        private IEnumerable GetSkillIndex()
        {
            var playerController = (PlayerController) FindObjectOfType(typeof (PlayerController));
            if (playerController == null) return null;
            var playerSkillsList = playerController.PlayerSkills;
            var aux = playerSkillsList.ToArray().Select(value => new ValueDropdownItem(value.Name, value.Name));
            return aux;
        }
        private void OnEnable()
        {
            if (player)
            {
                player.BipedIndex = 2;
                player.SetBipedData();
            
                player.transform.position = transform.position;
                player.transform.rotation = transform.rotation;
                Physics.SyncTransforms();
            }
            
            if(inputFly) DisableFly();
        
            if(playerAnimation && starterAnim) playerAnimation.StartInWalkOnly = true;

            if(menu && starterMenu) menu.gameObject.SetActive(true);
            if(menuCams && starterMenuCams) menuCams.gameObject.SetActive(true);
        
            if(initialCinematic && starterCinematic) initialCinematic.gameObject.SetActive(true);
            
            if(houseCam && starterHouseCam) houseCam.gameObject.SetActive(true);

            enabled = false;
        }

        private void DisableFly()
        {
            var playerController = PlayerSetup.PlayerController;
            var playerSkill = playerController.PlayerSkills.Find(x => x.Name == transformToFly);
            if (playerSkill == null || playerSkill.State != SkillState.Enabled) return;
            playerSkill.State = SkillState.Disabled;
            playerController.DisableSkill(playerSkill);
        }
    }
}
