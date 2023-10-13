using Com.Hide.UI.Main;
using Com.Hide.UI.Main.Settings;
using Com.Hide.Utils;
using UnityEngine;

namespace Com.Hide.Managers
{
    public class UtilUISystem : SingletonMonoBehaviour<UtilUISystem>
    {
        [SerializeField] private SettingsWindowCanvas settingsWindowCanvas;

        public void ShowOptionWindow()
        {
            settingsWindowCanvas.Show();
        }
    }
}