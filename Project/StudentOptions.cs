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
    public partial class StudentOptions : Form
    {
        Student student = new Student();
        public StudentOptions()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            StudentResultCard src = new StudentResultCard();
            src.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StudentLogin ado = new StudentLogin();
            ado.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            student.Email = StudentLogin.SetValueForText1;
            DataTable dt = student.checkEmail(student);
            MessageBox.Show("Your Fee status is : "+ dt.Rows[0][5].ToString());
        }

       
    }
}
