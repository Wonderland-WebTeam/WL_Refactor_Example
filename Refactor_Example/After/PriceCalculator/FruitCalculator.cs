using Refactor_Example.Entities;
using System.Collections.Generic;

namespace Refactor_Example.After.PriceCalculator
{
    public class FruitCalculator
    {
        private IPriceCategoryCalculator _calculator;

        public FruitCalculator(IPriceCategoryCalculator calculator)
        {
            _calculator = calculator;
        }

        public void SetCalculator(IPriceCategoryCalculator calculator) =>
            _calculator = calculator;

        public decimal Calculate(IEnumerable<Fruit> fruits) =>
            _calculator.GetTotalPrice(fruits);
    }
}