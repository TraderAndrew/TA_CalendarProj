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
            txtBoxStartDate.Text = $"{dt.Month}/{UserControlDays.static_day}/{dt.Year}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxStartDate.Text))
            {
                lblError.Text = "Please enter a start date.";
            }
            else if (String.IsNullOrEmpty(txtEvent.Text))
            {
                lblError.Text = "Please enter your event.";
            }
            else if (txtEvent.Text.Length < 3 || txtEvent.Text.Length > 100)
            {
                lblError.Text = "There must be between 3 to 100 characters to make a event.";
            }
            else if (!String.IsNullOrEmpty(txtBoxStartDate.Text) && !String.IsNullOrEmpty(txtBoxEndDate.Text))
            {
                RunDateRange();
            }
            else if (!String.IsNullOrEmpty(txtBoxStartDate.Text))
            {
                RunSingleDay();
            }
        }

        private void RunDateRange() 
        {
            DateTime sDate = DateTime.Parse(txtBoxStartDate.Text);
            DateTime eDate = DateTime.Parse(txtBoxEndDate.Text);

            EventModel tmp = new EventModel() { EventStartDay = sDate, EventEndDay = eDate, Name = txtEvent.Text, isMutliDay = true };
            AddEventArgs ae = new AddEventArgs() { Model = tmp };
            EventfrmAdd(this, ae);

            this.Close();
        }

        private void RunSingleDay() 
        {
            
            if (!DateTime.TryParse(txtBoxStartDate.Text, out dt))
            {
                lblError.Text = "Enter a valid date";
                dt = DateTime.Now;
            }
            else
            {
                EventModel tmp = new EventModel() { EventStartDay = dt, Name = txtEvent.Text, isMutliDay = false };
                AddEventArgs ae = new AddEventArgs() { Model = tmp };
                EventfrmAdd(this, ae);

                this.Close();
            }



        }





        
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
