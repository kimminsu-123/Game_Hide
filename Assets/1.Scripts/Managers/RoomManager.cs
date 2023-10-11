using System;
using System.Collections.Generic;
using System.Linq;
using Com.Hide.Utils;
using Photon.Realtime;
using UnityEngine;

namespace Com.Hide.Managers
{
    public class RoomManager : SingletonMonoBehaviourPunCallbacks<RoomManager>
    {
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
        
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            _roomInfos = roomList.ToDictionary(keySelector: r => r.Name, elementSelector: r => r);
        }
    }
}