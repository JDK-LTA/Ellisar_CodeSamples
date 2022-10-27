using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Ellisar.EllisarAssets.Scripts.Utilities.Visuals
{
    public class PostprocessingToggler : MonoBehaviour
    {
        [SerializeField] private List<VolumeProfile> volumes;
        private List<Bloom> _blooms = new List<Bloom>();
        private List<DepthOfField> _depthOfFields = new List<DepthOfField>();
        private List<ChromaticAberration> _chromaticAberrations = new List<ChromaticAberration>();

        private void Start()
        {

            if (volumes.Count > 0)
                foreach (var vol in volumes)
                {
                    vol.TryGet(out Bloom bloom);
                    _blooms.Add(bloom);

                    vol.TryGet(out DepthOfField depthOfField);
                    _depthOfFields.Add(depthOfField);

                    vol.TryGet(out ChromaticAberration chromaticAberration);
                    _chromaticAberrations.Add(chromaticAberration);
                }
        }


        public void ToggleBloom(bool active)
        {
            foreach (var bloom in _blooms)
            {
                bloom.active = active;
            }
        }

        public void ToggleChromaticAberration(bool active)
        {
            foreach (var chromaticAberration in _chromaticAberrations)
            {
                chromaticAberration.active = active;
            }
        }

        public void ToggleDepthOfField(bool active)
        {
            foreach (var depthOfField in _depthOfFields)
            {
                depthOfField.active = active;
            }
        }
    }
}