using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using BCrypt.Net;
using AjaxControlToolkit.HTMLEditor.ToolbarButton;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
public partial class MasterPage : System.Web.UI.MasterPage
{
 protected void Page_Load(object sender, EventArgs e)
 {
 }
    private string ReadValueFromFile(string fileName)
    {
        string userEmail = Session["Email"].ToString();
        string filePath = Server.MapPath($"~/App_Data/Users/{fileName}");
        string[] lines = File.ReadAllLines(filePath);
        string targetLine = lines.FirstOrDefault(line => line.StartsWith($"{userEmail}:"));
        return targetLine?.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
 {
 Session["Search"] = txtSearch.Text;
 Response.Redirect("Search.aspx");
 }

 protected void btnRegister_Click(object sender, EventArgs e)
 {
 string emailsFilePath = Server.MapPath("~/App_Data/Users/emails.txt");
 if (IsEmailAlreadyRegistered(txt_RegEmail.Text, emailsFilePath))
 {
            ALERT("Email already registered", "error");
 }
 else
 {
 string Password = BCrypt.Net.BCrypt.HashPassword(txt_RegPassword.Text);

            // Resolve the absolute paths
            string passwordsFilePath = Server.MapPath("~/App_Data/Users/passwords.txt");
            string themesFilePath = Server.MapPath("~/App_Data/Users/themes.txt");
            string creditsFilePath = Server.MapPath("~/App_Data/Users/credits.txt");
            string namesFilePath = Server.MapPath("~/App_Data/Users/names.txt");
            string picturesFilePath = Server.MapPath("~/App_Data/Users/pictures.txt");
            string MFAFilePath = Server.MapPath("~/App_Data/Users/MFAoptions.txt");
            string MFAqnsFilePath = Server.MapPath("~/App_Data/Users/MFAquestions.txt");
            string MFAansFilePath = Server.MapPath("~/App_Data/Users/MFAanswers.txt");
            // Append hashed password to passwords.txt
            string image = "image/svg+xml;base64,PHN2ZyBmaWxsPSIjZmZmIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MTAgODEwIj48cGF0aCBmaWxsPSIjMWQyMzJhIiBkPSJNLTgxLTgxaDk3MnY5NzJILTgxeiIvPg0KPHBhdGggZD0iTTI4MS40MyAyMzAuMjQ2YzAtNjguMjcgNTUuNjgzLTEyMy41NyAxMjMuNTctMTIzLjU3czEyMy41NjYgNTUuMyAxMjMuNTY2IDEyMy41N2MwIDY4LjI1NC01NS4zIDEyMy41NjYtMTIzLjU2NiAxMjMuNTY2LTY4LjI3IDAtMTIzLjU3LTU1LjY4LTEyMy41Ny0xMjMuNTY2Wm0yMzkuNTA3IDBjMC02NC4wNzQtNTEuODY3LTExNS45NDEtMTE1LjkzNy0xMTUuOTQxLTY0LjA3NCAwLTExNS45NDEgNTEuODY3LTExNS45NDEgMTE1Ljk0MSAwIDY0LjA3IDUxLjg2NyAxMTUuOTQxIDExNS45NDEgMTE1Ljk0MSA2NC4wNy0uMDAzIDExNS45MzgtNTIuMjUgMTE1LjkzOC0xMTUuOTRaTTQwNSAzNTYuNDU3bC0xODYuMjczIDE4Ni4yN0w0MDUgNzI4Ljk5N2wxODYuMjctMTg2LjI3Wm0wIDM2MC42NzJMMjMwLjQ2OSA1NDIuNjAyIDQwNSAzNjguMDc0bDE3NC41MjcgMTc0LjUyOFptMCAwIi8+PC9zdmc+\r\n";
            File.AppendAllText(passwordsFilePath, $"{txt_RegEmail.Text}: {Password}" + Environment.NewLine);
            File.AppendAllText(themesFilePath, $"{txt_RegEmail.Text}: default" + Environment.NewLine);
            File.AppendAllText(creditsFilePath, $"{txt_RegEmail.Text}: 200" + Environment.NewLine);
            File.AppendAllText(namesFilePath, $"{txt_RegEmail.Text}: {txt_Name.Text}" + Environment.NewLine);
            File.AppendAllText(emailsFilePath, $"{txt_RegEmail.Text}" + Environment.NewLine);
            File.AppendAllText(picturesFilePath, $"{txt_RegEmail.Text}: {image}" + Environment.NewLine);
            File.AppendAllText(MFAFilePath, $"{txt_RegEmail.Text}: 0" + Environment.NewLine);
            File.AppendAllText(MFAqnsFilePath, $"{txt_RegEmail.Text}: No Questions" + Environment.NewLine);
            File.AppendAllText(MFAansFilePath, $"{txt_RegEmail.Text}: No Answers" + Environment.NewLine);
            ALERT("Account Created", "success");
 }
 txt_Name.Text = "";
 txt_RegEmail.Text = "";
 }
 private bool IsEmailAlreadyRegistered(string email, string filePath)
 {
 try
 {
 string[] lines = File.ReadAllLines(filePath);
 return Array.Exists(lines, line => line.Equals(email, StringComparison.OrdinalIgnoreCase));
 }
 catch (Exception ex)
 {
 Console.WriteLine($"Error checking email: {ex.Message}");
 return false;
 }
 }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        Session["Email"] = txt_Email.Text;
        string email = txt_Email.Text;
        Session["Email"] = email;
        Session["Credit"] = ReadValueFromFile("credits.txt");
        Session["Theme"] = ReadValueFromFile("themes.txt");
        string MFA = ReadValueFromFile("MFAoptions.txt");

        string filePathPwd = Server.MapPath("~/App_Data/Users/passwords.txt");
        string[] linesPwd = File.ReadAllLines(filePathPwd);
        string targetLinePwd = Array.Find(linesPwd, line => line.StartsWith(txt_Email.Text + ":"));
        string[] partsPwd = targetLinePwd.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        string password = partsPwd[1].Trim().ToString();
        bool flag = BCrypt.Net.BCrypt.Verify(txt_Password.Text, password);
        if (flag == true)
        {
            if (MFA == "0")
            {
                Session["CHANGE_MASTERPAGE"] = "~/AfterLogin.Master";
                Session["CHANGE_MASTERPAGE2"] = null;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else if (MFA == "1")
            {
                Session["CHANGE_MASTERPAGE"] = "~/BLANK.Master";
                Session["CHANGE_MASTERPAGE2"] = null;
                Response.Redirect("Request.Url.AbsoluteUri");
            }

        }
        else
        {
            ALERT("Password or UserName is not correct", "error");
        }

        txt_Email.Text = "";
        txt_Password.Text = "";
    }
    protected void btnAdminSignIn_Click(object sender, EventArgs e)
 {
 string password = "$2a$12$V1AgwYpmZWFLaDkHLV1Bqe0Kt7T.TX2LRVFHysUcVQevj/Ke6HCtm";
 if (BCrypt.Net.BCrypt.Verify(txt_AdminPassword.Text, password) == true && txt_AdminEmail.Text == "iamsven2005@gmail.com")
 {
 Session["CHANGE_MASTERPAGE"] = "~/AdminMaster.Master";
 Session["CHANGE_MASTERPAGE2"] = null;
 Response.Redirect(Request.Url.AbsoluteUri);
 }
        ALERT("Password or UserName is not correct", "error");
 txt_AdminEmail.Text = "";
 txt_AdminPassword.Text = "";
 }
    private void ALERT(string alert, string color)
    {
        Alerts.Text = $"<div id=\"alert\"class=\"alert alert-{color}\">\r\n<span>{alert}</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";
    }
}