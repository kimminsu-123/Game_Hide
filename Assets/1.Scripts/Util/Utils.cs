using System;
using Com.Hide.Managers;
using UnityEditor;
using UnityEngine;

namespace Com.Hide.Utils
{
    public struct RoomCustomPropertiesName
    {
        public static readonly string Password = "Password";
    }

    public struct RoomProperty
    {
        public static readonly int MinimumPlayerCount = 2;
        public static readonly int MaximumPlayerCount = 8;
    }

    public struct PlayerPrefsSaveName
    {
        public static readonly string NickName = "NickName";
        public static readonly string MasterVolume = "MasterVolume";
        public static readonly string BGMVolume = "BGMVolume";
        public static readonly string SfxVolume = "SFXVolume";
        public static readonly string WindowMode = "WindowMode";
        public static readonly string Resolution = "Resolution";
    }

    public struct AudioMixerGroupName
    {
        public static readonly string Master = "Master";
        public static readonly string BGM = "BGM";
        public static readonly string SFX = "SFX";
    }
    
    public class Message
    {
        public string Title { get; private set; }
        public string Msg { get; private set; }

        public Message(string title, string msg)
        {
            Title = title;
            Msg = msg;
        }
    }
}