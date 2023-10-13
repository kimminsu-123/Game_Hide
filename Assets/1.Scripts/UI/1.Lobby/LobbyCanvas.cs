using Com.Hide.Managers;
using Com.Hide.Utils;
using TMPro;
using UnityEngine;

namespace Com.Hide.UI.Lobby.LobbyCanvas
{
    public class LobbyCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_Text nickNameText;
        [SerializeField] private BottomMenu bottomMenu;
        
        public void Initialize()
        {
            var sd = SaveDataManager.Instance.Find(PlayerPrefsSaveName.NickName);
            nickNameText.text = sd.SValue.Value;
            bottomMenu.BindingButtons();
        }
    }
}