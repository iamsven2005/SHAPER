<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BestSeller.aspx.cs" Inherits="BestSeller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Repeater ID="Repeater1" runat="server">
        <itemtemplate>
            <div style="width: 146px;">
                <asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID"))%>' ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("BS_Image") %>' runat="server" />
                <asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>
                <br />
                <asp:Label CssClass="bookauthor" ID="lblAuthor" runat="server" Text='<%#Eval("BS_Author") %>' Style="color: #48C9B0"></asp:Label>
            </div>
        </itemtemplate>
    </asp:Repeater>

    <asp:Repeater ID="Repeater2" runat="server">
        <itemtemplate>
            <div style="width: 146px;">
                <asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID"))%>' ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("BS_Image") %>' runat="server" />
                <asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>
                <br />
                <asp:Label CssClass="bookauthor" ID="lblAuthor" runat="server" Text='<%#Eval("BS_Author") %>' Style="color: #48C9B0"></asp:Label>
            </div>
        </itemtemplate>
    </asp:Repeater>

    <asp:Repeater ID="Repeater3" runat="server">
        <itemtemplate>
            <div style="width: 146px;">
                <asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID"))%>' ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("BS_Image") %>' runat="server" />
                <asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>
                <br />
                <asp:Label CssClass="bookauthor" ID="lblAuthor" runat="server" Text='<%#Eval("BS_Author") %>' Style="color: #48C9B0"></asp:Label>
            </div>
        </itemtemplate>
    </asp:Repeater>

    <asp:Repeater ID="Repeater4" runat="server">
        <itemtemplate>
            <div style="width: 146px;">
                <asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID"))%>' ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("BS_Image") %>' runat="server" />
                <asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>
                <br />
                <asp:Label CssClass="bookauthor" ID="lblAuthor" runat="server" Text='<%#Eval("BS_Author") %>' Style="color: #48C9B0"></asp:Label>
            </div>
        </itemtemplate>
    </asp:Repeater>
    </div>

                <asp:Repeater ID="Repeater5" runat="server">
                    <itemtemplate>
                        <div style="width: 146px;">
                            <asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID"))%>' ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("BS_Image") %>' runat="server" />
                            <asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>
                            <br />
                            <asp:Label CssClass="bookauthor" ID="lblAuthor" runat="server" Text='<%#Eval("BS_Author") %>' Style="color: #48C9B0"></asp:Label>
                        </div>
                    </itemtemplate>
                </asp:Repeater>

</asp:Content>

