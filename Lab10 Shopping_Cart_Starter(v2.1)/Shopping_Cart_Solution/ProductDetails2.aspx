<%@ Page Title="" Language="C#" MasterPageFile="~/Afterlogin.master" AutoEventWireup="true" CodeFile="ProductDetails2.aspx.cs" Inherits="ProductDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Image ID="imgProductDetails" runat="server" Style="width: 280px; height: 400px; padding: 12px 10px 1px" />

    <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>

    <asp:Label ID="lblAuthor" runat="server" Text="Label" Style="color: #48C9B0"></asp:Label>
    <asp:Label ID="lblGenre" runat="server" Text="Label"></asp:Label>

    <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblPrice2" runat="server" Text="Label"></asp:Label></a>

                <asp:Button ID="btnAddCart" runat="server" Text="ADD TO CART" class="cartbutton" OnClick="btnAddCart_Click" />
    <asp:Button ID="btnWishList" runat="server" Text="ADD TO WISHLIST" class="wishlistbutton" />
    <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Customer Review"></asp:Label>
    <asp:Label ID="Label1" Style="font-family: 'Noticia Text', serif; font-size: 16px" runat="server" Text="Average Rating"></asp:Label><br />
    <asp:Label ID="lblavgrating" runat="server" Text="Label" Font-Size="37px"></asp:Label>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:Rating
        ID="Rating1"
        runat="server"
        StarCssClass="Star"
        WaitingStarCssClass="WaitingStar"
        EmptyStarCssClass="Star"
        FilledStarCssClass="FilledStar">
    </asp:Rating>

    <asp:Label ID="lblresult" runat="server" Text="" Font-Size="Smaller"></asp:Label>

    <asp:TextBox runat="server" ID="txtreview" TextMode="MultiLine" Height="100px"></asp:TextBox>
    <asp:Button runat="server" class="cartbutton" Style="float: right;" Text="Submit Review" ID="btnSubmit" OnClick="btnSubmit_Click" Height="30px" Width="100px" />
</asp:Content>

