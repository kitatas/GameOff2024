namespace GameOff2024.Common.Data.DataStore
{
    public sealed class SaveData
    {
        public string uid;

        public static SaveData Create()
        {
            return new SaveData
            {
                uid = "",
            };
        }
    }
}