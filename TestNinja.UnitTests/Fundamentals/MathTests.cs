using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;
using System.Linq;
using System.Collections.Generic;

namespace TestNinja.MSUnitTests.Fundamentals
{
    [TestClass]
    public class MathTests
    {
        private Math _math;

        [TestInitialize]
        public void SetUp()
        {
            _math = new Math();
        }

        [TestMethod]
        [Ignore("Because I wante to")]
        public void Add_WhenCalled_ReturnsTheSumOfTheArguments()
        {
            // Arrange
            int a = 1, b = 2;
            int ExpectedSum = 3;

            // Act
            int actualSum = _math.Add(a, b);

            //Assert
            Assert.AreEqual(ExpectedSum, actualSum);
        }

        [TestMethod]
        [DataRow(1, 2, 2)]
        [DataRow(2, 1, 2)]
        [DataRow(1, 1, 1)]
        public void Max_WhenCalled_ReturnsTheBiggerArgument(int a, int b, int expected)
        {
            // Arrange

            // Act
            int actual = _math.Max(a, b);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        //[TestMethod]
        //public void Max_ArgumentBIsBiggerThanA_returnsB()
        //{
        //    // Arrange
        //    int a = 2, b = 3;

        //    // Act
        //    int actual = _math.Max(a, b);

        //    //Assert
        //    Assert.AreEqual(actual, b);
        //}

        //[TestMethod]
        //public void Max_ArgumentsAreEqual_returnsOneArgument()
        //{
        //    // Arrange
        //    int a = 2, b = 2;

        //    // Act
        //    int actual = _math.Max(a, b);

        //    //Assert
        //Assert.AreEqual(actual, b);
        //    Assert.AreEqual(actual, a);
        //}

        [TestMethod]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnsOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);
            IEnumerable<int> list = new[] { 1, 3, 5 };
            IList<int> orderedList = list.OrderByDescending(x => x).ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() >= 0);

            CollectionAssert.AreEquivalent(result.ToList(), list.ToList());

            Assert.AreEqual(result.Count(), 3);
            CollectionAssert.Contains(result.ToList(), 1);
            CollectionAssert.Contains(result.ToList(), 3);
            CollectionAssert.Contains(result.ToList(), 5);

            CollectionAssert.AllItemsAreUnique(result.ToList());

            Assert.IsTrue(orderedList.SequenceEqual(list));

        }
    }
}
