using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceVisualizer
{
    internal class DATE
    {
        private string day;

        private string TimeIn;

        private string TimeOut;
        public DATE(string day, string TimeIn, string TimeOut)
        {
            this.day = day;
            this.TimeIn = TimeIn;
            this.TimeOut = TimeOut;
        }
        public string Getday() { return day; }
        public string GetTimeIN() { return TimeIn; }
        public string GetTimeOut() { return TimeOut; }
        public TimeSpan Calculatetime()
        {
            if (TimeIn.Equals("-") && TimeOut.Equals("-")) { return new TimeSpan(-1,0,0); }
            else if((TimeIn.Equals("-") || TimeOut.Equals("-")|| TimeIn.EndsWith("(+1)")|| TimeOut.EndsWith("(+1)"))) { return TimeSpan.Zero; }
            else
            {
                TimeSpan Timein = TimeSpan.Parse(TimeIn);
                TimeSpan Timeout = TimeSpan.Parse(TimeOut);
                return Timeout-Timein;
            }
        }
    }}
