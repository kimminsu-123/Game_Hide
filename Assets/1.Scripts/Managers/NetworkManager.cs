using System;
using System.Collections;
using Com.Hide.ScriptableObjects;
using Com.Hide.Utils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Logger = Com.Hide.Utils.Logger;

namespace Com.Hide.Managers
{
    public class NetworkManager : SingletonMonoBehaviourPunCallbacks<NetworkManager>
    {
        private bool _isConnect = false;
        
        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (_isConnect)
                return;

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();

            EventManager.Instance.AddListener(EventType.SceneLoaded, OnSceneLoaded);
        }
        
        private void OnSceneLoaded(EventType type, Component sender, object[] args)
        {
            var sceneData = args[0] as SceneData;
            if (sceneData == null)
                return;
            
            switch (sceneData.Type)
            {
                case SceneType.None:
                    break;
                case SceneType.Lobby:
                    StartCoroutine(JoinLobbyCoroutine());
                    break;
                case SceneType.Room:
                    break;
                case SceneType.InGame:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IEnumerator JoinLobbyCoroutine()
        {
            while (!_isConnect)
                yield return null;
            
            var success = PhotonNetwork.JoinLobby();
            if(!success)
                Logger.LogError("Failed Join Lobby");
        }

        public void CreateRoom(string roomName, int maxPlayer = 8, string password = "")
        {
            if (PhotonNetwork.InRoom)
                return;
            
            var opt = new RoomOptions
            {
                MaxPlayers = maxPlayer,
                CustomRoomProperties =
                {
                    [RoomCustomPropertiesName.Password] = password
                }
            };
            
            PhotonNetwork.CreateRoom(roomName, opt);
        }

        public override void OnJoinedLobby()
        {                
            Logger.Log("Success Join Lobby");

            EventManager.Instance.PostNotification(EventType.OnJoinedLobby, this);
        }

        public override void OnConnectedToMaster()
        {
            _isConnect = true;
        }

        public override void OnCreatedRoom()
        {
            var currentRoom = PhotonNetwork.CurrentRoom;
            
            Logger.Log($"Created Room [Name: {currentRoom.Name}], [Password: {currentRoom.CustomProperties[RoomCustomPropertiesName.Password]}]");
            
            EventManager.Instance.PostNotification(EventType.OnJoinedRoom, this, PhotonNetwork.CurrentRoom);
        }

        private void OnDestroy()
        {
            EventManager.Instance.RemoveListener(EventType.SceneLoaded, OnSceneLoaded);
        }
    }
}