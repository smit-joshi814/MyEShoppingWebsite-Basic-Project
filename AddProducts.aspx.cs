using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class AddProducts : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBrands();
            BindMainCat();
            BindGender();
            ddlSubCategory.Enabled = false;
            ddlGender.Enabled = false;
        }
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

    private void BindMainCat()
    {
        SqlCommand cmd=new SqlCommand("Select * from tblCategory");
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

    private void BindBrands()
    {
        SqlCommand cmd=new SqlCommand("Select * from tblBrands");
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);
        SqlCommand cmd = new SqlCommand("sp_InsertProduct", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PName", txtProductName.Text);
        cmd.Parameters.AddWithValue("@PPrice", txtPrice.Text);
        cmd.Parameters.AddWithValue("@PSelPrice", txtSellPrice.Text);
        cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@PGenderID", ddlGender.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
        cmd.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text);
        cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
        if (chFD.Checked == true)
        {
            cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
        }

        if (ch30Ret.Checked == true)
        {
            cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@30DayRet", 0.ToString());
        }
        if (chCOD.Checked == true)
        {
            cmd.Parameters.AddWithValue("@COD", 1.ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@COD", 0.ToString());
        }
        cn.Open();
        Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());

        for (int i = 0; i < cblSize.Items.Count; i++)
        {
            if (cblSize.Items[i].Selected == true)
            {
                Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                int Quantity = Convert.ToInt32(txtQuantity.Text);
                SqlCommand cmd2 = new SqlCommand("Insert into tblProductSizeQuantity values(@PID,@SizeID,@Quantity)");
                cmd2.Parameters.AddWithValue("@PID", PID);
                cmd2.Parameters.AddWithValue("@SizeID", SizeID);
                cmd2.Parameters.AddWithValue("@Quantity", Quantity);
                shop.RunNonQuery(cmd2);
                cblSize.Items[i].Selected = false;
            }
        }
        cn.Close();

        //Image 1 Upload
        if (fuImg01.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
            fuImg01.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "01" + Extention);
            SqlCommand cmd3 = new SqlCommand("Insert into tblProductImages values(@PID,@Name,@Extention)");
            cmd3.Parameters.AddWithValue("@PID", PID);
            cmd3.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "01");
            cmd3.Parameters.AddWithValue("@Extention", Extention);
            shop.RunNonQuery(cmd3);
        }
        //Image 2 Upload
        if (fuImg02.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg02.PostedFile.FileName);
            fuImg02.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "02" + Extention);
            SqlCommand cmd4 = new SqlCommand("Insert into tblProductImages values(@PID,@Name,@Extention)");
            cmd4.Parameters.AddWithValue("@PID", PID);
            cmd4.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "02");
            cmd4.Parameters.AddWithValue("@Extention", Extention);
            shop.RunNonQuery(cmd4);
        }
        //Image 3 Upload
        if (fuImg03.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg03.PostedFile.FileName);
            fuImg03.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "03" + Extention);
            SqlCommand cmd5 = new SqlCommand("Insert into tblProductImages values(@PID,@Name,@Extention)");
            cmd5.Parameters.AddWithValue("@PID", PID);
            cmd5.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "03");
            cmd5.Parameters.AddWithValue("@Extention", Extention);
            shop.RunNonQuery(cmd5);
        }
        //Image 4 Upload
        if (fuImg04.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg04.PostedFile.FileName);
            fuImg04.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "04" + Extention);
            SqlCommand cmd6 = new SqlCommand("Insert into tblProductImages values(@PID,@Name,@Extention)");
            cmd6.Parameters.AddWithValue("@PID", PID);
            cmd6.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "04");
            cmd6.Parameters.AddWithValue("@Extention", Extention);
            shop.RunNonQuery(cmd6);
        }
        //Image 5 Upload
        if (fuImg05.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg05.PostedFile.FileName);
            fuImg05.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "05" + Extention);
            SqlCommand cmd7 = new SqlCommand("Insert into tblProductImages values(@PID,@Name,@Extention)");
            cmd7.Parameters.AddWithValue("@PID", PID);
            cmd7.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "05");
            cmd7.Parameters.AddWithValue("@Extention", Extention);
            shop.RunNonQuery(cmd7);
        }

        txtProductName.Text = null;
        txtPrice.Text = null;
        txtSellPrice.Text = null;
        ddlBrand.SelectedIndex = 0;
        ddlCategory.SelectedIndex = 0;
        ddlSubCategory.SelectedIndex = 0;
        ddlGender.SelectedIndex = 0;
        txtQuantity.Text = null;
        txtDescription.Text = null;
        txtPDetail.Text = null;
        txtMatCare.Text = null;
        ch30Ret.Checked = false;
        chFD.Checked = false;
        chCOD.Checked = false;
        lblAddProductMsg.Text = "Product Added SuccessFully";
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedIndex != 0)
        {
            int CatId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            ddlSubCategory.Enabled = true;
            SqlCommand cmd = new SqlCommand("Select * from tblSubCategory where MainCatID=@CatID");
            cmd.Parameters.AddWithValue("@CatID", CatId);
            DataSet ds = shop.RunSelectQuery(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSubCategory.DataSource = ds.Tables[0];
                ddlSubCategory.DataTextField = "SubCatName";
                ddlSubCategory.DataValueField = "SubCatID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }
        else
        {
            ddlSubCategory.Enabled = false;
        }
    }
    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Select SizeID,SizeName from tblSizes where BrandID=@BrandID and CategoryID=@CategoryID and SubCategoryID=@SubCategoryID and GenderID=GenderID");
        cmd.Parameters.AddWithValue("@BrandID", ddlBrand.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@SubCategoryID", ddlSubCategory.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@GenderID", ddlGender.SelectedItem.Value);
        DataSet ds = shop.RunSelectQuery(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cblSize.DataSource = ds.Tables[0];
            cblSize.DataTextField = "Sizename";
            cblSize.DataValueField = "SizeID";
            cblSize.DataBind();
        }
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubCategory.SelectedIndex != 0)
        {
            ddlGender.Enabled = true;
        }
        else
        {
            ddlGender.Enabled = false;
        }
    }
}