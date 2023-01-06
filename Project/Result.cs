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
    class Result
    {
        public String SID
        {
            get; set;
        }
        public String gOne
        {
            get; set;
        }
        public String gTwo
        {
            get; set;
        }
        public String gThree
        {
            get; set;
        }
        public String gFour
        {
            get; set;
        }
        public String gFive
        {
            get; set;
        }
        public String gSix
        {
            get; set;
        }
        public String chOne
        {
            get; set;
        }
        public String chTwo
        {
            get; set;
        }
        public String chThree
        {
            get; set;
        }
        public String chFour
        {
            get; set;
        }
        public String chFive
        {
            get; set;
        }
        public String chSix
        {
            get; set;
        }
        public String cnOne
        {
            get; set;
        }
        public String cnTwo
        {
            get; set;
        }
        public String cnThree
        {
            get; set;
        }
        public String cnFour
        {
            get; set;
        }
        public String cnFive
        {
            get; set;
        }
        public String cnSix
        {
            get; set;
        }
        public String gpa
        {
            get; set;
        }
        public String rID
        {
            get; set;
        }
        private static String myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        //int gRows;

        public const String InsertQuery = "Insert Into result(SID,gOne,gTwo,gThree,gFour,gFive,gSix,chOne,chTwo,chThree,chFour,chFive,chSix,cnOne,cnTwo,cnThree,cnFour,cnFive,cnSix,gpa) Values(@SID,@gOne,@gTwo,@gThree,@gFour,@gFive,@gSix,@chOne,@chTwo,@chThree,@chFour,@chFive,@chSix,@cnOne,@cnTwo,@cnThree,@cnFour,@cnFive,@cnSix,@gpa)";
        public const String resultDispaly = "Select * from result where SID=@SID ORDER BY rID DESC";
        public bool InsertResult(Result result)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {

                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {

                    com.Parameters.AddWithValue("@SID",result.SID);
                    com.Parameters.AddWithValue("@gOne",result.gOne);
                    com.Parameters.AddWithValue("@gTwo",result.gTwo);
                    com.Parameters.AddWithValue("@gThree",result.gThree);
                    com.Parameters.AddWithValue("@gFour",result.gFour);
                    com.Parameters.AddWithValue("@gFive",result.gFive);
                    com.Parameters.AddWithValue("@gSix",result.gSix);
                    com.Parameters.AddWithValue("@chOne", result.chOne);
                    com.Parameters.AddWithValue("@chTwo", result.chTwo);
                    com.Parameters.AddWithValue("@chThree", result.chThree);
                    com.Parameters.AddWithValue("@chFour", result.chFour);
                    com.Parameters.AddWithValue("@chFive", result.chFive);
                    com.Parameters.AddWithValue("@chSix", result.chSix);
                    com.Parameters.AddWithValue("@cnOne", result.cnOne);
                    com.Parameters.AddWithValue("@cnTwo", result.cnTwo);
                    com.Parameters.AddWithValue("@cnThree", result.cnThree);
                    com.Parameters.AddWithValue("@cnFour", result.cnFour);
                    com.Parameters.AddWithValue("@cnFive", result.cnFive);
                    com.Parameters.AddWithValue("@cnSix", result.cnSix);
                    com.Parameters.AddWithValue("@gpa", result.gpa);
                    rows = com.ExecuteNonQuery();
                }
            }


            return (rows > 0) ? true : false;
        }

        public DataTable Display(Result result)
        {
            var datatable = new DataTable();
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
               
                con.Open();
                using (SqlCommand com = new SqlCommand(resultDispaly, con))
                {

                    com.Parameters.AddWithValue("@SID", result.SID);

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
