using System;
using System.Collections.Generic;
using System.Linq;
using Com.Hide.Utils;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Com.Hide.Managers
{
    public class RoomManager : SingletonMonoBehaviourPunCallbacks<RoomManager>
    {
        public Room CurrentRoom => PhotonNetwork.CurrentRoom;

        private Dictionary<string, RoomInfo> _roomInfos = new();

        public bool ExistRoom(string roomName)
        {
            return _roomInfos.ContainsKey(roomName);
        }

        public bool IsRoomFull(string roomName)
        {
            if (!ExistRoom(roomName))
                return false;

            return _roomInfos[roomName].MaxPlayers <= _roomInfos[roomName].PlayerCount;
        }

        public bool ValidatePassword(string roomName, string password)
        {
            if (!ExistRoom(roomName))
                return false;

            var pwd = _roomInfos[roomName].CustomProperties[RoomCustomPropertiesName.Password].ToString();

            return pwd.Equals(string.Empty) || pwd.Equals(password);
        }

        /*==============================================
         1. 로비에 접속 시 (JoinLobby)
         2. 새로운 룸이 만들어질 경우 (CreateRoom)
         3. 룸이 삭제되는 경우 (LeaveRoom - All Player)
         4. 룸의 CustomProperties 나 IsOpen, MaxPlayer, Visible 등이 변경 되었을 경우
        ==============================================*/
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            _roomInfos = roomList.ToDictionary(
                keySelector: r => r.Name,
                elementSelector: r => r
            );
        }
    }
}