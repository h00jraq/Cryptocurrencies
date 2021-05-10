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

            var device = ChooseComputingDevice();
            foreach (var item in device)
            {
                Console.WriteLine(item.Manufacturer + item.Model + item.Version);
            }

            Console.WriteLine("--------------------------------");
            
            ShowAvailableCurrencies();
            Console.WriteLine("\n");

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
                                                                .Select(d =>d)
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
