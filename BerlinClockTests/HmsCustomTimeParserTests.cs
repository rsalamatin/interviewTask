using BerlinClock.Classes;
using BerlinClock.Classes.Contracts;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class HmsCustomTimeParserTests
    {
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("00:00:1")]
        [TestCase("00:00:-1")]
        [TestCase("00:00:61")]
        [TestCase("00:00:-61")]
        [TestCase("00:1:00")]
        [TestCase("00:-1:00")]
        [TestCase("00:-61:00")]
        [TestCase("-1:00:00")]
        [TestCase("25:00:00")]
        [TestCase("1:00:00")]
        [TestCase("0a:00:00")]
        [TestCase("00:0a:00")]
        [TestCase("00:00:0a")]
        [TestCase("24:00:01")]
        public void TryParse_InvalidTimeString_TimeIsNotParsed(string timeSting)
        {
            //Arrange
            var parser = new HmsCustomTimeParser();

            //Act
            bool isParsed = parser.TryParse(string.Empty, out Time time);

            //Assert
            Assert.IsFalse(isParsed);
            Assert.IsNull(time);
        }

        [Test]
        [TestCaseSource(typeof(TestData), "Cases")]
        public void TryParse_ValidTimeString_TimeIsParsed(string timeSting, Time expectedTime)
        {
            //Arrange
            var parser = new HmsCustomTimeParser();

            //Act
            bool isParsed = parser.TryParse(timeSting, out Time parsedTime);

            //Assert
            Assert.IsTrue(isParsed);
            Assert.IsNotNull(parsedTime);
            Assert.AreEqual(expectedTime.Hours, parsedTime.Hours);
            Assert.AreEqual(expectedTime.Minutes, parsedTime.Minutes);
            Assert.AreEqual(expectedTime.Seconds, parsedTime.Seconds);
        }

        private class TestData
        {
            static object[] Cases =
            {
                new object[] { "00:00:00", new Time()},
                new object[] { "24:00:00", new Time { Hours = 24 } },
                new object[] { "23:59:59", new Time() { Hours = 23, Minutes = 59, Seconds = 59 } }
            };
        }
    }
}
