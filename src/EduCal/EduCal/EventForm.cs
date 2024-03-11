using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCal
{
    public partial class EventForm : Form
    {
        public event AddEventHandler added;
        String connString = "server=localhost;user id=root;database=db_calendar;sslmode=none";

        public EventForm()
        {
            InitializeComponent();
        }

        
        private void EventForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = frmMain.static_month + "/" + UserControlDays.static_day +"/" + frmMain.static_year;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventModel tmp = new EventModel() { Id = 3, eventday = DateTime.Parse(txtDate.Text), Name = txtEvent.Text };
            AddEventArgs ae = new AddEventArgs() { Model = tmp };
            added(this, ae);
            this.Close();
        }
    }
}
