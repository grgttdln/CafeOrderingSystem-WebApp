<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_v4.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MP_CS107L.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-5 container">
        <div class="">
            <h1 class="">Admin Dashboard</h1>
            <h3 class="mt-1">Hello, <%: Session["Username"] %>!</h3>

        </div>
    </div>

    <div class="container mt-5">
        <div class="row mt-5">
            <div class="col-md-4 mb-3">
                <div class="card">
                    <div class="card-body text-center">
                        <h5 class="card-title">Create Staff</h5>
                        <p class="card-text">add new staff members</p>
                        <a href="CreateStaff.aspx?username=<%= Session["Username"] %>" class="btn btn-outline-dark btn-block">Create Staff</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card">
                    <div class="card-body text-center">
                        <h5 class="card-title">Manage Staff</h5>
                        <p class="card-text">remove existing staff profiles</p>
                        <a href="ManageStaff.aspx?username=<%= Session["Username"] %>" class="btn btn-outline-dark btn-block">Manage Staff</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card">
                    <div class="card-body text-center">
                        <h5 class="card-title">Sales Report</h5>
                        <p class="card-text">view sales performance</p>
                        <a href="Sales.aspx?username=<%= Session["Username"] %>" class="btn btn-outline-dark btn-block">Sales Report</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
