using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    Int64 UID;
    int Result;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            UID = Convert.ToInt64(Session["Uid"].ToString());
            Result = IsDetailAvailable(UID);
            chbSaveInfo.Checked = true;
            if (!IsPostBack)
            {
                if (Request.QueryString["Checkout"] == "true")
                {
                    BindPayment();
                }
                else
                {
                    Response.Redirect("~/Cart.aspx");
                }
                if (chbSameAdd.Checked == true) ShippingAdd.Visible = false;
                if (rbPayMethod.SelectedIndex == 3) PaymentMethod.Visible = false;
            }
        }
        else
        {
            Response.Redirect("~/SignIn.aspx?rurl=Payment");
        }
    }

    private void BindPayment()
    {
        if (Request.Cookies["CartPID"] != null)
        {

            DataSet ds = new DataSet();
            Int64 CartTotal = 0;
            Int64 Total = 0;
            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');
            if (CookieDataArray.Length > 0)
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);
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
                    CartTotal += Convert.ToInt64(ds.Tables[0].Rows[i]["PPrice"]);
                    Total += Convert.ToInt64(ds.Tables[0].Rows[i]["PSelPrice"]);
                }
            }
            pCountBill.InnerText = CookieDataArray.Length.ToString();

            rptrProdName.DataSource = ds;
            rptrProdName.DataBind();

            TotalAmount.InnerText = "₹ " + Total;
            TotDiscoount.InnerText = "₹ " + (Total - CartTotal).ToString();
            GrandTotal.InnerText = "₹ " + CartTotal.ToString();


            //FOR Billing ADDRESS #COUNTRIES #NAME #EMAIL #USERNAME
            SqlCommand cmd2 = new SqlCommand("SELECT CID,CNAME FROM tblCountries");

            SqlCommand cmd3;
            if (Result == 1)
            {
                cmd3 = new SqlCommand("SELECT A.Name AS UName,A.email AS UserEmail,A.username AS UserName,B.* FROM tblUsers A CROSS APPLY(SELECT TOP 1 B.* FROM tblAddressDetails B WHERE UID=@UID)B WHERE A.Uid=@UID");
            }
            else
            {
                cmd3 = new SqlCommand("SELECT Name AS UName,email AS UserEmail,username AS UserName FROM tblUsers WHERE Uid=@UID");
            }
            cmd3.Parameters.AddWithValue("@UID", UID);
            DataSet ds1 = shop.RunSelectQuery(cmd2);


            // Binding 
            dplCountry.DataSource = ds1.Tables[0];
            dplCountry.DataTextField = "CNAME";
            dplCountry.DataValueField = "CID";
            dplCountry.DataBind();
            dplCountry.Items.Insert(0, new ListItem("-Select-", "0"));
            dplState.Enabled = false;
            //FOR Shipping ADDRESS #COUNTRIES
            dplState1.Enabled = false;


            DataSet ds2 = shop.RunSelectQuery(cmd3);

            txtfName.Text = ds2.Tables[0].Rows[0][0].ToString();
            txtUName.Text = ds2.Tables[0].Rows[0][2].ToString();
            txtEmail.Text = ds2.Tables[0].Rows[0][1].ToString();
            if (Result == 1)
            {
                txtAddress.Text = ds2.Tables[0].Rows[0][4].ToString();
                dplCountry.SelectedIndex = Convert.ToInt32(ds2.Tables[0].Rows[0][6].ToString());
                dplCountry_SelectedIndexChanged(dplCountry, new EventArgs());
                dplState.SelectedIndex = Convert.ToInt32(ds2.Tables[0].Rows[0][7].ToString());
                txtZip.Text = ds2.Tables[0].Rows[0][5].ToString();
                chbSaveInfo.Checked = true;
            }
        }
        else
        {
            Response.Redirect("~/Products.aspx");
        }
    }
    protected void chbSameAdd_CheckedChanged(object sender, EventArgs e)
    {
        if (chbSameAdd.Checked == true)
        {
            ShippingAdd.Visible = false;
        }
        else
        {
            ShippingAdd.Visible = true;
        }
    }
    protected void rbPayMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbPayMethod.SelectedIndex == 3)
        {
            PaymentMethod.Visible = false;
        }
        else
        {
            PaymentMethod.Visible = true;
        }
    }
    protected void dplCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SELECT Sid,State FROM tblStateList WHERE CID = @CID");
        cmd.Parameters.AddWithValue("@CID", dplCountry.SelectedItem.Value);
        DataSet ds = shop.RunSelectQuery(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dplState.Enabled = true;
            dplState1.Enabled = true;
            dplState.DataSource = ds.Tables[0];
            dplState1.DataSource = ds.Tables[0];
            dplState.DataTextField = "State";
            dplState1.DataTextField = "State";
            dplState.DataValueField = "Sid";
            dplState1.DataValueField = "Sid";
            dplState.DataBind();
            dplState1.DataBind();
            dplState.Items.Insert(0, new ListItem("-Select-", "0"));
            dplState1.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        else
        {
            dplState.Items.Insert(0, new ListItem("Can't Ship To " + dplCountry.SelectedItem.Text, "0"));
            dplState1.Items.Insert(0, new ListItem("Can't Ship To " + dplCountry.SelectedItem.Text, "0"));
            dplState.Enabled = false;
            dplState1.Enabled = false;
        }
    }
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        if (Session["Uid"] != null)
        {
            if (chbSaveInfo.Checked == true)
            {
                if (Result == 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblAddressDetails (Address,ZIP,CID,SID,UID) VALUES (@Address,@ZIP,@CID,@SID,@UID)");
                    cmd.Parameters.AddWithValue("Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ZIP", txtZip.Text);
                    cmd.Parameters.AddWithValue("@CID", dplCountry.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@SID", dplState.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@UID", UID);
                    shop.RunNonQuery(cmd);
                }
            }



            //=====
            Int64 CartTotal = 0;
            Int64 Total = 0;
            String ProductsPurchased="";
            DataSet ds = new DataSet();
            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');
            if (CookieDataArray.Length > 0)
            {
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string PID = CookieDataArray[i].ToString().Split('-')[0];
                    string SizeID = CookieDataArray[i].ToString().Split('-')[1];
                    SqlCommand cmd = new SqlCommand("ps_BindCart");
                    cmd.Parameters.AddWithValue("@PID", PID);
                    cmd.Parameters.AddWithValue("@SizeID", SizeID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    ds = shop.RunSelectQuery(cmd);
                    CartTotal += Convert.ToInt64(ds.Tables[0].Rows[0]["PPrice"]);
                    Total += Convert.ToInt64(ds.Tables[0].Rows[0]["PSelPrice"]);

                    //Updating Quntity
                    SqlCommand cmd3 = new SqlCommand("UPDATE tblProductSizeQuantity SET Quantity=Quantity-1 WHERE PID=@PID and SizeID=@SizeID");
                    cmd3.Parameters.AddWithValue("@PID", PID);
                    cmd3.Parameters.AddWithValue("@SizeID", SizeID);
                    shop.RunNonQuery(cmd3);

                    // getting Purchased Product Names
                    SqlCommand cmd4 = new SqlCommand("SELECT A.PName,A.PDescription,B.Sizename,A.PPrice from tblProducts A CROSS APPLY ( SELECT SizeName FROM tblSizes B WHERE B.SizeID=@SizeID )B WHERE A.PID = @PID");
                    cmd4.Parameters.AddWithValue("@PID", PID);
                    cmd4.Parameters.AddWithValue("@SizeID", SizeID);
                    DataSet ds4 = shop.RunSelectQuery(cmd4);

                    ProductsPurchased += "<div style='border:1px solid #000;border-radius: 20px;width: fit-content;margin: 5px;padding:10px;display: flex;flex-direction: row;'><p><b>" + (i + 1) + "</b>&nbsp;&nbsp;" + ds4.Tables[0].Rows[0][0].ToString() + "&nbsp;&nbsp;Size : <b><tt>" + ds4.Tables[0].Rows[0][2].ToString() + "</tt></b><br/><small>" + ds4.Tables[0].Rows[0][1].ToString().Take(40).Aggregate("", (x, y) => x + y)+ "...</small><br/>Worth: <tt style='color:green;'>Rs. " + ds4.Tables[0].Rows[0][3].ToString() + "</tt></p><img style='border:1px solid rgb(53, 119, 232);margin-left:20px;margin-top:25px;width:100px;height:100px' src='https://rukminim1.flixcart.com/image/832/832/xif0q/shoe/t/i/p/-original-imagg3a8xtp3cgjj.jpeg?q=70'  alt='" + ds4.Tables[0].Rows[0][0].ToString() + "' /></div>";
                }
            }
            /* MAIL START */
            string ToEmailAddress = txtEmail.Text;
            string UserName = txtUName.Text;
            String Emailbody = "Hi ,<b>" + UserName + "</b><br/> <h4 style='font-size: 30px;font-weight: 300;line-height: 1;color:#14cda8;text-align:center'>Order Placed SuccessFully</h4><h6 style='color:#000;'>Ordered Items</h6><br/><br/><br/>" + ProductsPurchased + "<br/><br/><br/><br/><br/>Regards,<h3>Team@MyEShoppingSite</h3>";
            MailMessage PassRecmail = new MailMessage("myeshoopmailservice@gmail.com", ToEmailAddress);
            PassRecmail.Body = Emailbody;
            PassRecmail.IsBodyHtml = true;
            PassRecmail.Subject = "Thank You For Purchase -MyEShoppingSite ";
            SmtpClient SMTP = new SmtpClient();
            SMTP.Host = "smtp.gmail.com";
            SMTP.Port = 587;
            SMTP.EnableSsl = true;
            SMTP.UseDefaultCredentials = true;
            SMTP.Credentials = new NetworkCredential()
            {
                UserName = "myeshoopmailservice@gmail.com",
                Password = "vegteyxjdtxdzigz"
            };

            SMTP.Send(PassRecmail);

            /* MAIL END */

            SqlCommand cmd2 = new SqlCommand("ps_NewPurchase");
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@UserID", UID);
            cmd2.Parameters.AddWithValue("@PIDSizeID", CookieData);
            cmd2.Parameters.AddWithValue("@CartAmount", Total);
            cmd2.Parameters.AddWithValue("@CartDiscount", (Total - CartTotal));
            cmd2.Parameters.AddWithValue("@TotalPayed", CartTotal);
            cmd2.Parameters.AddWithValue("@PaymentType", rbPayMethod.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@PaymentStatus", rbPayMethod.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@DateOfPurchase", DateTime.Now);
            shop.RunNonQuery(cmd2);




            //Clearing Cookies
            HttpCookie CartProducts = Request.Cookies["CartPID"];
            CartProducts.Values["CartPID"] = null;
            CartProducts.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(CartProducts);

            //Redirecting To User Home Page

            Response.Redirect("~/userHome.aspx?Order=success");

        }
    }
    private int IsDetailAvailable(Int64 uid)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);
        SqlCommand cmd = new SqlCommand("SELECT dbo.IsAddressAvailable(@UID) FROM tblAddressDetails", cn);
        cmd.Parameters.AddWithValue("@UID", uid);
        cn.Open();
        try
        {
            Convert.ToInt64(cmd.ExecuteScalar());
            return 1;
        }
        catch (InvalidCastException)
        {
            return 0;
        }
        finally
        {
            cn.Close();
        }
    }
}