using System;
using System.Diagnostics;
using Com.Hide.Dialog;
using Com.Hide.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Hide.UI.Lobby.JoinRoomWindowCanvas
{
    public class JoinRoomWindowCanvas : WindowCanvas
    {
        [SerializeField] private TMP_InputField roomNameInputField;
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private Button joinButton;

        public void Initialize()
        {
            roomNameInputField.text = string.Empty;
            passwordInputField.text = string.Empty;
            
            joinButton.onClick.AddListener(ProcessJoin);
        }

        protected override void OnHide()
        {
            Initialize();
        }
        
        private void ProcessJoin()
        {
            try
            {
                NetworkManager.Instance.JoinRoom(roomNameInputField.text.Trim(), passwordInputField.text.Trim());
            }
            catch (Exception e)
            {
                MessageDialog.Instance.Show("오류", e.Message);
            }
        }
    }
}