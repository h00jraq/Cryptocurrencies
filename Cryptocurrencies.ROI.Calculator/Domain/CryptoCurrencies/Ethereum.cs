using System;
using Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices;
using Cryptocurrencies.ROI.Calculator.HelperClasses;

namespace Cryptocurrencies.ROI.Calculator.Domain.CryptoCurrencies
{
    public class Ethereum : ICalculateRoi
    {
        public string CurrencyName { get; }
        public decimal CurrencyPrice { get; }
        public decimal BlockRewards { get; }
        public decimal NetworkDifficulty { get; }


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

        public decimal CalculateRoIinDays(ComputingDevice device,  int powerConsumptionPerHour, decimal energyPricePerKwh, double currencyRate)
        {
            decimal coinsPerDay = (((device.HashPower * 1000000 * BlockRewards) / NetworkDifficulty) * 3600 * 24);
            var returnOfInvestmentTimeInDays = (device.Price / ((coinsPerDay * CurrencyPrice) - ((24 * powerConsumptionPerHour)/1000) * energyPricePerKwh));
            return Math.Round(returnOfInvestmentTimeInDays);
        }
    }
}
