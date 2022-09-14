using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLib;
namespace TOLEDO_act4.WFORMS
{
    public partial class LOGIN : Form
    {
        Class1 mydata = new Class1();
        public LOGIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!mydata.validateUserAccount(textBox1.Text, textBox2.Text))
            {
                Class1.IsLoggedIn = false;
                MessageBox.Show("Credentials Wrong!");
            }

            else if (mydata.validateUserAccount(textBox1.Text, textBox2.Text))
            {
                Class1.IsLoggedIn = true;
                if (textBox1.Text == "Admin" && textBox2.Text=="Admin")
                    MessageBox.Show("Welcome ADMIN!");
                else
                    MessageBox.Show("Welcome USER! " + textBox1.Text);
                this.Close();
            }
        }
    }
}
