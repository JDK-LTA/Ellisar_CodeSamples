using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ellisar
{
    public class ResetAllBindings : MonoBehaviour
    {
        [SerializeField] private InputActionAsset IAA;

        public void ResetBindings()
        {
            foreach (InputActionMap IAM in IAA.actionMaps)
            {
                IAM.RemoveAllBindingOverrides();
            }
        }
    }
}
