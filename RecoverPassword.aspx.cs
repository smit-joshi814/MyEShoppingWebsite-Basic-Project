using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecoverPassword : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    string myGuid;
    DataSet ds = new DataSet();
    int Uid;
    protected void Page_Load(object sender, EventArgs e)
    {
        myGuid = Request.QueryString["Id"];
        if (myGuid != null)
        {
            SqlCommand cmd = new SqlCommand("Select Uid from ForgotPass Where Id=@Id");
            cmd.Parameters.AddWithValue("@Id", myGuid);
            ds = shop.RunSelectQuery(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Uid = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            else
            {
                lblResetPassMsg.CssClass = "text-danger";
                lblResetPassMsg.Text = "Your Password Link Is Expired Or Invalid ! Try Again";
            }
        }
        else
        {
            Response.Redirect("~/index.aspx");
        }
        if (!IsPostBack)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                userPass.Visible = true;
                userPassCon.Visible = true;
                lblConPass.Visible = true;
                lblnewPass.Visible = true;
                RecoverPass.Visible = true;
            }
        }
    }
    protected void RecoverPass_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("update tblUsers set password=@pass where Uid=@uid");
        SqlCommand cmd1 = new SqlCommand("Delete from ForgotPass where Uid=@uid");
        cmd.Parameters.AddWithValue("@uid", Uid);
        cmd1.Parameters.AddWithValue("@uid", Uid);
        cmd.Parameters.AddWithValue("@pass", userPass.Text);
        shop.RunNonQuery(cmd);
        shop.RunNonQuery(cmd1);
        Response.Write("<script>alert('Password Reset Successfully')</script>");
        Response.Redirect("~/SignIn.aspx");
    }
}