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
        public event frmMainColorEventHandler frmMainBackground;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void checkBox_Changed(object sender, EventArgs e)
        {
            var dayBack = Color.White;
            var dayFore = Color.Black;
            var mainBack = Color.White;

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

            ColorOfDayEventArgs dayColor = new ColorOfDayEventArgs();
            dayColor.foreColor = dayFore;
            dayColor.backGroundColor = dayBack;
            settingsChanged(this, dayColor);

            frmMainColorEventArgs mainColor = new frmMainColorEventArgs();
            mainColor.mainBackground = mainBack;
            frmMainBackground(this, mainColor);


            this.Close();
        }
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
