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
 

    public partial class SIGNUP : Form
    {
        Class1 mydata = new Class1();
        public SIGNUP()
        {
            InitializeComponent();
        }



        //registration
        private void button1_Click(object sender, EventArgs e)
        {
            if (mydata.checkAccount(textBox1.Text))
                MessageBox.Show("Sorry the account is already in the records.");
            else if (textBox1.Text == "Admin" && textBox2.Text=="Admin")
                MessageBox.Show("Sorry the account is already in the records.");
            else
            {
                mydata.registerAccount(textBox1.Text, textBox2.Text);
                this.Close();
            }
          

        }
    }
}
