using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EduCal
{
    public delegate void frmMainColorEventHandler(object sender, frmMainColorEventArgs e);
    public class frmMainColorEventArgs:EventArgs
    {
        public Color mainBackground { get; set; }
    }
}
