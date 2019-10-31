namespace BerlinClock.Classes.Contracts
{
    public interface ITimeParser
    {
        bool TryParse(string time, out Time parsedTime);
    }
}
