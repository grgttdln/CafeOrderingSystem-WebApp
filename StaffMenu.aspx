<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_v5.Master" AutoEventWireup="true" CodeBehind="StaffMenu.aspx.cs" Inherits="MP_CS107L.StaffMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="mt-5 container">
        <div class="">
            <h1 class="">Staff Dashboard</h1>
            <h3 class="mt-1">Hello, <%: Session["Username"] %>!</h3>

        </div>
    </div>



    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4 mb-3">
                <div class="card">
                    <div class="card-body text-center">
                        <h5 class="card-title">Manage Product</h5>
                        <p class="card-text">manage availability of products</p>
                        <a href="ManageProduct.aspx?username=<%= Server.UrlEncode(Convert.ToString(Session["Username"])) %>" class="btn btn-outline-dark btn-block">Manage Product</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card">
                    <div class="card-body text-center">
                        <h5 class="card-title">Manage Order</h5>
                        <p class="card-text">manage orders of customers</p>
                        <a href="Staff.aspx?username=<%= Server.UrlEncode(Convert.ToString(Session["Username"])) %>" class="btn btn-outline-dark btn-block">Manage Order</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
