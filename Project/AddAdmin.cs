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
using Emgu.CV;
using Emgu.CV.Structure;




namespace Project
{
    public partial class AddAdmin : Form
    {
        bool i = true;
        bool _streaming;
        Capture _capture;
        
        Admin admin = new Admin();
        public AddAdmin()
        {
            InitializeComponent();
        }
       
        private void button2_Click(object sender, EventArgs e)              //add admin
        {
            if (i)
            {
                MessageBox.Show("First capture image");
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter the name");
                }
                else
                {
                    admin.Name = textBox1.Text;
                    MemoryStream stream = new MemoryStream();
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] pic = stream.ToArray();
                    admin.Picture = pic;

                    var success = admin.InsertCustomer(admin);
                    if (success)
                    {
                        ClearControls();
                        MessageBox.Show("Admin added successfully");
                    }
                    else
                    {
                        MessageBox.Show("Error occured!!!!!! Please try again... ");
                    }
                }
               
            }
            
        }

        private void ClearControls()
        {
            textBox1.ResetText();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void button_login_Click(object sender, EventArgs e)
        {
           // _capture = new Capture();
            if (!_streaming)
            {
                i = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                Application.Idle += streaming;
                button_login.Text = @"Capture";
                //_streaming = false;
            }
            else
            {
                i = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                button_login.Text = @"Open Camera";
                Application.Idle -= streaming;
                //_streaming = false;
                pictureBox2.Image = pictureBox1.Image;


            }
            _streaming = !_streaming;

        }
        private void streaming(object sender, System.EventArgs e)
        {
            try
            {
                var img = _capture.QueryFrame().ToImage<Bgr, byte>();
                var bmp = img.Bitmap;
                pictureBox1.Image = bmp;
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured!!!! Try again later");
            }
           
        }

        private void AddAdmin_Load(object sender, EventArgs e)
        {
            _streaming = false;
            _capture = new Capture();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdminOptions ao = new AdminOptions();
            ao.Show();
            this.Hide();
        }
    }
}
