namespace IllinoisSubawardReader.Interfaces
{
    public interface IDataReader<T>
    {
        IEnumerable<T> ReadData(string filePath);
    }
}
