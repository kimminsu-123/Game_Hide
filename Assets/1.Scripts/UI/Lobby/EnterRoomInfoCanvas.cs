using System;
using UnityEngine;

namespace Com.Hide.UI.Lobby.EnterRoomInfoCanvas
{
    public class EnterRoomInfoCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject dimmedPanel;
        [SerializeField] private GameObject windowPanel;

        [SerializeField] private EnterRoomInfoContents contents;

        private void Start()
        {
            Hide();
        }

        public void Show()
        {
            contents.Initialize();

            dimmedPanel.SetActive(true);   
            windowPanel.SetActive(true);
        }

        public void Hide()
        {
            dimmedPanel.SetActive(false);   
            windowPanel.SetActive(false);   
        }
    }
}