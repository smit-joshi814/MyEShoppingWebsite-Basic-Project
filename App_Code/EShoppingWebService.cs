using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for EShoppingWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EShoppingWebService : System.Web.Services.WebService {

    public EShoppingWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]

    public DataSet RunSelectQuery(SqlCommand cmd) {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);
        cmd.Connection = cn;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        return ds;
    }
    public void RunNonQuery(SqlCommand cmd)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);
        cmd.Connection = cn;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
}
