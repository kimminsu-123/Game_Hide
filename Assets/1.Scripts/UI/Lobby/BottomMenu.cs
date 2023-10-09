using System;
using Com.Hide.Managers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using EventType = Com.Hide.Managers.EventType;

namespace Com.Hide.UI.Lobby.LobbyCanvas
{
    public class BottomMenu : MonoBehaviour
    {
        [SerializeField] private SoundButton createRoomButton;
        [SerializeField] private SoundButton findRoomButton;
        [SerializeField] private SoundButton settingsButton;
        [SerializeField] private SoundButton exitButton;

        private void Start()
        {
            Initialize();
            EventManager.Instance.AddListener(EventType.OnJoinedLobby, OnJoinedLobby);
        }

        private void Initialize()
        {
            createRoomButton.ChangeText("joining lobby..");
            createRoomButton.interactable = false;
            findRoomButton.ChangeText("joining lobby..");
            findRoomButton.interactable = false;
        }
        
        private void OnJoinedLobby(EventType type, Component sender, object[] args)
        {
            createRoomButton.ChangeText("Create Room");
            createRoomButton.interactable = true;
            findRoomButton.ChangeText("Find Room");
            findRoomButton.interactable = true;
        }

        public void BindingButtons()
        {
            createRoomButton.onClick.AddListener(LobbyUIManager.Instance.ShowEnterRoomInfoDialog);
            findRoomButton.onClick.AddListener(null);
            settingsButton.onClick.AddListener(null);
            exitButton.onClick.AddListener(GameManager.Instance.ExitGame);
        }

        private void OnDestroy()
        {
            EventManager.Instance.RemoveListener(EventType.OnJoinedLobby, OnJoinedLobby);
        }
    }
}