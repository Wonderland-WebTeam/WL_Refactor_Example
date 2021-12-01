using Refactor_Example.After;
using Refactor_Example.Before;
using Refactor_Example.Database;
using Refactor_Example.Entities;
using System;
using System.Linq;

namespace Refactor_Example
{
    internal class Program
    {
        private static void Main()
        {
            IFruitRepository fruitRepository = new FruitRepository();
            var fruits = fruitRepository.GetAll().ToList();

            const DeliveryOptions deliveryOptions = DeliveryOptions.EMS;

            // Before
            var fruitLogicForBefore = new FruitLogic();
            var totalOfBefore = fruitLogicForBefore.GetTotalPrice(fruits, deliveryOptions);

            // After
            var shoppingService = new ShoppingService();
            var totalOfAfter = shoppingService.GetTotalPrice(fruits, deliveryOptions);

            // output $58
            Console.WriteLine($"Before:{totalOfBefore}");
            Console.WriteLine($"After:{totalOfAfter}");
            Console.Read();
        }
    }
}
