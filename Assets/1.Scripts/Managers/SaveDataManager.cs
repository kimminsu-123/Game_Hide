using System.Collections.Generic;
using System.Linq;
using Com.Hide.SaveDatas;
using Com.Hide.Utils;
using UnityEngine;

namespace Com.Hide.Managers
{
    public class SaveDataManager : SingletonMonoBehaviour<SaveDataManager>
    {
        [SerializeField] private SaveData[] saveDatas;

        public SaveData Find(string n)
        {
            return saveDatas.FirstOrDefault(s => s.SName.NamePathName.Equals(n));
        }
        
        public void Save(string n, string v)
        {
            var sd = Find(n);

            sd.SValue.Value = v;
            
            PlayerPrefs.SetString(sd.SName.NamePathName, sd.SValue.Value);
        }

        public void SaveAll()
        {
            for (var i = 0; i < saveDatas.Length; i++)
            {
                PlayerPrefs.SetString(saveDatas[i].SName.NamePathName, saveDatas[i].SValue.Value);
            }
        }

        public void Load()
        {
            for (var i = 0; i < saveDatas.Length; i++)
            {
                var v = PlayerPrefs.GetString(saveDatas[i].SName.NamePathName, "");
                saveDatas[i].SValue.Value = v;
            }
            
            EventManager.Instance.PostNotification(EventType.OnDataLoaded, this, null);
        }
    }
}