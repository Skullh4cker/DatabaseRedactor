using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }
    }
}
