using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace hospitalmanagement.DAL
{
    class Connection
    {
        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\skaya\Desktop\new_hospital\hospitaldatabase.mdf;Integrated Security=True");
    }
}
