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
    public partial class A_LoginHome : Form
    {
        Class1 myData = new Class1();
        public A_LoginHome()
        {
            InitializeComponent();
        }




        //CREATE BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new B_Create().ShowDialog();
        }


        //LOGIN
        private void button1_Click(object sender, EventArgs e)
        {
            if (myData.Loginer(textBox1.Text, textBox2.Text))
            {
                this.Hide();
                new C_Trans().ShowDialog();
            }
            else
                MessageBox.Show("Login Failed please check credentials carefully!");
        }
    }
}
