using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace CashRegister
{
    public class Change {
        public const int DIVISOR = 3;

        public enum Currency
        {
            USDollar,
        }

        public List<CsvRecord> LoadFlatFile() {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            
            using (var reader = new StreamReader(@"input.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<CsvRecord>().ToList();    
            }
        }

        public decimal CalculateChangeAmount(CsvRecord record)
        {
            return record.Paid - record.Owed;    
        }

        public Dictionary<string, int> CalculateChangeReturn(decimal amount, Currency currency)
        {
            Dictionary<string, int> retVal = new Dictionary<string, int>();

            if (currency == Currency.USDollar) 
            {
                int numHundredDollars = 0;
                int numFiftyDollars = 0;
                int numTwentyDollars = 0;
                int numTenDollars = 0;
                int numFiveDollars = 0;
                int numOneDollars = 0;
                int numQuarters = 0;
                int numDimes = 0;
                int numNickels = 0;
                int numPennies = 0;

                USDollarDenominations denoms = new USDollarDenominations();
                while(amount >= denoms.HundredDollar) 
                {
                    amount -= denoms.HundredDollar;
                    numHundredDollars++;                    
                }
                while(amount >= denoms.FiftyDollar) 
                {
                    amount -= denoms.FiftyDollar;
                    numFiftyDollars++;                    
                }
                while(amount >= denoms.TwentyDollar) 
                {
                    amount -= denoms.TwentyDollar;
                    numTwentyDollars++;                    
                }
                while(amount >= denoms.TenDollar) 
                {
                    amount -= denoms.TenDollar;
                    numTenDollars++;                    
                }
                while(amount >= denoms.FiveDollar) 
                {
                    amount -= denoms.FiveDollar;
                    numFiveDollars++;                    
                }
                while(amount >= denoms.OneDollar) 
                {
                    amount -= denoms.OneDollar;
                    numOneDollars++;                    
                }
                while(amount >= denoms.Quarter) 
                {
                    amount -= denoms.Quarter;
                    numQuarters++;                    
                }
                while(amount >= denoms.Dime) 
                {
                    amount -= denoms.Dime;
                    numDimes++;                    
                }
                while(amount >= denoms.Nickel) 
                {
                    amount -= denoms.Nickel;
                    numNickels++;                    
                }
                while(amount >= denoms.Penny) 
                {
                    amount -= denoms.Penny;
                    numPennies++;                    
                }

                retVal.Add(USDollarDenominations.DenominationNames.HundredDollars.ToString(), numHundredDollars);
                retVal.Add(USDollarDenominations.DenominationNames.FiftyDollars.ToString(), numFiftyDollars);
                retVal.Add(USDollarDenominations.DenominationNames.TwentyDollars.ToString(), numTwentyDollars);
                retVal.Add(USDollarDenominations.DenominationNames.TenDollars.ToString(), numTenDollars);
                retVal.Add(USDollarDenominations.DenominationNames.FiveDollars.ToString(), numFiveDollars);
                retVal.Add(USDollarDenominations.DenominationNames.OneDollars.ToString(), numOneDollars);
                retVal.Add(USDollarDenominations.DenominationNames.Quarters.ToString(), numQuarters);
                retVal.Add(USDollarDenominations.DenominationNames.Dimes.ToString(), numDimes);
                retVal.Add(USDollarDenominations.DenominationNames.Nickels.ToString(), numNickels);
                retVal.Add(USDollarDenominations.DenominationNames.Pennies.ToString(), numPennies);
            }

            return retVal;
        }

        public Dictionary<string, int> CalculateRandomChange(decimal amount, Currency currency)
        {
            Dictionary<string, int> retVal = new Dictionary<string, int>();

            if (currency == Currency.USDollar) 
            {
                int numHundredDollars = 0;
                int numFiftyDollars = 0;
                int numTwentyDollars = 0;
                int numTenDollars = 0;
                int numFiveDollars = 0;
                int numOneDollars = 0;
                int numQuarters = 0;
                int numDimes = 0;
                int numNickels = 0;
                int numPennies = 0;

                USDollarDenominations denoms = new USDollarDenominations();
                Random rand = new Random();
                Dictionary<string, decimal> denominations = new Dictionary<string, decimal>();
                denominations.Add(USDollarDenominations.DenominationNames.HundredDollars.ToString(), denoms.HundredDollar);
                denominations.Add(USDollarDenominations.DenominationNames.FiftyDollars.ToString(), denoms.FiftyDollar);
                denominations.Add(USDollarDenominations.DenominationNames.TwentyDollars.ToString(), denoms.TwentyDollar);
                denominations.Add(USDollarDenominations.DenominationNames.TenDollars.ToString(), denoms.TenDollar);
                denominations.Add(USDollarDenominations.DenominationNames.FiveDollars.ToString(), denoms.FiveDollar);
                denominations.Add(USDollarDenominations.DenominationNames.OneDollars.ToString(), denoms.OneDollar);
                denominations.Add(USDollarDenominations.DenominationNames.Quarters.ToString(), denoms.Quarter);
                denominations.Add(USDollarDenominations.DenominationNames.Dimes.ToString(), denoms.Dime);
                denominations.Add(USDollarDenominations.DenominationNames.Nickels.ToString(), denoms.Nickel);
                denominations.Add(USDollarDenominations.DenominationNames.Pennies.ToString(), denoms.Penny);

                while (amount > 0)
                {
                    int denomIdx = rand.Next(0, denominations.Count);
                    decimal denom = denominations.Values.ElementAt(denomIdx);
                    if (amount >= denom)
                    {
                        amount -= denom;

                        if (denominations.Keys.ElementAt(denomIdx) == USDollarDenominations.DenominationNames.HundredDollars.ToString())
                        {
                            numHundredDollars++;
                        }
                        else if (denominations.Keys.ElementAt(denomIdx) == USDollarDenominations.DenominationNames.FiftyDollars.ToString())
                        {
                            numFiftyDollars++;
                        }
                        else if (denominations.Keys.ElementAt(denomIdx) == USDollarDenominations.DenominationNames.TwentyDollars.ToString())
                        {
                            numTwentyDollars++;
                        }
                        else if (denominations.Keys.ElementAt(denomIdx) == USDollarDenominations.DenominationNames.TenDollars.ToString())
                        {
                            numTenDollars++;
                        }
                        else if (denominations.Keys.ElementAt(denomIdx) == USDollarDenominations.DenominationNames.FiveDollars.ToString())
                        {
                            numFiveDollars++;
                        }
                        else if (denominations.Keys.ElementAt(denomIdx) == USDollarDenominations.DenominationNames.OneDollars.ToString())
                        {
                            numOneDollars++;
                        }
                        else if (denominations.Keys.ElementAt(denomIdx) == USDollarDenominations.DenominationNames.Quarters.ToString())
                        {
                            numQuarters++;
                        }
                        else if (denominations.Keys.ElementAt(denomIdx) == USDollarDenominations.DenominationNames.Dimes.ToString())
                        {
                            numDimes++;
                        }
                        else if (denominations.Keys.ElementAt(denomIdx) == USDollarDenominations.DenominationNames.Nickels.ToString())
                        {
                            numNickels++;
                        }
                        else
                        {
                            numPennies++;
                        }
                    }
                }

                retVal.Add(USDollarDenominations.DenominationNames.HundredDollars.ToString(), numHundredDollars);
                retVal.Add(USDollarDenominations.DenominationNames.FiftyDollars.ToString(), numFiftyDollars);
                retVal.Add(USDollarDenominations.DenominationNames.TwentyDollars.ToString(), numTwentyDollars);
                retVal.Add(USDollarDenominations.DenominationNames.TenDollars.ToString(), numTenDollars);
                retVal.Add(USDollarDenominations.DenominationNames.FiveDollars.ToString(), numFiveDollars);
                retVal.Add(USDollarDenominations.DenominationNames.OneDollars.ToString(), numOneDollars);
                retVal.Add(USDollarDenominations.DenominationNames.Quarters.ToString(), numQuarters);
                retVal.Add(USDollarDenominations.DenominationNames.Dimes.ToString(), numDimes);
                retVal.Add(USDollarDenominations.DenominationNames.Nickels.ToString(), numNickels);
                retVal.Add(USDollarDenominations.DenominationNames.Pennies.ToString(), numPennies);
            }

            return retVal;
        }
    }
}