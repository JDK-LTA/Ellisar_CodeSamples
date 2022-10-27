using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.DialogueSystem
{
    [CreateAssetMenu(fileName = "NewDialogueDatabase", menuName = "Dialogue Database", order = 1)]
    public class DialogueDatabaseScriptableObject : ScriptableObject
    {
        public List<DialogueData> database;
    }

    [Serializable]
    public class DialogueData
    {
        public bool availableByDefault = true;
        [TextArea(2, 6)]
        public string dialogueText = "";
    
        [InfoBox("Is using text variant.", "@(useVariant && !showVariant)")]
        public bool showVariant = false;
        [ShowIf("@showVariant")]
        public bool useVariant = false;
        [TextArea(2, 6), ShowIf("@useVariant && showVariant")]
        public string dialogueTextVariant = "";
    }
}