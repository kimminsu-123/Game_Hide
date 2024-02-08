using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Com.Hide.Utils
{
    public static class Logger
    {
        [Conditional("UNITY_EDITOR")]
        public static void Log(string title, string msg, Color? color = null)
        {
            color ??= Color.white;
            
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGBA(color.Value)}>[{title}] : {msg}</color>");
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