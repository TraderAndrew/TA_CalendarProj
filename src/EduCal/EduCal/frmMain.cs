using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
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

    public partial class frmMain : Form 
    {
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

        private void BtnNext_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            NowDate = NowDate.AddMonths(1);
            Displaymonths();
        }

        private void MnuAboutBtn_Click(object sender, EventArgs e)
        {
            frmAbout CalendarProjectInfo = new frmAbout();
            CalendarProjectInfo.ShowDialog();
        }

        private void MnuSettings_Click(object sender, EventArgs e)
        {
            SettingMenu = new frmSettings();
            SettingMenu.SettingsChanged += MnuSetting_AddNew;
            SettingMenu.FrmMainBackground += MainBackgroundColor;
            SettingMenu.Show();
        }

        private void MnuSetting_AddNew(object sender, ColorOfDayEventArgs e)
        {
            dayFore = e.ForeColor;
            dayBack = e.BackGroundColor;           
            Displaymonths();
        }

        /// <summary>
        /// MnuFileEvent_Click allows the user to acess the event form to
        /// put an event on the calendar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuFileEvent_Click(object sender, EventArgs e)
        {
            CalEventForm = new EventForm();
            CalEventForm.EventfrmAdd += Eventform_AddNew;
            CalEventForm.Show();
        }

        private void Eventform_AddNew(object sender, AddEventArgs e)
        {
            Events.Add(e.Model);
            Displaymonths();
        }

        private void MainBackgroundColor(object sender, MainBackgroundEventArgs e)
        {
            this.BackColor = e.mainBackground;
        }

        /// <summary>
        /// XmlSave_Click, Xml_Open, and ICalExport_Click all save to 
        /// the file directory C:\WORKING\CIS285_EduCal_T2\bin\Debug
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XmlSave_Click(object sender, EventArgs e)
        {
            XmlSerializer XmlFile = new XmlSerializer(typeof(List<EventModel>));
            TextWriter writer = new StreamWriter("MyEvents.xml");

            if (Events != null && Events.Count > 0) 
            {
                XmlFile.Serialize(writer, Events);
                writer.Close();
            }
        }

        private void XmlOpen_Click(object sender, EventArgs e)
        {
            XmlSerializer XmlFile = new XmlSerializer(typeof(List<EventModel>));
            FileStream fs = new FileStream("MyEvents.xml", FileMode.Open);

            Events = (List<EventModel>)XmlFile.Deserialize(fs);
            Displaymonths();
        }

        private void ICalExport_Click(object sender, EventArgs e)
        {
            FileStream writer = new FileStream("Event.ics", FileMode.Create);
            StringBuilder var1 = new StringBuilder();
            var1.AppendLine("BEGIN: VCALENDAR");
            var1.AppendLine("VERSION:2.0");
            var1.AppendLine("PRODID: -//Andrews Calendar/ v1.0//EN");
            var1.AppendLine("BEGIN: VEVENT");
            var1.AppendLine($"DTSTAMP: {DateTime.Now}");
            var1.AppendLine($"DTSTART:{DateTime.Now}");
            var1.AppendLine($"DTEND:{DateTime.Now}");
            var1.AppendLine("END:VEVENT");
            var1.AppendLine("END:VCALENDAR"); 
            byte[] buffer = new ASCIIEncoding().GetBytes(var1.ToString());
            writer.Write(buffer, 0, buffer.Length);
            writer.Close();
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}