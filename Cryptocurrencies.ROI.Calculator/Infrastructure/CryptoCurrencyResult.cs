using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cryptocurrencies.ROI.Calculator.Infrastructure
{
    class CryptoCurrencyResult
    {
        [JsonProperty("conversion_rates")]
        public CryptoCurrencyData ConversionRates { get; set; }
    }
}
