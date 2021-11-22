﻿using Refactor_Example.After.DeliveryCalculator;
using Refactor_Example.After.PriceCalculator;
using Refactor_Example.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Refactor_Example.After
{
    public class ShoppingService
    {
        public decimal GetTotalPrice(IEnumerable<Fruit> fruits, DeliveryOptions deliveryOptions)
        {
            fruits = fruits.ToList();

            var calculatorContext = new FruitCalculator(new GeneralPriceCategoryCalculator());
            var generalCategoryTotalPrice = calculatorContext.Calculate(fruits);

            calculatorContext.SetCalculator(new OnSalePriceCategoryCalculator());
            var onSaleCategoryTotalPrice = calculatorContext.Calculate(fruits);

            var deliveryFeeCalculator = new DeliveryFeeCalculator();

            var totalPrice = generalCategoryTotalPrice + onSaleCategoryTotalPrice;
            var deliveryFee = deliveryFeeCalculator.CalculateFee(deliveryOptions);

            return totalPrice + deliveryFee;
        }
    }
}