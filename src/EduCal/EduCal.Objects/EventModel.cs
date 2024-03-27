using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCal
{
    public class EventModel
    {
        public bool isMutliDay = false;

        public string Name { get; set; }
        public DateTime EventStartDay { get; set; }
        public DateTime EventEndDay { get; set;}
    }
}
