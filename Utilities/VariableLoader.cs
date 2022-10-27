using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ellisar.EllisarAssets.Scripts.Utilities
{
    public class VariableLoader : SerializedMonoBehaviour
    {
        [SerializeField, OnValueChanged("LoadVariables", true)]
        private Object objectOfVariables;

        private FieldInfo[] _objectFields;

        private PropertyInfo[] _objectProperties;

        [SerializeField] private Dictionary<string, int> intVariables;

        [SerializeField] private Dictionary<string, float> floatVariables;

        [SerializeField] private Dictionary<string, string> stringVariables;

        [SerializeField] private Dictionary<string, Object> objectVariables;

        [SerializeField] private Dictionary<string, ICollection> objectsVariables;


        private void LoadVariables()
        {
            intVariables = new Dictionary<string, int>();
            floatVariables = new Dictionary<string, float>();
            stringVariables = new Dictionary<string, string>();
            objectVariables = new Dictionary<string, Object>();
            objectsVariables = new Dictionary<string, ICollection>();

            if (objectOfVariables == null) return;

            const BindingFlags flags =
                (BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var info in objectOfVariables.GetType().GetFields(flags))
            {
                if (info.IsDefined(typeof(ObsoleteAttribute), true)) continue;

                switch (info.GetValue(objectOfVariables))
                {
                    case int value:
                        intVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;

                    case float value:
                        floatVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;

                    case string value:
                        stringVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;

                    case Object value:
                        objectVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;

                    case ICollection value:
                        objectsVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;
                }
            }

            foreach (var info in objectOfVariables.GetType().GetProperties(flags))
            {
                if (info.IsDefined(typeof(ObsoleteAttribute), true)) continue;

                switch (info.GetValue(objectOfVariables))
                {
                    case int value:
                        intVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;

                    case float value:
                        floatVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;

                    case string value:
                        stringVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;


                    case Object value:
                        objectVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;

                    case ICollection value:
                        objectsVariables.Add(info.Name, value);
                        Debug.Log(value);
                        break;
                }
            }
        }
    }
}