using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            UserGreet.Text = "Login Success, Welcome " + Session["Username"].ToString();
        }
        if (Request.QueryString["Order"] == "success")
        {
            lblOrderPlaced.Text = "Order Placed SuccessFully !<br/> Check Your Mail Box For More Details";
        }
    }
}