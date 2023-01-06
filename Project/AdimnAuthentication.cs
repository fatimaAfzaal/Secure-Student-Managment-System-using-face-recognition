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
using FaceRecognitionDotNet;

namespace Project
{
    public partial class AdimnAuthentication : Form
    {
        bool i = true;
        bool _streaming;
        Capture _capture;
        Admin admin = new Admin();
        public static String nameOfAdmin ="";
        public AdimnAuthentication()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent form3 = new AddStudent();
            this.Hide();
            form3.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           // _capture = new Capture();
            if (!_streaming)
            {
                i = true;
                pictureBox1.Visible = true;             //for camera
                pictureBox2.Visible = false;                //for saving image
                Application.Idle += streaming;
                button1.Text = @"Capture";
               // _streaming = false;
            }
            else
            {
                
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                button1.Text = @"Open Camera";
                Application.Idle -= streaming;
                i = false;
                //_streaming = false;
                pictureBox2.Image = pictureBox1.Image;


            }
            _streaming = !_streaming;

        }

        private void streaming(object sender, EventArgs e)
        {
            
            try
            {
                var img = _capture.QueryFrame().ToImage<Bgr, byte>();
                var bmp = img.Bitmap;
                pictureBox1.Image = bmp;

            }
            catch (Exception)
            {
                MessageBox.Show("Time Out");
                SelectRole sr = new SelectRole();
                sr.Show();
                this.Hide();
            }
            
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (i)
            {
                MessageBox.Show("First capture image");
            }
            else
            {
                bool find = true;
                int row = 0;
                int count = 1;
                DataTable dt = admin.GetCustomer();
                // MessageBox.Show(dt.Rows.Count.ToString()) ;
                while (count <= dt.Rows.Count)
                {
                    try
                    {
                        byte[] img = (byte[])dt.Rows[row][2];
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox3.Image = System.Drawing.Image.FromStream(ms);


                        string currentDirectory = Environment.CurrentDirectory + "\\models";

                        FaceRecognition fr;
                        fr = FaceRecognition.Create(currentDirectory);

                        var dlibToComBuf = FaceRecognition.LoadImage((Bitmap)pictureBox2.Image);
                        var enToCompare = fr.FaceEncodings(dlibToComBuf).First();

                        var dlibToComBuf2 = FaceRecognition.LoadImage((Bitmap)pictureBox3.Image);
                        var enToCompare2 = fr.FaceEncodings(dlibToComBuf2).First();

                        bool result = FaceRecognition.CompareFace(enToCompare, enToCompare2);
                        if (result)
                        {
                            //count = (dt.Rows.Count) + 1;
                            nameOfAdmin = dt.Rows[row][1].ToString();
                            find = false;
                            AdminOptions add = new AdminOptions();
                            this.Hide();
                            add.Show();
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Your face is not clear");
                        count = (dt.Rows.Count) + 1;
                    }
                    //MessageBox.Show("Image"+count);
                    count++;
                    row++;
                }
                if (find)
                {
                    MessageBox.Show("Access denied");
                }

            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdimnAuthentication ad = new AdimnAuthentication();
            ad.Show();
            this.Hide();
        }

        private void AdimnAuthentication_Load(object sender, EventArgs e)
        {
            _streaming = false;
            _capture = new Capture();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            SelectRole sr = new SelectRole();
            sr.Show();
            this.Hide();
        }
    }
}
