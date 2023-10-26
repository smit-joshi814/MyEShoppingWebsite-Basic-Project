using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddSize : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBrands();
            BindMainCat();
            BindGender();
            BindRepeaterSize();
            ddlSubcategory.Enabled = false;
        }

    }

    private void BindRepeaterSize()
    {
        SqlCommand cmd = new SqlCommand("Select A.*,B.CatName,C.Name,D.SubCatName,E.GenderName from tblSizes A inner join tblCategory B on B.CatID=A.CategoryID inner join tblBrands C on C.BrandID = A.BrandID inner join tblSubCategory D on D.SubCatID=A.SubCategoryID inner join tblGender E on E.GenderID=A.GenderID");
        DataSet ds = shop.RunSelectQuery(cmd);
        RepeaterSizes.DataSource = ds.Tables[0];
        RepeaterSizes.DataBind();
    }

    private void BindGender()
    {
        SqlCommand cmd = new SqlCommand("Select * from tblGender");
        DataSet ds = shop.RunSelectQuery(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlGender.DataSource = ds.Tables[0];
            ddlGender.DataTextField = "GenderName";
            ddlGender.DataValueField = "GenderID";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));
        }
    }
    private void BindBrands()
    {
        SqlCommand cmd = new SqlCommand("Select * from tblBrands");
        DataSet ds = shop.RunSelectQuery(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBrand.DataSource = ds.Tables[0];
            ddlBrand.DataTextField = "Name";
            ddlBrand.DataValueField = "BrandID";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));
        }
    }

    private void BindMainCat()
    {
        SqlCommand cmd = new SqlCommand("Select * from tblCategory");
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
    protected void btnAddSize_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into tblSizes (SizeName,BrandID,CategoryID,SubcategoryID,GenderId) values ( @newSize , @BrandId , @CatId , @SubCatId , @GenderId )");
        cmd.Parameters.AddWithValue("@newSize", txtSize.Text);
        cmd.Parameters.AddWithValue("@BrandId", ddlBrand.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@CatId", ddlCategory.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@SubCatId", ddlSubcategory.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@GenderId", ddlGender.SelectedItem.Value);
        shop.RunNonQuery(cmd);
        lblAddSizeMsg.CssClass = "text-success";
        lblAddSizeMsg.Text = "Size Added Successfully";
        txtSize.Text = null;
        ddlBrand.ClearSelection();
        ddlBrand.Items.FindByValue("0").Selected = true;
        ddlCategory.ClearSelection();
        ddlCategory.Items.FindByValue("0").Selected = true;
        ddlSubcategory.ClearSelection();
        ddlSubcategory.Items.FindByValue("0").Selected = true;
        ddlGender.ClearSelection();
        ddlGender.Items.FindByValue("0").Selected = true;
        txtSize.Focus();
        BindRepeaterSize();
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CatId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        ddlSubcategory.Enabled = true;
        SqlCommand cmd = new SqlCommand("Select * from tblSubCategory where MainCatID=@CatID");
        cmd.Parameters.AddWithValue("@CatID", CatId);
        DataSet ds = shop.RunSelectQuery(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlSubcategory.DataSource = ds.Tables[0];
            ddlSubcategory.DataTextField = "SubCatName";
            ddlSubcategory.DataValueField = "SubCatID";
            ddlSubcategory.DataBind();
            ddlSubcategory.Items.Insert(0, new ListItem("-Select-", "0"));
        }

    }
}