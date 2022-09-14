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
    public partial class D_Transfer : Form
    {
        Class1 myData = new Class1();
        public D_Transfer()
        {
            InitializeComponent();
            label6.Text = Class1.CurAccNo;
            label8.Text = Class1.CurBal;
            // TODO: This line of code loads data into the 'masterDataSet3.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter1.Fill(this.masterDataSet3.Accounts);
            // TODO: This line of code loads data into the 'masterDataSet2.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.masterDataSet2.Accounts);
        }

        //CANCEL
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //SEND
        private void button1_Click(object sender, EventArgs e)
        {
            if (Class1.CurAccNo != comboBox1.Text)
            {
                MessageBox.Show(myData.senderist(numericUpDown1.Text, comboBox1.Text));
                label8.Text = Class1.CurBal;

            }
            else MessageBox.Show("You cannot send to yourself silly!");
        }

        private void D_Transfer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet3.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter1.Fill(this.masterDataSet3.Accounts);
            // TODO: This line of code loads data into the 'masterDataSet2.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.masterDataSet2.Accounts);
        }
    }
}
