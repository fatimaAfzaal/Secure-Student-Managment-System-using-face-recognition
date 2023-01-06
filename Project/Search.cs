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
    public partial class Search : Form
    {
        Student student = new Student();
        public Search()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = comboBox1.Text;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please fill all requirements");
            }
            else
            {
                if (label3.Text == "ID")
                    student.ID = textBox1.Text;
                else if (label3.Text == "Address")
                    student.Address = textBox1.Text;
                else if (label3.Text == "Gender")
                    student.Gender = textBox1.Text;
                else if (label3.Text == "FeeStatus")
                    student.FeeStatus = textBox1.Text;
                else if (label3.Text == "Semester")
                    student.Semester = textBox1.Text;
                else if (label3.Text == "Department")
                    student.Department = textBox1.Text;
                else
                    MessageBox.Show("Please select by which you want to search");
                dataGridView1.DataSource = student.SearchStudent(student, label3.Text);
                label5.Text = (dataGridView1.RowCount-1).ToString();
            }
           // ClearControls();
           
       
    }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource= student.GetAllStudent();
            label5.Text = (dataGridView1.RowCount - 1).ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminOptions ao = new AdminOptions();
            ao.Show();
            this.Hide();
        }
    }
}
