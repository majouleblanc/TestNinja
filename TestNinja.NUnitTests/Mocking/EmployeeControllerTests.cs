using NUnit.Framework;
using TestNinja.Mocking;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace TestNinja.Mocking.Tests
{
    [TestFixture()]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _employeeStorage;
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
        }

        [Test()]
        public void DeleteEmployeeTest_WhebCalled_ReturnsRedirectToActionOfEmployees()
        {
            _employeeStorage.Setup(es => es.DeleteEmployee(1)).Returns(true);
            var result = _employeeController.DeleteEmployee(1);

            Assert.IsTrue(result.GetType() == typeof(RedirectResult));
        }

        [Test()]
        public void DeleteEmployeeTest_WhebCalled_CallsDeleteEmployeOfEmployeeStorage()
        {
            _employeeStorage.Setup(es => es.DeleteEmployee(1)).Returns(true);
            var result = _employeeController.DeleteEmployee(1);
            _employeeStorage.Verify(s => s.DeleteEmployee(1));
        }
    }
}