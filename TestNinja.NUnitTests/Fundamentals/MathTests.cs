using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Fundamentals;

namespace TestNinja.NUnitTests.Fundamentals
{
    [TestFixture]
    class MathTests
    {
        private Math _math;

        // SetUp
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        [Ignore("Because i wanted to!")]
        public void Add_WhenCalled_ReturnsTheSumOfArguments()
        {
            // Arrange
            int sumExpected = 3;
            int a = 1, b = 2;

            // Act
            var  actualSum = _math.Add(a, b);

            // Assert
            Assert.That(sumExpected, Is.EqualTo(actualSum));
        }

        [Test]
        [TestCase(1,2,2)]
        [TestCase(2,1,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnsTheGreaterArgument(int a, int b, int expected)
        {
            // Arrange

            // Act
            int actual = _math.Max(a, b);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        //[Test]
        //public void Max_ArgumentBIsBiggerThanA_returnsB()
        //{
        //    // Arrange
        //    int a = 2, b = 3;

        //    // Act
        //    int actual = _math.Max(a, b);

        //    //Assert
        //    Assert.That(actual,Is.EqualTo(b));
        //}

        //[Test]
        //public void Max_ArgumentsAreEqual_returnsOneArgument()
        //{
        //    // Arrange
        //    int a = 2, b = 2;

        //    // Act
        //    int actual = _math.Max(a, b);

        //    //Assert
        //    Assert.That(actual, Is.EqualTo(b));
        //    Assert.That(actual, Is.EqualTo(a));
        //}

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnsOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
