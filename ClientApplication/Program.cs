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

            var yourCurrency = Console.ReadLine();
            //Console.WriteLine(result.conversion_rates.PLN);
            Console.WriteLine("Please choose Crypto Currency you are currently mining.\n" +
                              "List of available crypto currencies:");

            foreach (var currency in Enum.GetValues(typeof(CryptoCurrencyTypes)))
            {
                Console.WriteLine($"-{(int)currency}, {currency} ");
            }

            var choosenCryptoCurrency = Convert.ToInt32(Console.ReadLine());
            var cryptoResult = Parsing.TryParseEnum<CryptoCurrencyTypes>(choosenCryptoCurrency, out CryptoCurrencyTypes retVal);
            Console.WriteLine(cryptoResult);
            Console.WriteLine("\n");

            Console.WriteLine($"Everything is calculated to USD $ dollars as {choosenCryptoCurrency} has value in USD $. Chose your default currency:");
            var fromCurrency = Console.ReadLine();
            Console.WriteLine("\n");

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
                Console.WriteLine($"-{(int)currencyType}, {currencyType} ");
            }

            CurrencyTypes choosenCryptoCurrency = Convert.ToInt32(Console.ReadLine());
            CurrencyTypes cryptoResult = Parsing.TryParseEnum<CryptoCurrencyTypes>(choosenCryptoCurrency, out CryptoCurrencyTypes retVal);
            Console.WriteLine(cryptoResult);
            Console.WriteLine("\n");
            return choosenCryptoCurrency;
        }

    }
}
