using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.MSUnitTests.Fundamentals
{
    [TestClass]
    public class ErrorLoggerTests
    {
        private ErrorLogger _logger;
        [TestInitialize]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }

        [TestMethod]
        public void Log_WhenCalled_SetsTheLastErrorProperty()
        {
            _logger.Log("a");

            Assert.AreEqual(_logger.LastError, "a");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow(" ")]
        [DataRow("")]
        public void Log_InvalidError_ThrowsArgumentNullException(string error)
        {
            Assert.ThrowsException<ArgumentNullException>(() => { _logger.Log(error); });
        }

        //you can also use this to test a method that returns an exception
        //[TestMethod]
        //[DataRow(null)]
        //[DataRow(" ")]
        //[DataRow("")]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void Log_InvalidError_ThrowsArgumentNullException(string error)
        //{
        //    _logger.Log(error);
        //}


        [TestMethod]
        public void Log_ValidError_RaisesErrorLogedEvent()
        {
            var id = Guid.Empty;
            _logger.ErrorLogged += (sender, args) => { id = args; };
            _logger.Log("a");

            Assert.AreNotEqual(id, Guid.Empty);
        }


    }
}
