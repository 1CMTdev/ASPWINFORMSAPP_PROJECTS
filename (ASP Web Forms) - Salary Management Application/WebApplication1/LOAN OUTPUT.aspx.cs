using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABCclass;

namespace WebApplication1
{

    public partial class LOAN_OUTPUT : System.Web.UI.Page
    {
        Data myData = new Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            qname.Text = Data.Xemail;
            Label1.Text = Data.Xloanamm.ToString()+" PHP";
            Label2.Text = Data.Xinterest.ToString() + " PHP";
            Label3.Text = Data.Xthml.ToString() + " PHP";
            Label4.Text = Data.Xserv.ToString() + " PHP";
            Label5.Text = Data.Xmoarm.ToString() + " PHP";
            myData.reset();



        }
    }
}