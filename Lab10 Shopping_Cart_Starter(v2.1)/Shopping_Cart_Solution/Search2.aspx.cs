using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;

public partial class Search2 : BasePage
{
 protected void Page_Load(object sender, EventArgs e)
 {
 //C# treats the whole damn thing as a form and does an id bound check for onclick response
 txtSearch.Text = Session["Search"].ToString();
 if (!IsPostBack)
 {
 string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
 SqlConnection myConnect = new SqlConnection(strConnectionString);
 myConnect.Open();
 string checksearch = "SELECT COUNT(*) FROM [ALL_Products] WHERE Title LIKE @search OR Author LIKE @search";
 SqlCommand com = new SqlCommand(checksearch, myConnect);
 com.Parameters.AddWithValue("@search", txtSearch.Text);
 com.Parameters["@search"].Value = "%" + txtSearch.Text + "%";
 int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
 myConnect.Close();
 if (temp > 0)
 {
 string strCommandText = "SELECT *";
 strCommandText += " FROM ALL_Products WHERE Title LIKE @title OR Author LIKE @author";
 SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
 cmd.Parameters.Add("@title", SqlDbType.NVarChar, 50);
 cmd.Parameters["@title"].Value = "%" + txtSearch.Text + "%";
 cmd.Parameters.Add("@author", SqlDbType.NVarChar, 50);
 cmd.Parameters["@author"].Value = "%" + txtSearch.Text + "%";
 myConnect.Open();
 cmd.ExecuteNonQuery();
 SqlDataAdapter da = new SqlDataAdapter();
 da.SelectCommand = cmd;
 DataSet ds = new DataSet();
 da.Fill(ds, "Title");
 Repeater1.DataSource = ds;
 Repeater1.DataBind();
 myConnect.Close();
 }
 else
 {
 lblnoresult.Visible = true;
 }
 }
 }

}