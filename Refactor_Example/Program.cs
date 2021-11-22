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
            var fruits = FruitRepository.GetAll().ToList();

            var fruitLogicForBefore = new FruitLogic(fruits);
            const DeliveryOptions deliveryOptions = DeliveryOptions.EMS;

            // Before
            var totalOfBefore = fruitLogicForBefore.GetTotalPrice(deliveryOptions);

            // After
            var shoppingService = new ShoppingService();
            var totalOfAfter = shoppingService.GetTotalPrice(fruits, deliveryOptions);

            Console.WriteLine(totalOfBefore);
            Console.WriteLine(totalOfAfter);
            Console.Read();
        }
    }
}
