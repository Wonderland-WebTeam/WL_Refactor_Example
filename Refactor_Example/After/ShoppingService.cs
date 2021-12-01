using Refactor_Example.After.DeliveryCalculator;
using Refactor_Example.After.PriceCalculator;
using Refactor_Example.After.PriceCalculator.Context;
using Refactor_Example.Database;
using Refactor_Example.Entities;
using System.Linq;

namespace Refactor_Example.After
{
    public class ShoppingService
    {
        private readonly IFruitRepository _fruitRepository;

        public ShoppingService(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }

        public decimal GetTotalPrice(DeliveryOptions deliveryOptions)
        {
            // 避免延遲執行(Deferred Execution)
            // ToList or not ToList, that is the question.
            var fruits = _fruitRepository.GetAll().ToList();

            var calculatorContext = new FruitCalculator(new GeneralPriceCategoryCalculator());
            var generalCategoryTotalPrice = calculatorContext.Calculate(fruits);

            calculatorContext.SetCalculator(new OnSalePriceCategoryCalculator());
            var onSaleCategoryTotalPrice = calculatorContext.Calculate(fruits);

            var totalPrice = generalCategoryTotalPrice + onSaleCategoryTotalPrice;

            var deliveryFeeCalculator = new DeliveryFeeCalculator();
            var deliveryFee = deliveryFeeCalculator.CalculateFee(deliveryOptions);

            return totalPrice + deliveryFee;
        }
    }
}