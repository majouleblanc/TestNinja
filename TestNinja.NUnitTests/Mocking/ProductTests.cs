using NUnit.Framework;
using TestNinja.Mocking;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Moq.Language.Flow;

namespace TestNinja.Mocking.Tests
{
    [TestFixture()]
    public class ProductTests
    {

        [Test]
        public void GetPriceTest_GoldCustomer_Applies30PercentDiscount()
        {
            var product = new Product() { ListPrice = 100 };

            var customer = new Customer() { IsGold = true };

            var result = product.GetPrice(customer);

            Assert.AreEqual(70, result);
        }

        [Test()]
        public void GetPriceTest_GoldCustomer_Applies30PercentDiscount2()
        {
            var product = new Product() { ListPrice = 100};
            var _fakeCustomer = new Mock<ICustomer>();

            _fakeCustomer.Setup(c=>c.IsGold).Returns(true);

            var result = product.GetPrice(_fakeCustomer.Object);

            Assert.AreEqual(70, result);
        }
    }
}