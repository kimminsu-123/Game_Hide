using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Com.Hide.UI.Main.Settings
{
    public class SettingsWindowCanvas : WindowCanvas
    {
        [SerializeField] private OptionPanel[] optionPanels;

        protected override void OnShow()
        {          
            for (var i = 0; i < optionPanels.Length; i++)
            {
                optionPanels[i].Initialize();    
            }
        }

        protected override void OnHide()
        {
            for (var i = 0; i < optionPanels.Length; i++)
            {
                optionPanels[i].Save();    
            }
        }
    }
}