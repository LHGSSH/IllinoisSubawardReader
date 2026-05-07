using System;
using System.Collections.Generic;
using System.Text;

namespace IllinoisSubawardReader.Interfaces
{
    public interface IDataReader<T>
    {
        IEnumerable<T> ReadData(string filePath);
    }
}
