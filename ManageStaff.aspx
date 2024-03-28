<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_v4.Master" AutoEventWireup="true" CodeBehind="ManageStaff.aspx.cs" Inherits="MP_CS107L.ManageStaff1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <form class="container" runat="server">
        <h3 class="mt-5 mb-5">Manage Staff</h3>

        <%-- No Items in the Cart --%>
        <div id="NoStaff" runat="server">
            <div class="card text-center">
                <div class="card-body">
                    <p class="card-text">You have no staff.</p>
                </div>
            </div>
        </div>


        <asp:Repeater ID="AllStaffRepeater" runat="server">
            <ItemTemplate>
                <div>
                    <div class="card col-md-12 mt-3">
                        <div class="card-body">
                            <%-- product description --%>
                            <div class="d-flex justify-content-between align-items-center mt-3">
                                <div>
                                    <h5 class="card-title"><%# Eval("LastName") %>, <%# Eval("FirstName") %></h5>
                                    <p><%# Eval("PhoneNumber") %></p>
                                    <p><%# Eval("Address") %></p>
                                </div>
                                <div class="me-4">
                                    <asp:Button ID="deleteStaff" runat="server" Text="Remove Staff" class="btn btn-outline-danger" aria-label="Close" OnClick="deleteStaff_Click" CommandArgument='<%# Eval("Username") %>' />
                                </div>
                            </div>
                        </div>
                    </div>


                </div>

            </ItemTemplate>
        </asp:Repeater>
    </form>

</asp:Content>
