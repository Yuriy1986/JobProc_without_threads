using System.Collections.Generic;

namespace JobProc.DAL
{
    public class Person
    {
        public int CountImages { get; set; }
        public int CountPeople { get; set; }

        public List<int> PeopleTimes { get; set; }
        public Person()
        {
            PeopleTimes = new List<int>();
        }

    }
}
