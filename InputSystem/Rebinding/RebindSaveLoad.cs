using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ellisar
{
    public class RebindSaveLoad : MonoBehaviour
    {
        public InputActionAsset IAA;

        public void OnEnable()
        {
            //var rebinds = PlayerPrefs.GetString("rebinds");
            //if(!string.IsNullOrEmpty(rebinds))
                //IAA.LoadFromJson(rebinds);
        }

        public void OnDisable()
        {
            //var rebinds = actions.SaveBindingOverridesAsJson();
            //PlayerPrefs.SetString("rebinds", rebinds);
        }

    }
}
