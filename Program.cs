using System;
using System.Collections.Generic;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            Change change = new Change();
            Dictionary<string, int> changeReturn = new Dictionary<string, int>();
            List<CsvRecord> records = change.LoadFlatFile();
            foreach (CsvRecord record in records) 
            {
                decimal amount = change.CalculateChangeAmount(record);
                if (record.Owed % Change.DIVISOR == 0)
                {
                    changeReturn = change.CalculateRandomChange(amount, Change.Currency.USDollar);
                } 
                else 
                {
                    changeReturn = change.CalculateChangeReturn(amount, Change.Currency.USDollar);            
                }
                foreach (KeyValuePair<string, int> line in changeReturn)
                {
                    if (line.Value != 0)
                    {
                        Console.Write($"{line.Value} {line.Key} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
