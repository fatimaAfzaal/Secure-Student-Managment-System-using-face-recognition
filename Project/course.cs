using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class course
    {
        public String ID
        {
            get; set;
        }
        public String Name
        {
            get; set;
        }
        public String CreditHours
        {
            get; set;
        }
        public String Semester
        {
            get; set;
        }
        public String Department
        {
            get; set;
        }

        private static String myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public const String InsertQuery = "Insert Into course(Name,CreditHours,Semester,Department) Values(@Name,@CreditHours,@Semester,@Department)";
        public bool AddCourse(course course)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {

                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {

                    com.Parameters.AddWithValue("@Name", course.Name);
                    com.Parameters.AddWithValue("@CreditHours", course.CreditHours);
                    com.Parameters.AddWithValue("@Semester", course.Semester);
                    com.Parameters.AddWithValue("@Department", course.Department);
                    
                    rows = com.ExecuteNonQuery();
                }
            }


            return (rows > 0) ? true : false;
        }


        public const String SelectQuery = "select * from course where Semester=@Semester and Department=@Department";
        public DataTable SearchCourse(course course)
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    com.Parameters.AddWithValue("@Semester", course.Semester);
                    com.Parameters.AddWithValue("@Department", course.Department);
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
