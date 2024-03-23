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
        public DateTime eventStartDay { get; set; }
        public DateTime eventEndDay { get; set;}
    }
}
