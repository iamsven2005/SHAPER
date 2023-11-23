using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using BCrypt.Net;
using AjaxControlToolkit.HTMLEditor.ToolbarButton;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["Search"] = txtSearch.Text;
        Response.Redirect("Search.aspx");
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //Guid newGUID = Guid.NewGuid();
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString);
        
        //conn.Open();

        //bool exists = false;

        //using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [REGISTRATION] WHERE Email = @email", conn))
        //{
        //    //checks if the email that the user has entered exists in the database table
        //    cmd.Parameters.AddWithValue("Email", txt_RegEmail.Text);
        //    exists = (int)cmd.ExecuteScalar() > 0;
        //}

        //if (exists)
        //{
        //    Response.Write("<script>alert('Sorry, Email is already taken!');</script>");
        //}

        //else
        //{
            string Password = BCrypt.Net.BCrypt.HashPassword(txt_RegPassword.Text);

            // Resolve the absolute paths
            string passwordsFilePath = Server.MapPath("~/Users/passwords.txt");
            string themesFilePath = Server.MapPath("~/Users/themes.txt");
            string creditsFilePath = Server.MapPath("~/Users/credits.txt");
            string namesFilePath = Server.MapPath("~/Users/names.txt");

            // Append hashed password to passwords.txt
            File.AppendAllText(passwordsFilePath, $"{txt_RegEmail.Text}: {Password}" + Environment.NewLine);
            File.AppendAllText(themesFilePath, $"{txt_RegEmail.Text}: default" + Environment.NewLine);
            File.AppendAllText(creditsFilePath, $"{txt_RegEmail.Text}: 200" + Environment.NewLine);
            File.AppendAllText(namesFilePath, $"{txt_RegEmail.Text}: {txt_Name.Text}" + Environment.NewLine);

            Response.Write("<script>alert(' <div class=\"alert alert-success\" id=\"alert\">Successfully created account! Welcome!\r\n    < button onclick = \"closeAlert()\" class= \"float-right text-white\" >×</ button ></ div >');</script>");
        //}

        //conn.Close();

        //txt_Name.Text = "";

        //txt_RegEmail.Text = "";
    }
   
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
            Session["Email"] = txt_Email.Text;
            string filePathCrd = Server.MapPath("~/Users/credits.txt");
            string[] linesCrd = File.ReadAllLines(filePathCrd);
            string targetLineCrd = Array.Find(linesCrd, line => line.StartsWith(txt_Email.Text + ":"));
            string[] partsCrd = targetLineCrd.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            Session["Credit"] = partsCrd[1].Trim();
            string filePathThm = Server.MapPath("~/Users/themes.txt");
            string[] linesThm = File.ReadAllLines(filePathThm);
            string targetLineThm = Array.Find(linesThm, line => line.StartsWith(txt_Email.Text + ":"));
            string[] partsThm = targetLineThm.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            Session["Theme"] = partsThm[1].Trim();
            string filePathPwd = Server.MapPath("~/Users/passwords.txt");
            string[] linesPwd = File.ReadAllLines(filePathPwd);
            string targetLinePwd = Array.Find(linesPwd, line => line.StartsWith(txt_Email.Text + ":"));
            string[] partsPwd = targetLinePwd.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string password = partsPwd[1].Trim().ToString();
            bool flag = BCrypt.Net.BCrypt.Verify(txt_Password.Text, password);
            if (flag == true)
            {
                Session["CHANGE_MASTERPAGE"] = "~/AfterLogin.Master";
                Session["CHANGE_MASTERPAGE2"] = null;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
            }
        txt_Email.Text = "";
        txt_Password.Text = "";
    }

    protected void btnAdminSignIn_Click(object sender, EventArgs e)
    {
        if (txt_AdminPassword.Text == "5002nevsmai" && txt_AdminEmail.Text == "iamsven2005@gmail.com")
        {
            Response.Redirect("Admin-index.aspx");
        }
        txt_AdminEmail.Text = "";
        txt_AdminPassword.Text = "";
    }
}