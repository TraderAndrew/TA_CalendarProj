using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCal
{
    public partial class frmDescription : Form
    {
        private string fDescription = string.Empty;
        private string fLocation = string.Empty;
        public string FormDescription { get { return fDescription; } set { fDescription = value; frmTxtBoxDescription.Text = value; } }
        public string FormLocation { get { return fLocation; } set { fLocation = value; frmTxtBoxLocation.Text = value; } }

        public frmDescription()
        {
            InitializeComponent();
        }

        private void frmDescription_Load(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(FormDescription))
            {
                frmTxtBoxDescription.Text = "You did not put a description";
            }

            if (String.IsNullOrEmpty(FormLocation))
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
