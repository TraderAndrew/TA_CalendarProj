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
        public event AddEventHandler popAdd;

        public static string static_day;
        private String _ucTodaytxt;


        public DateTime ucToday { get; set; }
        public String ucTodaytxt { get { return _ucTodaytxt;  } set { _ucTodaytxt = value; lblUserTxt.Text = value; } }

       
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        
        public void days(int numday)
        {
            labelDays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = labelDays.Text;
            EventForm eventForm = new EventForm();
            EventModel tmp = new EventModel();
            AddEventArgs ae = new AddEventArgs();
            popAdd(this, ae);
            //eventForm.Show();

        }
    }
}
