using Refactor_Example.Entities;
using System.Collections.Generic;

namespace Refactor_Example.Database
{
    public static class FruitRepository
    {
        public static IEnumerable<Fruit> GetAll()
        {
            yield return
                new Fruit
                {
                    Id = 1,
                    Name = "Apple",
                    Price = 10,
                    PriceCategory = PriceCategory.General
                };

            yield return
                new Fruit
                {
                    Id = 2,
                    Name = "Banana",
                    Price = 10,
                    PriceCategory = PriceCategory.OnSale
                };

            yield return
                new Fruit
                {
                    Id = 3,
                    Name = "Orange",
                    Price = 10,
                    PriceCategory = PriceCategory.OnSale
                };

            yield return
                new Fruit
                {
                    Id = 4,
                    Name = "Cherry",
                    Price = 10,
                    PriceCategory = PriceCategory.General
                };
        }
    }
}