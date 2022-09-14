using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABCclass;
namespace WebApplication1
{
    public partial class LOAN : System.Web.UI.Page
    {
        Data myData = new Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text=Data.Xemail;

        }



        protected void Button1_Click(object sender, EventArgs e)
        {



            myData.computerx(Convert.ToDouble(TextBox1.Text), Convert.ToDouble(TextBox2.Text));
            Response.Redirect("LOAN OUTPUT.aspx");

        }
    }
}