using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using File = System.IO.File;
public partial class index : BasePage
{
 protected void Page_Load(object sender, EventArgs e)
 {

 }
 protected string[] GetTextFileLines()
 {
 string filePath = Server.MapPath("~/Users/pictures.txt");
 return File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];
 }
}