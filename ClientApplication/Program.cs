using System;
using System.Collections.Generic;
using Cryptocurrencies.ROI.Calculator.Domain;
using System.Linq;
using Newtonsoft.Json;
using Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices;
using Cryptocurrencies.ROI.Calculator.Domain.CryptoCurrencies;
using Cryptocurrencies.ROI.Calculator.HelperClasses;
using Cryptocurrencies.ROI.Calculator.Infrastructure;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var chosenCurrency = ChoseCurrencyRate();
                UserConsole.AskChooseCryptoCurrency();
                var chosenCryptoCurrency = ChoseCryptoCurrency();
                var device = ChooseComputingDevice()?.First();
                UserConsole.DisplayChosenDevice(device);
                var myCrypto = CreateCrypto(chosenCryptoCurrency);
                UserConsole.Ask_PowerConsumptionPerHour();
                var powerConsumptionPerHour = UserConsole.ReadPowerConsumptionPerHour();
                var energyPricePerKwh = UserConsole.ReadPricePerKWH();
                var roiInDays = myCrypto.CalculateRoIinDays(device, powerConsumptionPerHour, energyPricePerKwh, chosenCurrency);
                Console.WriteLine($"You will get your money back after " + roiInDays + " days of mining 24 hours/day");
                Console.WriteLine("--------The End--------");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        
        private static CryptoCurrencyTypes ChoseCryptoCurrency()
        {
            foreach (var enumerator in Enum.GetValues<CryptoCurrencyTypes>())
            {
                Console.WriteLine($"- {(int)enumerator}, {enumerator} ");
            }
            Console.Write("Your currency: ");
            CryptoCurrencyTypes chosenCryptoCurrency = 0;
            var success = false;
            do
            {
                Console.Write("Your currency: ");
                if (!Int32.TryParse(Console.ReadLine(), out int value) || !TryParseCurrencyEnum(value, out CryptoCurrencyTypes currencyValue))
                {
                    Console.WriteLine("That currency does not exist!");
                }
                else
                {
                    chosenCryptoCurrency = currencyValue;
                    Console.WriteLine($"You have chosen " + chosenCryptoCurrency + " as Crypto Currency \n");
                    success = true;
                }

            }
            while (!success);
            return chosenCryptoCurrency;
        }

        private static ICalculateRoi CreateCrypto(CryptoCurrencyTypes choosenCryptoCurrency) => choosenCryptoCurrency switch
        {
            CryptoCurrencyTypes.Ethereum => CryptoCurrencyFactory.CreateCrypto(CryptoCurrencyTypes.Ethereum, 3991.7733m, 4.446598m, 7503377692267855),
            CryptoCurrencyTypes.Bitcoin => CryptoCurrencyFactory.CreateCrypto(CryptoCurrencyTypes.Bitcoin, 50435.2699m, 6.88159m, 18046e16m),
            _ => throw new ArgumentOutOfRangeException(nameof(choosenCryptoCurrency), $"Not expected crypto value: {choosenCryptoCurrency}"),
        };
        private static double ChoseCurrencyRate()
        {
            double myCurrency = 0;
            try
            {
                var yourCurrency = ChooseCurrencyType();
                var exchangeRateResult = ExchangeRateProvider.Import();
                var conversionRateResult = exchangeRateResult.ConversionRates;
                var conversionRate = conversionRateResult.GetType().GetProperty(yourCurrency)?.GetValue(conversionRateResult, null);
                Console.WriteLine($"Conversion rate from $ to " + yourCurrency + " is " + conversionRate);
                return (double)conversionRateResult.GetType().GetProperty(yourCurrency).GetValue(conversionRateResult, null);
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
            Console.Write("Your choice:");
            string deviceType = Console.ReadLine();

            Console.WriteLine("Choose the device Manufacturer from below ones: \n");

            var manufacturers = DevicesProvider.AvailableDevices.Where(p => p.GetType().Name == deviceType)
                                .GroupBy(p => p.Manufacturer)
                                .Select(p => p.First())
                                .ToList();

            if (manufacturers.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceType), deviceType,
                    $"No manufactures for that type.");
            }
            
            foreach (var item in manufacturers)
            {
                Console.WriteLine("-" + item.Manufacturer);
            }
            Console.Write("Device Manufacturer: ");
            string deviceManufacturer = Console.ReadLine();
            Console.WriteLine("\n");

            Console.Write("Choose the Model: \n");

            var listOfDevicesByModel = DevicesProvider.AvailableDevices.Where(g => g.GetType().Name == deviceType).Where(g => g.Manufacturer == deviceManufacturer)
                                .GroupBy(g => g.Model)
                                .Select(g => g.First())
                                .ToList();
            
            if (listOfDevicesByModel.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceManufacturer), deviceManufacturer,
                    $"No devices for that device manufacturer.");
            }
            
            foreach (var item in listOfDevicesByModel)
            {
                Console.WriteLine("-" + item.Model);
            }
            Console.Write("Device Model: ");
            string deviceModel = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write("Choose the Version: \n");

            var listOfModelsByVersion = DevicesProvider.AvailableDevices.Where(g => g.GetType().Name == deviceType)
                               .Where(g => g.Model == deviceModel)
                               .GroupBy(g => g.Version)
                               .Select(g => g.First())
                               .ToList();
           
            if (listOfModelsByVersion.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceModel), deviceModel,
                    $"No versions for that device model.");
            }
            
            foreach (var item in listOfModelsByVersion)
            {
                Console.WriteLine("-" + item.Version);
            }
            
            Console.Write("Device Version: ");
            string version = Console.ReadLine();

            var chosenDevices = DevicesProvider.AvailableDevices.Where(d => d.GetType().Name == deviceType)
                .Where(d => d.Manufacturer == deviceManufacturer).Where(d => d.Model == deviceModel)
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

        static string ChooseCurrencyType()
        {
            Console.WriteLine("Please choose from the following Currencies: ");
            foreach (var currencyType in Enum.GetValues(typeof(CurrencyTypes)))
            {
                Console.WriteLine($"- {(int)currencyType}, {currencyType} ");
            }
            CurrencyTypes currencyValue = 0;
            CurrencyTypes choosenCurrency = 0;
            var success = false;
            do
            {
                Console.Write("Currency number: ");
                if(!Int32.TryParse(Console.ReadLine(), out int value) || !TryParseCurrencyEnum(value, out  currencyValue))
                {
                    Console.WriteLine("That currency does not exist!");
                }
                else
                {
                    choosenCurrency = currencyValue;
                    success = true;
                }
            }
            while (!success);
            Console.WriteLine($"You have chosen " + choosenCurrency + " currency");
            return choosenCurrency.ToString(); ;
        }

        private static bool TryParseCurrencyEnum<TEnum>(int enumValue, out TEnum retVal)
        {


            retVal = default(TEnum);
            bool success = Enum.IsDefined(typeof(TEnum), enumValue);
            if (success)
            {
                retVal = (TEnum)Enum.ToObject(typeof(TEnum), enumValue);
            }
            return success;

        }

    }
}
