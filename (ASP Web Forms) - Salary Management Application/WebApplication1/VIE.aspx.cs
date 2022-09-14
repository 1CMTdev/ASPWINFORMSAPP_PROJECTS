using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABCclass;

namespace WebApplication1
{
    public partial class VIE : System.Web.UI.Page
    {

        Data myData = new Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = myData.DisplayMyRecords();
            GridView1.DataBind();



      
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}