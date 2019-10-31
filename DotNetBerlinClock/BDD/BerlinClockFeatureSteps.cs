using BerlinClock.Classes;
using BerlinClock.Classes.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        /* In real appliation BerlinClockTimeConverter should be created via IoC container or factory. */
        private ITimeConverter berlinClock = new BerlinClockTimeConverter(new BerlinClockTimeFormatter(), new HmsCustomTimeParser());
        private String theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.ConvertTime(theTime), theExpectedBerlinClockOutput);
        }

    }
}
