using Refactor_Example.Entities;
using System.Collections.Generic;

namespace Refactor_Example.After.PriceCalculator
{
    public interface IPriceCategoryCalculator
    {
        decimal GetTotalPrice(IEnumerable<Fruit> fruits);
    }
}