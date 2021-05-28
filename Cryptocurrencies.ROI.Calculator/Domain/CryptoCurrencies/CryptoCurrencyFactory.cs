namespace Cryptocurrencies.ROI.Calculator.Domain.CryptoCurrencies
{
    public static class CryptoCurrencyFactory 
    {
        public static ICalculateRoi CreateCrypto(CryptoCurrencyTypes type, decimal currencyPrice, decimal blockReward, decimal networkDifficulty)
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
