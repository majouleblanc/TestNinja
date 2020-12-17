using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.NUnitTests.Fundamentals
{
    [TestFixture]
    class CustomerControllerTests
    {
        private CustomerController _customController;
        [SetUp]
        public void SetUp()
        {
            _customController = new CustomerController();
        }
        [Test]
        public void GetCustomer_IfIdIsZero_ReturnsNotFound()
        {
            var result = _customController.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());

            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IfIdIsNotZero_ReturnsOk()
        {
            var result = _customController.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());

            Assert.That(result, Is.InstanceOf<Ok>());
        }
    }
}
