namespace IllinoisSubawardReader.Interfaces
{
    public interface IDataWriter<T>
    {
        void WriteData(IEnumerable<T> data);
    }
}
