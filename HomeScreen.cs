﻿using System;
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
using System.IO;
using hospitalmanagement.BLL;
using Bunifu.UI.WinForms;

namespace hospitalmanagement
{
    public partial class HomeScreen : Form
    {
        //string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\UNI\proekt-bd\hospitalmanagement\hospitaldatabase.mdf;Integrated Security=True";
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\skaya\Desktop\new_hospital\hospitaldatabase.mdf;Integrated Security=True";

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
            pages.SetPage("diagnosesPage");
            diagnoseINNERpages.SetPage("diagnosesMainPage");
            GenerateDynamicUserControl();
        }

        private void button_prescription_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_prescription.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Prescriptions";
            pages.SetPage("prescriptionsPage");
            presINNERpages.SetPage("presMainPage");
        }

        private void button_medications_Click(object sender, EventArgs e)
        {
            resetButtonColor();
            button_medications.BackColor = Color.FromArgb(81, 107, 130);
            sectionLabel.Text = "Medications";
            pages.SetPage("medicationsPage");
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox_menu_Click(object sender, EventArgs e)
        {
            // Makes the menu smaller

            if (panel2.Width == 95) // small -> big
            {
                panel2.Width = 345;
                panel3.Location = new Point(344, -5);
                panel3.Size = new Size(1040, 71);

                Image img = pictureBox_menu.Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox_menu.Image = img;

                pages.Location = new Point(368, 93);
                pages.Size = new Size(975, 648);
            }
            else  // big -> small
            {
                panel2.Width = 95;
                panel3.Location = new Point(94, -5);
                panel3.Size = new Size(1270, 71);

                Image img = pictureBox_menu.Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox_menu.Image = img;

                pages.Location = new Point(118, 93);
                pages.Size = new Size(1225, 648);
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

            GenerateDynamicUserControl();
            GeneratePRESCRIPTIONUserControl();
     
        }

        #region Diagnoses Section

        private void GenerateDynamicUserControl()
        {
            flowLayoutPanel1.Controls.Clear();

            ClassBLL objbll = new ClassBLL();
            DataTable dt = objbll.GetItems();
            showDiagnoseControl(objbll, dt);
        }

        private void diagnoseSearchTextBox_KeyPress(object sender, KeyPressEventArgs e) { }

        private void searchTextBoxResult()
        {
            string s_search = diagnoseSearchTextBox.Text;

            flowLayoutPanel1.Controls.Clear();
            ClassBLL objbll = new ClassBLL();
            DataTable dt = objbll.GetSearchItems("DIAGNOSE", s_search);
            showDiagnoseControl(objbll, dt);
        }
        private void diagnoseSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchTextBoxResult();
            }
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            searchTextBoxResult();
        }
        private void showDiagnoseControl(ClassBLL objbll, DataTable dt) 
        {

            if (dt != null)
            {
                DiagnoseItem[] listItems = new DiagnoseItem[dt.Rows.Count];
                for (int i = 0; i < 1; i++)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        listItems[i] = new DiagnoseItem();

                        // Foreign key visualizaion (boring/long version, but it works? nah?)
                        string patient_id = row["DIAGNOSE_PATIENT"].ToString();
                        int id = Convert.ToInt32(patient_id);
                        DataTable dtt = objbll.GetFKItems("PATIENT", id);
                        DataRow rr = dtt.Rows[0];
                        listItems[i].PatientID = rr["PATIENT_NAME"].ToString() + " (" + row["DIAGNOSE_PATIENT"].ToString() + ")";
                        
                        listItems[i].ICDcode = row["DIAGNOSE_ICD"].ToString();
                    
                        string doctor_id = row["DIAGNOSE_DOCTOR"].ToString();
                        int dr_id = Convert.ToInt32(doctor_id);
                        DataTable dr_Dt = objbll.GetFKItems("DOCTOR", dr_id);
                        DataRow dr_rr = dr_Dt.Rows[0];
                        listItems[i].DoctorID = dr_rr["DOCTOR_NAME"].ToString() + " (" + row["DIAGNOSE_DOCTOR"].ToString() + ")";

                        listItems[i].DiagID = row["DIAGNOSE_ID"].ToString();
                        listItems[i].Prescription = row["DIAGNOSE_PRESCRIPTION"].ToString();
                        listItems[i].Test_Results = row["DIAGNOSE_TEST_RESULTS"].ToString();
                        listItems[i].Condition = row["DIAGNOSE_CONDITION"].ToString();

                        flowLayoutPanel1.Controls.Add(listItems[i]);

                        listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                    }
                    
                }
               
            }
        }

        private void UserControl_Click(object sender, EventArgs e)
        {
            DiagnoseItem obj = (DiagnoseItem)sender;

            diag_details_patient.Text = ""; diag_details_doctor.Text = ""; diag_details_icd.Text = ""; diag_details_id.Text = ""; diag_details_pres.Text = ""; diag_details_test.Text = ""; diag_details_condition.Text = "";


            diag_details_patient.Text = obj.PatientID;
            diag_details_doctor.Text = obj.DoctorID;
            diag_details_icd.Text = obj.ICDcode;
            diag_details_id.Text = obj.DiagID;
            diag_details_pres.Text = obj.Prescription;
            diag_details_test.Text = obj.Test_Results;
            diag_details_condition.Text = obj.Condition;

            diagnoseINNERpages.SetPage("diagnoseDetailsPage");


        }
        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            string id = diag_details_id.Text;

            sqlConnection = new SqlConnection(cs);
            sqlConnection.Open();
            query = "DELETE DIAGNOSE WHERE DIAGNOSE_ID=@id";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            GenerateDynamicUserControl();
            diagnoseINNERpages.SetPage("diagnosesMainPage");
        }

        private void addDiagnoseButton_Click(object sender, EventArgs e)
        {
            diagnoseINNERpages.SetPage("addDiagnosePage");

            Random generator = new Random();
            int number = generator.Next(0, 1000000000);

            diagnose_ID_textbox.Text = number.ToString();
            diagnose_icd_code_textbox.Text = "";
            diagnose_testR_richtextbox.Text = "";
            diagnose_condittion_richtextbox.Text = "";

            sqlConnection = new SqlConnection(cs);
            query = "SELECT * FROM DOCTOR";
            fillDropdown(query, sqlConnection, diagnose_doctor_dropdown);

            sqlConnection = new SqlConnection(cs);
            query = "SELECT * FROM PATIENT";
            fillDropdown(query, sqlConnection, diagnose_patient_dropdown);

          
            sqlConnection = new SqlConnection(cs);
            query = "SELECT * FROM PRESCRIPTION";
            fillDropdown(query, sqlConnection, diagnose_prescription_dropdown);
        }

        private void fillDropdown(string query, SqlConnection sqlConnection, Bunifu.UI.WinForms.BunifuDropdown bunifudropdown)
        {
            sqlCommand = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter();
            dataTable = new DataTable();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            bunifudropdown.DataSource = dataTable;
            bunifudropdown.ValueMember = dataTable.Columns[0].ColumnName;
            bunifudropdown.DisplayMember = dataTable.Columns[1].ColumnName;
        }

        private void diagnose_add_button_Click(object sender, EventArgs e)
        { 
            if (diagnose_icd_code_textbox.Text != "" && diagnose_patient_dropdown.Text != "" && diagnose_doctor_dropdown.Text != "" && diagnose_prescription_dropdown.Text != "" && diagnose_testR_richtextbox.Text != "" && diagnose_condittion_richtextbox.Text != "") 
            {
                ClassBLL objbll = new ClassBLL();
                string diagnose_id = diagnose_ID_textbox.Text;
                int id = Convert.ToInt32(diagnose_id);

                string patient = diagnose_patient_dropdown.SelectedValue.ToString();
                int patient_id = Convert.ToInt32(patient);

                string doctor = diagnose_doctor_dropdown.SelectedValue.ToString();
                int doctor_id = Convert.ToInt32(doctor);

                string prescription = diagnose_prescription_dropdown.SelectedValue.ToString();
                int pres_id = Convert.ToInt32(prescription);

                bool dt = objbll.SaveDIAGNOSEItems(
                    id,
                    patient_id,
                    diagnose_icd_code_textbox.Text,
                    doctor_id,
                    pres_id, // CHANGE IT TO PRESCRIPTION
                    diagnose_testR_richtextbox.Text,
                    diagnose_condittion_richtextbox.Text
                    );

                if (dt != false)
                {
                    MessageBox.Show("Added successfully!");
                }
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            GenerateDynamicUserControl();
            diagnoseINNERpages.SetPage("diagnosesMainPage");
        }

        #endregion






        #region PRESCRIPTION SECTION

        public void GeneratePRESCRIPTIONUserControl()
        {
            pres_flowLayoutPanel2.Controls.Clear();

            ClassBLL objbll = new ClassBLL();
            DataTable dt = objbll.GetTABLEItems(" PRESCRIPTION");
            showPrescriptionControl(objbll, dt);
        }

        private void showPrescriptionControl(ClassBLL objbll, DataTable dt)
        {

            if (dt != null)
            {
                DiagnoseItem[] listItems = new DiagnoseItem[dt.Rows.Count];
                for (int i = 0; i < 1; i++)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        listItems[i] = new DiagnoseItem();

                        listItems[i].Patient_label = "Patient ID:";
                        listItems[i].Medication_id_label = "Med ID:";
                        listItems[i].Doctor_id_label = "Doctor ID:";
                        listItems[i].Prescription_id_label = "Prescription ID:";


                        /*
                        // Foreign key visualizaion (boring/long version, but it works? nah?)
                        string patient_id = row["DIAGNOSE_PATIENT"].ToString();
                        int id = Convert.ToInt32(patient_id);
                        DataTable dtt = objbll.GetFKItems("PATIENT", id);
                        DataRow rr = dtt.Rows[0];
                        listItems[i].PatientID = rr["PATIENT_NAME"].ToString() + " (" + row["DIAGNOSE_PATIENT"].ToString() + ")";
*/
                        listItems[i].ICDcode = row["PRESCRIPTION_MEDICATION"].ToString();
                        /*
                        string doctor_id = row["DIAGNOSE_DOCTOR"].ToString();
                        int dr_id = Convert.ToInt32(doctor_id);
                        DataTable dr_Dt = objbll.GetFKItems("DOCTOR", dr_id);
                        DataRow dr_rr = dr_Dt.Rows[0];
                        listItems[i].DoctorID = dr_rr["DOCTOR_NAME"].ToString() + " (" + row["DIAGNOSE_DOCTOR"].ToString() + ")";
*/
                        listItems[i].PatientID = row["PRESCRIPTION_PATIENT"].ToString();
                        listItems[i].DoctorID = row["PRESCRIPTION_DOCTOR"].ToString();
                        listItems[i].DiagID = row["PRESCRIPTION_ID"].ToString();
                        //listItems[i].Condition = row["DIAGNOSE_CONDITION"].ToString();

                        pres_flowLayoutPanel2.Controls.Add(listItems[i]);

//                        listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                    }

                }

            }
        }

        
        private void pres_add_button_Click(object sender, EventArgs e)
        {
            presINNERpages.SetPage("presAddPage");

            Random generator = new Random();
            int number = generator.Next(0, 1000000000);

            presID_textBox.Text = number.ToString();
            pres_note_richtextBox.Text = "";

            sqlConnection = new SqlConnection(cs);
            query = "SELECT * FROM DOCTOR";
            fillDropdown(query, sqlConnection, pres_doctor_dropdown);

            sqlConnection = new SqlConnection(cs);
            query = "SELECT * FROM PATIENT";
            fillDropdown(query, sqlConnection, pres_patient_dropdown);

            Bunifu.UI.WinForms.BunifuDropdown[] drop = { med1_drop, med2_drop, med3_drop, med4_drop, med5_drop, med6_drop, med7_drop, med8_drop, med9_drop, med10_drop };
            for (int i = 0; i < 10; i++)
            {
                sqlConnection = new SqlConnection(cs);
                query = "SELECT * FROM MEDICATION";
                fillDropdown(query, sqlConnection, drop[i]);
            }
        }

        private void pres_search_button_Click(object sender, EventArgs e)
        {

        }
       
        private void pres_search_textBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
       
        private void loopForVisibility(int start_true, int end_true, int start_false, int end_false, BunifuLabel[] label, Bunifu.UI.WinForms.BunifuDropdown[] drop, BunifuTextBox[] edit)
        {
            for (int i = start_false; i < end_false; i++)
            {
                label[i].Visible = false;
                drop[i].Visible = false;
                edit[i].Visible = false;
            }

            for (int i = start_true; i < end_true; i++)
            {
                label[i].Visible = true;
                drop[i].Visible = true;
                edit[i].Visible = true;
            }
        }
        private void pres_quantity_dropbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            BunifuLabel[] label = { med1_label, med2_label, med3_label , med4_label , med5_label , med6_label , med7_label , med8_label , med9_label, med10_label };
            Bunifu.UI.WinForms.BunifuDropdown[] drop = { med1_drop, med2_drop, med3_drop, med4_drop, med5_drop, med6_drop, med7_drop, med8_drop, med9_drop, med10_drop };
            BunifuTextBox[] edit = { med1_mg, med2_mg, med3_mg, med4_mg, med5_mg, med6_mg, med7_mg, med8_mg, med9_mg, med10_mg };
         
            string selected = (string)pres_quantity_dropbox.SelectedItem;
            switch (selected)
            {
                case "1":
                    loopForVisibility(0, 1, 1, 10, label, drop, edit);
                    break;
                case "2":
                    loopForVisibility(0, 2, 2, 10, label, drop, edit);
                    break;
                case "3":
                    loopForVisibility(0, 3, 3, 10, label, drop, edit);
                    break;
                case "4":
                    loopForVisibility(0, 4, 4, 10, label, drop, edit);
                    break;
                case "5":
                    loopForVisibility(0, 5, 5, 10, label, drop, edit);
                    break;
                case "6":
                    loopForVisibility(0, 6, 6, 10, label, drop, edit);
                    break;
                case "7":
                    loopForVisibility(0, 7, 7, 10, label, drop, edit);
                    break;
                case "8":
                    loopForVisibility(0, 8, 8, 10, label, drop, edit);
                    break;
                case "9":
                    loopForVisibility(0, 9, 9, 10, label, drop, edit);
                    break;
                case "10":
                    loopForVisibility(0, 10, 10, 10, label, drop, edit);
                    break;
            }
        }
        private void pres_add_pres_button_Click(object sender, EventArgs e)
        {
            try
            {
                Bunifu.UI.WinForms.BunifuDropdown[] drop = { med1_drop, med2_drop, med3_drop, med4_drop, med5_drop, med6_drop, med7_drop, med8_drop, med9_drop, med10_drop };
                BunifuTextBox[] edit = { med1_mg, med2_mg, med3_mg, med4_mg, med5_mg, med6_mg, med7_mg, med8_mg, med9_mg, med10_mg };


                string selected = (string)pres_quantity_dropbox.SelectedValue;
                int quantity = Convert.ToInt32(selected);

                for (int i = 0; i < 2; i++)
                {
                    if (pres_note_richtextBox.Text != "")
                    {
                        ClassBLL objbll = new ClassBLL();

                        sqlConnection = new SqlConnection(cs);
                        sqlConnection.Open();
                        query = "SELECT MAX(ID_PRES) FROM PRESCRIPTION";
                        sqlCommand = new SqlCommand(query, sqlConnection);
                        int ID = (int)sqlCommand.ExecuteScalar();
                        ID++;

                        string pres_id = presID_textBox.Text;
                        int id = Convert.ToInt32(pres_id);

                        string patient = pres_patient_dropdown.SelectedValue.ToString();
                        int patient_id = Convert.ToInt32(patient);

                        string doctor = pres_doctor_dropdown.SelectedValue.ToString();
                        int doctor_id = Convert.ToInt32(doctor);

                        string medication = drop[i].SelectedValue.ToString();
                        int med_id = Convert.ToInt32(medication);

                        bool dt = objbll.SavePRESCRIPTIONItems(
                            ID,
                            id,
                            patient_id,
                            doctor_id,
                            med_id,
                            edit[i].Text,
                            pres_note_richtextBox.Text
                            );

                        if (dt != false)
                        {
                            MessageBox.Show("Added successfully!");
                        }
                        else MessageBox.Show("OOPS!");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            
          

           
        }
        #endregion









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

        private void diagnoseSearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        
    }
}
