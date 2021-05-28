using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Infrastructure
{
    class CryptoCurrencyData
    {
        public int id { get; set; }
        public string coin { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string algorithm { get; set; }
        public long network_hashrate { get; set; }
        public long difficulty { get; set; }
        public long reward { get; set; }
        public string reward_unit { get; set; }
        public decimal reward_block { get; set; }
        public decimal price { get; set; }
        public long volume { get; set; }
        public int updated { get; set; }

    }
}
