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
            var chosenCurrency = ChoseCurrencyRate();

            Console.WriteLine("Please choose Crypto Currency you are currently mining.\n" +
                              "List of available crypto currencies:");
            foreach (var enumerator in Enum.GetValues<CryptoCurrencyTypes>())
            {
                Console.WriteLine($"- {(int)enumerator}, {enumerator} ");
            }
            var cryptoCurrency = Convert.ToInt32(Console.ReadLine());
            var choosenCryptoCurrency = TryParseEnum<CryptoCurrencyTypes>(cryptoCurrency);
            {

                var device = ChooseComputingDevice();
                Console.WriteLine(device.Manufacturer + device.Model + device.Version);
                var myCrypto = CreateCrypto(choosenCryptoCurrency);
                Console.Write("What is your PC/Device power consumpsion per hour(in Kilowats)?");
                var powerConsumptionPerHours = Convert.ToInt32(Console.ReadLine());
                Console.Write("What is your PC/Device power consumpsion per hour(in Kilowats)?");
                var energyPricePerKWH = Convert.ToInt32(Console.ReadLine());
                var roiINDays = myCrypto.CalculateROIinDays(device, powerConsumptionPerHours, energyPricePerKWH, chosenCurrency);
                Console.WriteLine("--------The End--------");
            }

        }


        public static ICalculateROI CreateCrypto(CryptoCurrencyTypes choosenCryptoCurrency) => choosenCryptoCurrency switch 
        {
            CryptoCurrencyTypes.Ethereum => CryptoCurrencyFactory.CreateCrypto(CryptoCurrencyTypes.Ethereum, 3991m, 9.2679m, 750000000),
            CryptoCurrencyTypes.Bitcoin => CryptoCurrencyFactory.CreateCrypto(CryptoCurrencyTypes.Bitcoin, 54561.69751m, 6.8679m, 2060000000),
            _ => throw new ArgumentOutOfRangeException(nameof(choosenCryptoCurrency), $"Not expected crypto value: {choosenCryptoCurrency}"), 
        };
        private static decimal ChoseCurrencyRate()
        {
            decimal myCurrency = 0;
            try
            {
                var yourCurrency = ChooseCurrencyType();
                var exchangeRateResult = ExchangeRateProvider.Import();
                var conversionRateResult = exchangeRateResult.conversion_rates;
                decimal conversionRate = (decimal)conversionRateResult.GetType().GetProperty(yourCurrency).GetValue(conversionRateResult, null);
                Console.WriteLine($"Conversion rate from $ to " + yourCurrency + " is " + conversionRate);
                return (decimal)conversionRateResult.GetType().GetProperty(yourCurrency).GetValue(conversionRateResult, null);

            }
            catch
            {
                Console.WriteLine("API comunication error");
            }
            return myCurrency;
        }

        static IEnumerable<ComputingDevice> ChooseComputingDevice()
        {
            Console.WriteLine("Please choose what kind of device you are using to mine CryptoCurrency: ");
            var listOfDevices = DevicesProvider.AvailableDevices.Where(p => p.GetType().BaseType == typeof(ComputingDevice))
                                .GroupBy(p => p.GetType().Name)
                                .Select(g => g.First())
                                .ToList();

            foreach (var item in listOfDevices)
            {
                Console.WriteLine("-" + item.GetType().Name);
            }
            Console.WriteLine("\n");
            Console.Write("Your choice:");
            string deviceType = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Choose the device Manufacturer from below ones: \n");

            var manufacturers = DevicesProvider.AvailableDevices.Where(p => p.GetType().Name == deviceType)
                                .GroupBy(p => p.Manufacturer)
                                .Select(p => p.First())
                                .ToList();

            foreach (var item in manufacturers)
            {
                Console.WriteLine("-" + item.Manufacturer);
            }
            Console.WriteLine("\n");
            Console.Write("Device Manufacturer: ");
            string deviceManufacturer = Console.ReadLine();
            Console.WriteLine("\n");

            Console.Write("Choose the Model: \n");

            var listOfDevicesByModel = DevicesProvider.AvailableDevices.Where(g => g.GetType().Name == deviceType).Where(g => g.Manufacturer == deviceManufacturer)
                                .GroupBy(g => g.Model)
                                .Select(g => g.First())
                                .ToList();
            foreach (var item in listOfDevicesByModel)
            {
                Console.WriteLine(item.Model);
            }
            string deviceModel = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write("Choose the Version: \n");

            var listOfModelsByVersion = DevicesProvider.AvailableDevices.Where(g => g.GetType().Name == deviceType).Where(g => g.Model == deviceModel)
                               .GroupBy(g => g.Version)
                               .Select(g => g.First())
                               .ToList();
            foreach (var item in listOfModelsByVersion)
            {
                Console.WriteLine(item.Version);
            }
            Console.WriteLine("\n");
            string version = Console.ReadLine();

            var chosenDevices = DevicesProvider.AvailableDevices.Where(d => d.GetType().Name == deviceType).Where(d => d.Manufacturer == deviceManufacturer).Where(d => d.Model == deviceModel)
                                                                .Where(d => d.Version == version)
                                                                .Select(d => d)
                                                                .ToList();

            Console.WriteLine($"The Devices that you have chosen is: \n" +
                $"              DeviceType:{deviceType}  \n" +
                $"              Manufacturer:{deviceManufacturer}  \n" +
                $"              Model:{deviceModel} \n" +
                $"              Version:{version}\n");

            return chosenDevices;
        }

        static void ShowAvailableCurrencies()
        {
            string[] availableCurrency = CurrencyConverter.GetCurrencyTags();

            Console.WriteLine("Available Currencies");
            Console.WriteLine(string.Join(",", availableCurrency));
            Console.WriteLine("\n");

        }

        static string ChooseCurrencyType()
        {
            Console.WriteLine("Please choose from the following Currencies: ");
            foreach (var currencyType in Enum.GetValues(typeof(CurrencyTypes)))
            {
                Console.WriteLine($"- {(int)currencyType}, {currencyType} ");
            }
            Console.Write("Currency number: ");
            CurrencyTypes choosenCurrency = (CurrencyTypes)Enum.Parse(typeof(CurrencyTypes), Console.ReadLine());
            Console.WriteLine($"You have chosen " + choosenCurrency + " currency");
            return choosenCurrency.ToString(); ;
        }

        static TEnum TryParseEnum<TEnum>(int value)
        {


            Console.Write("Crypto currency number: ");
            TEnum choosenEnumerator = (TEnum)Enum.Parse(typeof(TEnum), Convert.ToString(value));
            Console.WriteLine($"You have chosen " + choosenEnumerator + " as Crypto Currency");
            return choosenEnumerator;

        }

    }
}
