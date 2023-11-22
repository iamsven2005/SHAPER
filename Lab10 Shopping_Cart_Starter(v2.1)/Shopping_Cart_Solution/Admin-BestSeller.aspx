<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin-BestSeller.aspx.cs" Inherits="BestSeller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="Repeater1" runat="server">
        <itemtemplate>
            <asp:ImageButton ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("BS_Image") %>' runat="server" />
            <asp:TextBox ID="txtImage" Text='<%#Eval("BS_Image")%>' runat="server" Visible="False"></asp:TextBox>


            <asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>
            <asp:TextBox ID="txtTitle" Text='<%#Eval("BS_Title")%>' runat="server" Visible="False"></asp:TextBox>


            <asp:Label CssClass="bookauthor" ID="lblAuthor" runat="server" Text='<%#Eval("BS_Author") %>' Style="color: #48C9B0"></asp:Label>
            <asp:TextBox ID="txtAuthor" Text='<%#Eval("BS_Author") %>' runat="server" Visible="False"></asp:TextBox>


            <asp:Label ID="lblBookId" runat="server" Text='<%# Eval("BS_ID") %>' Visible="False"></asp:Label>


            <asp:LinkButton ID="lnkEdit" Text="Edit |" runat="server" OnClick="OnEdit" Font-Size="X-Small" />
            <asp:LinkButton ID="lnkUpdate" Text="Update |" runat="server" Visible="false" OnClick="OnUpdate" Font-Size="X-Small" />
            <asp:LinkButton ID="lnkCancel" Text="Cancel |" runat="server" Visible="false" OnClick="OnCancel" Font-Size="X-Small" />
            <asp:LinkButton
                ID="lnkDelete"
                Text="Delete"
                runat="server"
                OnClick="OnDelete"
                OnClientClick="return confirm('Are you sure you want to delete this?');"
                Font-Size="X-Small" />

        </itemtemplate>
    </asp:Repeater>


</asp:Content>
