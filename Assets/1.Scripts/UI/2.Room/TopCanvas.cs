using System;
using Com.Hide.Managers;
using TMPro;
using UnityEngine;

namespace Com.Hide.UI.Room.RoomCanvas
{
    public class TopCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_Text roomNameText;
        
        private void Start()
        {
            roomNameText.text = RoomManager.Instance.CurrentRoom.Name;
        }
    }
}