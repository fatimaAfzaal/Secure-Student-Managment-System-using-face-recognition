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
    public partial class Update : Form
    {
        Student student = new Student();
        public Update()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            textBox4.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
           // MessageBox.Show(dataGridView1.Rows[index].Cells[4].Value.ToString());
            //MessageBox.Show(dataGridView1.Rows[index].Cells[5].Value.ToString());

            if (dataGridView1.Rows[index].Cells[4].Value.ToString().StartsWith("M")) 
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            if (dataGridView1.Rows[index].Cells[5].Value.ToString().StartsWith("Pai"))
            {
                radioButton4.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;
            }
            comboBox1.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter ID to load data");
            }
            else
            {
                student.ID = textBox1.Text;
                DataTable dt = student.SearchStudent(student, "ID");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No record found!!!!!");
                }
                else
                {
                   // MessageBox.Show("Gender : " + dt.Rows[0][4].ToString() + "\n Fee :" + dt.Rows[0][5].ToString());
                    textBox1.Text = dt.Rows[0][0].ToString();
                    textBox4.Text = dt.Rows[0][1].ToString();
                    textBox2.Text = dt.Rows[0][2].ToString();
                    textBox3.Text = dt.Rows[0][3].ToString();
                    String gender = dt.Rows[0][4].ToString();
                    if (gender.StartsWith("M"))
                    {
                        //MessageBox.Show("Inside if");
                        radioButton1.Checked = true;
                    }
                    else
                    {
                       // MessageBox.Show(dt.Rows[0][4].ToString());
                        radioButton2.Checked = true;
                    }
                    if (dt.Rows[0][5].ToString().StartsWith("Paid"))
                    {
                        radioButton4.Checked = true;
                    }
                    else
                    {
                     //   MessageBox.Show(dt.Rows[0][5].ToString());
                        radioButton3.Checked = true;
                    }
                    comboBox1.Text = dt.Rows[0][6].ToString();
                    comboBox2.Text = dt.Rows[0][7].ToString();
                }
            }
            

        }

        private void Update_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = student.AllStudent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {

            student.ID = textBox1.Text;
            student.Fname = textBox4.Text;
            student.Address = textBox2.Text;
            student.Contact = textBox3.Text;
            if(radioButton1.Checked==true)
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

           var success=student.UpdateStudent(student);
            if (success)
            {
                MessageBox.Show("Record updated successfully");
            }
            else
            {
                MessageBox.Show("No updation");
            }
            dataGridView1.DataSource= student.GetAllStudent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminOptions ad = new AdminOptions();
            ad.Show();
            this.Hide();
        }
    }
}
