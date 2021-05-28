using Newtonsoft.Json;

namespace Cryptocurrencies.ROI.Calculator.Infrastructure
{
    public class ConversionRatesResult
    {
        [JsonProperty("result")]
        public string Result { get; set; }
        [JsonProperty("documentation")]
        public string Documentation { get; set; }
        [JsonProperty("terms_of_use")]
        public string TermsOfUse { get; set; }
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
        [JsonProperty("time_last_update")]
        public string TimeLastUpdate { get; set; }
        [JsonProperty("time_next_update")]
        public string TimeNextUpdate { get; set; }
        [JsonProperty("conversion_rates")]
        public ConversionRate ConversionRates { get; set; }
    }
}
