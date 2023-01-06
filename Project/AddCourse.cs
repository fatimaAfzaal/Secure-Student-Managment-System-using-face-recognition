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
    public partial class AddCourse : Form
    {
        course course = new course();
        public AddCourse()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Please fill all the required feilds");
            }
            else
            {
               
                course.Name = textBox1.Text;
                course.CreditHours = textBox2.Text;
                course.Semester = comboBox1.Text;
                course.Department = comboBox2.Text;

                DataTable dt=course.SearchCourse(course);

                if (dt.Rows.Count < 6)
                {
                    var success = course.AddCourse(course);                   //for insertion

                    if (success)
                    {
                        ClearControls();
                        MessageBox.Show("Course added successfully");
                    }
                    else
                    {
                        MessageBox.Show("Error occured!!!!!! Please try again... ");
                    }
                }
                else
                {
                    MessageBox.Show("Course feild for this semester is already fill");
                }

               
            }
        }

        private void ClearControls()
        {
            textBox1.ResetText();
            textBox2.ResetText();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdminOptions ao = new AdminOptions();
            ao.Show();
            this.Hide();
        }
    }
}
