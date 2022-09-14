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
    public partial class E_Viewtrans : Form
    {
        Class1 myData = new Class1();
        public E_Viewtrans()
        {
            InitializeComponent();
            label6.Text = Class1.CurAccNo;
            dataGridView1.DataSource = myData.Viewtra();
      
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
