using System;
using UnityEngine;

namespace Com.Hide.UI.Main.Settings
{
    [Serializable]
    public abstract class OptionPanel : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Save();
    }
}