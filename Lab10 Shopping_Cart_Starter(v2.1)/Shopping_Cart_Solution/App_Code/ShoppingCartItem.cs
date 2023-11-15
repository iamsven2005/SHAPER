﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;



//IEquatable - type-specific to determine the equality of Instances
public class ShoppingCartItem : IEquatable<ShoppingCartItem>
{
    public int Quantity { get; set; }

    private string _ItemID;
    public string ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }

    private string _ItemName;
    public string Product_Name
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }

    private string _ItemImage;
    public string Product_Image
    {
        get { return _ItemImage; }
        set { _ItemImage = value; }

    }

    private string _ItemAuthor;
    public string Product_Author
    {
        get { return _ItemAuthor; }
        set { _ItemAuthor = value; }

    }

    private decimal _ItemPrice;
    public decimal Product_Price
    {
        get { return _ItemPrice; }
        set { _ItemPrice = value; }
    }

    public decimal TotalPrice
    {
        get { return Product_Price * Quantity; }
    }

    public ShoppingCartItem(string productID)
    {
        this.ItemID = productID;
    }

    public ShoppingCartItem(string productID, Product prod)
    {
        this.ItemID = productID;
        this.Product_Name = prod.Product_Name;
        this.Product_Image = prod.Product_Image;
        this.Product_Price = prod.Unit_Price;
        this.Product_Author = prod.Book_Author;
    }

    public ShoppingCartItem(string productID, string productName, string productImg, decimal productPrice, string productAuthor)
    {
        this.ItemID = productID;
        this.Product_Name = productName;
        this.Product_Image = productImg;
        this.Product_Price = productPrice;
        this.Product_Author = productAuthor;

    }

    public bool Equals(ShoppingCartItem anItem)
    {
        return anItem.ItemID == this.ItemID;
    }

    //public bool Equals(ShoppingCartItem product)
    //{
    //    return product.ItemID == this.ItemID;
    //}

}
