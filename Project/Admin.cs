using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Project
{
    class Admin
    {

        public int ID
        {
            get; set;
        }
        public String Name
        {
            get; set;
        }
        public byte[] Picture
        {
            get; set;
        }

        private static String myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public const String InsertQuery = "Insert Into admins(Name,Picture) Values(@Name,@Picture)";
        public bool InsertCustomer(Admin admin)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {

                    com.Parameters.AddWithValue("@Name", admin.Name);
                    
                    
                    com.Parameters.AddWithValue("@Picture", admin.Picture);
                   // com.Parameters.AddWithValue("@Phone", customer.Phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public const String SelectQuery = "select * from admins";
        public DataTable GetCustomer()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
    }
}
