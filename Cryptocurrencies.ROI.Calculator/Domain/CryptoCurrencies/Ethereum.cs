using Cryptocurrencies.ROI.Calculator.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Domain
{
    public class Ethereum : ICalculateROI
    {
        public string CurrencyName { get; private set; }
        public decimal CurrencyPrice { get; private set; }
        public decimal BlockRewards { get; private set; }
        public decimal NetworkDifficulty { get; private set; }


        public Ethereum(decimal currencyPrice, decimal blockReward, decimal networkDifficulty)
        {
            Check.GreaterThan(currencyPrice, nameof(currencyPrice));
            Check.GreaterThan(blockReward, nameof(blockReward));
            Check.GreaterThan(networkDifficulty, nameof(networkDifficulty));

            CurrencyName = "Ethereum";
            CurrencyPrice = currencyPrice;
            BlockRewards = blockReward;
            NetworkDifficulty = networkDifficulty;

        }

        public decimal CalculateROIinDays(ComputingDevice device,  int powerConsumptionPerHour, decimal energyPricePerKWH, double currencyRate)
        {
            decimal coinsPerDay = (((device.HashPower * 1000000 * BlockRewards) / NetworkDifficulty) * 3600 * 24);
            var returnOfInvestmentTimeInDays = (device.Price / ((coinsPerDay * CurrencyPrice) - ((24 * powerConsumptionPerHour)/1000) * energyPricePerKWH));
            return Math.Round(returnOfInvestmentTimeInDays);
        }
    }
}
