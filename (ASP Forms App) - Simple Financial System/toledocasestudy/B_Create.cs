using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace toledocasestudy
{
    public partial class B_Create : Form
    {
        Class1 myData = new Class1();
        public B_Create()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        //EXIT
        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            new A_LoginHome().ShowDialog();
        }


        //GEnerate
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                label11.Text = myData.generatorist(w1.Text, w2.Text);
                tooltip.Text = "You can copy this generated account number for your login.";
                MessageBox.Show("ACCOUNT NUMBER CREATED!");
                button2.Enabled = true;
            }
            catch 
            {
                MessageBox.Show("Please fill up the form properly.");
                button1.Enabled = true;
            }

       


        }

        //CREATE BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (w5.Text == "Savings Account")
                {
                    double x = Convert.ToDouble(w6.Text);

                    //W
                    if (x >= 10000)
                    {
                        myData.Creater(label11.Text, w1.Text, w2.Text, w3.Text, w4.Text, w5.Text, w6.Text);
                        MessageBox.Show("ACCOUNT CREATION SUCCESSFUL!");
                        label12.Text = "Login";
                        button2.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("10,000 PHP minimum for Savings account");
                    }
                }


                else if (w5.Text == "Checking Account")
                {
                    double x = Convert.ToDouble(w6.Text);
                    if (x >= 20000)
                    {
                        myData.Creater(label11.Text, w1.Text, w2.Text, w3.Text, w4.Text, w5.Text, w6.Text);
                        MessageBox.Show("ACCOUNT CREATION SUCCESSFUL!");
                        label12.Text = "Login";
                        button2.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("20,000 PHP minimum for Checking Account");
                    }
                }
                else MessageBox.Show("Wrong inputs.");
            }
            catch
            {
                MessageBox.Show("Please fill up the form properly.");
            }



        }//*******************************************/
    }
}
