using Refactor_Example.Database;
using Refactor_Example.Entities;
using System;

namespace Refactor_Example.Before
{
    public class FruitLogic
    {
        private readonly IFruitRepository _fruitRepository;

        public FruitLogic(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }

        public decimal GetTotalPrice(DeliveryOptions deliveryOptions)
        {
            decimal total = 0;
            var fruits = _fruitRepository.GetAll();

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