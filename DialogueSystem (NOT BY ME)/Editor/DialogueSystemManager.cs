using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.DialogueSystem.Editor
{
    public class DialogueSystemManager : OdinEditorWindow
    {
        [MenuItem("Tools/Dialogue System Manager")]
        private static void OpenWindow()
        {
            var window = GetWindow<DialogueSystemManager>();

            // Nifty little trick to quickly position the window in the middle of the editor.
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 700);
        }

        [OnValueChanged("UpdateDialogue")]
        public DialogueDatabaseScriptableObject dialogueDatabase;

        [FolderPath(RequireExistingPath = true)]
        public string databasePath = "Assets/EllisarAssets/Dialogue";
        [ShowIf("@dialogueDatabase == null")]
        public string databaseName = "NewDialogueDatabase";

        [PropertyOrder(1), OnValueChanged("UpdateDialogueDatabase"), ShowIf("@dialogueDatabase != null")]
        public List<DialogueData> database;
        
        [Button("Create new database"), ShowIf("@dialogueDatabase == null")]
        private void CreateNewDatabase()
        {
        
            var asset = ScriptableObject.CreateInstance<DialogueDatabaseScriptableObject>();
            var newDatabasePath = databasePath;
            if (!AssetDatabase.IsValidFolder(newDatabasePath))
            {
                while (newDatabasePath[0] == '/')
                {
                    newDatabasePath = newDatabasePath.Remove(0, 1);
                }
                while (newDatabasePath.Last() == '/')
                    newDatabasePath = newDatabasePath.Remove(newDatabasePath.Length - 1);
            
                var paths = newDatabasePath.Split('/');
            
                if (paths[0] != "Assets")
                {
                    newDatabasePath = "Assets/" + newDatabasePath;
                    paths = newDatabasePath.Split('/');
                }

                for (var i = 0; i < paths.Length; i++)
                {
                    if (paths[i] != "") continue;
                    var tempString = "";
                    for (var j = 0; j <= i; j++)
                    {
                        tempString += paths[j] + '/';
                    }
                    
                    newDatabasePath = newDatabasePath.Remove(tempString.Length - 1, 1);
                    paths = newDatabasePath.Split('/');
                    i = 0;
                }

                var checkedPath = "";
                foreach (var newFolderName in paths)
                {
                    if (!AssetDatabase.IsValidFolder(checkedPath + newFolderName))
                    {
                        Debug.Log("path not valid " + checkedPath + newFolderName + ", folder " + newFolderName + " does not exist");
                        if (checkedPath.Last() == '/')
                            checkedPath = checkedPath.Remove(checkedPath.Length - 1);
                        Debug.Log("create folder " + newFolderName + " in " + checkedPath);
                        AssetDatabase.CreateFolder(checkedPath, newFolderName);
                    
                        if (checkedPath.Last() != '/')
                            checkedPath += '/';
                    }
                
                    checkedPath += newFolderName + '/';
                }
            }
        
            if (newDatabasePath.Last() != '/')
                newDatabasePath += '/';
            AssetDatabase.CreateAsset(asset, newDatabasePath + databaseName + ".asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
            dialogueDatabase = asset;
        }
    
        private void UpdateDialogueDatabase()
        {
            if (dialogueDatabase == null || dialogueDatabase.database == null || database == null) return;
            if (database.Count != dialogueDatabase.database.Count || database != dialogueDatabase.database)
            {
                dialogueDatabase.database = database;
                EditorUtility.SetDirty(dialogueDatabase);
                return;
            }

            for (var i = 0; i < database.Count; i++)
            {
                if (!CheckChangedVariables(i)) continue;
                dialogueDatabase.database = database;
                EditorUtility.SetDirty(dialogueDatabase);

            }

        }

        private bool CheckChangedVariables(int databaseIndex)
        {
            return (database[databaseIndex].dialogueText != dialogueDatabase.database[databaseIndex].dialogueText ||
                    database[databaseIndex].useVariant != dialogueDatabase.database[databaseIndex].useVariant ||
                    database[databaseIndex].dialogueTextVariant != dialogueDatabase.database[databaseIndex].dialogueTextVariant ||
                    database[databaseIndex].availableByDefault != dialogueDatabase.database[databaseIndex].availableByDefault ||
                    database[databaseIndex].showVariant != dialogueDatabase.database[databaseIndex].showVariant);
        }
    
        private void UpdateDialogue()
        {
            if (dialogueDatabase != null && dialogueDatabase.database != null)
            {
                database = dialogueDatabase.database;
                var fullAssetPath = AssetDatabase.GetAssetPath(dialogueDatabase);
                databasePath = fullAssetPath.Remove(fullAssetPath.Length - (dialogueDatabase.name + ".asset").Length);
                EditorUtility.SetDirty(dialogueDatabase);
            }
            else
            {
                dialogueDatabase = null;
                database = new List<DialogueData>();
            }
        }
    }
}
