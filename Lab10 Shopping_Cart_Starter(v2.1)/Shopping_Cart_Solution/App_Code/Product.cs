﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class Product
{
 string _connStr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
 private string _prodID = null;
 private string _prodName = string.Empty;
 private string _prodDesc = "";
 private decimal _unitPrice = 0;
 private string _prodImage = "";
 private string _bookAuthor = "";
 private string _bookGenre = "";

 public Product()
 {
 }
 public Product(string prodID, string prodName, string prodDesc,
decimal unitPrice, string prodImage, string bookAuthor, string bookGenre)
 {
 _prodID = prodID;
 _prodName = prodName;
 _prodDesc = prodDesc;
 _unitPrice = unitPrice;
 _prodImage = prodImage;
 _bookAuthor = bookAuthor;
 _bookGenre = bookGenre;
 }
 //get/set the attributes of the Product object.
 public string Product_ID
 {
 get { return _prodID; }
 set { _prodID = value; }
 }
 public string Product_Name
 {
 get { return _prodName; }
 set { _prodName = value; }
 }
 public string Product_Desc
 {
 get { return _prodDesc; }
 set { _prodDesc = value; }
 }
 public decimal Unit_Price
 {
 get { return _unitPrice; }
 set { _unitPrice = value; }
 }
 public string Product_Image
 {
 get { return _prodImage; }
 set { _prodImage = value; }
 }

 public string Book_Author
 {
 get { return _bookAuthor; }
 set { _bookAuthor = value; }
 }
 public string Book_Genre
 {
 get { return _bookGenre; }
 set { _bookGenre = value; }
 }

 //below as the Class methods for some DB operations. 
 public Product getProduct(string prodID)
 {
 Product prodDetail = null;
 string prod_Name, prod_Desc, Prod_Image, book_Author, book_Genre;
 decimal unit_Price;
 string queryStr = "SELECT * FROM ALL_Products WHERE ID = @ProdID";
 SqlConnection conn = new SqlConnection(_connStr);
 SqlCommand cmd = new SqlCommand(queryStr, conn);
 cmd.Parameters.AddWithValue("@ProdID", prodID);
 conn.Open();
 SqlDataReader dr = cmd.ExecuteReader();

 if (dr.Read())
 {
 prod_Name = dr["Title"].ToString();
 prod_Desc = dr["Description"].ToString();
 Prod_Image = dr["Image"].ToString();
 unit_Price = decimal.Parse(dr["Price"].ToString());
 book_Author = dr["Author"].ToString();
 book_Genre = dr["Genre"].ToString();

 prodDetail = new Product(prodID, prod_Name, prod_Desc, unit_Price, Prod_Image, book_Author, book_Genre);
 }
 else
 {
 prodDetail = null;
 }
 conn.Close();
 dr.Close();
 dr.Dispose();

 return prodDetail;
 }

 public int ProductInsert()
 {
 int result = 0;
 string queryStr = "INSERT INTO ALL_Products(ID, Title, Description, Price, Image, Author, Genre)" + "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image, @Book_Author, @Book_Genre)";
 SqlConnection conn = new SqlConnection(_connStr);
 SqlCommand cmd = new SqlCommand(queryStr, conn);
 cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
 cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
 cmd.Parameters.AddWithValue("@Product_Desc", this.Product_Desc);
 cmd.Parameters.AddWithValue("@Unit_Price", this.Unit_Price);
 cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
 cmd.Parameters.AddWithValue("@Book_Author", this.Book_Author);
 cmd.Parameters.AddWithValue("@Book_Genre", this.Book_Genre);
 conn.Open();
 result += cmd.ExecuteNonQuery();
 conn.Close();
 return result;
 }//end Insert
}
public class Thriller
{
 string _connStr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
 private string _prodID = null;
 private string _prodName = string.Empty;
 private string _prodImage = "";
 private string _bookAuthor = "";
 public Thriller()
 {
 }
 // PRODUCTS
 public Thriller(string prodID, string prodName, string prodImage, string bookAuthor)
 {
 _prodID = prodID;
 _prodName = prodName;
 _prodImage = prodImage;
 _bookAuthor = bookAuthor;
 }
 // Constructor that take in all except product ID
 public Thriller(string prodName, string prodImage, string bookAuthor)
 : this(null, prodName, prodImage, bookAuthor)
 {
 }
 // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
 public Thriller(string prodID)
 : this(prodID, "", "", "")
 {
 }
 // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
 public string Product_ID
 {
 get { return _prodID; }
 set { _prodID = value; }
 }
 public string Product_Name
 {
 get { return _prodName; }
 set { _prodName = value; }
 }

 public string Product_Image
 {
 get { return _prodImage; }
 set { _prodImage = value; }
 }

 public string Book_Author
 {
 get { return _bookAuthor; }
 set { _bookAuthor = value; }
 }
 public int ThrillerInsert()
 {
 int result = 0;
 string queryStrThriller = "INSERT INTO BS_Thriller(BS_ID, BS_Image, BS_Title, BS_Author)" + "values (@Product_ID, @Product_Name, @Product_Image, @Book_Author)";
 SqlConnection conn = new SqlConnection(_connStr);
 SqlCommand cmd = new SqlCommand(queryStrThriller, conn);
 cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
 cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
 cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
 cmd.Parameters.AddWithValue("@Book_Author", this.Book_Author);

 conn.Open();
 result += cmd.ExecuteNonQuery();
 conn.Close();

 return result;
 }//end Insert
}