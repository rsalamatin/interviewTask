using BerlinClock.Classes.Contracts;
using System;

namespace BerlinClock
{
    /*Renamed from TimeConverter as it is a specific time converter.*/
    public class BerlinClockTimeConverter : ITimeConverter
    {
        private readonly ITimeFormatter timeFormatter;
        private readonly ITimeParser timeParser;

        public BerlinClockTimeConverter(ITimeFormatter timeFormatter, ITimeParser timeParser)
        {
            this.timeFormatter = timeFormatter;
            this.timeParser = timeParser;
        }

        public string ConvertTime(string aTime)
        {
            if (this.timeParser.TryParse(aTime, out Time time))
            {
                return this.timeFormatter.Format(time);
            }
            throw new ArgumentException($"Unable to convert time. Parameter [{nameof(aTime)}] should satisfy HH:mm:ss pattern");
        }
    }
}
