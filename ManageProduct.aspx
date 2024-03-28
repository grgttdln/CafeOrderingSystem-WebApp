<%@ Page Title="Manage Product Availability" Language="C#" MasterPageFile="~/Navbar_v5.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="MP_CS107L.ManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h3>Manage Product</h3>

        <div class="row mt-5">
            <div class="col-md-12">
                <asp:Repeater ID="ManageProductRepeater" runat="server" OnItemDataBound="ManageProductRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Name") %></h5>
                                <asp:HiddenField ID="ProductIdHiddenField" Value='<%# Eval("Id") %>' runat="server" />
                                <p class="card-text">Available: <%# Eval("IsAvailable") %></p>
                                <div>
                                    <div class="dropdown">
                                        <asp:DropDownList ID="AvailabilityDropDown" runat="server" CssClass="form-select">
                                            <asp:ListItem Text="True" Value="True"></asp:ListItem>
                                            <asp:ListItem Text="False" Value="False"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <!-- Button Checkout -->
            <div class="text-center mt-5 mb-5">
                <asp:Button ID="updateAvailability" class="btn btn-outline-success btn-lg col-md-12" runat="server" Text="Save Update" OnClick="updateAvailability_Click" />
            </div>
        </div>



    </div>
</asp:Content>
