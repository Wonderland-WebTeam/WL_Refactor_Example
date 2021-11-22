using Refactor_Example.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactor_Example.Before
{
    public class FruitLogic
    {
        private readonly IEnumerable<Fruit> _fruits;

        public FruitLogic(IEnumerable<Fruit> fruits)
        {
            _fruits = fruits;
        }

        public decimal GetTotalPrice(DeliveryOptions deliveryOptions)
        {
            decimal total = 0;

            // 總價
            foreach (var fruit in _fruits)
            {
                total += fruit.PriceCategory switch
                {
                    PriceCategory.General => fruit.Price,
                    PriceCategory.OnSale => fruit.Price * 0.9M,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            // 運費
            if (deliveryOptions == DeliveryOptions.EMS)
            {
                return total + 20;
            }

            if (deliveryOptions == DeliveryOptions.DHL)
            {
                return total + 30;
            }

            return total;
        }

        public decimal GetOnSaleTotalPrice()
        {
            return _fruits
                .Where(f => f.PriceCategory == PriceCategory.OnSale)
                .Sum(f => f.Price);
        }
    }
}