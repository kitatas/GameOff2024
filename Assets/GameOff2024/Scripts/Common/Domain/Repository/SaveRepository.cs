using GameOff2024.Common.Data.DataStore;
using UnityEngine;

namespace GameOff2024.Common.Domain.Repository
{
    public sealed class SaveRepository
    {
        public SaveData Load()
        {
            var data = ES3.Load(SaveConfig.ES3_KEY, defaultValue: "");
            return string.IsNullOrEmpty(data)
                ? CreateNewData()
                : JsonUtility.FromJson<SaveData>(data);
        }

        private SaveData CreateNewData()
        {
            var data = SaveData.Create();
            Save(data);
            return data;
        }

        private void Save(SaveData value)
        {
            ES3.Save(SaveConfig.ES3_KEY, JsonUtility.ToJson(value));
        }

        public void SaveUid(string uid)
        {
            var data = Load();
            data.uid = uid;
            Save(data);
        }

        public void SaveBgmVolume(float value)
        {
            var data = Load();
            data.bgm = value;
            Save(data);
        }

        public void SaveSeVolume(float value)
        {
            var data = Load();
            data.se = value;
            Save(data);
        }
    }
}