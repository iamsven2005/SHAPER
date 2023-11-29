<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script>
 window.onload = function() {
 // Check if the current URL path is not '/'
 if (window.location.pathname !== '/') {
 // Redirect to the root path
 window.location.href = '/';
 }};
 //security feature 
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

</asp:Content>

