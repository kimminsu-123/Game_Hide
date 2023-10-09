using System;
using UnityEngine;

namespace Com.Hide.UI.Lobby.LobbyCanvas
{
    public class EnterRoomInfoCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject dimmedPanel;
        [SerializeField] private GameObject windowPanel;

        private void Start()
        {
            Hide();
        }

        public void Show()
        {
            dimmedPanel.SetActive(true);   
            windowPanel.SetActive(true);
        }

        public void Hide()
        {
            dimmedPanel.SetActive(false);   
            windowPanel.SetActive(false);   
        }
    }
}