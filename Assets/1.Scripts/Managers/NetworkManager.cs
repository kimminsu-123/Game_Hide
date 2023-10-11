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
            if (string.IsNullOrEmpty(roomName))
                throw new ArgumentException($"방 이름은 공백이 될 수 없습니다.");

            if (PhotonNetwork.InRoom)
                throw new Exception($"이미 다른 방에 접속해 있습니다.");

            if (RoomManager.Instance.ExistRoom(roomName))
                throw new ArgumentNullException(roomName, $"중복된 방제목입니다. [{roomName}]");
            
            var opt = new RoomOptions
            {
                MaxPlayers = maxPlayer,
                CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
                {
                    {RoomCustomPropertiesName.Password, password}
                }
            };

            if (!PhotonNetwork.CreateRoom(roomName, opt))
                throw new Exception("방 생성 중 오류가 발생했습니다.");
        }

        public void JoinRoom(string roomName, string password = "")
        {
            if (string.IsNullOrEmpty(roomName))
                throw new ArgumentException($"방 제목은 공백이 될 수 없습니다.");

            if (PhotonNetwork.InRoom)
                throw new Exception($"이미 다른 방에 접속해 있습니다.");

            if (!RoomManager.Instance.ExistRoom(roomName))
                throw new ArgumentNullException(roomName, $"존재하지 않는 방입니다. [{roomName}]");

            if (RoomManager.Instance.IsRoomFull(roomName))
                throw new ArgumentOutOfRangeException(roomName, $"이미 꽉 찬 방입니다.");

            if (!RoomManager.Instance.ValidatePassword(roomName, password))
                throw new Exception("비밀번호가 다릅니다.");

            if (!PhotonNetwork.JoinRoom(roomName))
                throw new Exception("방에 접속 시, 오류가 발생하였습니다. 네트워크를 확인해주세요.");
            
            EventManager.Instance.PostNotification(EventType.OnJoinedRoom, this);
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

        private void OnDestroy()
        {
            EventManager.Instance.RemoveListener(EventType.SceneLoaded, OnSceneLoaded);
        }
    }
}