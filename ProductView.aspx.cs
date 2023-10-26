using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ProductView : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    private static Int64 PID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Pid"] != null)
        {
            PID = Convert.ToInt64(Request.QueryString["Pid"]);
            if (!IsPostBack)
            {
                BindProductImages();
                BindProductDetails();
            }
        }
        else
        {
            Response.Redirect("~/Products.aspx");
        }
    }

    private void BindProductDetails()
    {
        SqlCommand cmd = new SqlCommand("select A.*,A.PSelPrice - A.PPrice AS DiscAmount from tblProducts A Where PID=@PID");
        cmd.Parameters.AddWithValue("@PID", PID);
        DataSet ds = shop.RunSelectQuery(cmd);
        RepeaterProductDetails.DataSource = ds.Tables[0];
        RepeaterProductDetails.DataBind();
    }

    private void BindProductImages()
    {

        SqlCommand cmd = new SqlCommand("select * from tblProductImages Where PID=@PID");
        cmd.Parameters.AddWithValue("@PID", PID);
        DataSet ds = shop.RunSelectQuery(cmd);
        RepeaterImage.DataSource = ds.Tables[0];
        RepeaterImage.DataBind();
    }

    protected string GetActiveImageClass(int ItemIndex)
    {
        if (ItemIndex == 0)
        {
            return "active";
        }
        else
        {
            return "";
        }
    }
    protected void RepeaterProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string BrandID = (e.Item.FindControl("hdnPBrandID") as HiddenField).Value;
            string CategoryID = (e.Item.FindControl("hdnPCategoryID") as HiddenField).Value;
            string SubCategoryID = (e.Item.FindControl("hdnPSubCatID") as HiddenField).Value;
            string GenderID = (e.Item.FindControl("hdnPGenderID") as HiddenField).Value;

            RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;

            SqlCommand cmd = new SqlCommand("select SizeID,Sizename From tblSizes Where BrandID=@BrandID and CategoryID=@CatID and SubCategoryID=@SubCatID and GenderID = @GenderID");
            cmd.Parameters.AddWithValue("@BrandID", BrandID);
            cmd.Parameters.AddWithValue("@CatID", CategoryID);
            cmd.Parameters.AddWithValue("@SubCatID", SubCategoryID);
            cmd.Parameters.AddWithValue("@GenderID", GenderID);
            DataSet ds = shop.RunSelectQuery(cmd);
            rblSize.DataSource = ds.Tables[0];
            rblSize.DataTextField = "SizeName";
            rblSize.DataValueField = "SizeID";
            rblSize.DataBind();
        }
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        String SelectedSize = string.Empty;
        foreach (RepeaterItem item in RepeaterProductDetails.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButtonList rblSize = item.FindControl("rblSize") as RadioButtonList;
                SelectedSize = rblSize.SelectedValue;
                Label lblAddTocartMsg = item.FindControl("lblAddTocartMsg") as Label;
                lblAddTocartMsg.Text = "";
            }
        }

        if (SelectedSize != "")
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                CookiePID = CookiePID + "," + PID.ToString() + "-" + SelectedSize;
                HttpCookie CartProducts = new HttpCookie("CartPID");
                CartProducts.Values["CartPID"] = CookiePID;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);
            }
            else
            {
                HttpCookie CartProducts = new HttpCookie("CartPID");
                CartProducts.Values["CartPID"] = PID.ToString() + "-" + SelectedSize;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);
            }
            Response.Redirect("~/ProductView.aspx?Pid=" + PID);
        }
        else
        {
            foreach (RepeaterItem item in RepeaterProductDetails.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblAddTocartMsg = item.FindControl("lblAddTocartMsg") as Label;
                    lblAddTocartMsg.CssClass = "text-danger";
                    lblAddTocartMsg.Text = "Please Select a Size";
                }
            }
        }
    }
}