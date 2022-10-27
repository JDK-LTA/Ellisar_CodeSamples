using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.Interactables
{
    public class MaterialInitializator : MonoBehaviour
    {
        [SerializeField] private List<MaterialVariable> variables;

        private void Start()
        {
            var block = new MaterialPropertyBlock();
            var rend = GetComponent<Renderer>();
            
            rend.GetPropertyBlock(block);

            foreach (var v in variables)
            {
                switch(v.type)
                {
                    case MaterialType.Float:
                        block.SetFloat(v.name, v.floatValue);
                        break;
                    case MaterialType.Int:
                        block.SetInt(v.name, v.intValue);
                        break;
                    case MaterialType.Bool:
                        var val = v.boolValue ? 1f : 0f;
                        block.SetFloat(v.name, val);
                        break;
                    case MaterialType.Color:
                        block.SetColor(v.name, v.color);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            rend.SetPropertyBlock(block);
        }

        private enum MaterialType
        {
            Float, Int, Bool, Color
        }

        [Serializable]
        private class MaterialVariable
        {
            public string name;
            public MaterialType type;
            [ShowIf("@type == MaterialType.Float")] public float floatValue;
            [ShowIf("@type == MaterialType.Int")] public int intValue;
            [ShowIf("@type == MaterialType.Bool")] public bool boolValue;
            [ColorUsage(true, true), ShowIf("@type == MaterialType.Color")] public Color color = Color.white;
        }
    }
}
