using FluentAssertions;
using NUnit.Framework;
using Refactor_Example.After.DeliveryCalculator;
using Refactor_Example.Entities;

namespace Refactor.Tests
{
    public class DeliveryFeeCalculatorTest
    {
        private DeliveryFeeCalculator _deliveryFeeCalculator;

        [SetUp]
        public void Setup()
        {
            _deliveryFeeCalculator = new DeliveryFeeCalculator();
        }

        [Test]
        public void CalculateFee_CalculatorDhlFee_ReturnsCorrectDeliveryFee()
        {
            const decimal expectFee = 30;

            var deliveryFee = _deliveryFeeCalculator.CalculateFee(DeliveryOptions.DHL);

            deliveryFee.Should().Be(expectFee);
        }

        [Test]
        public void CalculateFee_CalculatorEmsFee_ReturnsCorrectDeliveryFee()
        {
            const decimal expectFee = 20;

            var deliveryFee = _deliveryFeeCalculator.CalculateFee(DeliveryOptions.EMS);

            deliveryFee.Should().Be(expectFee);
        }
    }
}