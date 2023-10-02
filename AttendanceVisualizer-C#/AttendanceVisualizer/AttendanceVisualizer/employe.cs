using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceVisualizer
{
    internal class employe 
    {
        private int ID;
        private Datelist Datelist ;
        public employe(int ID)
        {
            this.ID = ID;
        }
        public TimeSpan GetTotalTime()
        {
            return Datelist.CalculateTotalTime();
        }
        public int GetID()
        {
            return ID;
        }
        public Datelist GetDatelist()
        {
            return Datelist;
        }
        public void SetDatelist(Datelist Datelist)
        {
            this.Datelist = Datelist;
        }
       
    }

}
