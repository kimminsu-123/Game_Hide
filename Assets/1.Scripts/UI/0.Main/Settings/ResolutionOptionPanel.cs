using System;
using System.Linq;
using Com.Hide.Managers;
using Com.Hide.Utils;
using TMPro;
using UnityEngine;

namespace Com.Hide.UI.Main.Settings
{
    public class ResolutionOptionPanel : OptionPanel
    {
        public OptionPanel windowOptionPanel;
        
        [SerializeField] private TMP_Dropdown dropdown;
        private Resolution[] Resolutions => Screen.resolutions;

        public override void Initialize()
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(Resolutions.Select(r => r.ToString()).ToList());
            
            var sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.Resolution).SValue;
            dropdown.value = string.IsNullOrEmpty(sValue.Value) ? Resolutions.Length - 1 : int.Parse(sValue.Value);
            windowOptionPanel.Initialize();
        }

        public override void Save()
        {
            windowOptionPanel.Save();
            
            var v = dropdown.value;
            SaveDataManager.Instance.Save(PlayerPrefsSaveName.Resolution, v.ToString());
            
            var sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.WindowMode).SValue;
            var isWindow = !string.IsNullOrEmpty(sValue.Value) && bool.Parse(sValue.Value);
            Screen.SetResolution(Resolutions[v].width, Resolutions[v].height, isWindow);
        }
    }
}