using System;
using System.Collections.Generic;

namespace TimeCalc
{
    public class Week
    {
        private List<Day> weekDays = new List<Day>();
        public Week()
        {
            weekDays.Clear();
        }
        public void AddWeek(int[] ins, int[] outs)
        {
            for (int i = 0; i < ins.Length; i++)
            {
                var d = new Day() {
                    TimeIn = ins[i],
                    TimeOut = outs[i]
                };
                AddDay(d);
            }
        }
        public void AddWeek(Day[] week)
        {
            weekDays.AddRange(week);
        }
        public void AddDay(Day d)
        {
            weekDays.Add(d);
        }
        public void AddDay(int timeIn, int timeOut)
        {
            var d = new Day()
            {
                TimeIn = timeIn,
                TimeOut = timeOut
            };
            weekDays.Add(d);
        }
        public int CalculateWeek()
        {
            try
            {
                var hours = 0;
                foreach (var d in weekDays)
                {
                    hours += d.TotalTime();
                }
                return hours;
            }catch (ArgumentNullException ane)
            {
                throw new ArgumentNullException("hour in  and or hour out was not set!");
            }
            
        }
    }
}
