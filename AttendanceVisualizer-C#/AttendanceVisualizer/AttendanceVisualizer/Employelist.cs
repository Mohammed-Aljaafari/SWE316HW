using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceVisualizer
{
    internal class Employelist
    {
        private List<employe> employelists = new List<employe>();
        public Employelist(List<employe> employelists, object value) {
            this.employelists = employelists;
        }
        public Employelist()
        {
            this.employelists=new List<employe>();
        }
        public void AddTolist(employe s)
        {
            employelists.Add(s);
        }
        public employe GetEmploye(int i) {
            return employelists[i];
        }
        public List<employe > GetEmployelists()
        {
            return employelists;
        }
    }
}
