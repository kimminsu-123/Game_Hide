using Com.Hide.Dialog;
using Com.Hide.UI.Lobby.EnterRoomInfoCanvas;
using Com.Hide.UI.Lobby.JoinRoomWindowCanvas;
using Com.Hide.UI.Lobby.LobbyCanvas;
using Com.Hide.UI.Lobby.SetInfoCanvas;
using Com.Hide.UI.Main;
using Com.Hide.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Com.Hide.Managers
{
    public class LobbyUIManager : SingletonMonoBehaviour<LobbyUIManager>
    {
        [SerializeField] private LobbyCanvas lobbyCanvas;
        [SerializeField] private SetInfoCanvas setInfoCanvas;

        [SerializeField] private EnterRoomInfoCanvas enterRoomInfoCanvas;
        [SerializeField] private JoinRoomWindowCanvas joinRoomWindowCanvas;

        private void Start()
        {
            Initialize();
        }
        
        private void Initialize()
        {
            var nameData = SaveDataManager.Instance.Find(PlayerPrefsSaveName.NickName);
            if(string.IsNullOrEmpty(nameData.SValue.Value))
                setInfoCanvas.Show();
            
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