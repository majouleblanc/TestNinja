using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.NUnitTests.Exercises
{
    [TestFixture]
    public class DemeritPointsCalculatorTest
    {
        private DemeritPointsCalculator _demerit;

        [SetUp]
        public void SetUp()
        {
            _demerit = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-4)]
        [TestCase(300)]
        public void CalculateDemeritPoints_SpeedNegatif_ThrowsArgumentOutOfRangeException(int speed)
        {
            if (speed <0 || speed >300)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _demerit.CalculateDemeritPoints(-4));
            }
        }

        
        [Test]
        [TestCase(0, 0)]
        [TestCase(50, 0)]
        [TestCase(65,0)]
        [TestCase(70,1)]
        [TestCase(75,2)]
        [TestCase(80, 3)]
        public void CalculateDemeritPoints_SpeedGraiterThan0_ReturnsDemeritPoints(int speed, int expected)
        {
            var result = _demerit.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
