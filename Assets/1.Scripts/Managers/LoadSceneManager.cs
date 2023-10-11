using System.Collections;
using Com.Hide.Handler;
using Com.Hide.ScriptableObjects;
using Com.Hide.Utils;
using Photon.Pun;
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

            if(sceneData.IsNetworkSynchronize)
                yield return LoadSceneNetworking(sceneData);
            else
                yield return LoadSceneNotNetworking(sceneData);
            
            _currentLoadedScene = sceneData;

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneData.SceneName));
            loadingUIHandler.Hide();
            
            EventManager.Instance.PostNotification(EventType.SceneLoaded, this, _currentLoadedScene);
        }

        private IEnumerator LoadSceneNotNetworking(SceneData sceneData)
        {
            var operation = SceneManager.LoadSceneAsync(sceneData.BuildIndex, sceneData.Mode);
            while (!operation.isDone)
            {
                loadingUIHandler.UpdateProgress(operation.progress);
                
                yield return null;
            }
            
            loadingUIHandler.UpdateProgress(1f);
        }
        
        private IEnumerator LoadSceneNetworking(SceneData sceneData)
        {
            if(NetworkManager.Instance.IsHost)
                PhotonNetwork.LoadLevel(sceneData.BuildIndex, sceneData.Mode);
            
            while (PhotonNetwork.LevelLoadingProgress < 1f)
            {
                loadingUIHandler.UpdateProgress(PhotonNetwork.LevelLoadingProgress);
                
                yield return null;
            }
            
            loadingUIHandler.UpdateProgress(1f);
        }

        private IEnumerator UnloadSceneCoroutine()
        {
            if (_currentLoadedScene == null)
                yield break;

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