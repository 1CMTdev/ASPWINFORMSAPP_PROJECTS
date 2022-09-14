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

namespace TOLEDO_act4
{
    public partial class TOLEDO_ACT4 : Form
    {
        public TOLEDO_ACT4()
        {
            InitializeComponent();
            logOutToolStripMenuItem.Enabled = false;
            transactionToolStripMenuItem.Enabled = false;
            fileMaintenanceToolStripMenuItem.Enabled = false;
        }
        Class1 mydata = new Class1();


        //LOGIN
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WFORMS.LOGIN().ShowDialog();



            if (Class1.IsLoggedIn)
            {
                if (Class1.UserAccount == "Admin")
                {
                    fileToolStripMenuItem.Enabled = true;
                    loginToolStripMenuItem.Enabled = false;
                    signUpToolStripMenuItem.Enabled = false;
                    transactionToolStripMenuItem.Enabled = false;
                    fileMaintenanceToolStripMenuItem.Enabled = true;
                }

                else
                {
                    fileToolStripMenuItem.Enabled = true;
                    fileMaintenanceToolStripMenuItem.Enabled = false;
                    transactionToolStripMenuItem.Enabled = true;
                    loginToolStripMenuItem.Enabled = false;
                    signUpToolStripMenuItem.Enabled = false;
                }
                logOutToolStripMenuItem.Enabled = true;
            }
        }



        //SIGNUP
        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WFORMS.SIGNUP().ShowDialog();
        }


        //VIEW RECORDS
        private void viewRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDI.checkMdi(new WFORMS.A_View());
        }


        //EDIT RECORDS
        private void editRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDI.checkMdi(new WFORMS.A_Edit());
        }

        //DEL RECORDS
        private void deleteRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDI.checkMdi(new WFORMS.A_Del());
        }

        //MY DETAILS
        private void myDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDI.checkMdi(new WFORMS.U_details());
        }

        //Shop
        private void shopProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDI.checkMdi(new WFORMS.U_shopprod());
        }


        //MY ORDERS
        private void myOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDI.checkMdi(new WFORMS.U_orders());
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logOutToolStripMenuItem.Enabled = false;
            transactionToolStripMenuItem.Enabled = false;
            fileMaintenanceToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Enabled = true;
            signUpToolStripMenuItem.Enabled = true;

            this.Hide();
            new TOLEDO_ACT4().ShowDialog();
        }
    }
}
