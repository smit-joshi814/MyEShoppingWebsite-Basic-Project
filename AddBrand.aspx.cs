using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class AddBrand : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBrandRepeater();
        }
    }

    private void BindBrandRepeater()
    {
        SqlCommand cmd = new SqlCommand("Select * from tblBrands");
        DataSet ds = shop.RunSelectQuery(cmd);
        RepeaterBrands.DataSource = ds.Tables[0];
        RepeaterBrands.DataBind();
    }


    protected void btnAddBrand_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into tblBrands (Name) values ( @newBrand)");
        cmd.Parameters.AddWithValue("@newBrand", txtBrand.Text);
        shop.RunNonQuery(cmd);
        txtBrand.Text = null;
        lblAddBrandMsg.CssClass = "text-success";
        lblAddBrandMsg.Text = "Brand Added SuccessFully";
        txtBrand.Focus();
        BindBrandRepeater();
    }
}