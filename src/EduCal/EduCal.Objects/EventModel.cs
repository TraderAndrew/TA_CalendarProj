using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCal
{
    public class EventModel
    {
        public bool isMutliDay = false;

        [XmlAttribute("Name")]
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Location { get; set; }
        public int Day { get; set; }
        public DateTime EventStartDay { get; set; }
        public DateTime EventEndDay { get; set;}
    }
}
