using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCal
{
    public partial class EventForm : Form
    {
        public event AddEventHandler EventfrmAdd;
        DateTime dt = DateTime.Now;

        public EventForm()
        {
            InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UserControlDays.static_day))
            {
                txtBoxStartDate.Text = $"{dt.Month}/{dt.Day}/{dt.Year}";

            }
            else
            {
                txtBoxStartDate.Text = $"{dt.Month}/{UserControlDays.static_day}/{dt.Year}";

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxStartDate.Text))
            {
                lblError.Text = "START DATE IS EMPTY. YOU MUST ENTER A START DATE";
            }
            else if (String.IsNullOrEmpty(txtEvent.Text))
            {
                lblError.Text = "EVENT NAME EMPTY. YOU MUST ENTER AN EVENT NAME";
            }
            else if (txtEvent.Text.Length < 3)
            {
                lblError.Text = "EVENT NAME MUST BE GREATER THAN 3 CHARACTERS";
            }
            else if (txtEvent.Text.Length > 100)
            {
                lblError.Text = "EVENT NAME MUST LESS THAN 100 CHARACTERS";
            }
            else if (txtBoxDescription.Text.Length > 1000)
            {
                lblError.Text = "DESCRIPTION MUST BE LESS THAN 1000 CHARACTERS";
            }
            else
            {
                if (!String.IsNullOrEmpty(txtBoxStartDate.Text) && !String.IsNullOrEmpty(txtBoxEndDate.Text))
                {
                    RunDateRange();
                }
                else
                {
                    RunSingleDay();
                }
            }
        }

        private void RunDateRange()
        {
            if (!DateTime.TryParse(txtBoxStartDate.Text, out dt) && !DateTime.TryParse(txtBoxEndDate.Text, out dt))
            {
                lblError.Text = "BOTH DATES ARE NOT VALID";
            }
            else if (!DateTime.TryParse(txtBoxEndDate.Text, out dt))
            {
                lblError.Text = "YOU MUST ENTER A VALID END DATE";
            }
            else if (!DateTime.TryParse(txtBoxStartDate.Text, out dt))
            {
                lblError.Text = "YOU MUST ENTER A VALID START DATE";
            }
            else
            {
                DateTime sDate = DateTime.Parse(txtBoxStartDate.Text);
                DateTime eDate = DateTime.Parse(txtBoxEndDate.Text);

                EventModel tmp = new EventModel() {  Location = txtBoxLocation.Text, Description = txtBoxDescription.Text, EventStartDay = sDate, EventEndDay = eDate, Name = txtEvent.Text, isMutliDay = true };
                AddEventArgs ae = new AddEventArgs() { Model = tmp };
                EventfrmAdd(this, ae);

                this.Close();
            }
        }

        private void RunSingleDay() 
        {
            if (!DateTime.TryParse(txtBoxStartDate.Text, out dt))
            {
                lblError.Text = "YOU MUST ENTER A VALID START DATE";
            }
            else
            {
                EventModel tmp = new EventModel() { Location = txtBoxLocation.Text, Description = txtBoxDescription.Text, EventStartDay = dt, Name = txtEvent.Text, isMutliDay = false };
                AddEventArgs ae = new AddEventArgs() { Model = tmp };
                EventfrmAdd(this, ae);

                this.Close();
            }
        }
    }
}
