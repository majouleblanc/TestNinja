using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.NUnitTests.Mocking
{
    [TestFixture]
    class OrderServiceTests
    {
        private Mock<IStorage> _fakeStorage;
        private OrderService _orderService;

        [SetUp]
        public void SetUp()
        {
            _fakeStorage = new Mock<IStorage>();
            _orderService = new OrderService(_fakeStorage.Object);
        }

        [Test]
        public void PlaceOrder_whenCalled_StorsTheOrder()
        {
            var order = new Order();
            _orderService.PlaceOrder(order);

            _fakeStorage.Verify(s => s.Store(order));
        }
    }
}
