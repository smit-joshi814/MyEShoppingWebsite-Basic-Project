using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

public partial class ForgetPassword : System.Web.UI.Page
{
    EShoppingWebService shop = new EShoppingWebService();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RecoverPass_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from tblUsers where email=@email");
        cmd.Parameters.AddWithValue("@email", userEmail.Text);
        DataSet ds = shop.RunSelectQuery(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            String myGUID = Guid.NewGuid().ToString();
            int uid = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            SqlCommand cmd1 = new SqlCommand("Insert into ForgotPass (Id,Uid,RequestDateTime) values(@id,@uid,GETDATE())");
            cmd1.Parameters.AddWithValue("@Id", myGUID);
            cmd1.Parameters.AddWithValue("uid", uid);
            shop.RunNonQuery(cmd1);
            

            //===>   Send Reset Link To Email    <===

            string ToEmailAddress = ds.Tables[0].Rows[0][3].ToString();
            string UserName = ds.Tables[0].Rows[0][1].ToString();
            string Emailbody = "Hi, " + UserName + ",<br/><br/>Click The Link Below To Reset Password<br/> http://localhost:40551/RecoverPassword.aspx?Id=" + myGUID;

            MailMessage PassRecmail = new MailMessage("myeshoopmailservice@gmail.com", ToEmailAddress);
            PassRecmail.Body = Emailbody;
            PassRecmail.IsBodyHtml = true;
            PassRecmail.Subject = "Reset Password";
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

            //=====

            lblResetPassMsg.CssClass = "text-success";
            lblResetPassMsg.Text = "Reset Link Sent, Please Check Your Mail Box";
        }
        else
        {
            userEmail.Text = null;
            lblResetPassMsg.CssClass = "text-danger";
            lblResetPassMsg.Text = "Opps! User Not Found For Given Email Addresss";
            userEmail.Focus();
        }
    }
}