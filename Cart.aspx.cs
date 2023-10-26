using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Username"] != null)
        {
            if (!IsPostBack)
            {
                BindProductCart();
            }

        }
        else
        {
            Response.Redirect("~/SignIn.aspx?rurl=Cart");
        }
    }

    private void BindProductCart()
    {
        if (Request.Cookies["CartPID"] != null)
        {
            DataTable ds = new DataTable();
            Int64 CartTotal = 0;
            Int64 Total = 0;
            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);
            if (CookieDataArray.Length > 0)
            {
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string PID = CookieDataArray[i].ToString().Split('-')[0];
                    string SizeID = CookieDataArray[i].ToString().Split('-')[1];
                    SqlCommand cmd = new SqlCommand("ps_BindCart", cn);
                    cmd.Parameters.AddWithValue("@PID", PID);
                    cmd.Parameters.AddWithValue("@SizeID", SizeID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    CartTotal += Convert.ToInt64(ds.Rows[i]["PPrice"]);
                    Total += Convert.ToInt64(ds.Rows[i]["PSelPrice"]);
                }
            }
            RepeaterCartProducts.DataSource = ds;
            RepeaterCartProducts.DataBind();
            PriceDetails.Visible = true;

            spanCartTotal.InnerText = Total.ToString();
            spanGrandTotal.InnerText = CartTotal.ToString();
            spanDiscount.InnerText = (Total - CartTotal).ToString();
            NoItems.InnerText = "MY CART (" + CookieDataArray.Length.ToString() + " items)";
        }
        else
        {
            NoItems.InnerText = "There Is No Item In Cart";
        }
    }
    protected void btnRemoveCart_Click(object sender, EventArgs e)
    {
        string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
        Button btn = (Button)(sender);
        string PIDSIZE = btn.CommandArgument;
        List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
        CookiePIDList.Remove(PIDSIZE);
        string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
        if (CookiePIDUpdated == "")
        {
            HttpCookie CartProducts = Request.Cookies["CartPID"];
            CartProducts.Values["CartPID"] = null;
            CartProducts.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(CartProducts);

        }
        else
        {
            HttpCookie CartProducts = Request.Cookies["CartPID"];
            CartProducts.Values["CartPID"] = CookiePIDUpdated;
            CartProducts.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(CartProducts);
        }
        Response.Redirect("~/Cart.aspx");
    }
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            try
            {
                Response.Redirect("~/Payment.aspx?Checkout=true");
            }
            catch (IndexOutOfRangeException)
            {
                Response.Redirect("~/Products.aspx");
            }
        }
        else
        {
            Response.Redirect("~/SignIn.aspx?rurl=Cart");
        }

    }
}