<%@ Page Title="Log in to Dan's Cafe" Language="C#" MasterPageFile="~/Navbar_v1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MP_CS107L.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container py-5">
            <div class="row d-flex justify-content-center align-items-center">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card shadow-sm p-3 mb-5 bg-white rounded">
                        <div class="card-body py-4 text-center">
                            <h3 class="mb-1">Log In</h3>
                         </div>

                         <div class="card-body p-5">
                            <form runat="server">
                                <div class="form-outline mb-4">
                                    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                                    <asp:TextBox autocomplete="off" ID="userLogin" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-outline mb-4">
                                    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                                    <asp:TextBox autocomplete="off" ID="userPassword" class="form-control form-control-lg" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-outline mb-4 d-flex justify-content-center">
                                    <asp:Button ID="loginBtn" runat="server" class="btn btn-outline-dark flex-grow-1" Text="Log In" OnClick="loginBtn_Click" />
                                </div>

                                <a class="d-block text-center link-offset-2 link-underline link-underline-opacity-0" href="Register.aspx">Don't have an account yet? Sign up.</a>
                            </form>
                         </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
