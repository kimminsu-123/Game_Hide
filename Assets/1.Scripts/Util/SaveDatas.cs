using System;
using Com.Hide.Managers;
using UnityEngine;

namespace Com.Hide.SaveDatas
{
    [CreateAssetMenu(fileName = "SaveDataPathName", menuName = "Scriptable Object/SaveDataPathName", order = int.MaxValue)]
    public class SaveDataPathName : ScriptableObject
    {
        [SerializeField] private string namePathName;
        public string NamePathName => namePathName;
    }
    
    [Serializable]
    public class SaveDataValue
    {
        [SerializeField] private string value;
        public string Value { get => value; set => this.value = value; }
    }

    [Serializable]
    public class SaveData
    {
        [SerializeField] private SaveDataPathName sName;
        public SaveDataPathName SName => sName;
        
        [SerializeField] private SaveDataValue sValue;
        public SaveDataValue SValue => sValue;
    } 
}