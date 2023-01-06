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
    class Student
    {
        public String ID
        {
            get; set;
        }
        public String Fname
        {
            get; set;
        }
        public String Address
        {
            get; set;
        }
        public String Contact
        {
            get; set;
        }
        public String Gender
        {
            get; set;
        }
        public String FeeStatus
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
        public byte[] Picture
        {
            get; set;
        }
        public String Email
        {
            get; set;
        }
        public String Password
        {
            get; set;
        }
        private static String myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        //int gRows;

        public const String InsertQuery = "Insert Into student(Fname,Address,Contact,Gender,FeeStatus,Semester,Department,Picture,Email) Values(@Fname,@Address,@Contact,@Gender,@FeeStatus,@Semester,@Department,@Picture,@Email)";
        public const String UpdateQuery = "update student set Email=@Email where ID=@ID";
        public const String SelectQ = "select * from student ORDER BY ID DESC";
        public const String Check = "select * from student where Email=@Email";             //for student login
        public const String PasswordCheck = "update student set Password=@Password where Email=@Email";
        public const String selectAll = "select * from student";
        public const String update = "update student set Fname=@Fname,Address=@Address,Contact=@Contact,FeeStatus=@FeeStatus,Gender=@Gender,Semester=@Semester,Department=@Department where ID=@ID";
        public const String Select = "select * from student";
        public const String SelectFromEmail = "select ID,Fname,Semester,Department from student where Email=@Email";

        public bool InsertStudent(Student student)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {

                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {

                    com.Parameters.AddWithValue("@Fname", student.Fname);
                    com.Parameters.AddWithValue("@Address", student.Address);
                    com.Parameters.AddWithValue("@Contact", student.Contact);
                    com.Parameters.AddWithValue("@Gender", student.Gender);
                    com.Parameters.AddWithValue("@FeeStatus", student.FeeStatus);
                    com.Parameters.AddWithValue("@Semester", student.Semester);
                    com.Parameters.AddWithValue("@Department", student.Department);
                    com.Parameters.AddWithValue("@Picture", student.Picture);
                    com.Parameters.AddWithValue("@Email", student.Email);
                    rows = com.ExecuteNonQuery();
                }
            }
           

            return (rows > 0) ? true : false;
        }

        public bool UpdateEmail(Student student)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@ID", student.ID);
                    com.Parameters.AddWithValue("@Email", student.ID + "@aack.au.edu.pk");
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

   
        public DataTable GetStudent()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQ, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }



       
        public DataTable checkEmail(Student student)
        {
           // int rows;
           // int count=0;
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(Check, con))
                {
                    com.Parameters.AddWithValue("@Email", student.Email);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

         //for student login

        public bool UpdatePassword(Student student)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(PasswordCheck, con))
                {
                    com.Parameters.AddWithValue("@Password", student.Password);
                    com.Parameters.AddWithValue("@Email",student.Email);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        public DataTable SearchStudent(Student student, String txt)
        {

            String SearchQuery;
           
            if (txt == "Address")
                SearchQuery = "select * from student where Address=@Address";
            else if (txt == "Gender")
                SearchQuery = "select * from student where Gender=@Gender";
            else if (txt == "FeeStatus")
                SearchQuery = "select * from student where FeeStatus=@FeeStatus";
            else if (txt == "Semester")
                SearchQuery = "select * from student where Semester=@Semester";
            else if (txt == "Department")
                SearchQuery = "select * from student where Department=@Department";
            else
                SearchQuery = "select * from student where ID=@ID";
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SearchQuery, con))
                {
                    if (txt == "ID")
                        com.Parameters.AddWithValue("@ID", student.ID);
                    else if (txt == "Address")
                        com.Parameters.AddWithValue("@Address",
                       student.Address);
                    else if (txt == "Gender")
                        com.Parameters.AddWithValue("@Gender",
                       student.Gender);
                    else if (txt == "FeeStatus")
                        com.Parameters.AddWithValue("@FeeStatus",
                       student.FeeStatus);
                    else if (txt == "Semester")
                        com.Parameters.AddWithValue("@Semester",
                       student.Semester);
                    else
                        com.Parameters.AddWithValue("@Department", student.Department);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

                   //for student login
        public DataTable AllStudent()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(selectAll, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

        
        public bool UpdateStudent(Student student)
        {
            int rows;
            //var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(update, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        com.Parameters.AddWithValue("@ID", student.ID);
                        com.Parameters.AddWithValue("@Fname", student.Fname);
                        com.Parameters.AddWithValue("@Address", student.Address);
                        com.Parameters.AddWithValue("@Contact", student.Contact);
                        com.Parameters.AddWithValue("@Gender", student.Gender);
                        com.Parameters.AddWithValue("@FeeStatus", student.FeeStatus);
                        com.Parameters.AddWithValue("@Semester", student.Semester);
                        com.Parameters.AddWithValue("@Department", student.Department);
                        rows = com.ExecuteNonQuery();
                        //adapter.Fill(datatable);
                    }
                }
            }
            return (rows > 0) ? true : false;
        }

        
        public DataTable GetAllStudent()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(Select, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
        public DataTable loadData(Student student)
        {
            // int rows;
            // int count=0;
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectFromEmail, con))
                {
                    com.Parameters.AddWithValue("@Email", student.Email);
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