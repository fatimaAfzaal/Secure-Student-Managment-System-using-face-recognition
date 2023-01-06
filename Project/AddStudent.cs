using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AddStudent : Form
    {
        bool i = true;
        Student student = new Student();
        public AddStudent()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)                 //add student
        {


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false) || (radioButton3.Checked == false && radioButton4.Checked == false) || comboBox1.Text == "" || comboBox2.Text == "" || i == true)
            {
                MessageBox.Show("Please fill all the required feilds");
            }
            else
            {
                try
                {
                    student.Fname = textBox1.Text;
                    student.Address = textBox2.Text;
                    student.Contact = textBox3.Text;
                    if (radioButton1.Checked == true)
                    {
                        student.Gender = radioButton1.Text;
                    }
                    else
                    {
                        student.Gender = radioButton2.Text;
                    }

                    if (radioButton3.Checked == true)
                    {
                        student.FeeStatus = radioButton3.Text;
                    }
                    else
                    {
                        student.FeeStatus = radioButton4.Text;
                    }
                    student.Semester = comboBox1.Text;
                    student.Department = comboBox2.Text;
                    MemoryStream stream = new MemoryStream();
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] pic = stream.ToArray();
                    student.Picture = pic;
                    student.Email = student.ID + "@aack.au.edu.pk";
                    var success = student.InsertStudent(student);                   //for insertion

                    if (success)
                    {
                        ClearControls();
                        MessageBox.Show("Student added successfully");
                    }
                    else
                    {
                        MessageBox.Show("Error occured!!!!!! Please try again... ");
                    }
                    dataGridView1.DataSource = student.GetStudent();
                    student.ID = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    student.UpdateEmail(student);
                    dataGridView1.DataSource = student.GetStudent();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while entering data");
                }
               
            }  

        }

        private void ClearControls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text="";
            comboBox2.Text="";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            pictureBox1.Image = Image.FromFile("C:\\Users\\Mootu & Patlu\\source\\repos\\Project\\Project\\Resources\\person.png");
            i = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bpic1 = new Bitmap(System.Drawing.Image.FromFile(ofd.FileName));
                    pictureBox1.Image = bpic1;
                    i = false;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminOptions ado = new AdminOptions();
            ado.Show();
            this.Hide();
        }

      
    }
}
