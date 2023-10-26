using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubCategory : System.Web.UI.Page
{
    EShoppingWebService shop=new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMainCat();
            BindSubCategoryRepeater();
        }
    }

    private void BindSubCategoryRepeater()
    {
        SqlCommand cmd = new SqlCommand("Select A.*,B.CatName from tblSubCategory A inner join tblCategory B on B.CatID = A.MainCatID");
        DataSet ds = shop.RunSelectQuery(cmd);
        RepeaterSubCategory.DataSource = ds.Tables[0];
        RepeaterSubCategory.DataBind();
    }

    private void BindMainCat()
    {
        SqlCommand cmd = new SqlCommand("Select * from tblcategory");
        DataSet ds = shop.RunSelectQuery(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCategory.DataSource = ds.Tables[0];
            ddlCategory.DataTextField = "CatName";
            ddlCategory.DataValueField = "CatID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
        }
    }
    protected void btnAddSubCategory_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into tblSubCategory ( SubCatName , MainCatID ) values ( @newSubCat , @catId)");
        cmd.Parameters.AddWithValue("@catId", ddlCategory.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@newSubCat", txtSubCategory.Text);
        shop.RunNonQuery(cmd);
        lblAddSubCategoryMsg.CssClass = "text-success";
        lblAddSubCategoryMsg.Text = "Sub Category Added";
        txtSubCategory.Text = null;
        txtSubCategory.Focus();
        BindSubCategoryRepeater();
    }
}