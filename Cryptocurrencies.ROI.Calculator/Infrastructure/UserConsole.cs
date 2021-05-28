using Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Infrastructure
{
    public static class UserConsole
    {

        public static void AskChooseCryptoCurrency()
        {
            Console.WriteLine("\n Please choose Crypto Currency you are currently mining.\n" +
                                     "List of available crypto currencies:");
        }

        public static void DisplayChosenDevice(ComputingDevice device)
        {
            Console.WriteLine(device.Manufacturer + " " + device.Model + " " + device.Version);
        }

        public static void Ask_PowerConsumptionPerHour()
        {
            Console.Write("What is your PC/Device power consumpsion per hour(in Kilowats)?: ");
        }

        public static int ReadPowerConsumptionPerHour()
        {
            int powerConsumptionPerHour = 0;
            do
            {
                Console.Write("number: ");
                if ((!Int32.TryParse(Console.ReadLine(), out int value)) || (value == 0))
                {
                    Console.WriteLine("Not a correct number!");
                    
                }
                else
                {
                    powerConsumptionPerHour = value;
                }
                
            }
            while (powerConsumptionPerHour <= 0);
            return powerConsumptionPerHour;

        }

        public static int ReadPricePerKWH()
        {
            Console.Write("What is the Price per KWH in your country? ");
            int pricePerKWH = 0;
            do
            {
                Console.Write("Price per KWH: ");
                if ((!Int32.TryParse(Console.ReadLine(), out int value)) || (value == 0))
                {
                    Console.WriteLine("Not a correct number!");

                }
                else
                {
                    pricePerKWH = value;
                }

            }
            while (pricePerKWH <= 0);
            return pricePerKWH;

        }

    }
}
