using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.Utilities
{
    public static class Debugger
    {
        public static void MessageDebugger(object message, bool debugMode = true)
        {
            if (debugMode)
                Debug.Log(message);
        }
        
        public static void DebugEvent(string debugString)
        {
            MessageDebugger(debugString);
        }
        
    }
}