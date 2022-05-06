using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProc.DAL
{
    public class Person
    {
        public int CountImages { get; set; }
        public int CountPeoples { get; set; }

        public List<int> PeopleTimes { get; set; }
        public Person()
        {
            PeopleTimes = new List<int>();
        }

    }
}
