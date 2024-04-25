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
    public partial class frmDescription : Form
    {
        public frmDescription()
        {
            InitializeComponent();
        }

        private void frmDescription_Load(object sender, EventArgs e)
        {
            frmTxtBoxDescription.Text = EventForm.Description;
            frmTxtBoxLocation.Text = EventForm.Location;

            if (String.IsNullOrEmpty(frmTxtBoxDescription.Text))
            {
                frmTxtBoxDescription.Text = "You did not put a description";
            }
            if (String.IsNullOrEmpty(frmTxtBoxLocation.Text))
            {
                frmTxtBoxLocation.Text = "You did not put a location";
            }
        }

        private void btnOkCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
