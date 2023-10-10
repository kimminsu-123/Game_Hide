using Com.Hide.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Hide.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Scene Data", menuName = "Scriptable Object/Scene Data", order = int.MaxValue)]
    public class SceneData : ScriptableObject
    {
        [SerializeField] private int buildIndex;
        public int BuildIndex => buildIndex;
        
        [SerializeField] private string sceneName;
        public string SceneName => sceneName;

        [SerializeField] private SceneType type;
        public SceneType Type => type;

        [SerializeField] private LoadSceneMode mode;
        public LoadSceneMode Mode => mode;

        [SerializeField] private bool isNetworkSynchronize;
        public bool IsNetworkSynchronize => isNetworkSynchronize;
    }
}