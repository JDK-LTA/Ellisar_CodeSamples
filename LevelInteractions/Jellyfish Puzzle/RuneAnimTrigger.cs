using Ellisar.EllisarAssets.Scripts.LevelInteractions.TriggerSystem.Animations;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Jellyfish_Puzzle
{
    public class RuneAnimTrigger : AnimationTriggerSpecificTransformation
    {
        [SerializeField] private Color emissiveColor;
        private Renderer _renderer;

        protected void Start()
        {
            _renderer = GetComponent<Renderer>();
            _renderer.material.SetVector("_EmissionColor", emissiveColor * 0);
        }

        protected override void SpecificTriggerAction()
        {
            base.SpecificTriggerAction();
            _renderer.material.SetVector("_EmissionColor", emissiveColor * 600);
        }
    }
}
