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

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> sourceData,
                                               Func<T, bool> predicate)
        {

            foreach (var item in sourceData)
            {
                if (predicate(item))
                    yield return item;
            }

        }
    }
}
