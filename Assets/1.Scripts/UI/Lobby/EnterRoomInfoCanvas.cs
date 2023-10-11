using System;
using UnityEngine;

namespace Com.Hide.UI.Lobby.EnterRoomInfoCanvas
{
    public class EnterRoomInfoCanvas : WindowCanvas
    {
        [SerializeField] private EnterRoomInfoContents contents;

        private void Start()
        {
            Hide();
        }

        protected override void OnShow()
        {
            contents.Initialize();
        }
    }
}