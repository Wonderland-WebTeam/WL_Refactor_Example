using Refactor_Example.Entities;
using System;
using System.Collections.Generic;

namespace Refactor_Example.Before
{
    public class FruitLogic
    {
        public decimal GetTotalPrice(IEnumerable<Fruit> fruits, DeliveryOptions deliveryOptions)
        {
            decimal total = 0;

            // 總價
            foreach (var fruit in fruits)
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
    }
}