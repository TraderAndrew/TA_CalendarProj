using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EduCal
{
    public partial class frmSettings : Form
    {
        public event ColorOfDayEventHandler settingsChanged;


        public frmSettings()
        {
            InitializeComponent();
        }

        private void checkBox_Changed(object sender, EventArgs e)
        {
            var tmpBack = Color.White;
            var tmpFore = Color.Black;

            if (checkBox1.Checked)
            {
               tmpBack = Color.Pink;
               tmpFore = Color.Blue;
            }

            if (checkBox2.Checked) 
            {
                tmpBack = Color.White;
                tmpFore = Color.Black;
            }
           
            ColorOfDayEventArgs carrier = new ColorOfDayEventArgs();
            carrier.foreColor = tmpFore;
            carrier.backGroundColor = tmpBack;

            settingsChanged(this, carrier);
            this.Close();
        }

    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
