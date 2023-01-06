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
    public partial class AdminOptions : Form
    {
        public AdminOptions()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            AddStudent add = new AddStudent();
            this.Hide();
            add.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            AddStudent add = new AddStudent();
            this.Hide();
            add.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AddResult add = new AddResult();
            this.Hide();
            add.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            AddCourse add = new AddCourse();
            this.Hide();
            add.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Search add = new Search();
            this.Hide();
            add.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Update add = new Update();
            this.Hide();
            add.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AddAdmin add = new AddAdmin();
            this.Hide();
            add.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectRole sr = new SelectRole();
            sr.Show();
            this.Hide();
        }

        private void AdminOptions_Load(object sender, EventArgs e)
        {
            label10.Text = AdimnAuthentication.nameOfAdmin.ToUpper();
        }
    }
}
