using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock.Classes.Contracts
{
    public interface ITimeConverter
    {
        String ConvertTime(String aTime);
    }
}
