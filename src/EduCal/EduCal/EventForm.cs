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
        public event AddEventHandler eventfrmAdd;
        DateTime dt = DateTime.Now;

        public EventForm()
        {
            InitializeComponent();
        }


        private void EventForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = $"{dt.Month}/{dt.Day}/{dt.Year}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDate.Text.Contains("-"))
            {
                runDateRange();
            }
            else 
            {
                runSingleDay();
            }
        }

        private void runDateRange() 
        {
            //    var sDate = txtDate.Text.Split('-')[0];
            //    var eDate = txtDate.Text.Split('-')[1];
            lblError.Text = "Date ranges are not yet supported";
        }

        private void runSingleDay() 
        {
            
            if (!DateTime.TryParse(txtDate.Text, out dt))
            {
                lblError.Text = "Enter a valid date";
                dt = DateTime.Now;
            }
            else
            {
                EventModel tmp = new EventModel() { eventday = dt, Name = txtEvent.Text };
                AddEventArgs ae = new AddEventArgs() { Model = tmp };

                eventfrmAdd(this, ae);
                this.Close();
            }
        }

    }
}
