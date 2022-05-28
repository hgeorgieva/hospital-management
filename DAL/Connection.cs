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
       // public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\skaya\Downloads\hospitaldatabase.mdf;Integrated Security=True");
        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\UNI\proekt-bd\hospitalmanagement\hospitaldatabase.mdf;Integrated Security=True");
        // public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\hospitaldatabase.mdf;Integrated Security=True");
    }
}
