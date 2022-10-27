using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Jellyfish_Puzzle
{
    public class VisitSpot : MonoBehaviour
    {
        [SerializeField] private bool true1False2 = true;
        private bool _isQuitting;
        
        private void OnApplicationQuit()
        {
            _isQuitting = true;
        }

        private void OnDestroy()
        {
            if (!_isQuitting)
            {
                Visit();
            }
        }

        public void Visit()
        {
            if (true1False2)
            {
                JellyfishPuzzleManager.Instance.Spot1Visited = true;
            }
            else
            {
                JellyfishPuzzleManager.Instance.Spot2Visited = true;
            }
        }
    }
}
