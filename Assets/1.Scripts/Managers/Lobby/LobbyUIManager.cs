using Com.Hide.Dialog;
using Com.Hide.UI.Lobby.EnterRoomInfoCanvas;
using Com.Hide.UI.Lobby.JoinRoomWindowCanvas;
using Com.Hide.UI.Lobby.LobbyCanvas;
using Com.Hide.Utils;
using UnityEngine;

namespace Com.Hide.Managers
{
    public class LobbyUIManager : SingletonMonoBehaviour<LobbyUIManager>
    {
        [SerializeField] private LobbyCanvas lobbyCanvas;

        [SerializeField] private EnterRoomInfoCanvas enterRoomInfoCanvas;
        [SerializeField] private JoinRoomWindowCanvas joinRoomWindowCanvas;
        
        private void Start()
        {
            Initialize();
        }
        
        private void Initialize()
        {
            lobbyCanvas.Initialize();
            joinRoomWindowCanvas.Initialize();
        }

        public void ShowEnterRoomInfoDialog()
        {
            enterRoomInfoCanvas.Show();
        }

        public void ShowJoinRoomWindowDialog()
        {
            joinRoomWindowCanvas.Show();
        }
    }
}