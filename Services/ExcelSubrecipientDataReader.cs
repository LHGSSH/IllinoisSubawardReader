using IllinoisSubawardReader.Interfaces;
using IllinoisSubawardReader.Models;
using ClosedXML.Excel;

namespace IllinoisSubawardReader.Services
{
    public class ExcelSubrecipientDataReader : IDataReader<Subrecipient>
    {
        public IEnumerable<Subrecipient> ReadData(string filePath)
        {
            using var workbook = new XLWorkbook(filePath);
            var sheet = workbook.Worksheet(1);

            var subrecipientRows = GetSubrecipientRows(sheet);
            var results = new List<Subrecipient>();

            foreach (var row in subrecipientRows)
            {
                results.Add(new Subrecipient
                {
                    Name = GetSubrecipientName(row),
                    TotalSubawardAmount = GetTotalSubawardAmount(row)
                });
            }

            return results;
        }

        private IEnumerable<IXLRangeRow> GetSubrecipientRows(IXLWorksheet sheet)
        {
            return sheet.RangeUsed()
                .RowsUsed()
                .Where(row => row.Cells().Any(cell =>
                    cell.GetString().Contains("Subaward:", StringComparison.OrdinalIgnoreCase)));
        }
        private string GetSubrecipientName(IXLRangeRow row)
        {
            if (row.Cell(2).GetString().Trim().Equals("Subaward:", StringComparison.OrdinalIgnoreCase))
            {
                //Name is in column C
                //Example: "University of Illinois"
                return row.Cell(3).GetString().Trim();
            }
            else
            {
                //Name is in column B
                //Example: "Subaward: University of Illinois"
                return row.Cell(2).GetString().Split(':')[1].Trim();
            }
        }
        private double GetTotalSubawardAmount(IXLRangeRow row)
        {
            var blueCell = row.Cells().FirstOrDefault(cell => IsBlueFont(cell));
            if (blueCell != null)
            {
                return blueCell.GetDouble();
            }
            return 0.00;
        }
        private bool IsBlueFont(IXLCell cell)
        {
            var color = cell.Style.Font.FontColor;
            return color.ColorType == XLColorType.Indexed && color.Indexed == 12;
        }
    }
}
