using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Com.Hide.Utils
{
    public static class Logger
    {
        [Conditional("UNITY_EDITOR")]
        public static void Log(string title, string msg)
        {
            Debug.Log($"[{title}] : {msg}");
        }
        
        [Conditional("UNITY_EDITOR")]
        public static void LogError(string title, string msg)
        {
            Debug.LogError($"[{title}] : {msg}");
        }
        
        [Conditional("UNITY_EDITOR")]
        public static void LogWarning(string title, string msg)
        {
            Debug.LogWarning($"[{title}] : {msg}");
        }
    }
}