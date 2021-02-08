namespace _Root.Scripts.Data
{
    public abstract class DataSerialization
    {
        public abstract void Save(string json);

        public abstract string Load();

        public abstract void Clear();
    }
}
