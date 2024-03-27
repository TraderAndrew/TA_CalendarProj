using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCal
{
    public partial class UserControlDays : UserControl
    {
        public bool WeekEnd { get; set; } = false;
        public DateTime UcToday { get; set; }
        //UcToday gets todays date and displays it in the top left corner of the boxes in the calendar
        public String UcTodaytxt { get { return _ucTodaytxt; } set { _ucTodaytxt = value; lblUserTxt.Text = value; } }
        //UcTodaytxt gets the the txt from the event form the user inputs as his/her event and displays it in the middle of the boxes of the calendar


        public event AddEventHandler popAdd;
        public static string static_day;
        private String _ucTodaytxt;
       

        public UserControlDays()
        {
            InitializeComponent();
        }
        
        public void Days(int numday)
        {
            lblDays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lblDays.Text;
            EventForm eventForm = new EventForm();
            EventModel tmp = new EventModel();
            AddEventArgs ae = new AddEventArgs();
            popAdd(this, ae);
        }
















    }
}
