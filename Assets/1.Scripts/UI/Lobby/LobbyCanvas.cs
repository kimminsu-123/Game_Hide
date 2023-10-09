using Com.Hide.Managers;
using Com.Hide.UI.Lobby.LobbyCanvas;
using UnityEngine;

namespace Com.Hide.UI
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