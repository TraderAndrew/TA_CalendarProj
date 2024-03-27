﻿using System;
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
            if (dt.Month > 9)
            {
                txtBoxStartDate.Text = $"{dt.Month}/{dt.Day}/{dt.Year}";
                ///txtBoxEndDate.Text = $"{dt.Month}/00/{dt.Year}";
            }
            else 
            {
                txtBoxStartDate.Text = $"0{dt.Month}/{dt.Day}/{dt.Year}";
                //txtBoxEndDate.Text = $"0{dt.Month}/00/{dt.Year}";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBoxStartDate.Text) && !String.IsNullOrEmpty(txtBoxEndDate.Text))
            {
                runDateRange();            
            }
            else if (!String.IsNullOrEmpty(txtBoxStartDate.Text))
            {
                runSingleDay();
            }
            else 
            {
                lblError.Text = "You have to enter a start date";
            }
        }

        private void runDateRange() 
        {
            DateTime sDate = DateTime.Parse(txtBoxStartDate.Text);
            DateTime eDate = DateTime.Parse(txtBoxEndDate.Text);

            EventModel tmp = new EventModel() { eventStartDay = sDate, eventEndDay = eDate, Name = txtEvent.Text, isMutliDay = true };
            AddEventArgs ae = new AddEventArgs() { Model = tmp };
            eventfrmAdd(this, ae);

            this.Close();
        }

        private void runSingleDay() 
        {
            
            if (!DateTime.TryParse(txtBoxStartDate.Text, out dt))
            {
                lblError.Text = "Enter a valid date";
                dt = DateTime.Now;
            }
            else
            {
                EventModel tmp = new EventModel() { eventStartDay = dt, Name = txtEvent.Text, isMutliDay = false };
                AddEventArgs ae = new AddEventArgs() { Model = tmp };
                eventfrmAdd(this, ae);

                this.Close();
            }
        }

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
