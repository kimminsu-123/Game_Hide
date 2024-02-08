using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Com.Hide.Utils;
using UnityEngine;

namespace Com.Hide.Managers
{
    public class ScreenManager : SingletonMonoBehaviour<ScreenManager>
    {
        public Resolution[] Resolutions => _resolutions;
        public List<string> ResolutionsStrings { get; private set; }
        public int ResolutionCount => _resolutions.Length;

        private Resolution[] _resolutions;

        protected override void OnAwake()
        {
            _resolutions = Screen.resolutions;
            
            ResolutionsStrings = Resolutions.Select(r => r.ToString()).ToList();
        }

        public void SetResolution(int index, bool isFullscreen)
        {
            Screen.SetResolution(Resolutions[index].width, Resolutions[index].height, isFullscreen);
        }
    }
}