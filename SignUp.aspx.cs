using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUp : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void signUp_Click(object sender, EventArgs e)
    {
        if (IsFormValid())
        {
            
            SqlCommand cmd = new SqlCommand("Insert into tblUsers (username,password,email,Name,UserType) values (@uName,@Pass,@Email,@Name,'User')");
            cmd.Parameters.AddWithValue("@uName", txtUname.Text);
            cmd.Parameters.AddWithValue("@Pass", pass.Text);
            cmd.Parameters.AddWithValue("@Email", email.Text);
            cmd.Parameters.AddWithValue("@Name", FullName.Text);
            shop.RunNonQuery(cmd);
            suMsg.Text = "Registration SuccessFully";
            clr();
            Response.Redirect("~/SignIn.aspx");
        }
    }
    private bool IsFormValid()
    {
        if (Isvalidname.IsValid && IsValidUname.IsValid && Isvalidemail.IsValid && IsPassvalid.IsValid)
        {
            return true;
        }
        else
            return false;
    }
    private void clr()
    {
        txtUname.Text = null;
        email.Text = null;
        FullName.Text = null;
        pass.Text = null;
        ConPass.Text = null;
    }
}