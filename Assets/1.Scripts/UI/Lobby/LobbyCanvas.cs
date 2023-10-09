using UnityEngine;

namespace Com.Hide.UI.Lobby.LobbyCanvas
{
    public class LobbyCanvas : MonoBehaviour
    {
        [SerializeField] private BottomMenu bottomMenu;
        
        public void Initialize()
        {
            bottomMenu.BindingButtons();
        }
    }
}