using Refactor_Example.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Refactor_Example.After.PriceCalculator.Context
{
    public class OnSalePriceCategoryCalculator : IPriceCategoryCalculator
    {
        public decimal GetTotalPrice(IEnumerable<Fruit> fruits) =>
            fruits
                .Where(f => f.PriceCategory == PriceCategory.OnSale)
                .Select(f => f.Price * 0.9M)
                .Sum();
    }
}