<%@ Page Title="Manage Orders" Language="C#" MasterPageFile="~/Navbar_v5.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="MP_CS107L.Staff" %>

<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h3 class="mb-5">Manage Orders</h3>

        <asp:Repeater ID="OrderRepeater" runat="server" OnItemDataBound="OrderRepeater_ItemDataBound">
            <itemtemplate>

                <div class="card mb-5">
                    <div class="card-header p-4 d-flex align-items-center justify-content-between">
                        <div class="card-title">
                            <h6 style="font-size: 18px;">
                                Order ID:<asp:Label ID="OrderID_Lbl" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>


                                <div class="mt-2">
                                    Order Date: <%# DateTime.Parse(Eval("OrderDate").ToString()).ToString("MMMM dd, yyyy") %>
                                </div>

                                <div class="mt-2">
                                    Order Time: <%# ((TimeSpan)Eval("OrderTime")).ToString(@"hh\:mm\:ss") %>
                                </div>


                                <div class="mt-2">
                                    Status: <%# string.IsNullOrEmpty(Eval("Status").ToString()) ? "" : new CultureInfo("en-US", false).TextInfo.ToTitleCase(Eval("Status").ToString().ToLower()) %>
                                </div>
                            </h6>

                        </div>


                        <div class="d-flex align-items-center me-3">

                            <div>
                                <asp:DropDownList ID="drpdwnStatus" runat="server" class="btn-group btn btn-primary btn-sm">
                                    <asp:ListItem Text="Pending" Value="pending"></asp:ListItem>
                                    <asp:ListItem Text="In Process" Value="in process"></asp:ListItem>
                                    <asp:ListItem Text="Done" Value="done"></asp:ListItem>
                                    <asp:ListItem Text="Cancelled" Value="cancelled"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="updateOrderBtn" class="btn btn-outline-primary btn-sm" runat="server" Text="Update Order" OnClick="updateOrderBtn_Click" />
                            </div>

                        </div>
                    </div>

                    <div class="p-4">
                        <div style="font-size: 18px;" class="d-flex align-items-center justify-content-between mx-5">
                            <h6>
                                Item
                            </h6>
                            <h6>
                                Quantity
                            </h6>
                        </div>
                        <%-- Product Details --%>
                        <asp:Repeater ID="ProductRepeater" runat="server">
                            <itemtemplate>
                                <div style="font-size: 18px;" class="d-flex align-items-center justify-content-between mx-5">
                                    <div>
                                        <%# Eval("ProductName") %>
                                    </div>
                                    <div>
                                        <%# Eval("Quantity") %>
                                    </div>
                                </div>

                            </itemtemplate>
                        </asp:Repeater>
                    </div>
                </div>


            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Content>
