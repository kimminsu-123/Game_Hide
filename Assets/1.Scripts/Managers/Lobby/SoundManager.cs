using System;
using Com.Hide.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Com.Hide.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] private AudioMixer audioMixer;

        private void Start()
        {
            EventManager.Instance.AddListener(EventType.OnDataLoaded, OnDataLoaded);
        }

        private void OnDataLoaded(EventType type, Component sender, object[] args)
        {            
            var sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.MasterVolume).SValue;
            var v = string.IsNullOrEmpty(sValue.Value) ? 1f : float.Parse(sValue.Value);
            SetVolume(AudioMixerGroupName.Master, v);
            
            sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.BGMVolume).SValue;
            v = string.IsNullOrEmpty(sValue.Value) ? 0.5f : float.Parse(sValue.Value);
            SetVolume(AudioMixerGroupName.BGM, v);
            
            sValue = SaveDataManager.Instance.Find(PlayerPrefsSaveName.SfxVolume).SValue;
            v = string.IsNullOrEmpty(sValue.Value) ? 0.5f : float.Parse(sValue.Value);
            SetVolume(AudioMixerGroupName.SFX, v);
        }

        public void SetVolume(string n, float v)
        {
            audioMixer.SetFloat(n, (v - 0.8f) * 100f);
        }

        private void OnDestroy()
        {
            EventManager.Instance.RemoveListener(EventType.OnDataLoaded, OnDataLoaded);
        }
    }
}