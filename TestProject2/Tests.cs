using NUnit.Framework;
using NLog;
using System;
using hW1;

namespace hW1.Tests
{
    [TestFixture]
    public class Tests
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private WeekendChecker _weekendChecker;

        [SetUp]
        public void Setup()
        {
            _weekendChecker = new WeekendChecker();
        }

        [Test]
        public void IsWeekend_ShouldReturnTrue_ForSaturday()
        {
            try
            {
                var saturday = new DateTime(2024, 12, 21);
                Assert.IsTrue(_weekendChecker.IsWeekend(saturday));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Test failed: IsWeekend_ShouldReturnTrue_ForSaturday");
                throw; 
            }
        }

        [Test]
        public void IsWeekend_ShouldReturnTrue_ForSunday()
        {
            try
            {
                var sunday = new DateTime(2024, 12, 22);
                Assert.IsTrue(_weekendChecker.IsWeekend(sunday));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Test failed: IsWeekend_ShouldReturnTrue_ForSunday");
                throw;
            }
        }

        [Test]
        public void IsWeekend_ShouldReturnFalse_ForWeekday()
        {
            try
            {
                var monday = new DateTime(2024, 12, 23); // Monday
                Assert.IsFalse(_weekendChecker.IsWeekend(monday));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Test failed: IsWeekend_ShouldReturnFalse_ForWeekday");
                throw;
            }
        }
    }

    [TestFixture]
    public class DateDifferenceCalculatorTests
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private DateDifferenceCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new DateDifferenceCalculator();
        }

        [Test]
        public void DaysBetweenDates_ShouldReturnCorrectDifference()
        {
            try
            {
                // Искусственная ошибка: использование недопустимой даты
                DateTime invalidDate = new DateTime(2024, 13, 32); 

                var startDate = new DateTime(2024, 12, 20);
                var endDate = new DateTime(2024, 12, 25);

                var result = _calculator.DaysBetweenDates(startDate, endDate);

                Assert.AreEqual(5, result);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Test failed: DaysBetweenDates_ShouldReturnCorrectDifference");
                throw;
            }
        }

        [Test]
        public void DaysBetweenDates_ShouldReturnNegative_ForReversedDates()
        {
            try
            {
                var startDate = new DateTime(2024, 12, 25);
                var endDate = new DateTime(2024, 12, 20);

                var result = _calculator.DaysBetweenDates(startDate, endDate);

                Assert.AreEqual(-5, result);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Test failed: DaysBetweenDates_ShouldReturnNegative_ForReversedDates");
                throw;
            }
        }
    }

    [TestFixture]
    public class CurrentDateProviderTests
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private CurrentDateProvider _dateProvider;

        [SetUp]
        public void Setup()
        {
            _dateProvider = new CurrentDateProvider();
        }

        [Test]
        public void GetCurrentDate_ShouldReturnTodaysDate()
        {
            try
            {
                var currentDate = _dateProvider.GetCurrentDate().Date;
                var expectedDate = DateTime.Now.Date;

                Assert.AreEqual(expectedDate, currentDate);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Test failed: GetCurrentDate_ShouldReturnTodaysDate");
                throw;
            }
        }
    }
}
