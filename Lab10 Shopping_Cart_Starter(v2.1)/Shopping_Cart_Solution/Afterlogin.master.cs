using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using Salt_Password_Sample;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;
using Microsoft.Identity.Client;
using System.IO;
using System.Web.Services.Description;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        lblAftLogin.Text = Session["Email"].ToString();
        Credit.Text = Session["Credit"].ToString();
        string filePath = Server.MapPath("~/Users/themes.txt");
        string[] lines = File.ReadAllLines(filePath);
        string targetLine = Array.Find(lines, line => line.StartsWith(lblAftLogin.Text + ":"));
        string[] parts = targetLine.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        Theme.Text = parts[1].Trim();
        //Session["Theme"].ToString();
        //DeleteFromFile("robots.txt", "Line to delete");
        //AppendToFile("robots.txt", "New line to append");

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
        string filePath = Server.MapPath("~/Users/themes.txt");
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



    }
    protected string[] GetTextFileLines()
    {
        string filePath = Server.MapPath("~/Users/themes.txt"); // Adjust the path based on your file location
        return File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];
    }
    //protected void DeleteFromFile(string filePath, string lineToDelete)
    //{
    //    // Combine the file path with the application's root
    //    filePath = Server.MapPath("~/" + filePath);

    //    try
    //    {
    //        // Read all lines from the file
    //        string[] lines = File.ReadAllLines(filePath);

    //        // Find and remove the line to delete
    //        lines = Array.FindAll(lines, line => !line.Contains(lineToDelete));

    //        // Write the modified lines back to the file
    //        File.WriteAllLines(filePath, lines);
    //    }
    //    catch (Exception ex)
    //    {
    //        // Handle exceptions, e.g., log or display an error message
    //        Response.Write($"Error deleting from the file: {ex.Message}");
    //    }
    //}
    //protected void AppendToFile(string filePath, string lineToAppend)
    //{
    //    // Combine the file path with the application's root
    //    filePath = Server.MapPath("~/" + filePath);

    //    try
    //    {
    //        // Append the line to the text file
    //        File.AppendAllText(filePath, lineToAppend + Environment.NewLine);
    //    }
    //    catch (Exception ex)
    //    {
    //        // Handle exceptions, e.g., log or display an error message
    //        Response.Write($"Error appending to the file: {ex.Message}");
    //    }
    //}
}
