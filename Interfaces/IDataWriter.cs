using System;
using System.Collections.Generic;
using System.Text;

namespace IllinoisSubawardReader.Interfaces
{
    internal interface IDataWriter
    {
        void WriteData<T>(IEnumerable<T> data);
    }
}
