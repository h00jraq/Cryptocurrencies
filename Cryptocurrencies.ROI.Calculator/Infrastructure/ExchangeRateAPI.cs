using System;
using Cryptocurrencies.ROI.Calculator.API;
using Cryptocurrencies.ROI.Calculator.Infrastructure;
using Newtonsoft.Json;

namespace ExchangeRate_API
{

    public static class ExchangeRateProvider
    {
        public static ConversionRatesResult Import()
        {
            String URLString = ExchangeRateUrlProvider.URLString;
            using (var webClient = new System.Net.WebClient()) // Change WebClient() to HTTPClient()
            {
                var json = webClient.DownloadString(URLString);
                ConversionRatesResult result = (ConversionRatesResult)JsonConvert.DeserializeObject(json);
                return result;
            }
        }
    }

}