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

    public struct PlayerPrefsName
    {
        public static readonly string NickName = "NickName";
    }

    public struct SavedData
    {
        public static string NickName { get; private set; }

        public static bool IsNewbie { get; private set; }
        
        public static void Load()
        {
            NickName = PlayerPrefs.GetString(PlayerPrefsName.NickName, "");

            IsNewbie = string.IsNullOrEmpty(NickName);
        }

        public static void Save(string nickName)
        {
            PlayerPrefs.SetString(PlayerPrefsName.NickName, nickName);
            
            Load();
        }
    }

    public struct Message
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