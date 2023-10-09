using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Hide.Player.Status
{
    public enum PlayerStatusEnum
    {
        None,
        Move,
        Jump,
        Die
    }
    
    public class PlayerStatusHandler : MonoBehaviour
    {
        private PlayerStatusEnum _currStatus = PlayerStatusEnum.None;
        private List<IPlayerStatusListener> _listeners = new();

        public void AddListener(IPlayerStatusListener listener)
        {
            if (_listeners.Contains(listener))
                return;
            
            _listeners.Add(listener);
        }

        public void RemoveListener(IPlayerStatusListener listener)
        {
            if (!_listeners.Contains(listener))
                return;
            
            _listeners.Remove(listener);
        }

        public void ChangeStatus(PlayerStatusEnum status)
        {
            _currStatus = status;
            PostNotification();
        }

        public void PostNotification()
        {
            for(var i = 0; i < _listeners.Count; i++)
                _listeners[i].OnChangePlayerStatus(_currStatus);
        }

        private void OnDestroy()
        {
            _listeners.Clear();
        }
    }
}