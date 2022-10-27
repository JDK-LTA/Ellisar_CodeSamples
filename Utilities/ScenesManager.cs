using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Enums;
using UnityEngine.Events;
using UnityEngine.Playables;
using Cinemachine;
using Ellisar.EllisarAssets.Scripts.Audio;
using AK.Wwise;
using MoreMountains.Feedbacks;

namespace Ellisar.EllisarAssets.Scripts.Utilities
{
    public class ScenesManager : MonoBehaviour
    {
        [Serializable]
        public enum SceneState
        {
            Start, Village, FlyTuto, TownCrab, WaterStream, Graveyard, Spyro, Final, CaveOut, SpyroMid
        }


        public static ScenesManager Instance;
        [SerializeField] private bool startScenesAdditive = true;
        [SerializeField] private List<GameObject> seaAngels;
        [SerializeField] private UnityEvent loadCallback, resetterEvent;
        [SerializeField] private Animator savingText;
        [SerializeField] private PlayableDirector initialCinematic;
        [SerializeField] private CinemachineFreeLook houseCam, standardCam;
        [SerializeField] private State none, village, tutSwim, waterStreams, graveyard, spyroMusic ,final;
        [SerializeField] private GameObject corruptionStartTunnel;
        [SerializeField] private MMFeedbacks faderFeedback;
        [SerializeField]
        private Transform startPoint, caveOutPoint, villagePoint, flyPoint,
            crabPoint, waterPoint, gravePoint, spyroPoint, spyroMidPoint, finalPoint;
        [SerializeField] private Transform seaAngelStartPos1, seaAngelStartPos2, seaAngelStartPos3;
        private SceneState _scenesState = SceneState.Start;

        public bool[] Goldfishes = new bool[9];

        [ShowInInspector]
        public SceneState ScenesState
        {
            get => _scenesState;
            set
            {
                _scenesState = value;
            }
        }

        public void SetScenesState(int i)
        {
            ScenesState = (SceneState)i;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            if (startScenesAdditive)
            {
                LoadScene();
            }
        }

        private void EndLoading()
        {
            resetterEvent?.Invoke();

            if (ScenesState != SceneState.Start)
            {
                faderFeedback.PlayFeedbacks();
                loadCallback?.Invoke();
            }
        }

        public void SavingUI()
        {
            savingText.SetTrigger("Save");
        }

        public void SetSkillActive()
        {
            var playerController = PlayerSetup.PlayerController;
            var playerSkill = playerController.PlayerSkills.Find(x => x.Name == "Transformation to Fly");
            if (playerSkill == null || playerSkill.State != SkillState.Disabled) return;
            playerSkill.State = SkillState.Enabled;
            playerSkill.Equip = SkillEquip.Default;
            playerController.InitializeSkill(playerSkill);
        }
        public void SetSkillInactive()
        {
            var playerController = PlayerSetup.PlayerController;
            var playerSkill = playerController.PlayerSkills.Find(x => x.Name == "Transformation to Fly");
            if (playerSkill == null || playerSkill.State != SkillState.Enabled) return;
            playerSkill.State = SkillState.Disabled;
            playerSkill.Equip = SkillEquip.PowerUp;
            playerController.DisableSkill(playerSkill);
        }

        public void ClearLoadedScenes()
        {
            ClearLoadedScenesNoAudioChange();

            AudioManager.Instance?.SetAreaLayer(none);
        }

        public void ClearLoadedScenesNoAudioChange()
        {
            int countLoaded = SceneManager.sceneCount;
            Scene[] loadedScenes = new Scene[countLoaded];

            for (int i = 0; i < countLoaded; i++)
            {
                loadedScenes[i] = SceneManager.GetSceneAt(i);
            }

            for (int i = loadedScenes.Length - 1; i >= 0; i--)
            {
                Scene ls = loadedScenes[i];
                if (ls != SceneManager.GetActiveScene())
                {
                    SceneManager.UnloadSceneAsync(ls);
                }
            }
        }

