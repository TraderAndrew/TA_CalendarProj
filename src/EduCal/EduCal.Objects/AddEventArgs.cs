using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCal
{
    public delegate void AddEventHandler(object sender, AddEventArgs e);
    public class AddEventArgs:EventArgs
    {
        public EventModel Model;
    }
}
