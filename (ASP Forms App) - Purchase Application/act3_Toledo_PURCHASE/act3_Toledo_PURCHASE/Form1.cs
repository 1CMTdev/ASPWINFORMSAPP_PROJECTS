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

namespace act3_Toledo_PURCHASE
{
    public partial class Form1 : Form
    {
        DataHelper myData = new DataHelper();
        public Form1()
        {
            InitializeComponent();
            
            dataGridView1.Rows.Clear();
            for (int i = 0; i < myData.ProdId.Count; i++)
            { dataGridView1.Rows.Add(myData.ProdId[i].ToString(), myData.ProdName[i].ToString(), myData.ProdStocks[i].ToString(), myData.ProductSRP[i].ToString()); }
        }


        //Close Exit
        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //clock
        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString();
        }



        //Purchase btn
        private void button1_Click(object sender, EventArgs e)
        {
            myData.shinapi(comboBox1.Text,Convert.ToDouble(numericUpDown1.Text));
            if (myData.Purchaselog == "xxx")
            {
                MessageBox.Show("Sorry the available stocks doesn't meet your desired quantity.");
            }
            else
            {
                dataGridView1[2, myData.Determiner].Value = myData.Cur;
                listView1.Items.Add(myData.Purchaselog+" ~ "+label7.Text);
            }
        }
    }
}
