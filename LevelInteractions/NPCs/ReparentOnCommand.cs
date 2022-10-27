using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.NPCs
{
    public class ReparentOnCommand : MonoBehaviour
    {
        [SerializeField] private Transform parentToChangeTo;
        [SerializeField] private bool reparentSelf = true;
        [SerializeField, ShowIf("@!reparentSelf")] private Transform childToReparent;
        
        public void Reparent()
        {
            if (reparentSelf)
            {
                childToReparent = transform;
            }

            childToReparent.SetParent(parentToChangeTo, true);
        }
    }
}
