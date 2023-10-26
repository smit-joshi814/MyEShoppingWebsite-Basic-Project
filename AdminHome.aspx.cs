using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class AdminHome : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            AdminGreet.Text = "Welcome To Admin Panal, " + Session["Username"];
            BindPurchase();
        }
        else Response.Redirect("~/SignIn.aspx");
    }

    private void BindPurchase()
    {
        SqlCommand cmd = new SqlCommand("SELECT A.*,B.Address,B.ZIP,C.username FROM tblOrders A INNER JOIN tblAddressDetails B ON A.UserID=B.UID CROSS APPLY ( SELECT username FROM tblUsers C WHERE A.UserID=C.Uid)C ");
        DataSet ds = shop.RunSelectQuery(cmd);
        RepeaterAdmin.DataSource = ds.Tables[0];
        RepeaterAdmin.DataBind();
    }
}