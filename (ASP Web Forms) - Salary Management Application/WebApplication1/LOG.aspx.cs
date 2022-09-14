using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABCclass;

namespace WebApplication1
{
    public partial class LOG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        Data myData = new Data();
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (myData.CheckUserAccount(TextBox1.Text, TextBox2.Text))
            {
                Response.Redirect("LOAN OUTPUT.aspx");
                
            }
            else
                Response.Write("<script> alert('NO ACCOUNT : ACCESS DENIED')</script>");



        }
    }
}