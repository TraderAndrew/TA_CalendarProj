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
        /// This event handler will create a series of radioButtons that 
        /// the user can choose from with the first button being
        /// an option of one other color pairing for the color of the 
        /// number and background color of the weekdays and this choice 
        /// is pink for the background of the weekdays and blue for 
        /// color of the numbers of the weekdays. The second button will return 
        /// the colors of the numbers and background to their default colors.
        /// The third button will change the main background color to 
        /// lightblue. The final button will return the main background color
        /// to its default setting. The ColorOfDayEventArgs and the MainColorEventsArgs
        /// will hold the option that the users choose so that if they return to the calendar or
        /// copy the calendar into a file then it will retain the color setting choices.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            var dayBack = Color.White;
            var dayFore = Color.Black;
            var mainBack = SystemColors.Control;

            if (radioButton1.Checked)
            {
                dayBack = Color.Pink;
                dayFore = Color.Blue;
            }

            if (radioButton2.Checked)
            {
                dayBack = Color.White;
                dayFore = Color.Black;
            }

            if (radioButton3.Checked)
            {
                mainBack = Color.LightBlue;
            }

            if (radioButton4.Checked)
            {
                mainBack = SystemColors.Control;
            }

            ColorOfDayEventArgs dayColor = new ColorOfDayEventArgs { ForeColor = dayFore, BackGroundColor = dayBack };
            SettingsChanged(this, dayColor);

            MainBackgroundEventArgs mainColor = new MainBackgroundEventArgs { mainBackground = mainBack };
            FrmMainBackground(this, mainColor);

            this.Close();
        }

        
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
           //This radioButton_CheckedChanged method will ensure that when the user changes the color values of any of the 
           //items(letters, background, foregrounds, etc.) in the settings that those changes will only be applied after
           //the user clicks the apply button instead of automatically applying the changes when the user clicks on the options.
        }
    }
}