        public void LoadScene()
        {
            ClearLoadedScenes();

            switch (ScenesState)
            {
                case SceneState.Start:
                    SetSkillInactive();
                    SceneManager.LoadScene(1, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = startPoint.position;
                    PlayerSetup.CharController.transform.rotation = startPoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 2;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(true);
                    houseCam.m_XAxis.Value = startPoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(false);
                    seaAngels[1].transform.position = seaAngelStartPos1.position;
                    seaAngels[1].transform.rotation = seaAngelStartPos1.rotation;
                    Physics.SyncTransforms();
                    seaAngels[2].SetActive(false);
                    seaAngels[2].transform.position = seaAngelStartPos2.position;
                    seaAngels[2].transform.rotation = seaAngelStartPos2.rotation;
                    Physics.SyncTransforms();
                    seaAngels[3].SetActive(false);
                    seaAngels[3].transform.position = seaAngelStartPos3.position;
                    seaAngels[3].transform.rotation = seaAngelStartPos3.rotation;
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = true;
                    PlayerSetup.PlayerAnimationController.WalkOnly();
                    PlayerPhysicsController.MaxActionsAmount = 2;

                    corruptionStartTunnel.SetActive(false);
                    initialCinematic.Play();
                    break;
                case SceneState.CaveOut:
                    SetSkillInactive();
                    SceneManager.LoadScene(1, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = caveOutPoint.position;
                    PlayerSetup.CharController.transform.rotation = caveOutPoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 1;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(false);
                    standardCam.m_XAxis.Value = caveOutPoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(false);
                    seaAngels[1].transform.position = seaAngelStartPos1.position;
                    seaAngels[1].transform.rotation = seaAngelStartPos1.rotation;
                    Physics.SyncTransforms();
                    seaAngels[2].SetActive(false);
                    seaAngels[2].transform.position = seaAngelStartPos2.position;
                    seaAngels[2].transform.rotation = seaAngelStartPos2.rotation;
                    Physics.SyncTransforms();
                    seaAngels[3].SetActive(false);
                    seaAngels[3].transform.position = seaAngelStartPos3.position;
                    seaAngels[3].transform.rotation = seaAngelStartPos3.rotation;
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = false;
                    PlayerSetup.PlayerAnimationController.WalkOnly();

                    PlayerPhysicsController.MaxActionsAmount = 2;
                    AudioManager.Instance.SetAreaLayer(none);
                    break;
                case SceneState.Village:
                    SetSkillInactive();
                    SceneManager.LoadScene(2, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = villagePoint.position;
                    PlayerSetup.CharController.transform.rotation = villagePoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 1;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(false);
                    standardCam.m_XAxis.Value = villagePoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(false);
                    seaAngels[1].transform.position = seaAngelStartPos1.position;
                    seaAngels[1].transform.rotation = seaAngelStartPos1.rotation;
                    Physics.SyncTransforms();
                    seaAngels[2].SetActive(false);
                    seaAngels[2].transform.position = seaAngelStartPos2.position;
                    seaAngels[2].transform.rotation = seaAngelStartPos2.rotation;
                    Physics.SyncTransforms();
                    seaAngels[3].SetActive(false);
                    seaAngels[3].transform.position = seaAngelStartPos3.position;
                    seaAngels[3].transform.rotation = seaAngelStartPos3.rotation;
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = false;
                    PlayerSetup.PlayerAnimationController.WalkOnly();

                    PlayerPhysicsController.MaxActionsAmount = 2;
                    AudioManager.Instance.SetAreaLayer(village);
                    break;
                case SceneState.FlyTuto:
                    SetSkillActive();
                    SceneManager.LoadScene(2, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = flyPoint.position;
                    PlayerSetup.CharController.transform.rotation = flyPoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 1;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(false);
                    standardCam.m_XAxis.Value = flyPoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[1].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(true);
                    seaAngels[2].SetActive(false);
                    seaAngels[2].transform.position = seaAngelStartPos2.position;
                    seaAngels[2].transform.rotation = seaAngelStartPos2.rotation;
                    Physics.SyncTransforms();
                    seaAngels[3].SetActive(false);
                    seaAngels[3].transform.position = seaAngelStartPos3.position;
                    seaAngels[3].transform.rotation = seaAngelStartPos3.rotation;
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = false;
                    PlayerSetup.PlayerAnimationController.WalkOnly();

                    PlayerPhysicsController.MaxActionsAmount = 2;
                    AudioManager.Instance.SetAreaLayer(tutSwim);
                    break;
                case SceneState.TownCrab:
                    SetSkillActive();
                    SceneManager.LoadScene(2, LoadSceneMode.Additive);
                    SceneManager.LoadScene(3, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = crabPoint.position;
                    PlayerSetup.CharController.transform.rotation = crabPoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 1;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(false);
                    standardCam.m_XAxis.Value = crabPoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[1].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(true);
                    seaAngels[2].SetActive(false);
                    seaAngels[2].transform.position = seaAngelStartPos2.position;
                    seaAngels[2].transform.rotation = seaAngelStartPos2.rotation;
                    Physics.SyncTransforms();
                    seaAngels[3].SetActive(false);
                    seaAngels[3].transform.position = seaAngelStartPos3.position;
                    seaAngels[3].transform.rotation = seaAngelStartPos3.rotation;
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = false;
                    PlayerSetup.PlayerAnimationController.WalkOnly();

                    PlayerPhysicsController.MaxActionsAmount = 2;
                    AudioManager.Instance.SetAreaLayer(tutSwim);
                    break;
                case SceneState.WaterStream:
                    SetSkillActive();
                    SceneManager.LoadScene(3, LoadSceneMode.Additive);
                    SceneManager.LoadScene(4, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = waterPoint.position;
                    PlayerSetup.CharController.transform.rotation = waterPoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 1;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(false);
                    standardCam.m_XAxis.Value = waterPoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[1].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[2].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(true);
                    seaAngels[2].SetActive(true);
                    seaAngels[3].SetActive(false);
                    seaAngels[3].transform.position = seaAngelStartPos3.position;
                    seaAngels[3].transform.rotation = seaAngelStartPos3.rotation;
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = false;
                    PlayerSetup.PlayerAnimationController.WalkOnly();

                    PlayerPhysicsController.MaxActionsAmount = 3;
                    AudioManager.Instance.SetAreaLayer(waterStreams);
                    break;
                case SceneState.Graveyard:
                    SetSkillActive();
                    SceneManager.LoadScene(3, LoadSceneMode.Additive);
                    SceneManager.LoadScene(4, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = gravePoint.position;
                    PlayerSetup.CharController.transform.rotation = gravePoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 1;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(false);
                    standardCam.m_XAxis.Value = gravePoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[1].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[2].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(true);
                    seaAngels[2].SetActive(true);
                    seaAngels[3].SetActive(false);
                    seaAngels[3].transform.position = seaAngelStartPos3.position;
                    seaAngels[3].transform.rotation = seaAngelStartPos3.rotation;
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = false;
                    PlayerSetup.PlayerAnimationController.WalkOnly();

                    PlayerPhysicsController.MaxActionsAmount = 3;
                    AudioManager.Instance.SetAreaLayer(graveyard);
                    break;
                case SceneState.Spyro:
                    SetSkillActive();
                    SceneManager.LoadScene(5, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = spyroPoint.position;
                    PlayerSetup.CharController.transform.rotation = spyroPoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 1;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(false);
                    standardCam.m_XAxis.Value = spyroPoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[1].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[2].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(true);
                    seaAngels[2].SetActive(true);
                    seaAngels[3].SetActive(false);
                    seaAngels[3].transform.position = seaAngelStartPos3.position;
                    seaAngels[3].transform.rotation = seaAngelStartPos3.rotation;
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = false;
                    PlayerSetup.PlayerAnimationController.WalkOnly();

                    PlayerPhysicsController.MaxActionsAmount = 3;
                    break;
                case SceneState.SpyroMid:
                    SetSkillActive();
                    SceneManager.LoadScene(5, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = spyroMidPoint.position;
                    PlayerSetup.CharController.transform.rotation = spyroMidPoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 1;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(false);
                    standardCam.m_XAxis.Value = spyroMidPoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[1].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[2].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[3].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(true);
                    seaAngels[2].SetActive(true);
                    seaAngels[3].SetActive(true);
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = false;
                    PlayerSetup.PlayerAnimationController.WalkOnly();

                    PlayerPhysicsController.MaxActionsAmount = 4;
                    AudioManager.Instance.SetAreaLayer(spyroMusic);
                    break;
                case SceneState.Final:
                    SetSkillActive();
                    SceneManager.LoadScene(6, LoadSceneMode.Additive);

                    PlayerSetup.CharController.transform.position = finalPoint.position;
                    PlayerSetup.CharController.transform.rotation = finalPoint.rotation;
                    Physics.SyncTransforms();
                    PlayerSetup.PhysicsController.BipedIndex = 1;
                    PlayerSetup.PhysicsController.SetBipedData();

                    houseCam.gameObject.SetActive(false);
                    standardCam.m_XAxis.Value = finalPoint.rotation.eulerAngles.y;

                    seaAngels[0].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[1].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[2].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[3].transform.position = PlayerSetup.CharController.transform.position;
                    seaAngels[0].SetActive(true);
                    seaAngels[1].SetActive(true);
                    seaAngels[2].SetActive(true);
                    seaAngels[3].SetActive(true);
                    Physics.SyncTransforms();

                    PlayerSetup.PlayerAnimationController.StartInWalkOnly = false;
                    PlayerSetup.PlayerAnimationController.WalkOnly();

                    PlayerPhysicsController.MaxActionsAmount = 4;
                    AudioManager.Instance.SetAreaLayer(final);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Physics.SyncTransforms();
            EndLoading();
        }

        public void LoadAdditiveScene(int index)
        {
            if (!SceneManager.GetSceneByBuildIndex(index).isLoaded)
                SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        }

        public void UnloadAdditiveScene(int index)
        {
            if (SceneManager.GetSceneByBuildIndex(index).isLoaded)
                SceneManager.UnloadSceneAsync(index);
        }
    }
}
