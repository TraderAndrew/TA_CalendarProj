using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EduCal
{
    public delegate void ColorOfDayEventHandler(object sender, ColorOfDayEventArgs e);
    public class ColorOfDayEventArgs:EventArgs
    {
        public Color backGroundColor { get; set; }
        public Color foreColor { get; set; }
    }
}
