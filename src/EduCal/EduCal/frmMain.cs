using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCal {
    public partial class frmMain : Form 
    {
        int month, year;
        public static int static_month, static_year;


        public List<EventModel> Events { get; set; }
        public List<UserControlDays> userControlDays { get; set;  }
        public DateTime NowDate { get; set; } 
        public EventForm CalEventForm { get; set; }


        public frmMain() {
            
            InitializeComponent();
            Events = new List<EventModel>() {
                new EventModel() { Id = 1, eventday= DateTime.Parse("3/4/2024"), Name="My Test Date"},
                new EventModel() { Id = 2, eventday= DateTime.Parse("3/25/2024"), Name="Date Due"}
            };
            NowDate = DateTime.Now;
            CalEventForm = new EventForm();
            CalEventForm.added += eventform_AddNew;
            displaymonths();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }


        private void displaymonths() 
        {
            daycontainer.Controls.Clear();
            month = NowDate.Month;
            year = NowDate.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LabelDate.Text = monthname + " " + year;

            static_month = month;
            static_year = year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            displaydays(dayoftheweek, days);
        }


        private void displaydays(int _dayoftheweek, int _days)
        {
            userControlDays = new List<UserControlDays>();
            for (int i = 1; i < _dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            for(int i = 1 ; i <= _days ; i++) 
            {
                UserControlDays newDay= new UserControlDays();
                DateTime uniqToday = DateTime.Parse($"{NowDate.Month}/{i}/{NowDate.Year}");
                newDay.days(i); 
                foreach (EventModel em in Events)
                { 
                    if (em.eventday.ToShortDateString() == uniqToday.ToShortDateString()) {  
                        newDay.ucTodaytxt =em.Name;
                    } 
                }

                //eventwireup
                userControlDays.Add(newDay);


            }
            foreach (UserControlDays item in userControlDays) 
            {
                item.popAdd += day_Click;
                daycontainer.Controls.Add (item);
            }
        }

        public void popitday_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            NowDate = NowDate.AddMonths(-1);
            displaymonths();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            NowDate = NowDate.AddMonths(1);
            displaymonths();
        }


        private void eventform_AddNew(object sender, AddEventArgs e)
        { 
            Events.Add(e.Model);
            displaymonths();
        }

        public void day_Click(object sender, AddEventArgs e) 
        {
            CalEventForm = new EventForm();
            CalEventForm.Show();
        }
    }
}