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

        /// <summary>
        /// This event handler will create a series of checkboxes that 
        /// the user can choose from with the first checkbox being
        /// an option of one other color pairing for the color of the 
        /// number and background color of the weekdays and this choice 
        /// is pink for the background of the weekdays and blue for 
        /// color of the numbers of the weekdays. The second checkbox will return 
        /// the colors of the numbers and background to their default colors.
        /// The third checkbox will change the main background color to 
        /// lightblue. The final checkbox will return the main background color
        /// to its default setting. The ColorOfDayEventArgs and the MainColorEventsArgs
        /// will hold the option that the users choose so that if they return to the calendar or
        /// copy the calendar into a file then it will retain the color setting choices.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
<<<<<<< HEAD
// This event handler will allow the user to change the 
// background color of the calendar to blue as well as
// change the background color of the weekend days to pink
// and blue. 
        private void CheckBox_Changed(object sender, EventArgs e)
=======
        private void checkBox_Changed(object sender, EventArgs e)
>>>>>>> 643c877da4314d4a48bc95ecd99861f81009c9cc
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
                mainBack = Color.LightBlue;
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
