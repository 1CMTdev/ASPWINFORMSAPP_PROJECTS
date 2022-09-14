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

namespace EMPLOYEE_SALLARY_TOLEDO
{
    public partial class Form1 : Form
    {
        Class1 myData = new Class1();
        public Form1()
        {
            InitializeComponent();
        }

        //process button
        private void button1_Click(object sender, EventArgs e)
        {
           
            myData.awitized(Convert.ToDouble(maskedTextBox2.Text), comboBox1.Text, Convert.ToDouble(maskedTextBox3.Text));
            richTextBox1.AppendText("Employee Name: "+ textBox1.Text+"\n"+
                                    "Employee ID: "+ maskedTextBox1.Text+ "\n"+
                                    "Recorded: "+label8.Text+ "\n"+
                                    "Gross Pay: "+myData.Grr+"php"+"\n"+
                                    "Deduction: "+myData.Ded+ "php" + "\n" +
                                    "OT Pay: "+myData.Ot+ "php" + "\n" +
                                    "Net Pay: " +myData.Net+ "php" + "\n" +
                                    "___________________________________________"+"\n"
                                   );
            
        }


        //exit button
        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToShortDateString()+"   "+DateTime.Now.ToLongTimeString();
        }

    }
}
