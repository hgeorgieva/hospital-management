using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;

namespace hospitalmanagement
{
    public partial class HomeScreen : Form
    {
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\UNI\proekt-bd\hospitalmanagement\hospitaldatabase.mdf;Integrated Security=True";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        string query;
        DataTable dataTable;
        SqlDataAdapter adapter;
        int ID = 0;

        public HomeScreen()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button1.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Doctors";
            pages.SetPage("doctorsPage");
            doctorsInnerPages.SetPage("doctorsMainPage");

            String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID";
            DisplayDataInView(usedQuery, doctorsDataView);
        }

        private void button_patients_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_patients.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Patients";
            pages.SetPage("patientsPage");

            String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, PATIENT.PATIENT_GENDER, GENDER.GENDER from PATIENT inner join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID";
            DisplayDataInView(usedQuery, patientsDataView);
        }

        private void button_appoint_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_appoint.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Appointments";
            pages.SetPage("appointmentsPage");
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

                pages.Location = new Point(280, 76);
                pages.Size = new Size(725, 527);
            }
            else
            {
                panel2.Width = 75;
                panel3.Location = new Point(65, -17);
                panel3.Size = new Size(1040, 71);

                Image img = pictureBox_menu.Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox_menu.Image = img;

                pages.Location = new Point(90, 76);
                pages.Size = new Size(915, 527);
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

        private void addNewDoctorButton_Click(object sender, EventArgs e)
        {
            pages.SetPage("addNewDoctorPage");
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitaldatabaseDataSetPatient.PATIENT' table. You can move, or remove it, as needed.
            this.pATIENTTableAdapter.Fill(this.hospitaldatabaseDataSetPatient.PATIENT);

            // TODO: This line of code loads data into the 'hospitaldatabaseDataSet.DOCTOR' table. You can move, or remove it, as needed.
            this.dOCTORTableAdapter.Fill(this.hospitaldatabaseDataSet.DOCTOR);

        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void searchForPatientButton_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            doctorsInnerPages.SetPage("addNewDoctorPage");

            doctorNameTextBox.Text = "";
            doctorDesignationTextBox.Text = "";
            doctorGraduationTextBox.Text = "";
            doctorPhoneNumTextBox.Text = "";

            sqlConnection = new SqlConnection(cs);
            query = "select * from DEPARTMENT";
            sqlCommand = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter();
            dataTable = new DataTable();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            departmentDropdown.DataSource = dataTable;
            departmentDropdown.ValueMember = dataTable.Columns[0].ColumnName;
            departmentDropdown.DisplayMember = dataTable.Columns[1].ColumnName;

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            String doctorName = searchTextBox.Text;
            if (searchTextBox.Text != "")
            {
                String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID";
                DisplayDataInView(usedQuery, doctorsDataView);
            }
            else
            {
                MessageBox.Show("Please enter doctor name");
            }
        }

        private void addNewDoctorPage_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            if(doctorNameTextBox.Text!="" && doctorDesignationTextBox.Text!="" && doctorPhoneNumTextBox.Text != "" && departmentDropdown.Text!="" && doctorGraduationTextBox.Text!=""){
                sqlConnection = new SqlConnection(cs);
                sqlConnection.Open();
                query = "SELECT MAX(DOCTOR_ID) FROM DOCTOR";
                sqlCommand = new SqlCommand(query, sqlConnection);
                int doctorID = (int)sqlCommand.ExecuteScalar();
                doctorID++;
                query = "Insert INTO DOCTOR (DOCTOR_ID, DOCTOR_NAME, DOCTOR_DESIGNATION, DOCTOR_PHONENUM, DOCTOR_DEPARTMENT, DOCTOR_GRADUATION) VALUES (@id, @name, @designation, @phonenum, @department, @graduation)";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", doctorID);
                sqlCommand.Parameters.AddWithValue("@name", doctorNameTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@designation", doctorDesignationTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@phonenum", doctorPhoneNumTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@department", departmentDropdown.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@graduation", doctorGraduationTextBox.Text);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Inserted successfully!");

                doctorsInnerPages.SetPage("doctorsMainPage");
                String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID";
                DisplayDataInView(usedQuery, doctorsDataView);
            }
        }

        private void DisplayDataInView(String query, BunifuDataGridView dataView)
        {
            sqlConnection = new SqlConnection(cs);
            sqlCommand = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter();
            dataTable = new DataTable();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            dataView.DataSource = dataTable;
        }

        private void deleteDoctorButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = doctorsDataView.SelectedRows[0].Index;
            int rowID = int.Parse(doctorsDataView[0, selectedIndex].Value.ToString());

            if (selectedIndex != 0)
            {
                sqlConnection = new SqlConnection(cs);
                sqlConnection.Open();
                query = "Delete DOCTOR Where DOCTOR_ID=@id";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", rowID);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Doctor record deleted successfully!");
                
                String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID";
                DisplayDataInView(usedQuery, doctorsDataView);
            }
            else
            {
                MessageBox.Show("Please select doctor record to delete.");
            }
        }

        private void additionalSearchButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            doctorsInnerPages.SetPage("additionalSearchPage");

            sqlConnection = new SqlConnection(cs);
            query = "select * from DEPARTMENT";
            sqlCommand = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter();
            dataTable = new DataTable();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            filterDepartmentDropdown.DataSource = dataTable;
            filterDepartmentDropdown.ValueMember = dataTable.Columns[0].ColumnName;
            filterDepartmentDropdown.DisplayMember = dataTable.Columns[1].ColumnName;
        }

        private void searchTextBox_TextChange(object sender, EventArgs e)
        {
            String searchString = searchTextBox.Text;
            String usedQuery = "Select * from DOCTOR Where DOCTOR_NAME LIKE '%" + searchString + "%'";
            DisplayDataInView(usedQuery, doctorsDataView);
        }

        private void searchAdditionalTextBox_TextChange(object sender, EventArgs e)
        {
            if (searchIDRadioButton.Checked)
            {
                String searchString = searchAdditionalTextBox.Text;
                String usedQuery = "Select * from DOCTOR Where DOCTOR_ID LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, searchResultsDataGridView);
            }
            else if (searchPhoneNumRadioButton.Checked)
            {
                String searchString = searchAdditionalTextBox.Text;
                String usedQuery = "Select * from DOCTOR Where DOCTOR_PHONENUM LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, searchResultsDataGridView);
            }
            else if (searchDesignationRadioButton.Checked)
            {
                String searchString = searchAdditionalTextBox.Text;
                String usedQuery = "Select * from DOCTOR Where DOCTOR_DESIGNATION LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, searchResultsDataGridView);
            }
            else
            {
                MessageBox.Show("Please select search criteria.");
            }
        }

        private void filterDepartmentDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String searchDepartmentID = filterDepartmentDropdown.SelectedValue.ToString();
            String usedQuery = "Select * from DOCTOR Where DOCTOR_DEPARTMENT =" + searchDepartmentID;
            DisplayDataInView(usedQuery, searchResultsDataGridView);

        }

        private void submitPatientButton_Click(object sender, EventArgs e)
        {
            if (patientNameTextBox.Text != "" && patientAddressTextBox.Text != "" && patientPhoneNumberTextBox.Text!="")
            {
                sqlConnection = new SqlConnection(cs);
                sqlConnection.Open();
                query = "SELECT MAX(PATIENT_ID) FROM PATIENT";
                sqlCommand = new SqlCommand(query, sqlConnection);
                int patientID = (int)sqlCommand.ExecuteScalar();
                patientID++;
                query = "Insert INTO PATIENT (PATIENT_ID, PATIENT_NAME, PATIENT_ADDRESS, PATIENT_BIRTHDATE, PATIENT_PHONENUM, PATIENT_GENDER) VALUES (@id, @name, @address, @birthdate, @phonenum, @gender)";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", patientID);
                sqlCommand.Parameters.AddWithValue("@name", patientNameTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@address", patientAddressTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@birthdate", birthDatePicker.Value.Date);
                sqlCommand.Parameters.AddWithValue("@phonenum", patientPhoneNumberTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@gender", patientGenderDropdown.SelectedValue);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Patient submitted successfully!");

                patientsInnerPages.SetPage("patientsMainPage");
                String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, PATIENT.PATIENT_GENDER, GENDER.GENDER from PATIENT inner join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID";
                DisplayDataInView(usedQuery, patientsDataView);
            }
        }

        private void addNewPatientButton_Click(object sender, EventArgs e)
        {
            patientsInnerPages.SetPage("addNewPatientPage");

            patientNameTextBox.Text = "";
            patientPhoneNumberTextBox.Text = "";
            patientAddressTextBox.Text = "";

            sqlConnection = new SqlConnection(cs);
            query = "select * from GENDER";
            sqlCommand = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter();
            dataTable = new DataTable();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            patientGenderDropdown.DataSource = dataTable;
            patientGenderDropdown.ValueMember = dataTable.Columns[0].ColumnName;
            patientGenderDropdown.DisplayMember = dataTable.Columns[1].ColumnName;
        }

        private void additionalSearchPatientTextBox_TextChange(object sender, EventArgs e)
        {
            if (searchPatientIDRadioButton.Checked)
            {
                String searchString = additionalSearchPatientTextBox.Text;
                String usedQuery = "Select * from PATIENT Where PATIENT_ID LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, patientSearchResultsDataView);
            }
            else if (searchPatientPhoneNumRadioButton.Checked)
            {
                String searchString = additionalSearchPatientTextBox.Text;
                String usedQuery = "Select * from PATIENT Where PATIENT_PHONENUM LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, patientSearchResultsDataView);
            }
            else if (searchPatientAddressRadioButton.Checked)
            {
                String searchString = additionalSearchPatientTextBox.Text;
                String usedQuery = "Select * from PATIENT Where PATIENT_ADDRESS LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, patientSearchResultsDataView);
            }
            else
            {
                MessageBox.Show("Please select search criteria.");
            }
        }

        private void searchAdditionalPatientButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            patientsInnerPages.SetPage("additionalSearchPatientPage");
        }

        private void filterBirthdateButton_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(cs);
            sqlConnection.Open();
            query = "Select * from PATIENT Where PATIENT_BIRTHDATE=@birthdate";
            sqlCommand = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter();
            dataTable = new DataTable();
            sqlCommand.Parameters.AddWithValue("@birthdate", filterByBirthdatePicker.Value.Date);
            sqlCommand.ExecuteNonQuery();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            patientSearchResultsDataView.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void searchPatientTextBox_TextChange(object sender, EventArgs e)
        {
            String searchString = searchPatientTextBox.Text;
            String usedQuery = "Select * from PATIENT Where PATIENT_NAME LIKE '%" + searchString + "%'";
            DisplayDataInView(usedQuery, patientsDataView);
        }

        private void deletePatientButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = patientsDataView.SelectedRows[0].Index;
            int rowID = int.Parse(patientsDataView[0, selectedIndex].Value.ToString());

            if (selectedIndex != 0)
            {
                sqlConnection = new SqlConnection(cs);
                sqlConnection.Open();
                query = "Delete PATIENT Where PATIENT_ID=@id";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", rowID);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Patient record deleted successfully!");

                String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, PATIENT.PATIENT_GENDER, GENDER.GENDER from PATIENT inner join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID";
                DisplayDataInView(usedQuery, patientsDataView);
            }
            else
            {
                MessageBox.Show("Please select patient record to delete.");
            }
        }
    }
}
