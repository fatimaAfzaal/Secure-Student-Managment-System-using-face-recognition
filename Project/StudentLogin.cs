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
    public partial class StudentLogin : Form
    {
        Student student = new Student();
        public static String SetValueForText1 = ""; 
        public static String SetValueForText2 = ""; 

        public StudentLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
           
            student.Email = textBox_usrname.Text;
            student.Password = textBox_password.Text;
            dataGridView1.DataSource = student.checkEmail(student);
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Invalid email id");
            }
            else
            {
                if (textBox_password.Text == "")
                {
                    MessageBox.Show("Please Enter Password");
                }
                else
                {
                    if (dataGridView1.Rows[0].Cells[10].Value.ToString() == "")
                    {
                        student. UpdatePassword(student);
                    }
                    else if(dataGridView1.Rows[0].Cells[10].Value.ToString() == textBox_password.Text)
                    {
                        SetValueForText1 = textBox_usrname.Text;
                        SetValueForText2 = textBox_password.Text;
                        StudentOptions admin = new StudentOptions();
                        this.Hide();
                        admin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
            }
            //stud

        }

        private void textBox_password_Click(object sender, EventArgs e)
        {
            student.Email = textBox_usrname.Text;
            student.Password = textBox_password.Text;
            dataGridView1.DataSource = student.checkEmail(student);
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Invalid email id");
            }
            else
            {
                if (dataGridView1.Rows[0].Cells[10].Value.ToString() == "")
                {
                    MessageBox.Show("You are first time user!!!!\nSet your password, we will save it for later");
                }
               
            }
            //student.checkPassword(student);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectRole sr = new SelectRole();
            sr.Show();
            this.Hide();
        }
    }
}
