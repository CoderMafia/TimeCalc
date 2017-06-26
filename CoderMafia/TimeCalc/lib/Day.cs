
using System;

namespace TimeCalc
{
    public class Day
    {
        public int TimeIn { get; set; }
        public int TimeOut { get; set; }

        public int TotalTime()
        {
            try
            {
                Guard.ThrowIfNull(TimeIn);
                Guard.ThrowIfNull(TimeOut);
                return TimeOut - TimeIn;
            }catch(ArgumentNullException ane)
            {
                throw new ArgumentNullException("Time in or time out is null!");
            }
        }
    }
}
