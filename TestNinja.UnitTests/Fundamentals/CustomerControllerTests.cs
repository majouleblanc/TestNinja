using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.MSUnitTests.Fundamentals
{
    [TestClass]
    class CustomerControllerTests
    {
        private CustomerController _customerController;

        [TestInitialize]
        public void SetUp()
        {
            _customerController = new CustomerController();
        }

        [TestMethod]
        public void GetCustomer_IfIdIsZero_ReturnsNotFound()
        {
            var result = _customerController.GetCustomer(0);

            Assert.AreEqual(result.GetType(), typeof(NotFound));

            Assert.IsInstanceOfType(result.GetType(), typeof(NotFound));
        }

        [TestMethod]
        public void GetCustomer_IfIdIsNotZero_ReturnsOk()
        {
            var result = _customerController.GetCustomer(1);

            Assert.AreEqual(result.GetType(), typeof(Ok));

            Assert.IsInstanceOfType(result.GetType(), typeof(Ok));
        }
    }
}
