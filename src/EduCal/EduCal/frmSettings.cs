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
        public event ColorOfDayEventHandler SettingsChanged;
        public event frmMainColorEventHandler FrmMainBackground;

        public frmSettings()
        {
            InitializeComponent();
        }
        
// This event handler will allow the user to change the 
// background color of the calendar to blue as well as
// change the background color of the weekend days to pink
// and blue. 
        private void checkBox_Changed(object sender, EventArgs e)
        {
            var dayBack = Color.White;
            var dayFore = Color.Black;
            var mainBack = SystemColors.Control;

            if (checkBox1.Checked)
            {
               dayBack = Color.Pink;
               dayFore = Color.Blue;
            }

            if (checkBox2.Checked) 
            {
                dayBack = Color.White;
                dayFore = Color.Black;
            }

            if (checkBox3.Checked)
            {
                mainBack = Color.Blue;
            }

            if (checkBox4.Checked) 
            {
                mainBack = SystemColors.Control;
            }

            ColorOfDayEventArgs dayColor = new ColorOfDayEventArgs
            {
                ForeColor = dayFore,
                BackGroundColor = dayBack
            };
            SettingsChanged(this, dayColor);

            MainBackgroundChange mainColor = new MainBackgroundChange
            {
                mainBackground = mainBack
            };
            FrmMainBackground(this, mainColor);


            this.Close();
        }
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
