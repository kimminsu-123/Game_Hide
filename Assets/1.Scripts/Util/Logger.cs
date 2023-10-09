using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Com.Hide.Utils
{
    public static class Logger
    {
        [Conditional("UNITY_EDITOR")]
        public static void Log(string msg)
        {
            Debug.Log(msg);
        }
        
        [Conditional("UNITY_EDITOR")]
        public static void LogError(string msg)
        {
            Debug.LogError(msg);
        }
        
        [Conditional("UNITY_EDITOR")]
        public static void LogWarning(string msg)
        {
            Debug.LogWarning(msg);
        }
    }
}