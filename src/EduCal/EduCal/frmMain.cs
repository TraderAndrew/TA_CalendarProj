using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCal {
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMain : Form 
    {
        //ask why putting keyword(new) on line 17 removed the squiggly line
        public new List<EventModel> Events { get; set; }
        public List<UserControlDays> UserDays { get; set; }
        public DateTime NowDate { get; set; }
        public EventForm CalEventForm { get; set; }
        public frmSettings SettingMenu { get; set; }
        public frmSettings FrmMainBackColor { get; set; }


        int month, year;
        public Color dayFore, dayBack, mainColor;


        public frmMain() 
        { 
            InitializeComponent();
            Events = new List<EventModel>();
            NowDate = DateTime.Now;
            dayFore = Color.Black;
            dayBack = Color.White;
            Displaymonths();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }
/// <summary>
/// This method takes in _dayoftheweek and _days for the first
/// for loop will display usercontroldays within the daycontainer
/// which is set equal to datetime. The second for loop takes the
/// text from the first loop and applies it to the date range.
/// The two foreach loops determine whether or not the event will
/// effect the one day or the date range that the user selected or multiple days.
/// The last for loop changes the color of the weekend.
/// </summary>
/// <param name="_dayoftheweek"></param>
/// <param name="_days"></param>
        private void Displaydays(int _dayoftheweek, int _days)
        {
            UserDays = new List<UserControlDays>();

            for (int i = 1; i < _dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= _days; i++)
            {
                UserControlDays newDay = new UserControlDays();
                DateTime uniqToday = DateTime.Parse($"{NowDate.Month}/{i}/{NowDate.Year}");

                if (uniqToday.DayOfWeek == DayOfWeek.Sunday || uniqToday.DayOfWeek == DayOfWeek.Saturday)
                {
                    newDay.WeekEnd = true;
                }

                newDay.Days(i);

                foreach (EventModel em in Events)
                {
                    if (em.isMutliDay)
                    {
                        if (em.EventStartDay.Date <= uniqToday.Date)
                        {
                            if (em.EventEndDay.Date >= uniqToday.Date)
                            {
                                newDay.UcTodaytxt = em.Name;
                            }
                        }
                    }
                    else
                    {
                        if (em.EventStartDay.ToShortDateString() == uniqToday.ToShortDateString())
                        {
                            newDay.UcTodaytxt = em.Name;
                        }
                    }
                }

                UserDays.Add(newDay);
            }

            foreach (UserControlDays item in UserDays)
            {
                if (item.WeekEnd)
                {
                    item.BackColor = Color.DarkGray;
                    item.ForeColor = Color.Gray;
                }
                else
                {
                    item.BackColor = dayBack;
                    item.ForeColor = dayFore;
                }

                item.PopAdd += MnuFileEvent_Click;
                daycontainer.Controls.Add(item);
            }
        }

        
        /// <summary>
        /// The displayMonths method works to hold as well
        /// display the date, time, and year to be used by 
        /// on click buttons as well as the creation of
        /// events by the user.
        /// </summary>
        private void Displaymonths() 
        {
            daycontainer.Controls.Clear();

            month = NowDate.Month;
            year = NowDate.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblMonthYear.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            
            Displaydays(dayoftheweek, days);
        }

            
        /// <summary>
        /// This btnPrevious_Click allows user to toggle
        /// through the different months in a year as
        /// well go back to months in previous years.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            NowDate = NowDate.AddMonths(-1);
            Displaymonths();
        }

        /// <summary>
        /// This BtnNext_Click will allow the user to click back
        /// and forth between the different months of the year
        /// and even go back to the months of the previous and future
        /// years.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            NowDate = NowDate.AddMonths(1);
            Displaymonths();
        }
        
        /// <summary>
        /// This About_Click will display the names of the
        /// different people that contributed to making of
        /// this project.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Click(object sender, EventArgs e)
        {
            frmAbout TeamTwoNames = new frmAbout();
            TeamTwoNames.ShowDialog();
        }    

        /// <summary>
        /// The MnuSettings_Click when clicked will allow the user to
        /// change the settings of the calendar itself as well change
        /// the main background color of the calendar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuSettings_Click(object sender, EventArgs e)
        {
            SettingMenu = new frmSettings();
            SettingMenu.SettingsChanged += MnuSetting_AddNew;
            SettingMenu.FrmMainBackground += MainBackgroundColor;
            SettingMenu.Show();
        }
        
        /// <summary>
        /// This MnuSetting_AddNew will hold the color value
        /// that the user decides in the settings and ensure
        /// that they are displayed in the calendar everytime
        /// the user opens the calendar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuSetting_AddNew(object sender, ColorOfDayEventArgs e)
        {
            dayFore = e.ForeColor;
            dayBack = e.BackGroundColor;           
            Displaymonths();
        }

        private void MainBackgroundColor(object sender, frmMainColorEventArgs e) 
        {
            this.BackColor = e.mainBackground;
        }
        
        /// <summary>
        /// The MnuFileEvent_Click will allow the user to open an
        /// event form that will allow them to attach an event
        /// to the date or dates of their choosing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuFileEvent_Click(object sender, EventArgs e)
        {
            CalEventForm = new EventForm();
            CalEventForm.EventfrmAdd += Eventform_AddNew;
            CalEventForm.Show();
        }
        
        /// <summary>
        /// This Eventform_AddNew will ensure that the event or events that
        /// user inputs into the event form will be displayed visually
        /// on the calendar under the date or dates that they are relevant to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventform_AddNew(object sender, AddEventArgs e)
        { 
            Events.Add(e.Model);
            Displaymonths();
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}