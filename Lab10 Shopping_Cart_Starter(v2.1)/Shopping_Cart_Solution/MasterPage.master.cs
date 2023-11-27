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

 protected void btnSearch_Click(object sender, EventArgs e)
 {
 Session["Search"] = txtSearch.Text;
 Response.Redirect("Search.aspx");
 }

 protected void btnRegister_Click(object sender, EventArgs e)
 {
 //Guid newGUID = Guid.NewGuid();
 string emailsFilePath = Server.MapPath("~/App_Data/Users/emails.txt");
 // Check if the email already exists in the file
 if (IsEmailAlreadyRegistered(txt_RegEmail.Text, emailsFilePath))
 {
 Alerts.Text = "<div id=\"alert\"class=\"alert alert-error\">\r\n<span>Email already registered</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";
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
 // Append hashed password to passwords.txt
 string image = "<img src = \"/images/profile.svg\" />";
 File.AppendAllText(passwordsFilePath, $"{txt_RegEmail.Text}: {Password}" + Environment.NewLine);
 File.AppendAllText(themesFilePath, $"{txt_RegEmail.Text}: default" + Environment.NewLine);
 File.AppendAllText(creditsFilePath, $"{txt_RegEmail.Text}: 200" + Environment.NewLine);
 File.AppendAllText(namesFilePath, $"{txt_RegEmail.Text}: {txt_Name.Text}" + Environment.NewLine);
 File.AppendAllText(emailsFilePath, $"{txt_RegEmail.Text}" + Environment.NewLine);
 File.AppendAllText(picturesFilePath, $"{txt_RegEmail.Text}: {image}" + Environment.NewLine);
 Alerts.Text = "<div id=\"alert\"class=\"alert alert-success\">\r\n<span>Account Created</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";
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
 string filePathCrd = Server.MapPath("~/App_Data/Users/credits.txt");
 string[] linesCrd = File.ReadAllLines(filePathCrd);
 string targetLineCrd = Array.Find(linesCrd, line => line.StartsWith(txt_Email.Text + ":"));
 string[] partsCrd = targetLineCrd.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
 Session["Credit"] = partsCrd[1].Trim();
 string filePathThm = Server.MapPath("~/App_Data/Users/themes.txt");
 string[] linesThm = File.ReadAllLines(filePathThm);
 string targetLineThm = Array.Find(linesThm, line => line.StartsWith(txt_Email.Text + ":"));
 string[] partsThm = targetLineThm.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
 Session["Theme"] = partsThm[1].Trim();
 string filePathPwd = Server.MapPath("~/App_Data/Users/passwords.txt");
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
 Alerts.Text = "<div id=\"alert\"class=\"alert alert-error\">\r\n<span>Password or UserName is not correct</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";
 }
 txt_Email.Text = "";
 txt_Password.Text = "";
 }
 protected void btnAdminSignIn_Click(object sender, EventArgs e)
 {
 string password = "$2a$12$V1AgwYpmZWFLaDkHLV1Bqe0Kt7T.TX2LRVFHysUcVQevj/Ke6HCtm";
 if (BCrypt.Net.BCrypt.Verify(txt_AdminPassword.Text, password) == true && txt_AdminEmail.Text == "iamsven2005@gmail.com")
 {
 //Response.Redirect("Admin.aspx");
 Session["CHANGE_MASTERPAGE"] = "~/AdminMaster.Master";
 Session["CHANGE_MASTERPAGE2"] = null;
 Response.Redirect(Request.Url.AbsoluteUri);
 }
 Alerts.Text = "<div id=\"alert\"class=\"alert alert-error\">\r\n<span>Password or UserName is not correct</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";

 txt_AdminEmail.Text = "";
 txt_AdminPassword.Text = "";
 }
}