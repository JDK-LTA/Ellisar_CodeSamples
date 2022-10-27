using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class MenuCamerasManager : MonoBehaviour
    {
        public static MenuCamerasManager Instance;
    
        [SerializeField] private MMFeedbacks fadeFeedback;
        [FormerlySerializedAs("levelCameras")] [SerializeField] private List<BgVideos> bgVideosList;
        [SerializeField, ReadOnly] private List<BgVideos> availableVideos;
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField, ReadOnly] private int camIndex = 0;
        [SerializeField, ReadOnly] private bool systemActivated = false;
        private float _timerT = 0;

        public int CamIndex
        {
            get => camIndex;
            set
            {
                camIndex = value;
                if (camIndex >= availableVideos.Count)
                    camIndex = 0;
                
                videoPlayer.Stop();
                videoPlayer.clip = availableVideos[camIndex].clip;
                videoPlayer.Play();
            }
        }
        
        public bool SystemActivated
        {
            get => systemActivated;
            set => systemActivated = value;
        }
        
        private void Awake()
        {
            Instance = this;
        
            availableVideos = new List<BgVideos>(bgVideosList.Where(x => x.available));

            if (availableVideos.Count > 0)
            {
                videoPlayer.clip = availableVideos[camIndex].clip;
                videoPlayer.Play();
            }
        }
        
        private void Update()
        {
            if (!SystemActivated) return;
            if (availableVideos.Count <= 1) return;
        
            _timerT += Time.deltaTime;
            if (_timerT >= availableVideos[camIndex].time)
            {
                _timerT = 0;
                fadeFeedback.PlayFeedbacks();
            }
        }
        
        public void SetLevelCameraAvailable(int index)
        {
            if (index < bgVideosList.Count && !bgVideosList[index].available)
            {
                bgVideosList[index].available = true;
                availableVideos.Add(bgVideosList[index]);
            }
        }
        public void SetLevelCameraUnavailable(int index)
        {
            if (index < bgVideosList.Count && bgVideosList[index].available)
            {
                bgVideosList[index].available = false;
                availableVideos.Remove(bgVideosList[index]);
            }
        }
        public void SetCurrentLevelCamActive(bool active)
        {
            if (camIndex < availableVideos.Count && camIndex >= 0 && availableVideos[camIndex] != null)
            {
                videoPlayer.Stop();
                videoPlayer.clip = availableVideos[camIndex].clip;
                videoPlayer.Play();
            }
        }

        public void CamIndexPlus()
        {
            CamIndex++;
        }
    }

    [Serializable]
    public class BgVideos
    {
        public VideoClip clip;
        public bool available = false;
        public float time = 15f;
    }
}