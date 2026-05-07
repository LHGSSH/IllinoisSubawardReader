using IllinoisSubawardReader.Interfaces;
using IllinoisSubawardReader.Models;

namespace IllinoisSubawardReader.Services
{
    public class ConsoleSubrecipientDataWriter : IDataWriter<Subrecipient>
    {
        public void WriteData(IEnumerable<Subrecipient> subrecipients)
        {
            foreach (var subrecipient in subrecipients)
            {
                Console.WriteLine($"{subrecipient.Name}: {subrecipient.TotalSubawardAmount:C}");
            }
        }
    }
}
