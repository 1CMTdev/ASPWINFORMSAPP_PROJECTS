using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABCclass;


namespace WebApplication1
{
    public partial class REG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {




        }
        Data myData = new Data();
        protected void Button1_Click(object sender, EventArgs e)
        {


            try
            {
                myData.SaveRecords(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text);
                Response.Redirect("LOAN.aspx");
            }
            catch
            {
                Response.Write("<script> alert('Record already Exist!!! : ACCESS DENIED')</script>");
            }
        }
    }
}