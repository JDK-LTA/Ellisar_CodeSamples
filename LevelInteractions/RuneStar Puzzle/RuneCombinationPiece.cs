using Ellisar.EllisarAssets.Scripts.Player.Main;
using Ellisar.EllisarAssets.Scripts.Enums;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.RuneStar_Puzzle
{
    public class RuneCombinationPiece : MonoBehaviour
    {
        [SerializeField] private char letter;
        private bool added = false;
        private Renderer _renderer;

        public bool CanBeActivated { get; set; } = false;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            RunePuzzleManager.Instance.ResetPieces += ResetAdded;
        }

        private void ResetAdded()
        {
            added = false;
            _renderer.material.SetVector("_EmissionColor", Color.white * 0);
        }

        // private void OnCollisionEnter(Collision other)
        // {
        //     var pc = other.gameObject.GetComponent<PlayerController>();
        //     if (pc && PlayerController.CurrentPlayerState == PlayerModeState.Agile && !added)
        //     {
        //         RunePuzzleManager.Instance.AddLetterInput(letter);
        //     }
        // }

        private void OnTriggerEnter(Collider other)
        {
            var pc = other.GetComponent<PlayerController>();
            if (CanBeActivated &&pc && PlayerSetup.PlayerController.CurrentPlayerState == PlayerModeState.Agile && !added)
            {
                RunePuzzleManager.Instance.AddLetterInput(letter);
                added = true;
                _renderer.material.SetVector("_EmissionColor", Color.white * 600);
            }
        }
    }
}