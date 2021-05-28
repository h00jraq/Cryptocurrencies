using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cryptocurrencies.ROI.Calculator.Infrastructure
{
    class CryptoCurrencyData
    {
        [JsonProperty("id")]

        public int Id { get; set; }
        [JsonProperty("coin")]
        public string Coin { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; }
        [JsonProperty("network_hashrate")]
        public long NetworkHashrate { get; set; }
        [JsonProperty("difficulty")]
        public long Difficulty { get; set; }
        [JsonProperty("reward")]
        public long Reward { get; set; }
        [JsonProperty("reward_unit")]
        public string RewardUnit { get; set; }
        [JsonProperty("reward_block")]
        public decimal RewardBlock { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("volume")]
        public long Volume { get; set; }
        [JsonProperty("updated")]
        public int Updated { get; set; }

    }
}
