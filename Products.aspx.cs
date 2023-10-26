using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Products : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProductReapeter();
        }
    }

    private void BindProductReapeter()
    {
        SqlCommand cmd = new SqlCommand("ProBindAllProducts");
        cmd.CommandType = CommandType.StoredProcedure;
        DataSet ds = shop.RunSelectQuery(cmd);
        RepeaterProducts.DataSource = ds.Tables[0];
        RepeaterProducts.DataBind();
    }
}