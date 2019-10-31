using BerlinClock.Classes;
using BerlinClock.Classes.Contracts;
using NUnit.Framework;
using System;

namespace BerlinClock.UnitTests
{
    public class BerlinClockTimeFormatterTests
    {
        [Test]
        public void Format_NullAsTime_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BerlinClockTimeFormatter().Format(null));
        }

        /*Format validation can be done in more sophisticated way (using some schemas or RegEx), but I don't see the point to overcomplicate it now.*/
        [Test]
        public void Format_Time_TimeFormatIsValid()
        {
            //Arrange
            var time = new Time { Hours = 23, Minutes = 59, Seconds = 59 };
            var formatter = new BerlinClockTimeFormatter();

            //Act
            var formattedTimeString = formatter.Format(time);

            //Assert
            Assert.IsNotNull(formattedTimeString);
            var rows = formattedTimeString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            this.ValidateRowsLength(rows);
            this.ValidateRowsContainAllowedSymbols(rows);
        }

        private void ValidateRowsContainAllowedSymbols(string[] rows)
        {
            foreach (var item in rows)
            {
                Assert.IsTrue(item.Contains("Y") || item.Contains("O") || item.Contains("R"));
            }
        }

        private void ValidateRowsLength(string[] rows)
        {
            Assert.AreEqual(5, rows.Length);
            Assert.AreEqual(1, rows[0].Length);
            Assert.AreEqual(4, rows[1].Length);
            Assert.AreEqual(4, rows[2].Length);
            Assert.AreEqual(11, rows[3].Length);
            Assert.AreEqual(4, rows[4].Length);
        }
    }
}
