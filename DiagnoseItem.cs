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


        public string Med1_drop
        {
            get
            {
                return med1_drop.Text;
            }

            set
            {
                med1_drop.Text = value;
            }
        }

        public string Med1_mg
        {
            get
            {
                return med1_mg.Text;
            }
            set
            {
                med1_mg.Text = value;
            }
        }

        public string Med2_drop
        {
            get
            {
                return med2_drop.Text;
            }
            set
            {
                med2_drop.Text = value;
            }
        }

        public string Med2_mg
        {
            get
            {
                return med2_mg.Text;
            }
            set
            {
                med2_mg.Text = value;
            }
        }

        public string Med3_drop
        {
            get
            {
                return med3_drop.Text;
            }
            set
            {
                med3_drop.Text = value;
            }
        }

        public string Med3_mg
        {
            get
            {
                return med3_mg.Text;
            }
            set
            {
                med3_mg.Text = value;
            }
        }

        public string Med4_drop
        {
            get
            {
                return med4_drop.Text;
            }
            set
            {
                med4_drop.Text = value;
            }
        }

        public string Med4_mg
        {
            get
            {
                return med4_mg.Text;
            }
            set
            {
                med4_mg.Text = value;
            }
        }

        public string Med5_drop
        {
            get
            {
                return med5_drop.Text;
            }
            set
            {
                med5_drop.Text = value;
            }
        }

        public string Med5_mg
        {
            get
            {
                return med5_mg.Text;
            }
            set
            {
                med5_mg.Text = value;
            }
        }

        public string Med6_drop
        {
            get
            {
                return med6_drop.Text;
            }
            set
            {
                med6_drop.Text = value;
            }
        }

        public string Med6_mg
        {
            get
            {
                return med6_mg.Text;
            }
            set
            {
                med6_mg.Text = value;
            }
        }

        public string Med7_drop
        {
            get
            {
                return med7_drop.Text;
            }
            set
            {
                med7_drop.Text = value;
            }
        }

        public string Med7_mg
        {
            get
            {
                return med7_mg.Text;
            }
            set
            {
                med7_mg.Text = value;
            }
        }

        public string Med8_drop
        {
            get
            {
                return med8_drop.Text;
            }
            set
            {
                med8_drop.Text = value;
            }
        }

        public string Med8_mg
        {
            get
            {
                return med8_mg.Text;
            }
            set
            {
                med8_mg.Text = value;
            }
        }

        public string Med9_drop
        {
            get
            {
                return med9_drop.Text;
            }
            set
            {
                med9_drop.Text = value;
            }
        }

        public string Med9_mg
        {
            get
            {
                return med9_mg.Text;
            }
            set
            {
                med9_mg.Text = value;
            }
        }

        public string Med10_drop
        {
            get
            {
                return med10_drop.Text;
            }
            set
            {
                med10_drop.Text = value;
            }
        }

        public string Med10_mg
        {
            get
            {
                return med10_mg.Text;
            }
            set
            {
                med10_mg.Text = value;
            }
        }

    }
}
