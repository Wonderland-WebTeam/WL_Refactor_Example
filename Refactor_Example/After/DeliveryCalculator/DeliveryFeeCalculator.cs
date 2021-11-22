using Refactor_Example.Entities;
using System.Collections.Generic;

namespace Refactor_Example.After.DeliveryCalculator
{
    public class DeliveryFeeCalculator
    {
        private readonly Dictionary<DeliveryOptions, decimal> _feeMap;

        public DeliveryFeeCalculator()
        {
            _feeMap = new Dictionary<DeliveryOptions, decimal>
            {
                [DeliveryOptions.EMS] = 20,
                [DeliveryOptions.DHL] = 30
            };
        }

        public decimal CalculateFee(DeliveryOptions options)
        {
            return _feeMap[options];
        }
    }
}