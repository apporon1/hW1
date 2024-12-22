using NUnit.Framework;
using System;
using hW1; 

namespace hW1.Tests
{
    [TestFixture]
    public class Tests
    {
        private WeekendChecker _weekendChecker;

        [SetUp]
        public void Setup()
        {
            _weekendChecker = new WeekendChecker();
        }

        [Test]
        public void IsWeekend_ShouldReturnTrue_ForSaturday()
        {
            var saturday = new DateTime(2024, 12, 21); 
            Assert.IsTrue(_weekendChecker.IsWeekend(saturday));
        }

        [Test]
        public void IsWeekend_ShouldReturnTrue_ForSunday()
        {
            var sunday = new DateTime(2024, 12, 22); 
            Assert.IsTrue(_weekendChecker.IsWeekend(sunday));
        }

        [Test]
        public void IsWeekend_ShouldReturnFalse_ForWeekday()
        {
            var monday = new DateTime(2024, 12, 23); // Monday
            Assert.IsFalse(_weekendChecker.IsWeekend(monday));
        }
    }

    [TestFixture]
    public class DateDifferenceCalculatorTests
    {
        private DateDifferenceCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new DateDifferenceCalculator();
        }

        [Test]
        public void DaysBetweenDates_ShouldReturnCorrectDifference()
        {
            var startDate = new DateTime(2024, 12, 20);
            var endDate = new DateTime(2024, 12, 25);

            var result = _calculator.DaysBetweenDates(startDate, endDate);

            Assert.AreEqual(5, result);
        }

        [Test]
        public void DaysBetweenDates_ShouldReturnNegative_ForReversedDates()
        {
            var startDate = new DateTime(2024, 12, 25);
            var endDate = new DateTime(2024, 12, 20);

            var result = _calculator.DaysBetweenDates(startDate, endDate);

            Assert.AreEqual(-5, result);
        }
    }

    [TestFixture]
    public class CurrentDateProviderTests
    {
        private CurrentDateProvider _dateProvider;

        [SetUp]
        public void Setup()
        {
            _dateProvider = new CurrentDateProvider();
        }

        [Test]
        public void GetCurrentDate_ShouldReturnTodaysDate()
        {
            var currentDate = _dateProvider.GetCurrentDate().Date;
            var expectedDate = DateTime.Now.Date;

            Assert.AreEqual(expectedDate, currentDate);
        }
    }
}
