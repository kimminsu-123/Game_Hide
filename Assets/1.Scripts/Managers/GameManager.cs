using System;
using Com.Hide.ScriptableObjects;
using Com.Hide.Utils;
using UnityEditor;
using UnityEngine;

namespace Com.Hide.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private SceneData lobbySceneData;
        
        private void Start()
        {
            SaveDataManager.Instance.Load();
            LoadSceneManager.Instance.LoadSceneAsync(lobbySceneData);
        }

        public void ExitGame()
        {
            #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
            #else
                Application.Quit();
            #endif
        }
    }
}