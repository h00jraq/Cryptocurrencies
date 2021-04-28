using System;
using Cryptocurrencies.ROI.Calculator.Domain;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string fromCurrency = "PLN";
            string toCurrency = "USD";
            string defaultCurrency = "USD";
            int amount = 5000;

            // Get all available currency tags
            string[] availableCurrency = CurrencyConverter.GetCurrencyTags();
            // Print currency tags comma seperated
            Console.WriteLine("Available Currencies");
            Console.WriteLine(string.Join(",", availableCurrency));
            Console.WriteLine("\n");

            Console.WriteLine("Chose your default currency:");
            defaultCurrency = Console.ReadLine();
            Console.WriteLine("\n");
        }
    }
}
