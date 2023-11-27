<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 Shipping Address 

 <asp:TextBox ID="txtFirstName" runat="server" CssClass="shippingtxt" PlaceHolder="First Name"></asp:TextBox>
 <asp:RequiredFieldValidator
 ID="RequiredFieldValidator1"
 runat="server"
 ErrorMessage="Please enter your first name."
 ControlToValidate="txtFirstName"
 Font-Size="Small"
 ForeColor="Red">
 </asp:RequiredFieldValidator>

 <asp:TextBox ID="txtLastName" runat="server" CssClass="shippingtxt" PlaceHolder="Last Name"></asp:TextBox>
 <asp:RequiredFieldValidator
 ID="RequiredFieldValidator2"
 runat="server"
 ErrorMessage="Please enter your last name."
 ControlToValidate="txtLastName"
 Font-Size="Small"
 ForeColor="Red">
 </asp:RequiredFieldValidator>

 <asp:TextBox ID="txtAddress" runat="server" CssClass="shippingtxt" PlaceHolder="Street Address"></asp:TextBox>
 <asp:RequiredFieldValidator
 ID="RequiredFieldValidator3"
 runat="server"
 ErrorMessage="Please enter your address."
 ControlToValidate="txtAddress"
 Font-Size="Small"
 ForeColor="Red">
 </asp:RequiredFieldValidator>

 <asp:TextBox ID="txtSuite" runat="server" CssClass="shippingtxt" PlaceHolder="Apt/Suite [Optional]"></asp:TextBox>

 <asp:TextBox ID="txtZipCode" runat="server" CssClass="shippingtxt"
 PlaceHolder="Zip Code" Style="width: 49%; float: left; margin-top: 20px" required>
 </asp:TextBox>
 <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="shippingtxt"
 PlaceHolder="Phone Number" Style="width: 49%; float: right; margin-top: 20px" required>
 </asp:TextBox>

 Billing Information 

 <asp:TextBox ID="txtCardNo" runat="server" CssClass="shippingtxt" PlaceHolder="Card Number" required></asp:TextBox>
 <asp:TextBox ID="txtNameOnCard" runat="server" CssClass="shippingtxt" PlaceHolder="Name on Card" required></asp:TextBox>
 <asp:TextBox ID="txtExpMonth" runat="server" CssClass="shippingtxt" PlaceHolder="Month of Expiry" Style="width: 49%; float: left" required></asp:TextBox>
 <asp:TextBox ID="txtExpYear" runat="server" CssClass="shippingtxt" PlaceHolder="Year of Expiry" Style="width: 49%; float: right" required></asp:TextBox>
 <asp:TextBox ID="txtSecCode" runat="server" CssClass="shippingtxt" PlaceHolder="Security Code" Style="width: 18%; float: left" required></asp:TextBox>

 <asp:Label ID="lbl_TotalPrice" runat="server" Text="$0.00"></asp:Label>

 <asp:Label ID="lbl_ShippingPrice" runat="server" Text="$0.00"></asp:Label>
 Order Total:
<asp:Label ID="lbl_TotalPrice2" runat="server" Text="Label"></asp:Label>

 <asp:Button ID="btnSubmitOrder" runat="server" Text="SUBMIT ORDER" class="checkoutbtn" OnClick="btnSubmitOrder_Click" />

 Shipping Speed
 
 <asp:RadioButton ID="rbSS" runat="server" AutoPostBack="True" Checked="True" GroupName="Shipping" OnCheckedChanged="rbSS_CheckedChanged" />
 <asp:Label ID="Label1" runat="server" Text="Standard Shipping 5-7 Days" Font-Size="X-Small" for="rbSS"></asp:Label>
 <asp:RadioButton ID="rbES" runat="server" AutoPostBack="True" GroupName="Shipping" OnCheckedChanged="rbES_CheckedChanged" />
 <asp:Label ID="Label2" runat="server" Text="Expedited Shipping 2-3 Days" Font-Size="X-Small" for="rbES"></asp:Label>

 <asp:Label ID="lblSS" runat="server" Text="Label"></asp:Label>

 <asp:Label ID="lblES" runat="server" Text="$9.99"></asp:Label>

</asp:Content>
