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

            Console.WriteLine("\nPlease choose Crypto Currency you are currently mining.\n" +
                              "List of available crypto currencies:");
            foreach (var enumerator in Enum.GetValues<CryptoCurrencyTypes>())
            {
                Console.WriteLine($"- {(int)enumerator}, {enumerator} ");
            }
            Console.Write("Your currency: ");
            var cryptoCurrency = Convert.ToInt32(Console.ReadLine());
            var choosenCryptoCurrency = TryParseEnum<CryptoCurrencyTypes>(cryptoCurrency);
            {

                var device = ChooseComputingDevice().First();
                Console.WriteLine(device.Manufacturer +" " + device.Model + " " + device.Version);
                var myCrypto = CreateCrypto(choosenCryptoCurrency);
                Console.Write("What is your PC/Device power consumpsion per hour(in Kilowats)?: ");
                var powerConsumptionPerHours = Convert.ToInt32(Console.ReadLine());
                Console.Write(@"What is your price per Kilowat\h in Yoyr country?: ");
                var energyPricePerKWH = Convert.ToDecimal(Console.ReadLine());
                var roiINDays = myCrypto.CalculateROIinDays(device, powerConsumptionPerHours, energyPricePerKWH, chosenCurrency);
                Console.WriteLine($"You will get your money back after " + roiINDays + " days of mining 24 hours/day");
                Console.WriteLine("--------The End--------");
            }

        }


        public static ICalculateROI CreateCrypto(CryptoCurrencyTypes choosenCryptoCurrency) => choosenCryptoCurrency switch 
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
                var conversionRateResult = exchangeRateResult.conversion_rates;
                var conversionRate = conversionRateResult.GetType().GetProperty(yourCurrency).GetValue(conversionRateResult, null);
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
            foreach (var item in listOfDevicesByModel)
            {
                Console.WriteLine("-" + item.Model);
            }
            Console.Write("Device Model: ");
            string deviceModel = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write("Choose the Version: \n");

            var listOfModelsByVersion = DevicesProvider.AvailableDevices.Where(g => g.GetType().Name == deviceType).Where(g => g.Model == deviceModel)
                               .GroupBy(g => g.Version)
                               .Select(g => g.First())
                               .ToList();
            foreach (var item in listOfModelsByVersion)
            {
                Console.WriteLine("-" +item.Version);
            }
            Console.Write("Device Version: ");
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
            int value = Convert.ToInt32(Console.ReadLine());
            bool success = TryParseEnum2<CurrencyTypes>(value, out CurrencyTypes choosenCurrency);
            if (!success)
            {
                Console.WriteLine("That currency does not exist, default currency set to USD $");
            }
            Console.WriteLine($"You have chosen " + choosenCurrency + " currency");
            return choosenCurrency.ToString(); ;
        }

        static TEnum TryParseEnum<TEnum>(int value)
        {


            Console.Write("Crypto currency chosen: ");
            TEnum choosenEnumerator = (TEnum)Enum.Parse(typeof(TEnum), Convert.ToString(value));
            Console.WriteLine($"You have chosen " + choosenEnumerator + " as Crypto Currency \n");
            return choosenEnumerator;

        }

        public static bool TryParseEnum2<TEnum>(int enumValue, out TEnum retVal)
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
