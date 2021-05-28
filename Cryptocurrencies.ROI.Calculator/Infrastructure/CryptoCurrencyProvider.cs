using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Infrastructure
{
    class CryptoCurrencyProvider
    {
        public static CryptoCurrencyResult ImportCryptoCurrencies()
        {
            String URLString = "https://api.minerstat.com/v2/coins?list=ETH";
            using (var client = new HttpClient()) // Change WebClient() to HTTPClient()
            {
                var json = client.GetStringAsync(URLString);
                //why casting is not enough here and I have to use <T>? All ovverloards return .Net object or .Net type .
                // this throw exception System.InvalidCastException: 'Unable to cast object of type 'Newtonsoft.Json.Linq.JObject' to type 'Cryptocurrencies.ROI.Calculator.API.ConversionRatesResult'.'
                // ConversionRatesResult result2 = (ConversionRatesResult)JsonConvert.DeserializeObject(;
                CryptoCurrencyResult result = JsonConvert.DeserializeObject<CryptoCurrencyResult>(json.Result);
                return result;
            }
        }
    }
}
