using System.Collections;
using Com.Hide.Handler;
using Com.Hide.ScriptableObjects;
using Com.Hide.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Hide.Managers
{
    public enum SceneType
    {
        None,
        Lobby,
        Room,
        InGame
    }
    
    public class LoadSceneManager : SingletonMonoBehaviour<LoadSceneManager>
    {
        [SerializeField] private LoadingUIHandler loadingUIHandler;
        [SerializeField] private SceneData mainSceneData;
        
        private SceneData _currentLoadedScene;
        private Coroutine _loadSceneCoroutine;

        public void LoadSceneAsync(SceneData sceneData)
        {
            if(_loadSceneCoroutine != null)
                StopCoroutine(_loadSceneCoroutine);
            
            _loadSceneCoroutine = StartCoroutine(LoadSceneCoroutine(sceneData));
        }

        public void UnloadSceneAsync()
        {
            StartCoroutine(UnloadSceneCoroutine());
        }

        private IEnumerator LoadSceneCoroutine(SceneData sceneData)
        {
            loadingUIHandler.Show();

            var operation = SceneManager.LoadSceneAsync(sceneData.BuildIndex, sceneData.Mode);
            while (!operation.isDone)
            {
                loadingUIHandler.UpdateProgress(operation.progress);
                
                yield return null;
            }
            _currentLoadedScene = sceneData;

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneData.SceneName));
            loadingUIHandler.Hide();
            
            EventManager.Instance.PostNotification(EventType.SceneLoaded, this, _currentLoadedScene);
        }

        private IEnumerator UnloadSceneCoroutine()
        {
            var unloadingSceneData = _currentLoadedScene;
            
            var operation = SceneManager.UnloadSceneAsync(_currentLoadedScene.BuildIndex);
            while (!operation.isDone)
            {
                yield return null;
            }
            _currentLoadedScene = null;

            EventManager.Instance.PostNotification(EventType.SceneUnloaded, this, unloadingSceneData);
        }
    }
}