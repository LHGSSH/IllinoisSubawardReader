using IllinoisSubawardReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IllinoisSubawardReader.Services
{
    internal class ConsoleSubrecipientDataWriter : IDataWriter
    {
        public void WriteData<T>(IEnumerable<T> data)
        {
            throw new NotImplementedException();
        }
    }
}
