using System;
using System.Collections.Generic;
using System.Text;

namespace IllinoisSubawardReader.Interfaces
{
    public interface IDataWriter<T>
    {
        void WriteData(IEnumerable<T> data);
    }
}
