using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindCartNumber();
        if (Session["Username"] != null)
        {
            btnSignUp.Visible = false;
            btnSignIn.Visible = false;
            btnLogout.Visible = true;
        }
        else
        {
            btnSignUp.Visible = true;
            btnSignIn.Visible = true;
            btnLogout.Visible = false;
        }
    }

    private void BindCartNumber()
    {
        if (Request.Cookies["CartPID"] != null)
        {
            try
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int ProductCount = ProductArray.Length;
                pCount.InnerText = ProductCount.ToString();
            }
            catch (IndexOutOfRangeException)
            {
                pCount.InnerText = 0.ToString();
            }
        }
        else
        {
            pCount.InnerText = 0.ToString();
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session["Username"] = null;
        Response.Redirect("~/index.aspx");
    }
}
