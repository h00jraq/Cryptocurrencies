using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Domain
{
    public static class CryptoCurrencyFactory 
    {
        public static ICalculateROI CreateCrypto(CryptoCurrencyTypes type, decimal currencyPrice, decimal blockReward, decimal networkDifficulty)
        {
            switch (type)
            {
                case  CryptoCurrencyTypes.Ethereum:
                    return new Ethereum(currencyPrice,  blockReward, networkDifficulty);

                case  CryptoCurrencyTypes.Bitcoin:
                    return new Bitcoin(currencyPrice, blockReward, networkDifficulty);

                default:
                    return null;

            }
        }
    }
}
