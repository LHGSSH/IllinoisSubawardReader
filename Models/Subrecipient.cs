using System;
using System.Collections.Generic;
using System.Text;

namespace IllinoisSubawardReader.Models
{
    public class Subrecipient
    {
        public string Name { get; set; } = string.Empty;
        public double TotalSubawardAmount { get; set; }
    }
}
