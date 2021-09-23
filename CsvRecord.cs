using CsvHelper.Configuration.Attributes;

namespace CashRegister
{
    public class CsvRecord
    {
        [Index(0)]
        public decimal Owed { get; set; }
        [Index(1)]
        public decimal Paid { get; set; }
    }
}
