using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Player.Serializables
{
    [Serializable][ShowOdinSerializedPropertiesInInspector]
    public class PlayerConditions
    {
        [SerializeField] private Dictionary<string, bool> conditions;

        public Dictionary<string, bool> Conditions => conditions;
    }

    [Serializable]
    public class Condition
    {
        [SerializeField] private string conditionKey;
        [SerializeField] private bool conditionValue;

        public string ConditionKey
        {
            get => conditionKey;
            set => conditionKey = value;
        }

        public bool ConditionValue
        {
            get => conditionValue;
            set => conditionValue = value;
        }

        public Condition()
        {
            
        }
        
        public Condition(string conditionKey, bool conditionValue)
        {
            ConditionKey = conditionKey;
            ConditionValue = conditionValue;
        }
    }
    
}