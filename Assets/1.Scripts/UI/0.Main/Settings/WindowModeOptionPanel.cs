using System;
using Com.Hide.Managers;
using Com.Hide.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Hide.UI.Main.Settings
{
    public class WindowModeOptionPanel : OptionPanel
    {
        [SerializeField] private Toggle toggle;

        public override void Initialize()
        {
            var sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.WindowMode).SValue;
            var isOn = !string.IsNullOrEmpty(sValue.Value) && bool.Parse(sValue.Value);
            toggle.isOn = isOn;
        }

        public override void Save()
        {
            var isWindow = toggle.isOn;
            SaveDataManager.Instance.Save(PlayerPrefsSaveName.WindowMode, isWindow.ToString());
        }
    }
}