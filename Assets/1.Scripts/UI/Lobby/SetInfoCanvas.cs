using Com.Hide.Dialog;
using Com.Hide.Utils;
using TMPro;
using UnityEngine;

namespace Com.Hide.UI.Lobby.SetInfoCanvas
{
    public class SetInfoCanvas : WindowCanvas
    {
        [SerializeField] private TMP_InputField nickNameInputField;
        
        protected override void OnShow()
        {
            nickNameInputField.text = string.Empty;
        }

        public void Save()
        {
            var nickName = nickNameInputField.text.Trim();
            if (string.IsNullOrEmpty(nickName))
            {
                MessageDialog.Instance.Show("오류", "닉네임은 공백일 수 없습니다.");
                return;
            }
            
            SavedData.Save(nickName);

            Hide();
        }
    }
}