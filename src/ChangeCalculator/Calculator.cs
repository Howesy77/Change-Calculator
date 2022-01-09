using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeCalculator
{
    public class Calculator
    {
        public static List<Tuple<Denominations, int>> CalculateChange(decimal purchasePrice, decimal tenderedAmount)
        {
            var result = new List<Tuple<Denominations, int>>();

            if (tenderedAmount < purchasePrice)
            {
                throw new Exception("Insufficient funds to complete transaction");
            }

            if (tenderedAmount == purchasePrice)
            {
                throw new Exception("No change is required");
            }

            var change = (tenderedAmount - purchasePrice) * 100;

            foreach (var denomination in Enum.GetValues(typeof(Denominations)).Cast<Denominations>().OrderByDescending(d => d))
            {
                var total = (int)(change / (int) denomination);
                change %= (int) denomination;

                if(total > 0) result.Add(new Tuple<Denominations, int>(denomination, total));
            }

            return result;
        }
    }
}
