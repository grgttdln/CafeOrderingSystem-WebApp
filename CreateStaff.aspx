<%@ Page Title="Create Staff" Language="C#" MasterPageFile="~/Navbar_v4.Master" AutoEventWireup="true" CodeBehind="CreateStaff.aspx.cs" Inherits="MP_CS107L.ManageStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Main Container --%>
    <div class="container">

        <h3 class="mt-5 mb-5">Create Staff</h3>

        <%-- Create New Staff --%>
        <div class="mt-5">
            <div class="card mb-5">
                <h5 class="card-header mt-2 mb-2">Please enter the information:</h5>
                <div class="card-body">
                    <form runat="server">
                        <%-- Username --%>
                        <div class="row">
                            <h5 class="col">
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="staffUsername" Text="Username:"></asp:Label>
                                <asp:TextBox autocomplete="off" ID="staffUsername" class="form-control mt-2" runat="server"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="staffUsername" runat="server" ErrorMessage="Username is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                            </h5>
                        </div>
                        <%-- Password --%>
                        <div class="row mt-3">
                            <h5 class="col">
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="userPassword" Text="Password:"></asp:Label>
                                <asp:TextBox autocomplete="off" ID="userPassword" class="form-control mt-2" runat="server"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="userPassword" runat="server" ErrorMessage="Password is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                
                            </h5>
                        </div>
                        <%-- First Name --%>
                        <div class="row mt-3">
                            <h5 class="col">
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="staffFName" Text="First Name:"></asp:Label>
                                <asp:TextBox autocomplete="off" ID="staffFName" class="form-control mt-2" runat="server"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="staffFName" runat="server" ErrorMessage="First Name is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="staffFName" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^[a-zA-Z\s]{1,50}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>


                            </h5>
                        </div>
                        <%-- Last Name --%>
                        <div class="row mt-3">
                            <h5 class="col">
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="staffLName" Text="Last Name:"></asp:Label>
                                <asp:TextBox autocomplete="off" ID="staffLName" class="form-control mt-2" runat="server"></asp:TextBox>


                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="staffLName" runat="server" ErrorMessage="Last Name is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="staffLName" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^[a-zA-Z\s]{1,50}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>


                            </h5>
                        </div>
                        <%-- Phone Number --%>
                        <div class="row mt-3">
                            <h5 class="col">
                                <asp:Label ID="Label5" runat="server" AssociatedControlID="staffNum" Text="Phone Number:"></asp:Label>
                                <asp:TextBox autocomplete="off" ID="staffNum" class="form-control mt-2" runat="server"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="staffNum" runat="server" ErrorMessage="Phone Number is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="staffNum" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^09\d{9}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>


                            </h5>
                        </div>
                        <%-- Address --%>
                        <div class="row mt-3">
                            <h5 class="col">
                                <asp:Label ID="Label6" runat="server" AssociatedControlID="staffAddress" Text="Address:"></asp:Label>
                                <asp:TextBox autocomplete="off" ID="staffAddress" class="form-control mt-2" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="staffAddress" runat="server" ErrorMessage="Address is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="staffAddress" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^[a-zA-Z0-9\s\-,.'#/]{1,100}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </h5>
                        </div>
                        <%-- Button --%>
                        <div class="row mt-5">
                            <div class="col">
                                <asp:Button ID="createStaffBtn" runat="server" CssClass="btn btn-outline-dark w-100" Text="Create Staff" OnClick="createStaffBtn_Click" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>


    </div>


</asp:Content>
