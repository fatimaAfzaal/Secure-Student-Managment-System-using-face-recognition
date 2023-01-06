using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class StudentResultCard : Form
    {
        int tRows=0;
        Student student = new Student();
        Result result = new Result();
        public StudentResultCard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            StudentOptions so = new StudentOptions();
            so.Show();
            this.Hide();
        }

        private void StudentResultCard_Load(object sender, EventArgs e)
        {
            student.Email = StudentLogin.SetValueForText1;
           // MessageBox.Show("Email: "+ StudentLogin.SetValueForText1);
            DataTable dt= student.loadData(student);
            label9.Text = dt.Rows[0][1].ToString();
            label11.Text = dt.Rows[0][0].ToString();
            label8.Text = dt.Rows[0][2].ToString();
            label10.Text = dt.Rows[0][3].ToString();

            result.SID = dt.Rows[0][0].ToString();
           // dataGridView1.DataSource= result.Display(result);
            DataTable dr = result.Display(result);
            label7.Text = "Your SGPA is " + dr.Rows[0][19].ToString();
            //textBox5.Text = dr.Rows[0][19].ToString();
            //tRows = dr.Rows.Count;


            //for (int i = 0; i < tRows; i++)
            //{
            //    switch (i)
            //    {
            //        case 0:
            //            label28.Visible = true;
            //            label8.Visible = true;
            //            label22.Visible = true;
            //            label22.Text = dr.Rows[0][15].ToString();
            //            label8.Text = dr.Rows[0][7].ToString();
            //            label22.Text = dr.Rows[0][1].ToString();
            //            break;
            //        case 1:
            //            label27.Visible = true;
            //            label21.Visible = true;
            //            label10.Visible = true;
            //            break;
            //        case 2:
            //            label26.Visible = true;
            //            label20.Visible = true;
            //            label11.Visible = true;
            //            break;
            //        case 3:
            //            label25.Visible = true;
            //            label19.Visible = true;
            //            label14.Visible = true;
            //            break;
            //        case 4:
            //            label24.Visible = true;
            //            label18.Visible = true;
            //            label13.Visible = true;
            //            break;
            //        case 5:
            //            label23.Visible = true;
            //            label9.Visible = true;
            //            label12.Visible = true;
            //            break;
            //    }
            //}




        }
    }
}
