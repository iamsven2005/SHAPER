using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using AjaxControlToolkit.HTMLEditor.ToolbarButton;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        option4.Text = ReadValueFromFile("MFAquestions.txt");

    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {

            string ans2 = ReadValueFromFile("MFAanswers.txt");
            string ans = answer.Text;
            if (ans == ans2)
            {
                Session["CHANGE_MASTERPAGE"] = "~/AfterLogin.Master";
                Session["CHANGE_MASTERPAGE2"] = null;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                ShowAlert("Answer is incorrect", "error");
            }
    }
    private string ReadValueFromFile(string fileName)
    {
        string userEmail = Session["Email"].ToString();
        string filePath = Server.MapPath($"~/App_Data/Users/{fileName}");
        string[] lines = File.ReadAllLines(filePath);
        string targetLine = lines.FirstOrDefault(line => line.StartsWith($"{userEmail}:"));
        return targetLine?.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
    }
    private void ShowAlert(string alert, string color)
    {
        Alerts.Text = $"<div id=\"alert\"class=\"alert alert-{color}\">\r\n<span>{alert}</span><span onclick=\"closeAlert()\">&times;</span>\r\n</div>";
    }
    protected void SignOut_Click(object sender, EventArgs e)
    {
        Session["CHANGE_MASTERPAGE"] = "~/MasterPage.Master";
        Session["CHANGE_MASTERPAGE2"] = null;
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}