using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using hospitalmanagement.DAL;

namespace hospitalmanagement.BLL
{
    class ClassBLL
    {
        #region Save Items

        public bool SaveDIAGNOSEItems(int diagnose_id, int patient_id, string icd_code, int doctor_id, int prescription_id, string test_results, string condition)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.AddDIAGNOSEItemsToTable(diagnose_id, patient_id, icd_code, doctor_id, prescription_id, test_results, condition);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        #endregion

        public bool SavePRESCRIPTIONItems(int id, int pres_id, int patient_id, int doctor_id, int med_id, string formula, string note)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.addPRESCRIPTIONItemsToTable(id, pres_id, patient_id, doctor_id, med_id, formula, note);                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public DataTable GetItems()
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.ReadItemsTable();
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }

        public DataTable GetFKItems(string table_name, int table_id)
        {
            try
            {
                ClassDAL objDal = new ClassDAL();
                return objDal.ReadFKItemsTable(table_name, table_id);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }

        public DataTable GetSearchItems(string table_name, string input)
        {
            try
            {
                ClassDAL objDAL = new ClassDAL();
                return objDAL.ReadSearchItemsTable(table_name, input);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }

        public DataTable GetTABLEItems(string table_name)
        {
            try
            {
                ClassDAL objDAL = new ClassDAL();
                return objDAL.ReadTABLETable(table_name);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
    }
}
