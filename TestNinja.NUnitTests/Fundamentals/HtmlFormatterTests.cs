using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.NUnitTests.Fundamentals
{
    [TestFixture]
    class HtmlFormatterTests
    {
        private HtmlFormatter _formatter;
        [SetUp]
        public void SetUp()
        {
            _formatter = new HtmlFormatter();
        }
        [Test]
        [TestCase("abc")]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement(string input)
        {

            var result = _formatter.FormatAsBold(input);


            // Specific 
            Assert.That(result, Is.EqualTo($"<strong>{input}</strong>").IgnoreCase);

            // General
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain(input));
        }
        
    }
}