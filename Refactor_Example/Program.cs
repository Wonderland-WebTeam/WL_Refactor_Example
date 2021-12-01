using Refactor_Example.After;
using Refactor_Example.Before;
using Refactor_Example.Database;
using Refactor_Example.Entities;
using System;

namespace Refactor_Example
{
    internal class Program
    {
        private static void Main()
        {
            const DeliveryOptions deliveryOptions = DeliveryOptions.EMS;

            // Before
            var fruitLogicForBefore = new FruitLogic(new FruitRepository());
            var totalOfBefore = fruitLogicForBefore.GetTotalPrice(deliveryOptions);

            // After
            var shoppingService = new ShoppingService(new FruitRepository());
            var totalOfAfter = shoppingService.GetTotalPrice(deliveryOptions);

            // output $58
            Console.WriteLine($"Before:{totalOfBefore}");
            Console.WriteLine($"After:{totalOfAfter}");
            Console.Read();
        }
    }
}
