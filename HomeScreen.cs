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

            String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT left outer join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID";
            DisplayDataInView(usedQuery, patientsDataView);
        }

        private void button_appoint_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_appoint.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Appointments";
            pages.SetPage("appointmentsPage");

            sqlConnection = new SqlConnection(cs);
            sqlConnection.Open();
            query = "select * from APPOINTMENT where APPOINTMENT_DATE=@date";
            sqlCommand = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter();
            dataTable = new DataTable();
            sqlCommand.Parameters.AddWithValue("@date", DateTime.Today);
            sqlCommand.ExecuteNonQuery();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            appointmentsTodayDataView.DataSource = dataTable;
            sqlConnection.Close();
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
            // TODO: This line of code loads data into the 'hospitaldatabaseDataSetAppointment.APPOINTMENT' table. You can move, or remove it, as needed.
            this.aPPOINTMENTTableAdapter.Fill(this.hospitaldatabaseDataSetAppointment.APPOINTMENT);
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

            String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID";
            DisplayDataInView(usedQuery, searchResultsDataGridView);

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
            String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID Where DOCTOR_NAME LIKE '%" + searchString + "%'";
            DisplayDataInView(usedQuery, doctorsDataView);
        }

        private void searchAdditionalTextBox_TextChange(object sender, EventArgs e)
        {
            if (searchIDRadioButton.Checked)
            {
                String searchString = searchAdditionalTextBox.Text;
                String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID Where DOCTOR_ID LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, searchResultsDataGridView);
            }
            else if (searchPhoneNumRadioButton.Checked)
            {
                String searchString = searchAdditionalTextBox.Text;
                String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID Where DOCTOR_PHONENUM LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, searchResultsDataGridView);
            }
            else if (searchDesignationRadioButton.Checked)
            {
                String searchString = searchAdditionalTextBox.Text;
                String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID Where DOCTOR_DESIGNATION LIKE '%" + searchString + "%'";
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
            String usedQuery = "select DOCTOR.DOCTOR_ID, DOCTOR.DOCTOR_NAME, DOCTOR.DOCTOR_DESIGNATION, DOCTOR.DOCTOR_PHONENUM, DOCTOR.DOCTOR_DEPARTMENT, DOCTOR.DOCTOR_GRADUATION, DEPARTMENT.DEPARTMENT_NAME from DOCTOR inner join DEPARTMENT on DOCTOR.DOCTOR_DEPARTMENT=DEPARTMENT.DEPARTMENT_ID Where DOCTOR_DEPARTMENT =" + searchDepartmentID;
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
                String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT inner join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID";
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
                String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT left outer join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID Where PATIENT_ID LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, patientSearchResultsDataView);
            }
            else if (searchPatientPhoneNumRadioButton.Checked)
            {
                String searchString = additionalSearchPatientTextBox.Text;
                String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT left outer join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID Where PATIENT_PHONENUM LIKE '%" + searchString + "%'";
                DisplayDataInView(usedQuery, patientSearchResultsDataView);
            }
            else if (searchPatientAddressRadioButton.Checked)
            {
                String searchString = additionalSearchPatientTextBox.Text;
                String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT left outer join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID Where PATIENT_ADDRESS LIKE '%" + searchString + "%'";
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

            String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT left outer join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID";
            DisplayDataInView(usedQuery, patientSearchResultsDataView);
        }

        private void filterBirthdateButton_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(cs);
            sqlConnection.Open();
            query = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT left outer join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID Where PATIENT_BIRTHDATE=@birthdate";
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
            String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT left outer join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID Where PATIENT_NAME LIKE '%" + searchString + "%'";
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

                String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT inner join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID";
                DisplayDataInView(usedQuery, patientsDataView);
            }
            else
            {
                MessageBox.Show("Please select patient record to delete.");
            }
        }

        private void newAppointmentButton_Click(object sender, EventArgs e)
        {
            appointmentsInnerPages.SetPage("createAppointmentPage");

           // appointmentTimePicker.CustomFormat = "HH:mm tt"; // Only use hours and minutes
           // appointmentTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //appointmentTimePicker.MinDate = DateTime.Now;
            appointmentDatePicker.MinDate = DateTime.Today;

            String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT inner join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID";
            DisplayDataInView(usedQuery, appointmentPatientSearchDataView);

            sqlConnection = new SqlConnection(cs);
            query = "select * from DEPARTMENT";
            sqlCommand = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter();
            dataTable = new DataTable();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            departmentListBox.DataSource = dataTable;
            departmentListBox.ValueMember = dataTable.Columns[0].ColumnName;
            departmentListBox.DisplayMember = dataTable.Columns[1].ColumnName;
        }

        private void appointmentPatientSearchTextBox_TextChange(object sender, EventArgs e)
        {
            String searchString = appointmentPatientSearchTextBox.Text;
            String usedQuery = "select PATIENT.PATIENT_ID, PATIENT.PATIENT_NAME, PATIENT.PATIENT_ADDRESS, PATIENT.PATIENT_BIRTHDATE, PATIENT.PATIENT_PHONENUM, GENDER.GENDER from PATIENT left outer join GENDER on PATIENT.PATIENT_GENDER=GENDER.GENDER_ID Where PATIENT_NAME LIKE '%" + searchString + "%'";
            DisplayDataInView(usedQuery, appointmentPatientSearchDataView);
        }

        private void checkDoctorsButton_Click(object sender, EventArgs e)
        {
            String searchDepartmentID = departmentListBox.SelectedValue.ToString();
            sqlConnection = new SqlConnection(cs);
            sqlConnection.Open();
            query = "select * from DOCTOR where DOCTOR.DOCTOR_DEPARTMENT="+searchDepartmentID;
            sqlCommand = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter();
            dataTable = new DataTable();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            availableDoctorsListBox.DataSource = dataTable;
            availableDoctorsListBox.ValueMember = dataTable.Columns[0].ColumnName;
            availableDoctorsListBox.DisplayMember = dataTable.Columns[1].ColumnName;
            sqlConnection.Close();
        }

        private void bookAppointmentButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = appointmentPatientSearchDataView.SelectedRows[0].Index;
            int patientID = int.Parse(appointmentPatientSearchDataView[0, selectedIndex].Value.ToString());

            if (selectedIndex!=0)
            {
                sqlConnection = new SqlConnection(cs);
                sqlConnection.Open();
                query = "SELECT * FROM APPOINTMENT WHERE APPOINTMENT_DATE=@date AND APPOINTMENT_TIME=@time AND APPOINTMENT_DOCTOR_ID=@doctor_id";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@date", appointmentDatePicker.Value.Date);
                sqlCommand.Parameters.AddWithValue("@time", appointmentTimePicker.Value.TimeOfDay);
                sqlCommand.Parameters.AddWithValue("@doctor_id", availableDoctorsListBox.SelectedValue);
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("This doctor already has an appointment at the selected timeslot. Please select another.");
                }
                else
                {
                    sqlConnection = new SqlConnection(cs);
                    sqlConnection.Open();
                    query = "SELECT MAX(APPOINTMENT_ID) FROM APPOINTMENT";
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    int appointmentID = (int)sqlCommand.ExecuteScalar();
                    appointmentID++;
                    query = "Insert INTO APPOINTMENT (APPOINTMENT_ID, APPOINTMENT_DATE, APPOINTMENT_TIME, APPOINTMENT_DOCTOR_ID, APPOINTMENT_PATIENT_ID) VALUES (@id, @date, @time, @doctor_id, @patient_id)";
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@id", appointmentID);
                    sqlCommand.Parameters.AddWithValue("@date", appointmentDatePicker.Value.Date);
                    sqlCommand.Parameters.AddWithValue("@time", appointmentTimePicker.Value.TimeOfDay);
                    sqlCommand.Parameters.AddWithValue("@doctor_id", availableDoctorsListBox.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@patient_id", patientID);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Appointment booked successfully!");

                    appointmentsInnerPages.SetPage("appointmentsMainPage");
                    sqlConnection = new SqlConnection(cs);
                    sqlConnection.Open();
                    query = "select APPOINTMENT.APPOINTMENT_TIME, DOCTOR.DOCTOR_NAME, PATIENT.PATIENT_NAME from APPOINTMENT inner join DOCTOR ON APPOINTMENT.APPOINTMENT_DOCTOR_ID=DOCTOR.DOCTOR_ID inner join PATIENT on APPOINTMENT.APPOINTMENT_PATIENT_ID=PATIENT.PATIENT_ID where APPOINTMENT_DATE=@date";
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    adapter = new SqlDataAdapter();
                    dataTable = new DataTable();
                    sqlCommand.Parameters.AddWithValue("@date", DateTime.Today);
                    sqlCommand.ExecuteNonQuery();
                    adapter.SelectCommand = sqlCommand;
                    adapter.Fill(dataTable);
                    appointmentsTodayDataView.DataSource = dataTable;
                    sqlConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill all required information.");
            }
        }
    }
}
