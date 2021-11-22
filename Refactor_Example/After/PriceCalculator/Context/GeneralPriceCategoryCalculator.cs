using Refactor_Example.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Refactor_Example.After.PriceCalculator.Context
{
    public class GeneralPriceCategoryCalculator : IPriceCategoryCalculator
    {
        public decimal GetTotalPrice(IEnumerable<Fruit> fruits) =>
            fruits
                .Where(f => f.PriceCategory == PriceCategory.General)
                .Select(f => f.Price)
                .Sum();
    }
}