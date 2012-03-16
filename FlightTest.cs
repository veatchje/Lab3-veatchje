using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
    [TestFixture()]
    public class FlightTest
    {
        private readonly DateTime StartTime = new DateTime(2012, 3, 15);
        private readonly DateTime EndTime = new DateTime(2012, 3, 22);
        private readonly int miles = 243;


        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(StartTime, EndTime, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof (InvalidOperationException))]
        public void TestThatFlightThrowsWithInvalidDates()
        {
            var falseStart = new DateTime(2012, 3, 15);
            var badEnding = new DateTime(2011, 3, 22);

            new Flight(falseStart, badEnding, miles);
        }

        [Test()]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsWithBadMilage()
        {
            new Flight(StartTime, EndTime, -15);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDay()
        {
            var target = new Flight(StartTime, new DateTime(2012, 3, 16), miles);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDays()
        {
            var target = new Flight(StartTime, new DateTime(2012, 3, 17), miles);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDays()
        {
            var target = new Flight(StartTime, new DateTime(2012, 3, 25), 10);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        public void TestThatTwoFlightsAreEqual()
        {
            var flightOne = new Flight(StartTime, EndTime, miles);
            var flightTwo = new Flight(StartTime, EndTime, miles);

            Assert.True(flightOne.Equals(flightTwo));
        }

        [Test()]
        public void TestThatTwoFlightsAreNotEqualWithDifferentMiles()
        {
            var flightOne = new Flight(StartTime, EndTime, miles);
            var flightTwo = new Flight(StartTime, EndTime, 432);

            Assert.False(flightOne.Equals(flightTwo));
        }

        [Test()]
        public void TestThatAFlightDoesNotEqualAnotherObject()
        {
            var flight = new Flight(StartTime, EndTime, miles);
            var hotel = new Hotel(5);

            Assert.False(flight.Equals(hotel));
        }
    }
}