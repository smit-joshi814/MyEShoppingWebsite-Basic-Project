using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UNAME"] != null && Request.Cookies["UPASS"] != null)
            {
                username.Text = Request.Cookies["UNAME"].Value;
                password.Text = Request.Cookies["UPASS"].Value;
                remember.Checked = true;
            }
        }
    }
    protected void signIn_Click(object sender, EventArgs e)
    {
        if (IsFormValid())
        {
            
            SqlCommand cmd = new SqlCommand("select * from tblUsers where username=@username and password=@password");
            cmd.Parameters.AddWithValue("@username", username.Text);
            cmd.Parameters.AddWithValue("@password", password.Text);

            DataSet ds = shop.RunSelectQuery(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (remember.Checked)
                {
                    Response.Cookies["UNAME"].Value = username.Text;
                    Response.Cookies["UPASS"].Value = password.Text;
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["UPASS"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["UPASS"].Expires = DateTime.Now.AddDays(-1);
                }
                string UserType = ds.Tables[0].Rows[0][5].ToString().Trim();
                Session["Username"] = username.Text;
                Session["Uid"] = ds.Tables[0].Rows[0][0];
                Session["UserType"] = ds.Tables[0].Rows[0][5];
                if (UserType == "User")
                {
                    if (Request.QueryString["rurl"] != null)
                    {
                        if (Request.QueryString["rurl"] == "Cart")
                            Response.Redirect("~/Cart.aspx");
                        if (Request.QueryString["rurl"] == "Payment")
                            Response.Redirect("~/Payment.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/userHome.aspx");
                    }
                }
                else if (UserType == "Admin")
                {
                    Response.Redirect("~/AdminHome.aspx");
                }
                cls();
            }
            else
            {
                siMsg.CssClass = "text-danger";
                siMsg.Text = "Invalid Credintatials";
            }
        }
    }

    private void cls()
    {
        username.Text = null;
        password.Text = null;
    }

    private bool IsFormValid()
    {
        if (username.Text != "" && password.Text != "")
        {
            return true;
        }
        else
        {
            siMsg.CssClass = "text-danger";
            siMsg.Text = "Please Insert Username And Password";
            return false;
        }
    }
}