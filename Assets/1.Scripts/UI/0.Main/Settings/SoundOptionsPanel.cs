using System;
using System.Globalization;
using Com.Hide.Managers;
using Com.Hide.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Hide.UI.Main.Settings
{
    public class SoundOptionsPanel : OptionPanel
    {
        [SerializeField] private SynchronizeSliderText masterVolumeSlider;
        [SerializeField] private SynchronizeSliderText bgmVolumeSlider;
        [SerializeField] private SynchronizeSliderText sfxVolumeSlider;

        private void Start()
        {
            masterVolumeSlider.OnValueChanged += v => SoundManager.Instance.SetVolume(AudioMixerGroupName.Master, v);
            bgmVolumeSlider.OnValueChanged += v => SoundManager.Instance.SetVolume(AudioMixerGroupName.BGM, v);
            sfxVolumeSlider.OnValueChanged += v => SoundManager.Instance.SetVolume(AudioMixerGroupName.SFX, v);
        }

        public override void Initialize()
        {
            var sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.MasterVolume).SValue;
            var v = string.IsNullOrEmpty(sValue.Value) ? 1f : float.Parse(sValue.Value);
            masterVolumeSlider.UpdateValueText(v);
            
            sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.BGMVolume).SValue;
            v = string.IsNullOrEmpty(sValue.Value) ? 1f : float.Parse(sValue.Value);
            bgmVolumeSlider.UpdateValueText(v);
            
            sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.SfxVolume).SValue;
            v = string.IsNullOrEmpty(sValue.Value) ? 1f : float.Parse(sValue.Value);
            sfxVolumeSlider.UpdateValueText(v);
        }
        
        public override void Save()
        {
            var masterValue = masterVolumeSlider.Value;
            var bgmValue = bgmVolumeSlider.Value;
            var sfxValue = sfxVolumeSlider.Value;
            
            SaveDataManager.Instance.Save(PlayerPrefsSaveName.MasterVolume, masterValue.ToString(CultureInfo.CurrentCulture));
            SaveDataManager.Instance.Save(PlayerPrefsSaveName.BGMVolume, bgmValue.ToString(CultureInfo.CurrentCulture));
            SaveDataManager.Instance.Save(PlayerPrefsSaveName.SfxVolume, sfxValue.ToString(CultureInfo.CurrentCulture));
        }
    }
}