using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCal {
    public partial class frmMain : Form {

        public frmMain() {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            displaydays();
        }

        private void displaydays()
        {
            DateTime now = DateTime.Now;

            //This gets the first day of the month
            DateTime startofthemonth = new DateTime(now.Year, now.Month,1);

            //This gets the amount of days in the month
            int days = DateTime.DaysInMonth(now.Year, now.Month);

            //This converts the startofmonth to an integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            //This is a blank user control to align the boxes for the first days of the week
            for(int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            //This is a user control for the days
            for(int i = 1 ; i <= days ; i++) 
            {
                UserControlDays userControlDays = new UserControlDays();
                userControlDays.days(i);
                daycontainer.Controls.Add(userControlDays);
            }

        }
    }
}