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

        public override void Initialize()
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(ScreenManager.Instance.ResolutionsStrings);
            
            var sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.Resolution).SValue;
            dropdown.value = string.IsNullOrEmpty(sValue.Value) ? ScreenManager.Instance.ResolutionCount - 1 : int.Parse(sValue.Value);
            windowOptionPanel.Initialize();
        }

        public override void Save()
        {
            windowOptionPanel.Save();
            
            var v = dropdown.value;
            SaveDataManager.Instance.Save(PlayerPrefsSaveName.Resolution, v.ToString());
            
            var sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.WindowMode).SValue;
            var isWindow = !string.IsNullOrEmpty(sValue.Value) && bool.Parse(sValue.Value);
            ScreenManager.Instance.SetResolution(v, !isWindow);
        }
    }
}