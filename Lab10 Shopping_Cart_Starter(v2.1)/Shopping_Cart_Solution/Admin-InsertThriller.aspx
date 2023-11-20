<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin-InsertThriller.aspx.cs" Inherits="Admin_InsertThriller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


                        <asp:Label CssClass="labels" ID="lblID" runat="server" Text="Product ID"></asp:Label>

                        <asp:TextBox Style="width: 20%; height: 30px; border: 0.5px solid" ID="txtThrillerID" runat="server"></asp:TextBox>

                        <asp:Label CssClass="labels" ID="Label1" runat="server" Text="Product Name"></asp:Label>

                        <asp:TextBox CssClass="textboxes" ID="txtThrillerName" runat="server"></asp:TextBox>

                        <asp:Label CssClass="labels" ID="Label2" runat="server" Text="Product Author"></asp:Label>

                        <asp:TextBox CssClass="textboxes" ID="txtThrillerAuthor" runat="server"></asp:TextBox>

                        <asp:Label CssClass="labels" ID="Label3" runat="server" Text="Unit Price"></asp:Label>

                        <asp:TextBox Style="width: 30%; height: 30px; border: 0.5px solid" ID="txtThrillerPrice" runat="server"></asp:TextBox>

                        <asp:Label CssClass="labels" ID="Label4" runat="server" Text="Product Genre"></asp:Label>

                        <asp:TextBox CssClass="textboxes" ID="txtThrillerGenre" runat="server"></asp:TextBox>

                        <asp:Label CssClass="labels" ID="Label5" runat="server" Text="Image"></asp:Label>

                        <asp:FileUpload ID="FileUpload1" runat="server" />

                        <asp:Label CssClass="labels" ID="Label6" runat="server" Text="Description"></asp:Label>

                        <asp:TextBox Style="width: 100%; height: 80px; border: 0.5px solid" ID="txtThrillerDesc" runat="server" TextMode="MultiLine"></asp:TextBox>

                        <asp:Button CssClass="btns" ID="btnInsertItems" runat="server" Text="Insert" OnClick="btnInsertItems_Click" />
                        <asp:Button CssClass="btns" ID="btnBack" runat="server" Text="Back" BackColor="#66FFFF" OnClick="btnBack_Click" />

</asp:Content>