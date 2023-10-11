using System;
using Com.Hide.Managers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using EventType = Com.Hide.Managers.EventType;

namespace Com.Hide.UI.Lobby.LobbyCanvas
{
    public class BottomMenu : MonoBehaviour
    {
        [SerializeField] private Button createRoomButton;
        [SerializeField] private Button findRoomButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;

        private SoundButton _createRoomSoundButton;
        private SoundButton _findRoomSoundButton;

        private void Awake()
        {
            _createRoomSoundButton = createRoomButton as SoundButton;
            _findRoomSoundButton = findRoomButton as SoundButton;
        }

        private void Start()
        {
            Initialize();
            EventManager.Instance.AddListener(EventType.OnJoinedLobby, OnJoinedLobby);
        }

        private void Initialize()
        {
            _createRoomSoundButton.ChangeText("joining lobby..");
            _createRoomSoundButton.interactable = false;
            _findRoomSoundButton.ChangeText("joining lobby..");
            _findRoomSoundButton.interactable = false;
        }
        
        private void OnJoinedLobby(EventType type, Component sender, object[] args)
        {
            _createRoomSoundButton.ChangeText("Create Room");
            _createRoomSoundButton.interactable = true;
            _findRoomSoundButton.ChangeText("Find Room");
            _findRoomSoundButton.interactable = true;
        }

        public void BindingButtons()
        {
            createRoomButton.onClick.AddListener(LobbyUIManager.Instance.ShowEnterRoomInfoDialog);
            findRoomButton.onClick.AddListener(LobbyUIManager.Instance.ShowJoinRoomWindowDialog);
            settingsButton.onClick.AddListener(null);
            exitButton.onClick.AddListener(GameManager.Instance.ExitGame);
        }

        private void OnDestroy()
        {
            EventManager.Instance.RemoveListener(EventType.OnJoinedLobby, OnJoinedLobby);
        }
    }
}