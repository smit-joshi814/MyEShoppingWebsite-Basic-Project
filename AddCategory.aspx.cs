using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCategory : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategoryRepeater();
        }
    }

    private void BindCategoryRepeater()
    {
        SqlCommand cmd = new SqlCommand("Select * from tblCategory");
        DataSet ds = shop.RunSelectQuery(cmd);
        RepeaterCategory.DataSource = ds.Tables[0];
        RepeaterCategory.DataBind();


    }
    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into tblCategory (CatName) values ( @newCat)");
        cmd.Parameters.AddWithValue("@newCat", txtCategory.Text);
        shop.RunNonQuery(cmd);
        txtCategory.Text = null;
        lblAddCategoryMsg.CssClass = "text-success";
        lblAddCategoryMsg.Text = "Category Added SuccessFully";
        txtCategory.Focus();
        BindCategoryRepeater();
    }
}