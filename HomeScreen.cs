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
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button1.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Doctors";
            //bunifuPages1.SetPage("tabDrs");
        }

        private void button_patients_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_patients.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Patients";
            //bunifuPages1.SetPage("tabPtnts");
        }

        private void button_appoint_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_appoint.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Appointments";
            //bunifuPages1.SetPage("tabAppoint");
        }

        private void button_diagnose_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_diagnose.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Diagnoses";
            //bunifuPages1.SetPage("tabDiag");
        }

        private void button_prescription_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_prescription.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Prescriptions";
            //bunifuPages1.SetPage("tabPres");
        }

        private void button_medications_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_medications.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Medications";
           // bunifuPages1.SetPage("tabMedic");
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox_menu_Click(object sender, EventArgs e)
        {
            // Makes the menu smaller
            if (panel2.Width == 75)
            {
                panel2.Width = 265;
                panel3.Location = new Point(260, -17);
                panel3.Size = new Size(1040, 71);

                Image img = pictureBox_menu.Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox_menu.Image = img;

                bunifuPages1.Location = new Point(280, 76);
                bunifuPages1.Size = new Size(725, 527);
            }
            else
            {
                panel2.Width = 75;
                panel3.Location = new Point(65, -17);
                panel3.Size = new Size(1040, 71);

                Image img = pictureBox_menu.Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox_menu.Image = img;

                bunifuPages1.Location = new Point(90, 76);
                bunifuPages1.Size = new Size(915, 527);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sectionLabel.Text = "Home";
        }

        private void resetButtonColor()
        {
            button1.BackColor = Color.FromArgb(26, 32, 40);
            button_appoint.BackColor = Color.FromArgb(26, 32, 40);
            button_diagnose.BackColor = Color.FromArgb(26, 32, 40);
            button_medications.BackColor = Color.FromArgb(26, 32, 40);
            button_patients.BackColor = Color.FromArgb(26, 32, 40);
            button_prescription.BackColor = Color.FromArgb(26, 32, 40);
        }
    }
}
