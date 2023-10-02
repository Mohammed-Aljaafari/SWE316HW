using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceVisualizer
{
    internal class Datelist
    {
        private List<DATE> datalist = new List<DATE>();
        public Datelist()
        {
            List<DATE> datalist = new List<DATE>();
        }
        public Datelist(List<DATE> datelist)
        {
            this.datalist = datelist;
        }
        public List<DATE> Getdatalist()
        {
            return this.datalist;
        }
        public void Addtolist(DATE d)
        {
            datalist.Add(d);
        }
       
        public int GetSize()
        {
            return datalist.Count;
        }
        public DATE Getitem(int i) {
            return datalist[i];
        }
        public TimeSpan CalculateTotalTime()
        {
            TimeSpan Total = new TimeSpan();
            foreach (var item in datalist)
            {
                Total += item.Calculatetime();
            }


            return Total;
        }

    }
}
