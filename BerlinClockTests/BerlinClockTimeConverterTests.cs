using BerlinClock.Classes.Contracts;
using NSubstitute;
using NUnit.Framework;
using System;

namespace BerlinClock.UnitTests
{
    public class BerlinClockTimeConverterTests
    {
        private ITimeFormatter formatter;
        private ITimeParser parser;

        [SetUp]
        public void Setup()
        {
            formatter = Substitute.For<ITimeFormatter>();
            parser = Substitute.For<ITimeParser>();
        }

        [Test]
        public void ConvertTime_TimeCannotBeParsed_ArgumentException()
        {
            //Arrange
            this.parser.TryParse(string.Empty, out _).ReturnsForAnyArgs(false);
            var converter = new BerlinClockTimeConverter(this.formatter, this.parser);

            //Act //Assert
            Assert.Throws<ArgumentException>(() => converter.ConvertTime(string.Empty));
            this.formatter.DidNotReceiveWithAnyArgs().Format(null);
            this.parser.ReceivedWithAnyArgs(1).TryParse(null, out _);
        }

        [Test]
        public void ConvertTime_TimeCanBeParsed_FormatMethodCalled()
        {
            //Arrange
            string expectedFormattedValue = "formattedValue";
            this.parser.TryParse(string.Empty, out _).ReturnsForAnyArgs(true);
            this.formatter.Format(null).ReturnsForAnyArgs(expectedFormattedValue);
            var converter = new BerlinClockTimeConverter(this.formatter, this.parser);

            //Act
            var formattedValue = converter.ConvertTime(null);

            //Assert
            Assert.AreEqual(expectedFormattedValue, formattedValue);
            this.parser.ReceivedWithAnyArgs(1).TryParse(null, out _);
            this.formatter.ReceivedWithAnyArgs(1).Format(null);
        }
    }
}
