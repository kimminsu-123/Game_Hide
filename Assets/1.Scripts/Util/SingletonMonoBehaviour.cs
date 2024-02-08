using System;
using UnityEngine;

namespace Com.Hide.Utils
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour
    {
        public bool dontDestroyGameObject = false;
        
        private static T _instance;
        public static T Instance => _instance; 

        private void Awake()
        {
            if(_instance != null)
                Destroy(gameObject);
            
            _instance = GetComponent<T>();
            
            if(dontDestroyGameObject)
                DontDestroyOnLoad(gameObject);
            
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }
        
        protected virtual void OnDestroy()
        {
            _instance = default;
        }
    }
}