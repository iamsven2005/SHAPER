<%@ Page Title="" Language="C#" MasterPageFile="~/Afterlogin.master" AutoEventWireup="true" CodeFile="index2.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script>
 window.onload = function() {
 // Check if the current URL path is not '/'
 if (window.location.pathname !== '/') {
 // Redirect to the root path
 window.location.href = '/';
 }
 };
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

</asp:Content>