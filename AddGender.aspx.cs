using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class AddGender : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGenderRepeater();
        }
    }

    private void BindGenderRepeater()
    {


        SqlCommand cmd = new SqlCommand("Select * from tblGender");
        DataSet ds = shop.RunSelectQuery(cmd);
        RepeaterGender.DataSource = ds.Tables[0];
        RepeaterGender.DataBind();
    }
    protected void btnAddGender_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into tblGender (GenderName) values ( @newGender )");
        cmd.Parameters.AddWithValue("@newGender", txtGender.Text);
        shop.RunNonQuery(cmd);
        lblAddGenderMsg.CssClass = "text-success";
        lblAddGenderMsg.Text = "Gender Added SuccessFully";
        txtGender.Text = null;
        txtGender.Focus();
        BindGenderRepeater();
    }
}