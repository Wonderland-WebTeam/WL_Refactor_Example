using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Refactor_Example.After.PriceCalculator;
using Refactor_Example.After.PriceCalculator.Context;
using Refactor_Example.Database;
using Refactor_Example.Entities;
using System.Collections.Generic;

namespace Refactor.Tests
{
    public class FruitCalculatorTest
    {
        private IFruitRepository _fruitRepository;

        [SetUp]
        public void Setup()
        {
            var fruitRepositoryStub = Substitute.For<IFruitRepository>();
            fruitRepositoryStub.GetAll().Returns(new List<Fruit>
            {
                new Fruit {Id = 1, Price = 100, PriceCategory = PriceCategory.General, Name = "A"},
                new Fruit {Id = 2, Price = 100, PriceCategory = PriceCategory.OnSale, Name = "B"},
                new Fruit {Id = 3, Price = 100, PriceCategory = PriceCategory.General, Name = "C"},
                new Fruit {Id = 4, Price = 100, PriceCategory = PriceCategory.OnSale, Name = "D"}
            });

            _fruitRepository = fruitRepositoryStub;
        }

        [Test]
        public void Calculate_GeneralPrice_ReturnsCorrectAmount()
        {
            const decimal expectPrice = 200;

            var calculatorContext = new FruitCalculator(new GeneralPriceCategoryCalculator());
            var generalCategoryTotalPrice = calculatorContext.Calculate(_fruitRepository.GetAll());

            generalCategoryTotalPrice.Should().Be(expectPrice);
        }

        [Test]
        public void Calculate_OnSalePrice_ReturnsCorrectAmount()
        {
            const decimal expectPrice = 180;

            var calculatorContext = new FruitCalculator(new OnSalePriceCategoryCalculator());
            var onSaleCategoryTotalPrice = calculatorContext.Calculate(_fruitRepository.GetAll());

            onSaleCategoryTotalPrice.Should().Be(expectPrice);
        }
    }
}