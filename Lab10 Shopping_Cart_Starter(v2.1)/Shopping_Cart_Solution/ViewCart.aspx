<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="Label1" runat="server" Text="ADD"></asp:Label>
    <asp:Label ID="lbl_AmtLeft" runat="server" Text="nil"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="OF ELIGIBLE ITEMS TO QUALIFY FOR FREE SHIPPING"></asp:Label>
    <asp:Label ID="lblQualify" runat="server" Text="CONGRATULATIONS! YOU QUALIFY FOR FREE SHIPPING" Visible="False"></asp:Label>

    <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" GridLines="None" ShowHeader="False" OnRowCommand="gv_CartView_RowCommand">
        <columns>
            <asp:TemplateField>
                <itemtemplate>

                    <asp:Image ID="imgPoster" ImageUrl='<%#Eval("Product_Image") %>' runat="server" Style="height: 220px; width: 140px;" />

                    <asp:Label
                        Style="font-family: 'Poppins', sans-serif; font-size: 23px;"
                        ID="lblTitle"
                        runat="server"
                        Text='<%#Eval("Product_Name") %>'></asp:Label>

                    <asp:Label
                        Style="font-family: 'Poppins', sans-serif; font-size: 10px; color: #138D75"
                        ID="lblAuthor"
                        runat="server"
                        Text='<%#Eval ("Product_Author") %>'></asp:Label>

                    <asp:Label
                        Style="font-family: 'Poppins', sans-serif; font-size: 15px; font-weight: bold;"
                        ID="lblPrice"
                        runat="server"
                        Text='<%#Eval("Product_Price") %>'></asp:Label>
                    <asp:Label Style="font-size: 12px;" ID="Label3" runat="server" Text="per item"></asp:Label>

                    <asp:TextBox
                        Style="width: 15px; height: 20px; border: 0.6px solid black; padding: 5px 5px 5px 10px"
                        ID="tb_Quantity"
                        runat="server"
                        Text='<%# Eval("Quantity") %>'
                        Width="50px"
                        ReadOnly="False">
                    </asp:TextBox>
                    <asp:Button
                        Style="font-family: 'Poppins', sans-serif; border: none; width: 48px; height: 20px; font-size: 10px; margin-left: 5px;"
                        ID="btnUpdate"
                        runat="server"
                        Text="Update"
                        OnClick="btnUpdate_Click" />
                    <asp:LinkButton
                        Style="color: #48C9B0;"
                        ID="linkRemove"
                        runat="server"
                        Text="Remove"
                        CommandArgument='<%# Eval("ItemID") %>'
                        CommandName="Remove">
                    </asp:LinkButton>

                </itemtemplate>
            </asp:TemplateField>
        </columns>
    </asp:GridView>

    <asp:Label ID="lbl_TotalPrice" runat="server" Text="$0.00"></asp:Label>

    <asp:Label ID="lbl_ShippingPrice" runat="server" Text="$0.00"></asp:Label>

    <asp:Label ID="lbl_TotalPrice2" runat="server" Text="Label"></asp:Label>


    <asp:Button ID="btnCheckOut" type="button" runat="server" Text="CHECKOUT" class="checkoutbtn" OnClick="btnCheckOut_Click" />

    <asp:Image ID="imgPaypal" ImageUrl="images/paypal.png" runat="server" Style="width: 95px; height: 30px; float: left; margin: 11px 5px 5px 86px" />

</asp:Content>
