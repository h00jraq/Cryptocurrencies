using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.HelperClasses
{
    public static class Parsing
    {
        public static (bool state, Enum enumVal) TryParseEnum(Enum enumValue)
        {
            var state = false;
            var enumVal = default(Enum);
            bool success = Enum.IsDefined(typeof(Enum), enumValue);
            if (success)
            {
                enumVal = enumValue;
            }
            return (state, enumVal);
        }
    }
}
