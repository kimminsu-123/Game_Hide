using System;
using Com.Hide.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Hide.UI.Room.RoomCanvas
{
    public class BottomCanvas : MonoBehaviour
    {
        [SerializeField] private Button settingsButton;

        private void Start()
        {
            BindButtons();
        }

        private void BindButtons()
        {
            settingsButton.onClick.AddListener(UtilUISystem.Instance.ShowOptionWindow);
        }
    }
}