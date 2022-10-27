using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.OnDestroyOrDisable
{
    public class DisableGameobjectOnDestroy : MonoBehaviour
    {
        [SerializeField] private GameObject objectToDisable;

        private void OnDestroy()
        {
            objectToDisable.SetActive(false);
        }
    }
}
