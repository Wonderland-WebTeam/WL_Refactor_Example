using FluentAssertions;
using NUnit.Framework;
using Refactor_Example.After.PriceCalculator;
using Refactor_Example.After.PriceCalculator.Context;
using Refactor_Example.Entities;
using System.Collections.Generic;

namespace Refactor.Tests
{
    public class FruitCalculatorTest
    {
        private List<Fruit> _fruits;

        [SetUp]
        public void Setup()
        {
            _fruits = new List<Fruit>
            {
                new Fruit {Id = 1, Price = 100, PriceCategory = PriceCategory.General, Name = "A"},
                new Fruit {Id = 2, Price = 100, PriceCategory = PriceCategory.OnSale, Name = "B"},
                new Fruit {Id = 3, Price = 100, PriceCategory = PriceCategory.General, Name = "C"},
                new Fruit {Id = 4, Price = 100, PriceCategory = PriceCategory.OnSale, Name = "D"},
            };
        }

        [Test]
        public void Calculate_GeneralPrice_ReturnsCorrectAmount()
        {
            const decimal expectPrice = 200;

            var calculatorContext = new FruitCalculator(new GeneralPriceCategoryCalculator());
            var generalCategoryTotalPrice = calculatorContext.Calculate(_fruits);

            generalCategoryTotalPrice.Should().Be(expectPrice);
        }

        [Test]
        public void Calculate_OnSalePrice_ReturnsCorrectAmount()
        {
            const decimal expectPrice = 180;

            var calculatorContext = new FruitCalculator(new OnSalePriceCategoryCalculator());
            var onSaleCategoryTotalPrice = calculatorContext.Calculate(_fruits);

            onSaleCategoryTotalPrice.Should().Be(expectPrice);
        }
    }
}