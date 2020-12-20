using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.NUnitTests.Fundamentals
{
    [TestFixture]
    class ErrorLoggerTests
    {
        private ErrorLogger _errorLogger;
        [SetUp]
        public void SetUp()
        {
            _errorLogger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetsTheLastErrorProperty()
        {
            _errorLogger.Log("a");

            Assert.That(_errorLogger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowsArgumentNullException(string error)
        {

            Assert.That(() => { _errorLogger.Log(error); } , Throws.ArgumentNullException);
            //Assert.That(() => { _errorLogger.Log(error)}, Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}
