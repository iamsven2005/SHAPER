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
//this is used to define overlapped path with web (web implementation is stupid)
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblAftLogin.Text = Session["Email"].ToString();
        Credit.Text = Session["Credit"].ToString();
        Theme.Text = ReadValueFromFile("themes.txt");
        Pics.Text = $"data:{ReadValueFromFile("pictures.txt")}".Replace("\"", "");
        Question2.Text = ReadValueFromFile("MFAquestions.txt");
        Answer2.Text = ReadValueFromFile("MFAanswers.txt");
    }

    private string ReadValueFromFile(string fileName)
    {
        string userEmail = Session["Email"].ToString();
        string filePath = Server.MapPath($"~/App_Data/Users/{fileName}");
        string[] lines = File.ReadAllLines(filePath);
        string targetLine = lines.FirstOrDefault(line => line.StartsWith($"{userEmail}:"));
        return targetLine?.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
    }

    private void UpdateFileValue(string fileName, string newValue)
    {
        string userEmail = Session["Email"].ToString();
        string filePath = Server.MapPath($"~/App_Data/Users/{fileName}");
        string[] lines = File.ReadAllLines(filePath);
        int index = Array.FindIndex(lines, line => line.StartsWith(userEmail + ":"));
        if (index != -1)
        {
            lines[index] = $"{userEmail}: {newValue}";
            File.WriteAllLines(filePath, lines);
            Response.Redirect(Request.RawUrl, false);
            Context.ApplicationInstance.CompleteRequest();
        }
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
        UpdateFileValue("themes.txt", Theme2.Text);
        ShowAlert("Theme has been changed", "success");
    }

    protected void btnInsertItems_Click(object sender, EventArgs e)
    {
        UpdateFileValue("pictures.txt", Filetext.Text);
        ShowAlert("Insert Successful", "success");
    }

    protected void ChangePassword(object sender, EventArgs e)
    {
        string filePathPwd = Server.MapPath("~/App_Data/Users/passwords.txt");
        string password = ReadValueFromFile(filePathPwd);
        bool flag = BCrypt.Net.BCrypt.Verify(OldPassword.Text, password);
        if (flag)
        {
            UpdateFileValue("passwords.txt", BCrypt.Net.BCrypt.HashPassword(NewPassword.Text));
            ShowAlert("Password has been changed", "success");
        }
        else
        {
            ShowAlert("Password seems wrong", "error");
        }
    }

    protected void ChangeQns_Click(object sender, EventArgs e)
    {
        UpdateFileValue("MFAquestions.txt", Question.Text);
        UpdateFileValue("MFAanswers.txt", Answer.Text);
        ShowAlert("Changes saved", "success");
    }

    private void SetMFAOption(int option)
    {
        UpdateFileValue("MFAoptions.txt", option.ToString());
    }

    protected void MFA_0(object sender, EventArgs e)
    {
        SetMFAOption(0);
    }

    protected void MFA_1(object sender, EventArgs e)
    {
        SetMFAOption(1);
    }

    protected void MFA_2(object sender, EventArgs e)
    {
        SetMFAOption(2);
    }

    private void ShowAlert(string alert, string color)
    {
        Alerts.Text = $"<div id=\"alert\"class=\"alert alert-{color}\">\r\n<span>{alert}</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";
    }
}
