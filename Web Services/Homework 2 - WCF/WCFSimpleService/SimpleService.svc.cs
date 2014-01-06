using System;

namespace WCFSimpleService
{
    public class SimpleService : ISimpleService
    {
        public string GetDayOfWeekInBulgarian(DateTime value)
        {
            return value.ToString("dddd", 
                  System.Globalization.CultureInfo.CreateSpecificCulture("bg-BG"));
        }
    }
}
