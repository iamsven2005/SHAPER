<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">   
    <asp:TextBox ID="txtSearch" Style="display:none;" runat="server"></asp:TextBox>
    <asp:Label ID="lblnoresult" runat="server" Text="No results found." Font-Size="Larger" Visible="False"></asp:Label>

        <asp:Repeater ID="Repeater1" runat="server">
        
        <ItemTemplate>
            <div class="card w-96 bg-base-100 shadow-xl mx-auto center">
                <figure>
                    <div class="carousel carousel-center max-w p-4 space-x-4 bg-neutral rounded-box">
                        <div id="item1" class="carousel-item">
                            <img href="ProductDetails.aspx?ProdID=<%# Eval("ID") %>"  src='<%#Eval("Image") %>' />
                        </div>
                    </div>
                </figure>
                <div class="flex justify-center w-full py-2 gap-2">
                    <a href="#item1" class="btn btn-xs">1</a>
                </div>
                <div class="join carousel rounded-box">
                    <button class="btn join-item">
                        <svg class="h-5 w-5" version="1.0" viewBox="0 0 810 810" xmlns="http://www.w3.org/2000/svg"
                            zoomAndPan="magnify">
                            <path d="m179.88 210.04h450.25l-225.12 389.91zm429.44 11.977h-408.64l204.32 353.89z"
                                fill="#79c7ff" />
                        </svg>
                    </button>
                    <button class="btn join-item">
                    Value
                    </button>
                    <button class="btn join-item">
                        <svg class="h-5 w-5" version="1.0" viewBox="0 0 810 810" xmlns="http://www.w3.org/2000/svg">
                            <path d="m630 600h-450l225-390zm-430-12h408.64l-204.32-354z" fill="#f00" />
                        </svg>
                    </button>
                    <a class="btn join-item" href="ProductDetails.aspx?ProdID=<%# Eval("ID") %>">
                        <svg class="h-5 w-5" version="1.0" fill="#fff" viewBox="0 0 810 810"
                            xmlns="http://www.w3.org/2000/svg" zoomAndPan="magnify">
                            <path
                                d="m146.25 570c0-51.793 42.246-93.75 93.75-93.75s93.75 41.957 93.75 93.75-41.957 93.75-93.75 93.75-93.75-42.246-93.75-93.75zm181.71 0c0-48.609-39.355-87.965-87.965-87.965s-87.965 39.355-87.965 87.965 39.355 87.965 87.965 87.965 87.965-39.645 87.965-87.965z" />
                            <path d="m277.11 177.1v-12.102h330.77v12.102z" />
                            <path d="m277.11 570v-12.102h330.77v12.102z" />
                            <path d="m240 532.89v-330.77h12.102v330.77z" />
                            <path d="m632.9 532.89v-330.77h12.102v330.77z" />
                            <path d="m252.1 177.1h25.012v-12.102h-37.113v37.113h12.102z" />
                            <path d="m252.1 557.9v-25.012h-12.102v37.113h37.113v-12.102z" />
                            <path d="m632.9 177.1v25.012h12.102v-37.113h-37.113v12.102z" />
                            <path d="m632.9 557.9h-25.012v12.102h37.113v-37.113h-12.102z" />
                        </svg>
                        Comment
                    </a>

                    <button class="btn join-item" >
                        <svg class="h-5 w-5" version="1.0" fill="#fff" viewBox="0 0 810 810"
                            xmlns="http://www.w3.org/2000/svg" zoomAndPan="magnify">
                            <path d="m221.11 193.57v-13.445h367.53v13.445z" />
                            <path d="m221.11 630.12v-13.449h367.53v13.449z" />
                            <path d="m179.88 588.88v-367.53h13.445v367.53z" />
                            <path d="m616.43 588.88v-367.53h13.449v367.53z" />
                            <path d="m193.32 193.57h27.789v-13.445h-41.234v41.234h13.445z" />
                            <path d="m193.32 616.67v-27.789h-13.445v41.238h41.234v-13.449z" />
                            <path d="m616.43 193.57v27.789h13.449v-41.234h-41.238v13.445z" />
                            <path d="m616.43 616.67h-27.789v13.449h41.238v-41.238h-13.449z" />
                            <path d="m582.21 558.67h-354.75l177.38-307.42zm-338.36-9.4414h321.97l-160.98-279.02z" />

                        </svg>

                        Share
                    </button>
                </div>
                <div class="card-body">
                    <p class="card-title" ><%#Eval("Title")%></p>
                    <p class="bookauthor" ><%#Eval("Author") %></p>
<%--                    <p><asp:Label ID="Label1" runat="server" Text='<%#Eval("Description") %>'></asp:Label></p>--%>
                    <div class="card-actions justify-end">
                    </div>
                </div>
            </div>
        </ItemTemplate>
        
    </asp:Repeater>
    

</asp:Content>
