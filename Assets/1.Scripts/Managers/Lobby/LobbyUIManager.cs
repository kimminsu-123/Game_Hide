using System;
using Com.Hide.Managers;
using Com.Hide.UI;
using Com.Hide.UI.Lobby.LobbyCanvas;
using Com.Hide.Utils;
using UnityEngine;

namespace Com.Hide.Managers
{
    public class LobbyUIManager : SingletonMonoBehaviour<LobbyUIManager>
    {
        [SerializeField] private LobbyCanvas lobbyCanvas;

        [SerializeField] private EnterRoomInfoCanvas enterRoomInfoCanvas; 

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            lobbyCanvas.Initialize();
        }

        public void ShowEnterRoomInfoDialog()
        {
            enterRoomInfoCanvas.Show();
        }
    }
}