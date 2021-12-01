using Refactor_Example.Entities;
using System.Collections.Generic;

namespace Refactor_Example.Database
{
    public interface IFruitRepository
    {
        IEnumerable<Fruit> GetAll();
    }
}