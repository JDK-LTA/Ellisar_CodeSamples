using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class NavigateLeftRight : MonoBehaviour, IMoveHandler
    {
        [SerializeField] private UnityEvent navigateLeft, navigateRight;
        
        public void OnMove(AxisEventData eventData)
        {
            if (eventData.moveDir == MoveDirection.Left)
            {
                navigateLeft?.Invoke();
            }
            else if (eventData.moveDir == MoveDirection.Right)
            {
                navigateRight?.Invoke();
            }
        }
    }
}
