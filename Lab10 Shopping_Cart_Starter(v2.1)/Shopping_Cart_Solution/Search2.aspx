<%@ Page Title="" Language="C#" MasterPageFile="~/Afterlogin.master" AutoEventWireup="true" CodeFile="Search2.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="assets/css/Search.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <body>
        <br />
        <div class="pagetitle">Search Result</div>
        <br />

        <div>
            <asp:TextBox ID="txtSearch" Style="height: 0.1px; width: 0.1px; border: none" runat="server"></asp:TextBox>
        </div>

        <div class="bookcontainer">
            <asp:Label ID="lblnoresult" runat="server" Text="No results found." Font-Size="Larger" Visible="False"></asp:Label>
            <div class="bookshelf">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div style="width: 146px;">
                            <asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails2.aspx?ProdID=" + Eval("ID") ) %>' class="bookimage" ID="imgBooks" ImageUrl='<%#Eval("Image") %>' runat="server" />
                            <asp:Label class="Card Title" ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label><br />
                            <asp:Label ID="lblAuthor" runat="server" Text='<%#Eval("Author") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </body>
</asp:Content>
