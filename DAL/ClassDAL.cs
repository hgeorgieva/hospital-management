using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace hospitalmanagement.DAL
{
    class ClassDAL
    {

        public bool AddDIAGNOSEItemsToTable(int diagnose_id, int patient_id, string icd_code, int doctor_id, int prescription_id, string test_results, string condition)
        {
            Connection con = new Connection();
            if (ConnectionState.Closed == con.connect.State)
            {
                con.connect.Open();
            }

            string query = "Insert into DIAGNOSE(DIAGNOSE_ID,DIAGNOSE_PATIENT,DIAGNOSE_ICD,DIAGNOSE_DOCTOR,DIAGNOSE_PRESCRIPTION,DIAGNOSE_TEST_RESULTS,DIAGNOSE_CONDITION)values(@DIAGNOSE_ID,@DIAGNOSE_PATIENT,@DIAGNOSE_ICD,@DIAGNOSE_DOCTOR,@DIAGNOSE_PRESCRIPTION,@DIAGNOSE_TEST_RESULTS,@DIAGNOSE_CONDITION)";
            
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con.connect))
                {
                    cmd.Parameters.AddWithValue("@DIAGNOSE_ID", diagnose_id);
                    cmd.Parameters.AddWithValue("@DIAGNOSE_PATIENT", patient_id);
                    cmd.Parameters.AddWithValue("@DIAGNOSE_ICD", icd_code.Trim());
                    cmd.Parameters.AddWithValue("@DIAGNOSE_DOCTOR", doctor_id);
                    cmd.Parameters.AddWithValue("@DIAGNOSE_PRESCRIPTION", prescription_id);
                    cmd.Parameters.AddWithValue("@DIAGNOSE_TEST_RESULTS", test_results.Trim());
                    cmd.Parameters.AddWithValue("@DIAGNOSE_CONDITION", condition.Trim());

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool addMEDICATIONItemsToTable(int id, string med_name, string producer, string leaflet)
        {
            Connection con = new Connection();
            if (ConnectionState.Closed == con.connect.State)
            {
                con.connect.Open();
            }
           // string query = "Insert into PRESCRIPTION(ID_PRES,PRESCRIPTION_ID,PRESCRIPTION_PATIENT,PRESCRIPTION_DOCTOR,PRESCRIPTION_MEDICATION,PRESCRIPTION_FORMULA,PRESCRIPTION_NOTE)values(@ID_PRES,@PRESCRIPTION_ID,@PRESCRIPTION_PATIENT,@PRESCRIPTION_DOCTOR,@PRESCRIPTION_MEDICATION,@PRESCRIPTION_FORMULA,@PRESCRIPTION_NOTE)";

            string query = "Insert into MEDICATION(MEDICATION_ID,MEDICATION_NAME,MEDICATION_PRODUCER,MEDICATION_INFO_LEAFLET)values(@MEDICATION_ID,@MEDICATION_NAME,@MEDICATION_PRODUCER,@MEDICATION_INFO_LEAFLET)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con.connect))
                {
                    cmd.Parameters.AddWithValue("@MEDICATION_ID", id);
                    cmd.Parameters.AddWithValue("@MEDICATION_NAME", med_name.Trim());
                    cmd.Parameters.AddWithValue("@MEDICATION_PRODUCER", producer.Trim());
                    cmd.Parameters.AddWithValue("@MEDICATION_INFO_LEAFLET", leaflet.Trim());

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }

        }

        public bool addPRESCRIPTIONItemsToTable(int id, int pres_id, int patient_id, int doctor_id, int med_id, string formula, string note)
        {
            Connection con = new Connection();
            if (ConnectionState.Closed == con.connect.State)
            {
                con.connect.Open();
            }

            string query = "Insert into PRESCRIPTION(ID_PRES,PRESCRIPTION_ID,PRESCRIPTION_PATIENT,PRESCRIPTION_DOCTOR,PRESCRIPTION_MEDICATION,PRESCRIPTION_FORMULA,PRESCRIPTION_NOTE)values(@ID_PRES,@PRESCRIPTION_ID,@PRESCRIPTION_PATIENT,@PRESCRIPTION_DOCTOR,@PRESCRIPTION_MEDICATION,@PRESCRIPTION_FORMULA,@PRESCRIPTION_NOTE)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con.connect))
                {
                    cmd.Parameters.AddWithValue("@ID_PRES", id);
                    cmd.Parameters.AddWithValue("@PRESCRIPTION_ID", pres_id);
                    cmd.Parameters.AddWithValue("@PRESCRIPTION_PATIENT", patient_id);
                    cmd.Parameters.AddWithValue("@PRESCRIPTION_DOCTOR", doctor_id);
                    cmd.Parameters.AddWithValue("@PRESCRIPTION_MEDICATION", med_id);
                    cmd.Parameters.AddWithValue("@PRESCRIPTION_FORMULA", formula.Trim());
                    cmd.Parameters.AddWithValue("@PRESCRIPTION_NOTE", note.Trim());
                  
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }


        public DataTable ReadItemsTable()
        {
            Connection con = new Connection();
            if (ConnectionState.Closed == con.connect.State)
            {
                con.connect.Open();
            }

            string query = "SELECT * FROM DIAGNOSE";
            SqlCommand cmd = new SqlCommand(query, con.connect);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable ReadFKItemsTable(string table_name, int fkTable_id)
        {
            Connection con = new Connection();
            if (ConnectionState.Closed == con.connect.State)
            {
                con.connect.Open();
            }

            string table_id = table_name + "_ID";
            string query = "SELECT * FROM " + table_name + " WHERE " + table_id + " = @id";

            SqlCommand cmd = new SqlCommand(query, con.connect);
            cmd.Parameters.AddWithValue("@table_id", table_id);
            //cmd.Parameters.AddWithValue("@table", table_name);
            cmd.Parameters.AddWithValue("@id", (int)fkTable_id);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable ReadSearchItemsTable(string table_name, string input)
        {
            string table_id, query;
            SqlCommand cmd = new SqlCommand();

            Connection con = new Connection();
            if (ConnectionState.Closed == con.connect.State)
            {
                con.connect.Open();
            }

            // Apparently SQL can't provide a good 'check for value in all columns' that's why I can't simplify it (Shorter code).. 
            if (table_name == "DIAGNOSE")
            {
                // add DIAGNOSE.DIAGNOSE_ID and OR DIAGNOSE_ID LIKE '%" + input + "%'"
                query = "SELECT DIAGNOSE.DIAGNOSE_ID,DIAGNOSE.DIAGNOSE_ICD, DIAGNOSE.DIAGNOSE_PATIENT, DIAGNOSE.DIAGNOSE_DOCTOR, DIAGNOSE.DIAGNOSE_PRESCRIPTION, DIAGNOSE_TEST_RESULTS, DIAGNOSE_CONDITION, PATIENT.PATIENT_NAME, DOCTOR.DOCTOR_NAME  " +
                    "FROM DIAGNOSE inner join PATIENT on DIAGNOSE.DIAGNOSE_PATIENT=PATIENT.PATIENT_ID inner join DOCTOR on DIAGNOSE.DIAGNOSE_DOCTOR=DOCTOR.DOCTOR_ID " +
                    "WHERE DIAGNOSE_ICD LIKE '%" + input + "%' OR DIAGNOSE_PATIENT LIKE '%" + input + "%' OR DIAGNOSE_DOCTOR LIKE '%" + input + "%' OR DIAGNOSE_PRESCRIPTION LIKE '%" + input + "%' OR PATIENT_NAME LIKE '%" + input + "%' OR DOCTOR_NAME LIKE '%" + input + "%'OR DIAGNOSE_ID LIKE '%" + input + "%'";
                cmd = new SqlCommand(query, con.connect);
            }
            else if (table_name == "PRESCRIPTION")
            {
                query = "SELECT PRESCRIPTION.PRESCRIPTION_ID, PRESCRIPTION.PRESCRIPTION_PATIENT, PRESCRIPTION.PRESCRIPTION_DOCTOR, PRESCRIPTION.PRESCRIPTION_MEDICATION, PRESCRIPTION_FORMULA, PRESCRIPTION_NOTE, PATIENT.PATIENT_NAME, DOCTOR.DOCTOR_NAME, MEDICATION.MEDICATION_NAME FROM PRESCRIPTION " +
                    "inner join  PATIENT on PRESCRIPTION.PRESCRIPTION_PATIENT=PATIENT.PATIENT_ID inner join DOCTOR on PRESCRIPTION.PRESCRIPTION_DOCTOR=DOCTOR.DOCTOR_ID inner join MEDICATION on PRESCRIPTION.PRESCRIPTION_MEDICATION=MEDICATION.MEDICATION_ID " +
                    "WHERE PRESCRIPTION_ID LIKE '%" + input + "%' OR PRESCRIPTION_PATIENT LIKE '%" + input + "%' OR PRESCRIPTION_DOCTOR LIKE '%" + input + "%' OR PRESCRIPTION_MEDICATION LIKE '%" + input + "%' OR PATIENT_NAME LIKE '%" + input + "%' OR DOCTOR_NAME LIKE '%" + input + "%' OR MEDICATION_NAME LIKE '%" + input + "%'";

                // ID_PRES
                // PRESCRIPTION_ID
                // PRESCRIPTION_PATIENT   THIS
                // PRESCRIPTION_DOCTOR    THIS
                // PRESCRIPTION_MEDICATION     THIS
                // PRESCRIPTION_FORMULA
                // PRESCRIPTION_NOTE

                cmd = new SqlCommand(query, con.connect);
            }
            else if (table_name == "MEDICATION")
            {
                query = "SELECT MEDICATION.MEDICATION_ID,MEDICATION.MEDICATION_NAME, MEDICATION.MEDICATION_PRODUCER, MEDICATION.MEDICATION_INFO_LEAFLET " +
                   "FROM MEDICATION " +
                   "WHERE MEDICATION_ID LIKE '%" + input + "%' OR MEDICATION_NAME LIKE '%" + input + "%' OR MEDICATION_PRODUCER LIKE '%" + input + "%'";
                cmd = new SqlCommand(query, con.connect);
            }


            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }


        public DataTable ReadTABLETable(string table_name)
        {
            Connection con = new Connection();
            if (ConnectionState.Closed == con.connect.State)
            {
                con.connect.Open();
            }

            string query = "SELECT * FROM" + table_name;
            SqlCommand cmd = new SqlCommand(query, con.connect);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
