using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.MSUnitTests.Fundamentals
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void GetOutput_NumberDivisileBy3And5_returnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.AreEqual(result, "FizzBuzz");
        }

        [TestMethod]
        public void GetOutput_NumberDivisibleBy3Only_returnFizz()
        {
            var result = FizzBuzz.GetOutput(3);

            Assert.AreEqual(result, "Fizz");
        }

        [TestMethod]
        public void GetOutput_NumberDivisibleBy5Only_returnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);

            Assert.AreEqual(result, "Buzz");

        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(4)]
        [DataRow(7)]
        [DataRow(8)]
        public void GetOutput_NumberNotDivisibleBy3Or5_returnNumber(int number)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.AreEqual(result, number.ToString());
        }

    }
}
