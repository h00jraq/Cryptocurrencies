using System;
using System.Net.Http;
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
            using (var client = new HttpClient()) // Change WebClient() to HTTPClient()
            {
                var json = client.GetStringAsync(URLString);
                //why casting is not enough here and I have to use <T>? All ovverloards return .Net object or .Net type .
                // this throw exception System.InvalidCastException: 'Unable to cast object of type 'Newtonsoft.Json.Linq.JObject' to type 'Cryptocurrencies.ROI.Calculator.API.ConversionRatesResult'.'
                // ConversionRatesResult result2 = (ConversionRatesResult)JsonConvert.DeserializeObject(;
                ConversionRatesResult result = JsonConvert.DeserializeObject<ConversionRatesResult>(json.Result);
                return result;
            }
        }
    }

}