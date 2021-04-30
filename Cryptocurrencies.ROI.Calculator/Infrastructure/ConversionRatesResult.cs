using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.API
{
    public class ConversionRatesResult
    {
        [JsonProperty("result")]
        public string Result { get; set; }
        public string documentation { get; set; }
        public string terms_of_use { get; set; }
        public string time_zone { get; set; }
        public string time_last_update { get; set; }
        public string time_next_update { get; set; }
        public ConversionRate conversion_rates { get; set; }
    }
}
