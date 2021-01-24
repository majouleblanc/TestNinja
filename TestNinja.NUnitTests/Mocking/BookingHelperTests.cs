using NUnit.Framework;
using TestNinja.Mocking;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using System.Linq;

namespace TestNinja.Mocking.Tests
{
    [TestFixture()]
    public class BookingHelperTests
    {
        private Mock<IBookingRepository> _repository;
        private Booking _existingBooking;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IBookingRepository>();

            _existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = DepartOn(2017, 1, 15),
                DepartureDate = ArriveOn(2017, 1, 20),
                Reference = "a"
            };
        }

        [Test]
        public void BookingOvelapsButNewBookingIsCancelled_ReturnsEmptyString()
        {
            _repository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.DepartureDate),
                DepartureDate = After(_existingBooking.DepartureDate, days:2),
                Status = "Cancelled"
            }, _repository.Object);

            Assert.IsEmpty(result);
        }

        [Test]
        public void BookingStartAndFinishesAfterAnExistingBoonking_ReturnsEmptyString()
        {
            _repository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.DepartureDate, days:2),
                DepartureDate = After(_existingBooking.DepartureDate, days: 3)
            }, _repository.Object);


            Assert.IsEmpty(result);
        }


        [Test]
        public void BookingStartInTheMiddelButFinishesAfterAnExistingBoonking_ReturnsExistingBokingReference()
        {
            _repository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.DepartureDate)
            }, _repository.Object);


            Assert.AreEqual(_existingBooking.Reference, result);
        }

        [Test]
        public void BookingStartAndFinishesInTheMiddelOfAnExistingBoonking_ReturnsExistingBokingReference()
        {
            _repository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.ArrivalDate),
                DepartureDate = Before(_existingBooking.DepartureDate)
            }, _repository.Object);


            Assert.AreEqual(_existingBooking.Reference, result);
        }

        [Test]
        public void BookingStartBeforeAndFinishesAfterAnExistingBoonking_ReturnsExistingBokingReference()
        {
            _repository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.DepartureDate)
            }, _repository.Object);


            Assert.AreEqual(_existingBooking.Reference, result);
        }


        [Test]
        public void BookingStartBeforeAndFinishesInTheMiddleOfAnExistingBoonking_ReturnsExistingBokingReference()
        {
            _repository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.ArrivalDate)
            }, _repository.Object);


            Assert.AreEqual(_existingBooking.Reference, result);
        }


        [Test()]
        public void BookingStartAndFinishesBeforeAnExistingBoonking_ReturnsAnEmptyString()
        {
            _repository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingBooking.ArrivalDate)
            }, _repository.Object);


            Assert.IsEmpty(result);
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}