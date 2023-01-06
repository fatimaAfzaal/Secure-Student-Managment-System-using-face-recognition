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
    public partial class AddResult : Form
    {
        Result result = new Result();
        int tRows = 0;
        double credit;
        double caltimes = 0;
        double totalcal = 0;
        double totalcredit = 0;
        double finalgpa = 0;
        double A = 4.0;
        double AMINUS = 3.67;
        double BPLUS = 3.33;
        double B = 3.0;
        double BMINUS = 2.67;
        double CPLUS = 2.33;
        double C = 2.0;
        double CMINUS = 1.67;
        double D = 1.00;
        double F = 0.0;
        String  b;
        



        Student student = new Student();
        course courde = new course();
        public AddResult()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            result.SID = ""; result.gOne = ""; result.gTwo = ""; result.gThree = ""; result.gFour = ""; result.gFive = ""; result.gSix = ""; result.chOne = ""; result.chTwo = ""; result.chThree = ""; result.chFour = ""; result.chFive = ""; result.chSix = ""; result.cnOne = ""; result.cnTwo = ""; result.cnThree = ""; result.cnFour = ""; result.cnFive = ""; result.cnSix = ""; result.gpa = "";
            credit = 0;
            caltimes = 0;
            totalcal = 0;
            totalcredit = 0;
            finalgpa = 0;
            

                for (int i = 0; i < tRows; i++)
            {
                switch(i)
                {
                    case 0:
                        b = comboBox1.Text;
                        switch (b)
                        {
                            case "A":
                                caltimes = int.Parse(label2.Text) * A;
                                credit = int.Parse(label2.Text);
                                break;
                            case "A-":
                                caltimes = int.Parse(label2.Text) * AMINUS;
                                credit = int.Parse(label2.Text);
                                break;
                            case "B+":
                                caltimes = int.Parse(label2.Text) * BPLUS;
                                credit = int.Parse(label2.Text);
                                break;
                            case "B":
                                caltimes = int.Parse(label2.Text) * B;
                                credit = int.Parse(label2.Text);
                                break;
                            case "B-":
                                caltimes = int.Parse(label2.Text) * BMINUS;
                                credit = int.Parse(label2.Text);
                                break;
                            case "C+":
                                caltimes = int.Parse(label2.Text) * CPLUS;
                                credit = int.Parse(label2.Text);
                                break;
                            case "C":
                                caltimes = int.Parse(label2.Text) * C;
                                credit = int.Parse(label2.Text);
                                break;
                            case "C-":
                                caltimes = int.Parse(label2.Text) * CMINUS;
                                credit = int.Parse(label2.Text);
                                break;
                            case "D":
                                caltimes = int.Parse(label2.Text) * D;
                                credit = int.Parse(label2.Text);
                                break;
                            case "F":
                                caltimes = int.Parse(label2.Text) * F;
                                credit = int.Parse(label2.Text);
                                break;

                        }
                       break;

                    case 1:
                        b = comboBox2.Text;
                        switch (b)
                        {
                            case "A":
                                caltimes = int.Parse(label10.Text) * A;
                                credit = int.Parse(label10.Text);
                                break;
                            case "A-":
                                caltimes = int.Parse(label10.Text) * AMINUS;
                                credit = int.Parse(label10.Text);
                                break;
                            case "B+":
                                caltimes = int.Parse(label10.Text) * BPLUS;
                                credit = int.Parse(label10.Text);
                                break;
                            case "B":
                                caltimes = int.Parse(label10.Text) * B;
                                credit = int.Parse(label10.Text);
                                break;
                            case "B-":
                                caltimes = int.Parse(label10.Text) * BMINUS;
                                credit = int.Parse(label10.Text);
                                break;
                            case "C+":
                                caltimes = int.Parse(label10.Text) * CPLUS;
                                credit = int.Parse(label10.Text);
                                break;
                            case "C":
                                caltimes = int.Parse(label10.Text) * C;
                                credit = int.Parse(label10.Text);
                                break;
                            case "C-":
                                caltimes = int.Parse(label10.Text) * CMINUS;
                                credit = int.Parse(label10.Text);
                                break;
                            case "D":
                                caltimes = int.Parse(label10.Text) * D;
                                credit = int.Parse(label10.Text);
                                break;
                            case "F":
                                caltimes = int.Parse(label10.Text) * F;
                                credit = int.Parse(label10.Text);
                                break;

                        }
                        break;
                    case 2:
                       
                        b = comboBox3.Text;
                        switch (b)
                        {
                            case "A":
                                caltimes = int.Parse(label11.Text) * A;
                                credit = int.Parse(label11.Text);
                                break;
                            case "A-":
                                caltimes = int.Parse(label11.Text) * AMINUS;
                                credit = int.Parse(label11.Text);
                                break;
                            case "B+":
                                caltimes = int.Parse(label11.Text) * BPLUS;
                                credit = int.Parse(label11.Text);
                                break;
                            case "B":
                                caltimes = int.Parse(label11.Text) * B;
                                credit = int.Parse(label11.Text);
                                break;
                            case "B-":
                                caltimes = int.Parse(label11.Text) * BMINUS;
                                credit = int.Parse(label11.Text);
                                break;
                            case "C+":
                                caltimes = int.Parse(label11.Text) * CPLUS;
                                credit = int.Parse(label11.Text);
                                break;
                            case "C":
                                caltimes = int.Parse(label11.Text) * C;
                                credit = int.Parse(label11.Text);
                                break;
                            case "C-":
                                caltimes = int.Parse(label11.Text) * CMINUS;
                                credit = int.Parse(label11.Text);
                                break;
                            case "D":
                                caltimes = int.Parse(label11.Text) * D;
                                credit = int.Parse(label11.Text);
                                break;
                            case "F":
                                caltimes = int.Parse(label11.Text) * F;
                                credit = int.Parse(label11.Text);
                                break;

                        }
                        break;

                    case 3:
                        b = comboBox4.Text;
                        switch (b)
                        {
                            case "A":
                                caltimes = int.Parse(label14.Text) * A;
                                credit = int.Parse(label14.Text);
                                break;
                            case "A-":
                                caltimes = int.Parse(label14.Text) * AMINUS;
                                credit = int.Parse(label14.Text);
                                break;
                            case "B+":
                                caltimes = int.Parse(label14.Text) * BPLUS;
                                credit = int.Parse(label14.Text);
                                break;
                            case "B":
                                caltimes = int.Parse(label14.Text) * B;
                                credit = int.Parse(label14.Text);
                                break;
                            case "B-":
                                caltimes = int.Parse(label14.Text) * BMINUS;
                                credit = int.Parse(label14.Text);
                                break;
                            case "C+":
                                caltimes = int.Parse(label14.Text) * CPLUS;
                                credit = int.Parse(label14.Text);
                                break;
                            case "C":
                                caltimes = int.Parse(label14.Text) * C;
                                credit = int.Parse(label14.Text);
                                break;
                            case "C-":
                                caltimes = int.Parse(label14.Text) * CMINUS;
                                credit = int.Parse(label14.Text);
                                break;
                            case "D":
                                caltimes = int.Parse(label14.Text) * D;
                                credit = int.Parse(label14.Text);
                                break;
                            case "F":
                                caltimes = int.Parse(label14.Text) * F;
                                credit = int.Parse(label14.Text);
                                break;

                        }
                        break;

                    case 4:
                        
                        b = comboBox5.Text;
                        switch (b)
                        {
                            case "A":
                                caltimes = int.Parse(label13.Text) * A;
                                credit = int.Parse(label13.Text);
                                break;
                            case "A-":
                                caltimes = int.Parse(label13.Text) * AMINUS;
                                credit = int.Parse(label13.Text);
                                break;
                            case "B+":
                                caltimes = int.Parse(label13.Text) * BPLUS;
                                credit = int.Parse(label13.Text);
                                break;
                            case "B":
                                caltimes = int.Parse(label13.Text) * B;
                                credit = int.Parse(label13.Text);
                                break;
                            case "B-":
                                caltimes = int.Parse(label13.Text) * BMINUS;
                                credit = int.Parse(label13.Text);
                                break;
                            case "C+":
                                caltimes = int.Parse(label13.Text) * CPLUS;
                                credit = int.Parse(label13.Text);
                                break;
                            case "C":
                                caltimes = int.Parse(label13.Text) * C;
                                credit = int.Parse(label13.Text);
                                break;
                            case "C-":
                                caltimes = int.Parse(label13.Text) * CMINUS;
                                credit = int.Parse(label13.Text);
                                break;
                            case "D":
                                caltimes = int.Parse(label13.Text) * D;
                                credit = int.Parse(label13.Text);
                                break;
                            case "F":
                                caltimes = int.Parse(label13.Text) * F;
                                credit = int.Parse(label13.Text);
                                break;

                        }
                        break;
                    case 5:
                       
                        b = comboBox6.Text;
                        switch (b)
                        {
                            case "A":
                                caltimes = int.Parse(label12.Text) * A;
                                credit = int.Parse(label12.Text);
                                break;
                            case "A-":
                                caltimes = int.Parse(label12.Text) * AMINUS;
                                credit = int.Parse(label12.Text);
                                break;
                            case "B+":
                                caltimes = int.Parse(label12.Text) * BPLUS;
                                credit = int.Parse(label12.Text);
                                break;
                            case "B":
                                caltimes = int.Parse(label12.Text) * B;
                                credit = int.Parse(label12.Text);
                                break;
                            case "B-":
                                caltimes = int.Parse(label12.Text) * BMINUS;
                                credit = int.Parse(label12.Text);
                                break;
                            case "C+":
                                caltimes = int.Parse(label12.Text) * CPLUS;
                                credit = int.Parse(label12.Text);
                                break;
                            case "C":
                                caltimes = int.Parse(label12.Text) * C;
                                credit = int.Parse(label12.Text);
                                break;
                            case "C-":
                                caltimes = int.Parse(label12.Text) * CMINUS;
                                credit = int.Parse(label12.Text);
                                break;
                            case "D":
                                caltimes = int.Parse(label12.Text) * D;
                                credit = int.Parse(label12.Text);
                                break;
                            case "F":
                                caltimes = int.Parse(label12.Text) * F;
                                credit = int.Parse(label12.Text);
                                break;

                        }
                        break;
                    default:
                        MessageBox.Show("Error occured");
                        break;
                }
                totalcredit = totalcredit + credit;
                totalcal = totalcal + caltimes;
            }
            
            finalgpa = totalcal / totalcredit;
            //MessageBox.Show("GPA : " + finalgpa);

           label18.Text = finalgpa.ToString("#.00");


            result.SID = textBox1.Text;
            result.cnOne = label3.Text;
            result.cnTwo = label4.Text;
            result.cnThree = label5.Text;
            result.cnFour = label7.Text;
            result.cnFive = label8.Text;
            result.cnSix = label9.Text;

            result.chOne = label2.Text;
            result.chTwo = label10.Text;
            result.chThree = label11.Text;
            result.chFour = label14.Text;
            result.chFive = label13.Text;
            result.chSix = label12.Text;

            result.gOne = comboBox1.Text;
            result.gTwo = comboBox2.Text;
            result.gThree = comboBox3.Text;
            result.gFour = comboBox4.Text;
            result.gFive = comboBox5.Text;
            result.gSix = comboBox6.Text;

            result.gpa = label18.Text;

            var success=result.InsertResult(result);
            if (success)
            {
                MessageBox.Show("Result added successfully");
            }
            else
            {
                MessageBox.Show("Error occured!!!!!!!!");
            }

            //clearControl();
        }

        //private void clearControl()
        //{
        //    textBox1.ResetText();
        //    label3.ResetText();
        //    label4.ResetText();
        //    label5.ResetText();
        //    label7.ResetText();
        //    label8.ResetText();
        //    label9.ResetText();

        //    label2.ResetText();
        //    label10.ResetText();
        //    label11.ResetText();
        //    label14.ResetText();
        //    label13.ResetText();
        //    label12.ResetText();

        //    label9.ResetText();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //First select semester and department of a student
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter ID");
            }
            else
            {
                int row = 0;
                student.ID = textBox1.Text;
                DataTable dt = student.SearchStudent(student, "ID");

                //MessageBox.Show(dt.Rows[0][6].ToString() + "\n Dept:" +dt.Rows[0][7].ToString());
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("There is no data at this ID");
                }
                else
                {
                    courde.Semester = dt.Rows[0][6].ToString();
                    courde.Department = dt.Rows[0][7].ToString();

                    DataTable dc = courde.SearchCourse(courde);

                    row = dc.Rows.Count;
                    //MessageBox.Show(row.ToString());
                    tRows = row;
                    String[] array = new String[] { " ", " ", " ", " ", " ", " " };
                    for (int i = 0; i < row; i++)
                    {
                        array[i] = dc.Rows[i][1].ToString();
                    }
                    label3.Text = array[0];
                    label4.Text = array[1];
                    label5.Text = array[2];
                    label7.Text = array[3];
                    label8.Text = array[4];
                    label9.Text = array[5];



                    String[] array1 = new String[] { " ", " ", " ", " ", " ", " " };
                    for (int i = 0; i < row; i++)
                    {
                        array1[i] = dc.Rows[i][2].ToString();
                    }
                    label2.Text = array1[0];
                    label10.Text = array1[1];
                    label11.Text = array1[2];
                    label14.Text = array1[3];
                    label13.Text = array1[4];
                    label12.Text = array1[5];

                    for (int i = 0; i < tRows; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                comboBox1.Visible = true;
                                label3.Visible = true;
                                label2.Visible = true;
                                break;
                            case 1:
                                comboBox2.Visible = true;
                                label4.Visible = true;
                                label10.Visible = true;
                                break;
                            case 2:
                                comboBox3.Visible = true;
                                label5.Visible = true;
                                label11.Visible = true;
                                break;
                            case 3:
                                comboBox4.Visible = true;
                                label7.Visible = true;
                                label14.Visible = true;
                                break;
                            case 4:
                                comboBox5.Visible = true;
                                label8.Visible = true;
                                label13.Visible = true;
                                break;
                            case 5:
                                comboBox6.Visible = true;
                                label9.Visible = true;
                                label12.Visible = true;
                                break;
                        }
                    }

                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminOptions ao = new AdminOptions();
            ao.Show();
            this.Hide();
        }
    }
}
