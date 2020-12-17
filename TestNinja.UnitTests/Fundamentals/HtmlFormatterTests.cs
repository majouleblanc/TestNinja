using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.MSUnitTests.Fundamentals
{
    [TestClass()]
    public class HtmlFormatterTests
    {
        private HtmlFormatter _formatter;
        [TestInitialize]
        public void SetUp()
        {
            _formatter = new HtmlFormatter();
        }

        [TestMethod()]
        [DataRow("abc")]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement(string input)
        {

            var result = _formatter.FormatAsBold(input);

            // Specific
            Assert.AreEqual(result, $"<strong>{input}</strong>");

            // More General
            StringAssert.StartsWith(result, "<strong>");
            StringAssert.EndsWith(result, "</strong>");
            StringAssert.Contains(result, input);
        }
    }
}