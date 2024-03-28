<%@ Page Title="View Sales" Language="C#" MasterPageFile="~/Navbar_v4.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="MP_CS107L.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container mt-3">

        <h3>Sales Report</h3>

        <div class="card mt-3 mb-5">
            <%-- All time --%>
            <h3 class="card-header">All Time</h3>
            <div class="card-body">
                <%-- No information --%>
                <div id="infoMostSold" runat="server" class="mb-3">
                    <div class="card text-center">
                        <div class="card-body">
                            <p class="card-text">No current information on most sold products.</p>
                        </div>
                    </div>
                </div>
                <asp:Repeater ID="TotalMaxSaleRepeater" runat="server">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="row g-0">
                                <div class="col-md-2">
                                    <img src="images/<%# Eval("ProductID") %>.png" class="card-img-top" alt="Product Image" style="height: 215px;" />
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h5 class="card-title">Most Sold Product: <%# Eval("ProductItem") %></h5>
                                        <p class="card-text">Quantity Sold: <%# Eval("MaxQuantity") %></p>
                                        <p class="card-text">Price: <%# Eval("Price") %></p>
                                        <h6 class="card-footer">Total Price: ₱<%# Convert.ToDouble(Eval("Price")) * Convert.ToInt32(Eval("MaxQuantity")) %>.00</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


                <%-- No information --%>
                <div id="infoLeastSold" runat="server" class="mb-3">
                    <div class="card text-center">
                        <div class="card-body">
                            <p class="card-text">No current information on least sold products.</p>
                        </div>
                    </div>
                </div>
                <%-- least sold --%>
                <asp:Repeater ID="TotalLeastSaleRepeater" runat="server">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="row g-0">
                                <div class="col-md-2">
                                    <img src="images/<%# Eval("ProductID") %>.png" class="card-img-top" alt="Product Image" style="height: 215px;" />
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h5 class="card-title">Least Sold Product: <%# Eval("ProductItem") %></h5>
                                        <p class="card-text">Quantity Sold: <%# Eval("MaxQuantity") %></p>
                                        <p class="card-text">Price: <%# Eval("Price") %></p>
                                        <h6 class="card-footer">Total Price: ₱<%# Convert.ToDouble(Eval("Price")) * Convert.ToInt32(Eval("MaxQuantity")) %>.00</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>


        <div class="card mt-3 mb-5">
            <%-- view all product sales --%>
            <div class="card-header p-4 d-flex align-items-center justify-content-between">
                <h3>View Sales</h3>
                <div class="d-flex align-items-center">
                    <asp:DropDownList ID="ViewReportDDL" runat="server" class="btn-group btn btn-primary btn-sm me-1">
                        <asp:ListItem Text="Today" Value="today"></asp:ListItem>
                        <asp:ListItem Text="This Week" Value="thisweek"></asp:ListItem>
                        <asp:ListItem Text="January" Value="1"></asp:ListItem>
                        <asp:ListItem Text="February" Value="2"></asp:ListItem>
                        <asp:ListItem Text="March" Value="3"></asp:ListItem>
                        <asp:ListItem Text="April" Value="4"></asp:ListItem>
                        <asp:ListItem Text="May" Value="5"></asp:ListItem>
                        <asp:ListItem Text="June" Value="6"></asp:ListItem>
                        <asp:ListItem Text="July" Value="7"></asp:ListItem>
                        <asp:ListItem Text="August" Value="8"></asp:ListItem>
                        <asp:ListItem Text="September" Value="9"></asp:ListItem>
                        <asp:ListItem Text="October" Value="10"></asp:ListItem>
                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                        <asp:ListItem Text="December" Value="12"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="ViewReportBtn" runat="server" Text="View Report" OnClick="ViewReportBtn_Click" class="btn btn-outline-primary btn-sm me-1" />
                </div>

            </div>

            <div class="card-body">
                <%-- No information --%>
                <div id="infoRepAll" runat="server" class="mb-3">
                    <div class="card text-center">
                        <div class="card-body">
                            <p class="card-text">No current information on sold products.</p>
                        </div>
                    </div>
                </div>
                <asp:Repeater ID="ProductSalesRepeater" runat="server">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="row g-0">
                                <div class="col-md-2">
                                    <asp:Image ID="productImage" ImageUrl='<%# "images/" + Eval("ProductID") + ".png" %>' class="card-img-top" alt="Product Image" Style="height: 215px;" runat="server" />
                                </div>
                                <div class="col-md-10">
                                    <div class="card-body">
                                        <h5 class="card-title">Product: <%# Eval("ProductItem") %></h5>
                                        <p class="card-text">Quantity Sold: <%# Eval("MaxQuantity") %></p>
                                        <p class="card-text">Price: <%# Eval("Price") %></p>
                                        <%--<p class="card-text">Total Price: <%# Convert.ToDouble(Eval("Price")) * Convert.ToInt32(Eval("MaxQuantity")) %></p>--%>
                                        <h6 class="card-footer">Price: ₱<asp:Label ID="totalPrice" runat="server" Text='<%# Convert.ToDouble(Eval("Price")) * Convert.ToInt32(Eval("MaxQuantity")) %>'></asp:Label>.00
                                        </h6>


                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <h5 class="mt-5">
                    <asp:Label ID="TotalProductsLabel" runat="server" Text="Total Price: " CssClass="font-weight-bold"></asp:Label>
                </h5>
            </div>
        </div>
    </form>
</asp:Content>
