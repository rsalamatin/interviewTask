using BerlinClock.Classes.Contracts;

namespace BerlinClock.Classes
{
    /*Expected time format HH:mm:ss. 
     * According to BDD tests, this parser should allows 24:00:00 time,
     * so it is some custom time format.*/
    public class HmsCustomTimeParser : ITimeParser
    {
        public bool TryParse(string time, out Time parsedTime)
        {
            parsedTime = null;
            if (string.IsNullOrEmpty(time))
                return false;

            var timeParameters = time.Split(':');

            if (timeParameters.Length != 3)
                return false;

            foreach (var item in timeParameters)
            {
                if (item.Length != 2)
                    return false;
            }

            var hoursAreValid = int.TryParse(timeParameters[0], out int hours);
            var minutesAreValid = int.TryParse(timeParameters[1], out int minutes);
            var secondsAreValid = int.TryParse(timeParameters[2], out int seconds);

            if (!hoursAreValid || !minutesAreValid || !secondsAreValid)
                return false;

            if (hours > 24 || hours < 0) return false;
            if (minutes > 59 || minutes < 0) return false;
            if (seconds > 59 || seconds < 0) return false;

            if (hours == 24 && minutes != 0 && seconds != 0)
                return false;

            parsedTime = new Time()
            {
                Hours = hours,
                Minutes = minutes,
                Seconds = seconds
            };

            return true;
        }
    }
}
