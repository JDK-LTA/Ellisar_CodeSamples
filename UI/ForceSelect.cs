using UnityEngine;
using UnityEngine.EventSystems;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class ForceSelect : MonoBehaviour, IDeselectHandler
    {
        public void OnDeselect(BaseEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}
