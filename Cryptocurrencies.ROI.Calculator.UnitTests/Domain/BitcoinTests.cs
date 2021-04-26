using Cryptocurrencies.ROI.Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Cryptocurrencies.ROI.Calculator.UnitTests.Domain
{
    public class BitcoinTests
    {
        [Fact]
        public void Given_AllValidParameters_When_BitcoinCreated_Then_ObjectInstantiated()
        {
            //Arrange
            var currencyValue = 2100;
            var blockReward = 4.5m;
            var networkDifficulty = 45000000;
            //Act
            var bitcoin = new Bitcoin(currencyValue, blockReward, networkDifficulty);
            //Assert
            Assert.Equal("Bitcoin", bitcoin.CurrencyName);
            Assert.Equal(currencyValue, bitcoin.CurrencyPrice);
            Assert.Equal(blockReward, bitcoin.BlockRewards);
            Assert.Equal(networkDifficulty, bitcoin.NetworkDifficulty);


        }
        [Fact]
        public void Given_AllValidParameters_When_CalculateROIinDaysCalled_Then_ROITimeCalculated()
        {
            //Arrange
            var graphicsCardPrice = 5000;
            var cardName = "GTX 3080";
            var manufacturer = "Nvidia";
            var modelVersion = "10GB";
            var hashPower = 100;

            var GPU = new GraphicsCard(graphicsCardPrice, cardName, manufacturer, modelVersion, hashPower);

            var currencyValue = 2273.3251m;
            var blockReward = 3.7239m;
            var networkDifficulty = 6686223571428240;

            var bitcoin = new Bitcoin(currencyValue, blockReward, networkDifficulty);

            var powerConsumptionPerHour = 450;
            var energyPricePerKWH = 0.1m;
            var expectedDays = 503;

            //Act
            var days = bitcoin.CalculateROIinDays(GPU,  powerConsumptionPerHour, energyPricePerKWH);

            //Assert
            Assert.Equal(expectedDays, days);

        }


    }
}
