using System;
using System.Collections.Generic;
using Cryptocurrencies.ROI.Calculator.Domain;
using System.Linq;
using ExchangeRate_API;
using Newtonsoft.Json;
using Cryptocurrencies.ROI.Calculator.API;
using Cryptocurrencies.ROI.Calculator.HelperClasses;
using Cryptocurrencies.ROI.Calculator.Infrastructure;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            ShowAvailableCurrencies();


            ConversionRatesResult result;
            try
            {
                result = ExchangeRateProvider.Import();
            }
           catch
            {
                Console.WriteLine("API comunication error");
            }

            var yourCurrency = ChooseCurrencyType();
            Console.WriteLine("Please choose Crypto Currency you are currently mining.\n" +
                              "List of available crypto currencies:");

            int choosenCryptoCurrency = 0;
            Console.WriteLine("\n");
            var choosenCryptoCurrencyy = TryParseEnum<CryptoCurrencyTypes>(choosenCryptoCurrency);
            Console.WriteLine("\n");
            Console.WriteLine("Please choose what kind of device (GPU, ASIC etc) you are using to mine CryptoCurrency");
            var query = (m => m.)

        }




        static void ShowAvailableCurrencies()
        {
            string[] availableCurrency = CurrencyConverter.GetCurrencyTags();

            Console.WriteLine("Available Currencies");
            Console.WriteLine(string.Join(",", availableCurrency));
            Console.WriteLine("\n");

        }

        static CurrencyTypes ChooseCurrencyType()
        {
            foreach (var currencyType in Enum.GetValues(typeof(CurrencyTypes)))
            {
                Console.WriteLine($"- {(int)currencyType}, {currencyType} ");
            }

            CurrencyTypes choosenCryptoCurrency = (CurrencyTypes)Enum.Parse(typeof(CurrencyTypes), Console.ReadLine());
            Console.WriteLine(choosenCryptoCurrency);
            Console.WriteLine("\n");
            return choosenCryptoCurrency;
        }

        static TEnum TryParseEnum<TEnum>(int value)
        {
            
            foreach (var enumerator in Enum.GetValues(typeof(TEnum)))
              {
                  Console.WriteLine($"- {(int)enumerator}, {enumerator} ");
              }
            TEnum choosenEnumerator = (TEnum)Enum.Parse(typeof(TEnum), Console.ReadLine());
            Console.WriteLine(choosenEnumerator);
            return choosenEnumerator;

        }

    }
}
