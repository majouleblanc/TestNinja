using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationMSTests
    {
        [TestMethod]
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
        }

        [TestMethod]
        public void CanBeCancelledBy_UserIsCancellingHisReservation_ReturnsTrue()
        {
            //Arrange
            User user = new User { IsAdmin = false };
            Reservation reservation = new Reservation { MadeBy = user };

            //Act
            var expected = reservation.CanBeCancelledBy(user);

            //Assert

            Assert.IsTrue(expected);
        }

        [TestMethod]
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
        }
    }
}
