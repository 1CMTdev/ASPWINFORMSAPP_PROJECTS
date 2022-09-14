using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOLEDO_act4.WFORMS
{
    public partial class A_View : Form
    {
        public A_View()
        {
            InitializeComponent();
        }

        private void A_View_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.ACCTable' table. You can move, or remove it, as needed.
            this.aCCTableTableAdapter.Fill(this.database1DataSet.ACCTable);

        }
    }
}
