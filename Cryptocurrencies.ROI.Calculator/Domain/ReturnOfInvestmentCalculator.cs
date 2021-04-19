using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cryptocurrencies.ROI.Calculator.Domain
{
    static class ReturnOfInvestmentCalculator
    {
        //((hashrate [h/s] * reward) / difficulty) * (1 - poolfee) * 3600 * 24 = reward in coins per day
        public static double CalculateProfitPerDay(GraphicsCard card, decimal energyPricePerHour,  decimal pricePerCoin,
                                               int difficulty, decimal reward )
        {

            int CoinsPerDay = Convert.ToInt32(((card.hashPower * 1000000 * reward) / difficulty) * 3600 * 24);
            var ReturnOfInvestmentTimeInDays =  (card.price / ((CoinsPerDay * pricePerCoin) - (24 * energyPricePerHour)));
            return Convert.ToDouble(ReturnOfInvestmentTimeInDays);
        }


    }
}
