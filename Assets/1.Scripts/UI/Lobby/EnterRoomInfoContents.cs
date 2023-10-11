using System;
using Com.Hide.Dialog;
using Com.Hide.Managers;
using Com.Hide.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Logger = Com.Hide.Utils.Logger;

namespace Com.Hide.UI.Lobby.EnterRoomInfoCanvas
{
    public class EnterRoomInfoContents : MonoBehaviour
    {
        [SerializeField] private TMP_InputField roomNameInputField;
        [SerializeField] private TMP_Text maxPlayerText;
        [SerializeField] private TMP_InputField passwordInputField;

        [SerializeField] private Button changePasswordTypeButton;
        [SerializeField] private Sprite showPasswordSprite;
        [SerializeField] private Sprite hidePasswordSprite;
        private bool _isShowPassword;
        
        public void Initialize()
        {
            roomNameInputField.text = string.Empty;
            maxPlayerText.text = RoomProperty.MinimumPlayerCount.ToString();
            passwordInputField.text = string.Empty;

            _isShowPassword = false;
            passwordInputField.contentType = TMP_InputField.ContentType.Password;
            changePasswordTypeButton.image.sprite = hidePasswordSprite;
        }
        
        public void Submit()
        {
            var roomName = roomNameInputField.text.Trim();
            var playerCount = Mathf.Clamp(
                int.Parse(maxPlayerText.text), 
                RoomProperty.MinimumPlayerCount, 
                RoomProperty.MaximumPlayerCount);
            var password = passwordInputField.text.Trim();

            try
            {
                NetworkManager.Instance.CreateRoom(roomName, playerCount, password);
            }
            catch (Exception e)
            {
                MessageDialog.Instance.Show("오류", e.Message);
            }
        }

        public void IncreasePlayerCount()
        {
            var cnt = int.Parse(maxPlayerText.text);
            cnt = Mathf.Min(RoomProperty.MaximumPlayerCount, cnt + 1);
            maxPlayerText.text = $"{cnt}";
        }

        public void DecreasePlayerCount()
        {
            var cnt = int.Parse(maxPlayerText.text);
            cnt = Mathf.Max(RoomProperty.MinimumPlayerCount, cnt - 1);
            maxPlayerText.text = $"{cnt}";
        }

        public void ChangePasswordShow()
        {
            _isShowPassword = !_isShowPassword;
            passwordInputField.contentType = _isShowPassword ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
            changePasswordTypeButton.image.sprite = _isShowPassword ? showPasswordSprite : hidePasswordSprite;
            
            passwordInputField.ForceLabelUpdate();
        }
    }
}