using Com.Hide.Managers;
using Com.Hide.Utils;
using Photon.Pun;
using TMPro;
using UnityEngine;
using Logger = Com.Hide.Utils.Logger;

namespace Com.Hide.UI.Room.RoomCanvas
{
    public class RightPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerNameText;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            var nameData = SaveDataManager.Instance.Find(PlayerPrefsSaveName.NickName);
            if(!string.IsNullOrEmpty(nameData.SValue.Value))
                playerNameText.text = nameData.SValue.Value;
        }
    }
}