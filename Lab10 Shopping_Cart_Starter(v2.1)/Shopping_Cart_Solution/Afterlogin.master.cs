using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;
using Microsoft.Identity.Client;
using System.IO;
using System.Web.Services.Description;
using static System.Net.WebRequestMethods;
using System.Security.Cryptography;
using System.Windows;
using File = System.IO.File;

public partial class MasterPage : System.Web.UI.MasterPage
{
 protected void Page_Load(object sender, EventArgs e)
 {

 lblAftLogin.Text = Session["Email"].ToString();
 Credit.Text = Session["Credit"].ToString();
 string filePath = Server.MapPath("~/App_Data/Users/themes.txt");
 string[] lines = File.ReadAllLines(filePath);
 string targetLine = Array.Find(lines, line => line.StartsWith(lblAftLogin.Text + ":"));
 string[] parts = targetLine.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
 Theme.Text = parts[1].Trim();
 string filePathPics = Server.MapPath("~/App_Data/Users/pictures.txt");
 string[] linesPics = File.ReadAllLines(filePathPics);
 string targetLinePics = Array.Find(linesPics, linePics => linePics.StartsWith(lblAftLogin.Text + ":"));
 string[] partsPics = targetLinePics.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
 Pics.Text = partsPics[1].Trim();
 }
 protected void btnSearch_Click(object sender, EventArgs e)
 {
 Session["Search"] = txtSearch.Text;
 Response.Redirect("Search.aspx");
 }

 protected void btnSignOut_Click(object sender, EventArgs e)
 {
 Session["CHANGE_MASTERPAGE2"] = "~/MasterPage.Master";
 Session["CHANGE_MASTERPAGE"] = null;
 Response.Redirect(Request.Url.AbsoluteUri);
 }
 protected void SaveTheme_Click(object sender, EventArgs e)
 {
 string filePath = Server.MapPath("~/App_Data/Users/themes.txt");
 string targetEmail = lblAftLogin.Text;
 string newTheme = Theme2.Text;
 string[] lines = File.ReadAllLines(filePath);
 int index = Array.FindIndex(lines, line => line.StartsWith(targetEmail + ":"));
 string[] parts = lines[index].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
 if (parts.Length == 2)
 {
 lines[index] = $"{targetEmail}: {newTheme}";
 File.WriteAllLines(filePath, lines);
 Response.Redirect(Request.RawUrl, false);
 Context.ApplicationInstance.CompleteRequest();

 }
 Alerts.Text = "<div id=\"alert\"class=\"alert alert-success\">\r\n<span>Theme has been changed</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";

 }
 protected void btnInsertItems_Click(object sender, EventArgs e)
 {
 string image = "";
 image = "profilepictures/" + FileUpload1.FileName;
 string saveimg = Server.MapPath(" ") + "\\" + image;
 FileUpload1.SaveAs(saveimg);
 string filePath = Server.MapPath("~/App_Data/Users/pictures.txt");
 string targetEmail = lblAftLogin.Text;
 string picture = $"<img src=\"/{image}\">";
 string[] lines = File.ReadAllLines(filePath);
 int index = Array.FindIndex(lines, line => line.StartsWith(targetEmail + ":"));
 string[] parts = lines[index].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
 if (parts.Length == 2)
 {
 lines[index] = $"{targetEmail}: {picture}";
 File.WriteAllLines(filePath, lines);
 Response.Redirect(Request.RawUrl, false);
 Context.ApplicationInstance.CompleteRequest();
 }
 Alerts.Text = "<div id=\"alert\"class=\"alert alert-success\">\r\n<span>Insert Successful</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";
 }
 protected void ChangePassword(object sender, EventArgs e)
 {
 string Email = lblAftLogin.Text;
 string filePathPwd = Server.MapPath("~/App_Data/Users/passwords.txt");
 string[] linesPwd = File.ReadAllLines(filePathPwd);
 string targetLinePwd = Array.Find(linesPwd, line => line.StartsWith(Email + ":"));
 string[] partsPwd = targetLinePwd.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
 string password = partsPwd[1].Trim().ToString();
 bool flag = BCrypt.Net.BCrypt.Verify(OldPassword.Text, password);
 if (flag == true)
 {
 string Password = BCrypt.Net.BCrypt.HashPassword(NewPassword.Text);
 string[] lines = File.ReadAllLines(filePathPwd);
 int index = Array.FindIndex(lines, line => line.StartsWith(Email + ":"));
 string[] parts = lines[index].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
 if (parts.Length == 2)
 {
 lines[index] = $"{Email}: {Password}";
 File.WriteAllLines(filePathPwd, lines);
 Response.Redirect(Request.RawUrl, false);
 Context.ApplicationInstance.CompleteRequest();
 }
 else
 {
 Alerts.Text = "<div id=\"alert\"class=\"alert alert-error\">\r\n<span>Please try again</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";
 }
 }
 else
 {
 Alerts.Text = "<div id=\"alert\"class=\"alert alert-error\">\r\n<span>Password seems wrong</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";
 }

 }
}
//Session["Theme"].ToString();
//DeleteFromFile("robots.txt", "Line to delete");
//protected void DeleteFromFile(string filePath, string lineToDelete)
//{
// // Combine the file path with the application's root
// filePath = Server.MapPath("~/" + filePath);

// try
// {
// // Read all lines from the file
// string[] lines = File.ReadAllLines(filePath);

// // Find and remove the line to delete
// lines = Array.FindAll(lines, line => !line.Contains(lineToDelete));

// // Write the modified lines back to the file
// File.WriteAllLines(filePath, lines);
// }
// catch (Exception ex)
// {
// // Handle exceptions, e.g., log or display an error message
// Response.Write($"Error deleting from the file: {ex.Message}");
// }
//}
//AppendToFile("robots.txt", "New line to append");

//protected void AppendToFile(string filePath, string lineToAppend)
//{
// // Combine the file path with the application's root
// filePath = Server.MapPath("~/" + filePath);

// try
// {
// // Append the line to the text file
// File.AppendAllText(filePath, lineToAppend + Environment.NewLine);
// }
// catch (Exception ex)
// {
// // Handle exceptions, e.g., log or display an error message
// Response.Write($"Error appending to the file: {ex.Message}");
// }
//}
