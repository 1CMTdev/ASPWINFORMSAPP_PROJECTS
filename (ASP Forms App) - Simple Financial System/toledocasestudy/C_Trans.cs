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
    public partial class C_Trans : Form
    {
        Class1 myData = new Class1();
        public C_Trans()
        {
            InitializeComponent();
            label8.Text = Class1.CurBal;
            label6.Text = Class1.CurAccNo;
            label13.Text = Class1.CurAccT;

        }


        //Logout
        private void label3_Click(object sender, EventArgs e)
        {

            this.Hide();
            this.Close();
            new A_LoginHome().ShowDialog();
        }


        //DEPOSIT
        private void Deposit_Click(object sender, EventArgs e)
        {


            if (myData.depositorist(numericUpDown1.Text))
            {
                label8.Text = Class1.CurBal;
                MessageBox.Show("Deposit succesful.");
                myData.Transactioner(Class1.CurAccNo,Class1.CurMensahe,numericUpDown1.Text,label9.Text);
            }   
           else
                MessageBox.Show("Minimum deposit doesnt meet.");
            
                  
        }


        //Timer and date
        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString();
        }


        //View trans
        private void button1_Click(object sender, EventArgs e)
        {
            new E_Viewtrans().ShowDialog();

        }


        //withdraw
        private void button3_Click(object sender, EventArgs e)
        {

            
            MessageBox.Show(myData.withrawist(numericUpDown1.Text));
            label8.Text = Class1.CurBal;

        }


        //Balance transfer
        private void button2_Click(object sender, EventArgs e)
        {
            new D_Transfer().ShowDialog();
        }
    }
}
