using IllinoisSubawardReader.Interfaces;
using IllinoisSubawardReader.Models;
using IllinoisSubawardReader.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddSingleton<IDataReader<Subrecipient>, ExcelSubrecipientDataReader>()
    .BuildServiceProvider();
var reader = services.GetRequiredService<IDataReader<Subrecipient>>();

var files = Directory.GetFiles(@"Data", "*.xlsx");

IEnumerable<Subrecipient> allSubrecipients = Enumerable.Empty<Subrecipient>();

foreach (var filePath in files)
{
    IEnumerable<Subrecipient> currentSubrecipients = reader.ReadData(filePath);

    Console.WriteLine(filePath + " - Subrecipient Info");
    foreach (var currentSubrecipient in currentSubrecipients)
    {
        Console.WriteLine($"{currentSubrecipient.Name}: {currentSubrecipient.TotalSubawardAmount:C}");

        if (allSubrecipients.Any(subrecipient => subrecipient.Name.Equals(currentSubrecipient.Name, StringComparison.OrdinalIgnoreCase)))
        {
            var existingSubrecipient = allSubrecipients.First(subrecipient => subrecipient.Name.Equals(currentSubrecipient.Name, StringComparison.OrdinalIgnoreCase));
            existingSubrecipient.TotalSubawardAmount += currentSubrecipient.TotalSubawardAmount;
        }
        else
        {
            allSubrecipients = allSubrecipients.Append(currentSubrecipient);
        }
    }
    Console.WriteLine();
}

Console.WriteLine("Overall Subrecipient Info (all files combined)");
foreach (var subrecipient in allSubrecipients)
{
    Console.WriteLine($"{subrecipient.Name}: {subrecipient.TotalSubawardAmount:C}");
}