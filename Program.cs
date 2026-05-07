using IllinoisSubawardReader.Interfaces;
using IllinoisSubawardReader.Models;
using IllinoisSubawardReader.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddSingleton<IDataReader<Subrecipient>, ExcelSubrecipientDataReader>()
    .AddSingleton<IDataWriter<Subrecipient>, ConsoleSubrecipientDataWriter>()
    .BuildServiceProvider();
var reader = services.GetRequiredService<IDataReader<Subrecipient>>();
var writer = services.GetRequiredService<IDataWriter<Subrecipient>>();

var files = Directory.GetFiles(@"Data", "*.xlsx");

var allSubrecipients = new Dictionary<string, Subrecipient>(StringComparer.OrdinalIgnoreCase);

foreach (var filePath in files)
{
    IEnumerable<Subrecipient> currentSubrecipients = reader.ReadData(filePath);

    Console.WriteLine(filePath + " - Subrecipient Names");
    foreach (var subrecipient in currentSubrecipients)
    {
        Console.WriteLine(subrecipient.Name);
    }

    foreach (var s in currentSubrecipients)
    {
        if (allSubrecipients.TryGetValue(s.Name, out var existing))
        {
            existing.TotalSubawardAmount += s.TotalSubawardAmount;
        }
        else
        {
            allSubrecipients[s.Name] = s;
        }
    }
    Console.WriteLine();
}

Console.WriteLine("Overall Subrecipient Info (all files combined)");
writer.WriteData(allSubrecipients.Values);