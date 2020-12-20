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

        //[TestMethod]
        //[DataRow(null)]
        //[DataRow(" ")]
        //[DataRow("")]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void Log_InvalidError_ThrowsArgumentNullException(string error)
        //{
        //    _logger.Log(error);
        //}
    }
}
