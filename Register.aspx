<%@ Page Title="Register to Dan's Cafe" Language="C#" MasterPageFile="~/Navbar_v1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MP_CS107L.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="">
        <div class="container py-5">
            <div class="row d-flex justify-content-center align-items-center">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card shadow-sm p-3 mb-5 bg-white rounded" style="border-radius: 1rem;">
                        <div class="card-body py-4 text-center">
                            <h3 class="mb-1">Sign Up</h3>
                         </div>

                         <div class="card-body p-5">
                            <form runat="server">

                                <%-- First Name --%>
                                <div class="form-outline mb-4">
                                    <asp:Label ID="fnameLbl" runat="server" Text="First Name:"></asp:Label>
                                    <asp:TextBox autocomplete="off" ID="fname" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="fname" runat="server" ErrorMessage="First Name is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="fname" runat="server" ErrorMessage="Invalid Input."  ValidationExpression="^[a-zA-Z\s]{1,50}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <%-- Last Name --%>
                                <div class="form-outline mb-4">
                                    <asp:Label ID="lnameLbl" runat="server" Text="Last Name:"></asp:Label>
                                    <asp:TextBox autocomplete="off" ID="lname" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="lname" runat="server" ErrorMessage="Last Name is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="lname" runat="server" ErrorMessage="Invalid Input."  ValidationExpression="^[a-zA-Z\s]{1,50}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>


                                <%-- Address --%>
                                <div class="form-outline mb-4">
                                    <asp:Label ID="addressLbl" runat="server" Text="Address:"></asp:Label>
                                    <asp:TextBox autocomplete="off" ID="address" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="address" runat="server" ErrorMessage="Address is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="address" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^[a-zA-Z0-9\s\-,.'#/]{1,100}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <%-- Phone Number --%>
                                <div class="form-outline mb-4">
                                    <asp:Label ID="telNumLbl" runat="server" Text="Phone Number:"></asp:Label>
                                    <asp:TextBox autocomplete="off" ID="telNum" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="telNum" runat="server" ErrorMessage="Phone Number is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="telNum" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^09\d{9}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <%-- Username --%>
                                <div class="form-outline mb-4">
                                    <asp:Label ID="usernameLbl" runat="server" Text="Username:"></asp:Label>
                                    <asp:TextBox autocomplete="off" ID="username" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="username" runat="server" ErrorMessage="Username is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="username" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^(?=.*[a-zA-Z])[a-zA-Z][a-zA-Z0-9]{2,49}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <%-- Password --%>
                                <div class="form-outline mb-4">
                                    <asp:Label ID="passwordLbl" runat="server" Text="Password:"></asp:Label>
                                    <asp:TextBox autocomplete="off" ID="password" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="password" runat="server" ErrorMessage="Password is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="password" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^(?=.{1,50}$).*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    <asp:CompareValidator ID="passCV" ControlToValidate="password" ControlToCompare="confirmPass" Operator="Equal" Type="String" runat="server" ErrorMessage="Passwords do not match." ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                </div>

                                <%-- Confirm Password --%>
                                <div class="form-outline mb-4">
                                    <asp:Label ID="confirmPassLbl" runat="server" Text="Confirm Password:"></asp:Label>
                                    <asp:TextBox autocomplete="off" ID="confirmPass" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="confirmPass" runat="server" ErrorMessage="Password is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="confirmPass" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^(?=.{1,50}$).*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    <asp:CompareValidator ID="CompareValidator1" ControlToValidate="confirmPass" ControlToCompare="password" Operator="Equal" Type="String" runat="server" ErrorMessage="Passwords do not match." ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                </div>

                                <%-- Submit --%>
                                <div class="form-outline mb-4 d-flex justify-content-center">
                                    <asp:Button ID="registerBtn" runat="server" Text="Sign Up" class="btn btn-outline-dark flex-grow-1" OnClick="registerBtn_Click"/>
                                </div>

                                <a class="d-block text-center link-offset-2 link-underline link-underline-opacity-0" href="Login.aspx">Already have an account? Log in.</a>
                            
                            </form>
                         </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
