using System;
using System.Collections.Generic;
using Cryptocurrencies.ROI.Calculator.Domain;
using System.Linq;
using ExchangeRate_API;
using Newtonsoft.Json;
using Cryptocurrencies.ROI.Calculator.API;
using Cryptocurrencies.ROI.Calculator.HelperClasses;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            var GraphicsCardList = new List<GraphicsCard>()
            {
                new GraphicsCard(1000, "GTX 1080", "MSI", "Gaming X", 40),
                new GraphicsCard(2000, "RTX 3080", "MSI", "OC 3", 100),
                new GraphicsCard(3000, "RTX 3090", "Asus", "TUF", 140),
                new GraphicsCard(2100, "RTX 3080", "EVGA", "Ultra", 105),
                new GraphicsCard(1500, "RTX 3070", "Asus", "OC 2", 70),
                new GraphicsCard(2100, "RTX 3080", "Asus", "ROG Strix", 105),
                new GraphicsCard(2000, "RTX 3080", "Gigabyte", "Gaming Trio", 95),
                new GraphicsCard(3150, "RTX 3090", "Asus", "ROG Strix", 145),
                new GraphicsCard(1250, "RTX 3060", "Asus", "TUF", 80),
                new GraphicsCard(1350, "RTX 3060 Ti", "MSI", "Gaming X", 85),
                new GraphicsCard(1450, "RTX 3070", "MSI", "Gaming OC", 98)
            };

            IEnumerable<GraphicsCard> gpuList = GraphicsCardList;

            string fromCurrency = "PLN";
            string toCurrency = "USD";
            string defaultCurrency = "USD";
            int amount = 5000;

            String URLString = "https://v6.exchangerate-api.com/v6/21befb41ac31b6bda340a9b8/latest/USD";
            var webClient = new System.Net.WebClient();
            var json = webClient.DownloadString(URLString);
            API_Obj currencyRate = JsonConvert.DeserializeObject<API_Obj>(json);
            Console.WriteLine(currencyRate.conversion_rates.PLN);

            Console.WriteLine("Please choose Crypto Currency you are currently mining.\n" +
                              "List of available crypto currencies:");
            foreach(var currency in Enum.GetValues(typeof(CryptoCurrencyTypes)))
            {
                Console.WriteLine($"-{(int)currency}, {currency} ");
            }
            
            var choosenCryptoCurrency =  Convert.ToInt32(Console.ReadLine());
            var result = Parsing.TryParseEnum<CryptoCurrencyTypes>(choosenCryptoCurrency, out CryptoCurrencyTypes retVal);
            Console.WriteLine(result);
            Console.WriteLine("\n");

            // Get all available currency tags
            string[] availableCurrency = CurrencyConverter.GetCurrencyTags();
            // Print currency tags comma seperated
            Console.WriteLine("Available Currencies");
            Console.WriteLine(string.Join(",", availableCurrency));
            Console.WriteLine("\n");

            Console.WriteLine($"Everything is calculated to USD $ dollars as {choosenCryptoCurrency} has value in USD $. Chose your default currency:");
            fromCurrency = Console.ReadLine();
            Console.WriteLine("\n");

            float exchangeRate = CurrencyConverter.GetExchangeRate(fromCurrency, toCurrency, amount);
            // Print result of currency exchange
            Console.WriteLine("FROM " + amount + " " + fromCurrency.ToUpper() + " TO " + toCurrency.ToUpper() + " = " + exchangeRate);

            // Wait for key press to close console window
            Console.ReadLine();
        }

       
    }
}
