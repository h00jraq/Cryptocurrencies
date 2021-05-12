﻿using System;
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
            //ShowAvailableCurrencies();
            var chosenCurrency = ChoseCurrencyRate();

            Console.WriteLine("Please choose Crypto Currency you are currently mining.\n" +
                              "List of available crypto currencies:");

            int choosenCryptoCurrency = 0;
            var choosenCryptoCurrencyy = TryParseEnum<CryptoCurrencyTypes>(choosenCryptoCurrency);
            { 
            int currencyValue;
            if (choosenCryptoCurrencyy == CryptoCurrencyTypes.Ethereum)
            {
                var currencyValue = 3991;
                var blockReward = 9.2679m;
                var networkDifficulty = 750000000;
            }
            if (choosenCryptoCurrencyy == CryptoCurrencyTypes.Bitcoin)
            {
                var currencyValue = 68206631527.88;
                var blockReward = 6.8679m;
                var networkDifficulty =2060000000;
            }
            var device = ChooseComputingDevice();
            foreach (var item in device)
            {
                Console.WriteLine(item.Manufacturer + item.Model + item.Version);
            }


            var cryptoCurrency = CryptoCurrencyFactory.CreateCrypto(choosenCryptoCurrencyy, currencyValue, blockReward, networkDifficulty);
            Console.WriteLine("--------The End--------");
            }

        }

        private static object ChoseCurrencyRate()
        {
            Object myCurrency = null;
            try
            {
                var yourCurrency = ChooseCurrencyType();
                var exchangeRateResult = ExchangeRateProvider.Import();
                var conversionRateResult = exchangeRateResult.conversion_rates;
                var conversionRate = conversionRateResult.GetType().GetProperty(yourCurrency).GetValue(conversionRateResult, null);
                Console.WriteLine($"Conversion rate from $ to " + yourCurrency + " is " + conversionRate);
                return conversionRateResult.GetType().GetProperty(yourCurrency).GetValue(conversionRateResult, null);
                
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
            
            foreach (var enumerator in Enum.GetValues(typeof(TEnum)))
              {
                  Console.WriteLine($"- {(int)enumerator}, {enumerator} ");
              }
            Console.Write("Crypto currency number: ");
            TEnum choosenEnumerator = (TEnum)Enum.Parse(typeof(TEnum), Console.ReadLine());
            Console.WriteLine($"You have chosen " + choosenEnumerator + " as Crypto Currency");
            return choosenEnumerator;

        }

    }
}
