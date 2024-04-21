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
        public String UcTodaytxt { get { return _ucTodaytxt; } set { _ucTodaytxt = value; lblUserTxt.Text = value; } }


        public event AddEventHandler PopAdd;
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
            PopAdd(this, ae);
        }

        private void lblUserTxtClick(object sender, EventArgs e)
        {
            frmDescription frmDescription = new frmDescription();
            frmDescription.Show();
        }
    }
}
