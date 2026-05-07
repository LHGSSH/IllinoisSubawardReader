using IllinoisSubawardReader.Interfaces;
using IllinoisSubawardReader.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ClosedXML.Excel;

namespace IllinoisSubawardReader.Services
{
    internal class ExcelSubrecipientDataReader : IDataReader<Subrecipient>
    {
        public IEnumerable<Subrecipient> ReadData(string filePath)
        {
            using var workbook = new XLWorkbook(filePath);
            var sheet = workbook.Worksheet(1);

            var subrecipientRows = GetSubrecipientRows(sheet);

            foreach (var row in subrecipientRows)
            {
                string subrecipientName = GetSubrecipientName(row);
                double totalSubawardAmount = GetTotalSubawardAmount(row);

                yield return new Subrecipient
                {
                    Name = subrecipientName,
                    TotalSubawardAmount = totalSubawardAmount
                };
            }
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
