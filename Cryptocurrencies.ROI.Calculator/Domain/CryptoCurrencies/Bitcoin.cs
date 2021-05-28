using System;
using Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices;
using Cryptocurrencies.ROI.Calculator.HelperClasses;

namespace Cryptocurrencies.ROI.Calculator.Domain.CryptoCurrencies
{
    public class Bitcoin : ICalculateRoi
    {

        public string CurrencyName { get; }
        public decimal CurrencyPrice { get; }
        public decimal BlockRewards { get; }
        public decimal NetworkDifficulty { get; }


        public Bitcoin(decimal currencyPrice, decimal blockReward, decimal networkDifficulty)
        {
            Check.GreaterThan(currencyPrice, nameof(currencyPrice));
            Check.GreaterThan(blockReward, nameof(blockReward));
            Check.GreaterThan(networkDifficulty, nameof(networkDifficulty));

            CurrencyName = "Bitcoin";
            CurrencyPrice = currencyPrice;
            BlockRewards = blockReward;
            NetworkDifficulty = networkDifficulty;

        }

        /*Average coins/day for a miner can be estimated by comparing the miner's hashrate with the hashrate of the network.

        Cm/day = subsidy* (1440 / blocktime) * (Hm / Hn)
        where,
        Cm is total coins for the miner
        subsidy is the number of coins/block a miner gets as a reward
        blocktime is the average time per block
        Hm is the miner's hashrate (Hash/sec)
        Hn is the total network hashpower(Hash/sec)
        1440 is minutes per day
        
        Since the total network hashpower is unknown, it must be estimated based on the current difficulty.This can be done by noting that Difficulty D
        D = hashrate / 7158388.055
        Because
        difficulty = hashrate / (2 ^ 256 / max_target / intended_time_per_block)
                   = hashrate / (2 ^ 256 / (2 ^ 208 * 65535) / 600)
                   = hashrate / (2 ^ 48 / 65535 / 600)
                   = hashrate / 7158388.055
        Check Relationship Between Hashrate and Difficulty
        So, for bitcoin given a current difficulty of 5,949,437,371,610 an Antminer S9 with a hashrate of about 14TH/s:
        Hn = 5,949,437,371,610 * 7158388.055 = 42,588,381 TH/s
        Cm/day = 12.5 * (1440 / 10) * (14e12 / 42588381e12) = 0.00059171068
        Note: This is an average value, so with a large enough pool and enough days, 
        your earnings will average to this formula (this does not account for the difficulty and network hashpower changing, of course).
        */
        public decimal CalculateRoIinDays(ComputingDevice device, int powerConsumptionPerHour, decimal energyPricePerKwh, double currencyRate)
        {
            var blockTime = 10; //block length in minutes
            var coinsPerDay = BlockRewards * (1440 / blockTime) * (device.HashPower / NetworkDifficulty);
            Console.WriteLine($"With curren setup, you will mine " + coinsPerDay +" per day");
            var returnOfInvestmentTimeInDays = (device.Price / ((coinsPerDay * CurrencyPrice * (decimal)currencyRate) - ((24 * powerConsumptionPerHour) / 1000) * energyPricePerKwh));
            return Math.Round(returnOfInvestmentTimeInDays);
        }

    }


}
