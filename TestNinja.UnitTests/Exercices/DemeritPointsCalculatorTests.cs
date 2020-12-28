using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.MSUnitTests.Exercices
{
    [TestClass]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demerite;

        [TestInitialize]
        public void SetUp()
        {
            _demerite = new DemeritPointsCalculator();
        }

        [TestMethod]
        [DataRow(-4)]
        public void CalculateDemeritPoints_SpeedNegatif_ThrowsArgumentOutOfRangeException(int speed)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _demerite.CalculateDemeritPoints(speed));
        }

        [TestMethod]
        [DataRow(0,0)]
        [DataRow(50,0)]
        [DataRow(65,0)]
        [DataRow(70, 1)]
        [DataRow(75, 2)]
        [DataRow(80, 3)]
        public void CalculateDemeritPoints_SpeedGraiterThan0_ReturnsDemeritPoints(int speed, int expected)
        {
            var result = _demerite.CalculateDemeritPoints(speed);

            Assert.AreEqual(result, expected);
        }

    }
}
