using BerlinClock.Classes.Contracts;
using System;
using System.Linq;

namespace BerlinClock.Classes
{
    public class BerlinClockTimeFormatter : ITimeFormatter
    {
        private const string OFF = "O";
        private const string RED = "R";
        private const string YELLOW = "Y";
        private const string YYYRowPart = "YYY";
        private const string YYRRowPart = "YYR";

        public string Format(Time time)
        {
            if(time == null)
                throw new ArgumentNullException(nameof(time));

            var secondsRow = (time.Seconds % 2 == 0) ? YELLOW : OFF;
            var hoursFirstRow = this.GetRowString(time.Hours / 5, 4, RED);
            var hoursSecondRow = this.GetRowString(time.Hours % 5, 4, RED);
            var minutesFirstRow = this.GetRowString(time.Minutes / 5, 11, YELLOW).Replace(YYYRowPart, YYRRowPart);
            var minutesSecondRow = this.GetRowString(time.Minutes % 5, 4, YELLOW);

            return string.Join(Environment.NewLine, new[] { secondsRow, hoursFirstRow, hoursSecondRow, minutesFirstRow, minutesSecondRow });
        }

        private string GetRowString(int litLights, int lightsInRow, string lampType)
        {
            int unlitLights = lightsInRow - litLights;
            var lit = string.Join(string.Empty, Enumerable.Repeat(lampType, litLights));
            var unlit = string.Join(string.Empty, Enumerable.Repeat(OFF, unlitLights));
            return lit + unlit;
        }
    }
}
