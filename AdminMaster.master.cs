using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            if (Session["UserType"].ToString() == "Admin")
            {
            }
            else
            {
                Response.Redirect("~/index.aspx");
            }
        }
        else Response.Redirect("~/SignIn.aspx");
    }
    protected void Adminout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session["Username"] = null;
        Response.Redirect("~/index.aspx");
    }
}
