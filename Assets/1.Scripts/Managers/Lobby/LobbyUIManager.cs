using Com.Hide.Dialog;
using Com.Hide.UI.Lobby.EnterRoomInfoCanvas;
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