namespace Refactor_Example.Entities
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PriceCategory PriceCategory { get; set; }
    }
}