using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Com.Hide.Dialog;
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
        public bool IsHost => PhotonNetwork.IsMasterClient;
        
        private bool _isConnect = false;
        private RoomInfo[] _roomInfos = Array.Empty<RoomInfo>();

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

            if (!PhotonNetwork.JoinLobby())
            {
                MessageDialog.Instance.Show("오류", "로비에 접속 실패하였습니다.");
                Logger.LogError("Join Lobby Error", "Failed Join Lobby");
            }
        }

        public void CreateRoom(string roomName, int maxPlayer = 8, string password = "")
        {
            if (PhotonNetwork.InRoom)
                return;

            var opt = new RoomOptions
            {
                MaxPlayers = maxPlayer,
                CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
                {
                    { RoomCustomPropertiesName.Password, password }
                }
            };
            
            var r = _roomInfos?.FirstOrDefault(room => room.Name.Equals(roomName));
            if (r != null)
            {
                MessageDialog.Instance.Show("오류", $"중복된 방제목입니다. [{roomName}]");
                Logger.LogError("Duplicate Room Name", "this room already been created. use other room name");
            }

            PhotonNetwork.CreateRoom(roomName, opt);
        }

        public override void OnJoinedLobby()
        {
            Logger.Log("Join Room", "Success Join Lobby");

            EventManager.Instance.PostNotification(EventType.OnJoinedLobby, this);
        }

        public override void OnConnectedToMaster()
        {
            _isConnect = true;
        }

        public override void OnCreatedRoom()
        {
            var currentRoom = PhotonNetwork.CurrentRoom;

            Logger.Log("Create Room", $"Created Room [Name: {currentRoom.Name}], [Password: {currentRoom.CustomProperties[RoomCustomPropertiesName.Password]}]");

            EventManager.Instance.PostNotification(EventType.OnJoinedRoom, this, PhotonNetwork.CurrentRoom);
        }

        public override void OnJoinedRoom()
        {
            Logger.Log("Joined Room", "Success Join Room");
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            _roomInfos = new RoomInfo[roomList.Count];
            roomList?.CopyTo(_roomInfos);
        }

        private void OnDestroy()
        {
            EventManager.Instance.RemoveListener(EventType.SceneLoaded, OnSceneLoaded);
        }
    }
}