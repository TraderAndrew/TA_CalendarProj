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
using System.Windows.Forms.VisualStyles;


namespace EduCal {

    public partial class frmMain : Form 
    {
        public List<EventModel> EventModelInfo { get; set; }
        public List<UserControlDays> UserDays { get; set; }
        public DateTime NowDate { get; set; }
        public EventForm CalEventForm { get; set; }
        public frmSettings SettingMenu { get; set; }


        int month, year;
        public Color dayFore, dayBack;

        public frmMain() 
        { 
            InitializeComponent();
            EventModelInfo = new List<EventModel>();
            NowDate = DateTime.Now;
            dayFore = Color.Black;
            dayBack = Color.White;
            Displaymonths();
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

                foreach (EventModel em in EventModelInfo)
                {
                    em.Day = i;
                    if (em.isMutliDay)
                    {
                        if (em.EventStartDay.Date <= uniqToday.Date) 
                        {
                            if (em.EventEndDay.Date >= uniqToday.Date) 
                            {
                                newDay.Event = em;
                            }
                        }
                    }
                    else 
                    {
                        if (em.EventStartDay.ToShortDateString() == uniqToday.ToShortDateString())
                        {
                            newDay.Event = em;
                        }
                    }
                }
                newDay.Days(i);
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
        /// back to previous months in a year as well as
        /// months in past years.
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
        /// This BtnNext_Click will allow the user to toggle forward
        /// to future months as well as months in future years.
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
        /// Brings up the about form when the dropdown on the about button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuAboutBtn_Click(object sender, EventArgs e)
        {
            frmAbout CalendarProjectInfo = new frmAbout();
            CalendarProjectInfo.ShowDialog();
        }

        /// <summary>
        /// This MnuSettings_CLick when clicked will display
        /// a form that will allow the user to change the color
        /// settings of the calendar as well as change the main
        /// background color of the calendar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuSettings_Click(object sender, EventArgs e)
        {
            SettingMenu = new frmSettings();
            SettingMenu.SettingsChanged += MnuSetting_AddNew;
            SettingMenu.Show();
        }

        /// <summary>
        /// This MnuSetting_AddNew will hold the the color values
        /// that the users decides on in the settings form and ensure
        /// that they are displayed on the calendar everytime the user
        /// opens the calendar as well as if the user decides to send a
        /// copy of the calendar to a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuSetting_AddNew(object sender, ColorOfDayEventArgs e)
        {
            dayFore = e.ForeColor;
            dayBack = e.BackGroundColor;
            this.BackColor = e.MainBackGroundColor;
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

        /// <summary>
        /// Adds the event from the model AddEventArgs e
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventform_AddNew(object sender, AddEventArgs e)
        {
            EventModelInfo.Add(e.Model);
            Displaymonths();
        }

        /// <summary>
        /// XmlSave_Click, Xml_Open, and ICalExport_Click all save to 
        /// the file directory C:\WORKING\CIS285_EduCal_T2\bin\Debug
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XmlSave_Click(object sender, EventArgs e)
        {
            if (Events != null && EventModelInfo.Count > 0) 
            {
                try 
                {
                    XmlSerializer XmlFile = new XmlSerializer(typeof(List<EventModel>));
                    TextWriter writer = new StreamWriter("MyEvents.xml");
                    XmlFile.Serialize(writer, EventModelInfo);
                    writer.Close();

                    MessageBox.Show("Saved :)", "Education Project");
                } 
                catch (Exception)
                {
                    MessageBox.Show("You already have a file opened! You must restart to save the new events :)", "Education Calendar XML Save");
                }
            }
            else
            {
                MessageBox.Show("There is nothing to save!", "Education Calendar XML Save");
            }
        }

        private void XmlOpen_Click(object sender, EventArgs e)
        {
            if (Events != null && EventModelInfo.Count > 0)
            {
                MessageBox.Show("You can not opend a file with events already displayed!", "Education Calendar XML Open");
            }
            else
            {
                try
                {
                    XmlSerializer XmlFile = new XmlSerializer(typeof(List<EventModel>));
                    FileStream fs = new FileStream("MyEvents.xml", FileMode.Open);

                    EventModelInfo = (List<EventModel>)XmlFile.Deserialize(fs);
                    Displaymonths();
                }
                catch (Exception)
                {
                    MessageBox.Show("You have an empty 'MyEvents' file! You need to make events first :)", "Education Calendar XML Open");
                }
            }
            
        }

        private void ICalExport_Click(object sender, EventArgs e)
        {
            if(Events != null && EventModelInfo.Count > 0)
            {
                EventModel em = EventModelInfo.FirstOrDefault();
                FileStream writer = new FileStream("Event.ics", FileMode.Create);
                StringBuilder var1 = new StringBuilder();
                var1.AppendLine("BEGIN: VCALENDAR");
                var1.AppendLine("VERSION:2.0");
                var1.AppendLine("PRODID: -//Andrews Calendar/v1.0//EN");
                var1.AppendLine("BEGIN: VEVENT");
                var1.AppendLine("DURATION:PT1H0M0S");
                var1.AppendLine("DUE:19980430T000000Z");
                var1.AppendLine($"DTSTAMP: {em.Name}");
                var1.AppendLine($"DTSTART:{em.EventStartDay}");
                var1.AppendLine($"DTEND:{em.EventEndDay}");
                var1.AppendLine($"DECRIPTION:{em.Description}");
                var1.AppendLine($"LOCATION:{em.Location}");
                var1.AppendLine("END:VEVENT");
                var1.AppendLine("END:VCALENDAR");
                byte[] buffer = new ASCIIEncoding().GetBytes(var1.ToString());
                writer.Write(buffer, 0, buffer.Length);
                writer.Close();

                MessageBox.Show("Saved :)", "Education Project");
            }
            else
            {
                MessageBox.Show("There is nothing to save!", "Education Calendar iCal Save");
            }
        }
    }
}