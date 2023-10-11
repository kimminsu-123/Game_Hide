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
            nickNameText.text = SavedData.NickName;
            bottomMenu.BindingButtons();
        }
    }
}