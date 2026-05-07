using System;
using System.Collections.Generic;
using System.Text;

namespace IllinoisSubawardReader.Interfaces
{
    internal interface IDataWriter<T>
    {
        void WriteData(IEnumerable<T> data);
    }
}
