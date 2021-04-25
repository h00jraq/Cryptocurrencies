using Cryptocurrencies.ROI.Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cryptocurrencies.ROI.Calculator.UnitTests.Domain
{
    public class CryptoCurrencyFactoryTests
    {
        [Fact]
        public void Given_CryptoCurrencyName_When_CreateCryptoCalled_Then_ObjectInstantiated()
        {
            //Arrange
            var currencyValue = 2100;
            var blockReward = 4.5m;
            var networkDifficulty = 45000000;

            //Act
            var ethereum = CryptoCurrencyFactory.CreateCrypto(CryptoCurrencyTypes.Ethereum, currencyValue, blockReward, networkDifficulty);

            //Assert
            Assert.NotNull(ethereum);
            Assert.IsType<Ethereum>(ethereum);


        }


    }
}
