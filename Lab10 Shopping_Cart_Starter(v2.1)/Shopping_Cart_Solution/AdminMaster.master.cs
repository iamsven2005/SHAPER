using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using File = System.IO.File;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using Ionic.Zip;

public partial class MasterPage : System.Web.UI.MasterPage
{
 string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;

 protected void Page_Load(object sender, EventArgs e)
 {
 if (!this.IsPostBack)
 {
 this.BindRepeater();
 }
 Alerts.Text = "<div id=\"alert\"class=\"alert alert-success\">\r\n<span>Welcome Admin</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";

 }
 protected string[] GetTextFileLines1()
 {
 string filePath = Server.MapPath("~/App_Data/Users/emails.txt");
 return File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];
 }
 protected string[] GetTextFileLines2()
 {
 string filePath = Server.MapPath("~/App_Data/Users/names.txt");
 return File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];
 }
 protected string[] GetTextFileLines3()
 {
 string filePath = Server.MapPath("~/App_Data/Users/credits.txt");
 return File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];
 }
 protected string[] GetTextFileLines4()
 {
 string filePath = Server.MapPath("~/App_Data/Users/pictures.txt");
 return File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];
 }
 protected void btnInsertItems_Click(object sender, EventArgs e)
 {
 int result = 0;
 int result2 = 0;
 string image = "";

 if (FileUpload1.HasFile == true)
 {
 image = "images/" + FileUpload1.FileName;
 }

 Product prod = new Product(txtThrillerID.Text, txtThrillerName.Text,
 txtThrillerDesc.Text, decimal.Parse(txtThrillerPrice.Text),
 image, txtThrillerAuthor.Text, txtThrillerGenre.Text);
 Thriller item = new Thriller(txtThrillerID.Text, image,
 txtThrillerName.Text, txtThrillerAuthor.Text);
 result = prod.ProductInsert();
 result2 = item.ThrillerInsert();

 if (result > 0)
 {
 string saveimg = Server.MapPath(" ") + "\\" + image;
 FileUpload1.SaveAs(saveimg);
 }

 if (result2 > 0)
 {
 string saveimg = Server.MapPath(" ") + "\\" + image;
 FileUpload1.SaveAs(saveimg);
 Response.Write("<script>alert('Insert Successful');</script>");
 }

 else { Response.Write("<script>alert('Failed to Insert');</script>"); }

 txtThrillerAuthor.Text = "";
 txtThrillerDesc.Text = "";
 txtThrillerGenre.Text = "";
 txtThrillerID.Text = "";
 txtThrillerName.Text = "";
 txtThrillerPrice.Text = "";
 }
 private void BindRepeater()
 {
 using (SqlConnection con = new SqlConnection(constr))
 {
 using (SqlCommand cmd = new SqlCommand("Thriller_CRUD"))
 {
 cmd.Parameters.AddWithValue("@Action", "SELECT");
 using (SqlDataAdapter sda = new SqlDataAdapter())
 {
 cmd.CommandType = CommandType.StoredProcedure;
 cmd.Connection = con;
 sda.SelectCommand = cmd;
 using (DataTable dt = new DataTable())
 {
sda.Fill(dt);
Repeater1.DataSource = dt;
Repeater1.DataBind();
 }
 }
 }
 }
 }

 protected void OnEdit(object sender, EventArgs e)
 {
 //Find the reference of the Repeater Item.
 RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
 this.ToggleElements(item, true);
 }

 private void ToggleElements(RepeaterItem item, bool isEdit)
 {
 //Toggle Buttons.
 item.FindControl("lnkEdit").Visible = !isEdit;
 item.FindControl("lnkUpdate").Visible = isEdit;
 item.FindControl("lnkCancel").Visible = isEdit;


 //Toggle Labels.
 item.FindControl("lblTitle").Visible = !isEdit;
 item.FindControl("lblAuthor").Visible = !isEdit;
 item.FindControl("imgBooks").Visible = !isEdit;

 //Toggle TextBoxes.
 item.FindControl("txtTitle").Visible = isEdit;
 item.FindControl("txtAuthor").Visible = isEdit;
 item.FindControl("txtImage").Visible = isEdit;
 }

 protected void OnUpdate(object sender, EventArgs e)
 {
 //Find the reference of the Repeater Item.
 RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

 //Finds the matching BS_ID in the row of data
 int bookId = int.Parse((item.FindControl("lblBookId") as Label).Text);
 //Trim() allows data to be modified
 string name = (item.FindControl("txtTitle") as TextBox).Text.Trim();
 string price = (item.FindControl("txtAuthor") as TextBox).Text.Trim();
 string image = (item.FindControl("txtImage") as TextBox).Text.Trim();

 using (SqlConnection con = new SqlConnection(constr))
 {
 //using stored procedure
 using (SqlCommand cmd = new SqlCommand("Thriller_CRUD"))
 {
 cmd.CommandType = CommandType.StoredProcedure;
 //call the action UPDATE
 cmd.Parameters.AddWithValue("@Action", "UPDATE");
 //pass in new values
 cmd.Parameters.AddWithValue("@BookId", bookId);
 cmd.Parameters.AddWithValue("@Title", name);
 cmd.Parameters.AddWithValue("@Author", price);
 cmd.Parameters.AddWithValue("@Image", image);
 cmd.Connection = con;
 con.Open();
 cmd.ExecuteNonQuery();
 con.Close();
 }
 }
 //display
 this.BindRepeater();
 }

 protected void OnCancel(object sender, EventArgs e)
 {
 RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
 this.ToggleElements(item, false);
 }

 protected void OnDelete(object sender, EventArgs e)
 {
 RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
 int bookId = int.Parse((item.FindControl("lblBookId") as Label).Text);
 using (SqlConnection con = new SqlConnection(constr))
 {
 using (SqlCommand cmd = new SqlCommand("Thriller_CRUD"))
 {
 cmd.CommandType = CommandType.StoredProcedure;
 cmd.Parameters.AddWithValue("@Action", "DELETE");
 cmd.Parameters.AddWithValue("@BookId", bookId);
 cmd.Connection = con;
 con.Open();
 cmd.ExecuteNonQuery();
 con.Close();
 }
 }
 this.BindRepeater();
 }
 //Zip
 protected void btnDownload_Click(object sender, EventArgs e)
 {
 string Paththing = downloadtb.Text;
 string folderPath = Server.MapPath($"~/{Paththing}");
 using (MemoryStream memoryStream = new MemoryStream())
 {
 using (ZipFile zip = new ZipFile())
 {
 foreach (string filePath in Directory.GetFiles(folderPath))
 {
 string fileName = Path.GetFileName(filePath);
 zip.AddFile(filePath, string.Empty);
 }
 zip.Save(memoryStream);
 }
 Response.Clear();
 Response.BufferOutput = false;
 Response.ContentType = "application/zip";
 Response.AddHeader("content-disposition", $"attachment; filename={Paththing}.zip");
 memoryStream.WriteTo(Response.OutputStream);
 Response.End();
 }
 }
 //Sign OUt
 protected void btnSignOut_Click(object sender, EventArgs e)
 {
 Session["CHANGE_MASTERPAGE2"] = "~/MasterPage.Master";
 Session["CHANGE_MASTERPAGE"] = null;
 Response.Redirect(Request.Url.AbsoluteUri);
 }
 //ChangePwd
 protected void ChangePassword(object sender, EventArgs e)
 {
 string Email = lblAftLogin.Text;
 string filePathPwd = Server.MapPath("~/App_Data/Users/passwords.txt");
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
}