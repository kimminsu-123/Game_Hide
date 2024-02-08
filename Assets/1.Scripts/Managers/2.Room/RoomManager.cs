using System;
using Com.Hide.ScriptableObjects;
using Com.Hide.Utils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Com.Hide.Managers
{
    public class RoomManager : SingletonMonoBehaviourPunCallbacks<RoomManager>
    {
        [SerializeField] private SceneData lobbySceneData;

        public Room CurrentRoom => _currentRoom;
        
        private Room _currentRoom;

        protected override void OnAwake()
        {
            _currentRoom = PhotonNetwork.CurrentRoom;
        }

        public void ExitRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            LoadSceneManager.Instance.UnloadSceneAsync();
            LoadSceneManager.Instance.LoadSceneAsync(lobbySceneData);
        }
    }
}