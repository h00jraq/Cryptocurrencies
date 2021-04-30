using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Domain
{
    abstract class CryptoCurrency
    {
        public string CurrencyName { get; set; }
        public int CurrencyPrice { get; set; }
        public int BlockRewards { get; set; }
        public int NetworkDifficulty { get; set; }
    }
}
