using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationNUnitTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancellingReservation_ReturnsTrue()
        {
            //Arrange
            Reservation reservation = 
                new Reservation { MadeBy = new User { IsAdmin = true } };
            User admin = new User { IsAdmin = true };

            //Act
            var expected = reservation.CanBeCancelledBy(admin);

            //Assert
            Assert.IsTrue(expected);
            Assert.That(expected, Is.True);
            Assert.That(expected == true);
        }

        [Test]
        public void CanBeCancelledBy_UserIsCancellingHisReservation_ReturnsTrue()
        {
            //Arrange
            User user = new User { IsAdmin = false };
            Reservation reservation = new Reservation { MadeBy = user };

            //Act
            var expected = reservation.CanBeCancelledBy(user);

            //Assert

            Assert.IsTrue(expected);
            Assert.That(expected, Is.True);
            Assert.That(expected == true);
        }

        [Test]
        public void CanBeCancelledBy_anotherUserIsCancelling_ReturnFalse()
        {
            //Arrange
            User MadeByUSer = new User { IsAdmin = false };
            User user = new User { IsAdmin = false };
            Reservation reservation = new Reservation { MadeBy = MadeByUSer };

            //Act
            var expected = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsFalse(expected);
            Assert.That(expected, Is.False);
            Assert.That(expected == false);
        }
    }
}
