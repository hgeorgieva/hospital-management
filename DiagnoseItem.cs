using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospitalmanagement
{
    public partial class DiagnoseItem : Bunifu.UI.WinForms.BunifuUserControl
    {
        
        public DiagnoseItem()
        {
            InitializeComponent();
        }

        public string PatientID
        {
            get
            {
                return patient_id_label.Text;
            }
            set
            {
                patient_id_label.Text = value;
            }
        }

        public string ICDcode
        {
            get
            {
                return icd_code_label.Text;
            }
            set
            {
                icd_code_label.Text = value;
            }
        }

        public string DoctorID
        {
            get
            {
                return doctor_id_label.Text;
            }
            set
            {
                doctor_id_label.Text = value;
            }
        }

  
        public string DiagID
        {
            get
            {
                return diagnose_id.Text;
            }
            set
            {
                diagnose_id.Text = value;
            }
        }

        public string Prescription
        {
            get
            {
                return prescription.Text;
            }
            set
            {
                prescription.Text = value;
            }
        }

        public string Test_Results
        {
            get
            {
                return test_results.Text;
            }
            set
            {
                test_results.Text = value;
            }
        }

        public string Condition
        {
            get
            {
                return condition.Text;
            }
            set
            {
                condition.Text = value;
            }
        }

        private void diagnose_id_Click(object sender, EventArgs e)
        {

        }

        private void DiagnoseItem_Click(object sender, EventArgs e)
        {

        }

        public string Patient_label
        {
            get
            {
                return bunifuLabel1.Text;
            }
            set
            {
                bunifuLabel1.Text = value;
            }
        }
        public string Medication_id_label
        {
            get
            {
                return bunifuLabel3.Text;
            }
            set
            {
                bunifuLabel3.Text = value;
            }
        }
        public string Doctor_id_label
        {
            get
            {
                return bunifuLabel5.Text;
            }
            set
            {
                bunifuLabel5.Text = value;
            }
        }
        public string Prescription_id_label
        {
            get
            {
                return bunifuLabel2.Text;
            }
            set
            {
                bunifuLabel2.Text = value;
            }
        }
    }
}
