<%@ Page Title="Your Cart" Language="C#" MasterPageFile="~/Navbar_v3.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="MP_CS107L.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .full-width-button {
            width: 100%;
        }

        .grid-container {
            display: grid;
            grid-template-columns: 70% 30%;
        }
    </style>

    <form class="container" runat="server">
        <div class="container mt-4">
            <h3 class="mt-5 mb-3">Your Cart</h3>
            <div class="row">
                <div class="col-md-12">

                    <%-- No Items in the Cart --%>
                    <div id="NoProduct" runat="server">
                        <div class="card text-center">
                            <div class="card-body">
                                <p class="card-text">You have no items in your cart.</p>
                            </div>
                        </div>
                    </div>

            <asp:Repeater ID="CartItemRepeater" runat="server">
                <ItemTemplate>
                    <div class="card mb-3">
                        <div class="row g-0">
                            <div class="col-md-4">
                                <!-- product image -->
                                <img class="card-img-top" src="images/<%# Eval("prodID") %>.png" alt="Card image cap" style="width: 180px; height: auto;">
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <%-- product description --%>
                                    <div class="d-flex justify-content-between align-items-center">
                                        <div>
                                            <h5 class="card-title"><%# Eval("prodName") %></h5>
                                            <p class="card-text">Size: <%# Eval("size") %></p>

                                            <asp:Button ID="subItem" runat="server" class="btn btn-danger" Text="-" OnClick="subItem_Click" CommandArgument='<%# Eval("prodID") %>' />
                                            <asp:TextBox ID="quantityTxt" runat="server" Enabled="False" Text='<%# Eval("quantity") %>' Width="40px" Style="text-align: center;"></asp:TextBox>
                                            <asp:Button ID="addItem" runat="server" class="btn btn-success" Text="+" OnClick="addItem_Click" CommandArgument='<%# Eval("prodID") %>' />

                                            <p class="card-text">Price: ₱<%# Eval("price", "{0:F2}") %></p>
                                        </div>
                                        <div class="me-4">
                                            <asp:Button ID="deleteItem" runat="server" Text="" class="btn btn-close" aria-label="Close" OnClick="deleteItem_Click" CommandArgument='<%# Eval("prodID") %>' />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        </div>


            <!-- total section -->
        <div id="totalSection" runat="server">
            <div class="row mt-4">
                <div class="col-md-12">
                    <h2>Total</h2>
                    <div class="card">
                        <div class="row my-3 d-flex justify-content-between align-items-center">
                            <div class="col-12 col-md-4">
                                <h4 class="text-center">Product Name</h4>
                            </div>
                            <div class="col-12 col-md-4">
                                <h4 class="text-center">Quantity</h4>
                            </div>
                            <div class="col-12 col-md-4">
                                <h4 class="text-center">Price</h4>
                            </div>
                        </div>
                        <asp:Repeater ID="CartItemRepeater_Total" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-1 border-bottom"></div>
                                <div class="row my-2">
                                    <div class="col-12 col-md-4">
                                        <p class="text-center text-md-left"><%# Eval("prodName") %></p>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <p class="text-center text-md-left"><%# Eval("quantity") %></p>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <p class="text-center text-md-left"><%# Eval("price", "{0:C}") %></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <div class="mt-4">
                <div class="card">
                    <h5 class="mx-5 my-3">Price: ₱<asp:Label class="flex-grow-1 text-right" ID="totalCart" runat="server" Text=""></asp:Label>
                    </h5>
                </div>
            </div>
        </div>

        <!-- Button Checkout -->
        <div class="row">
            <div class="col-md-12 mt-5 my-5">
                <asp:Button ID="checkoutBtn" class="btn btn-outline-success btn-lg full-width-button" runat="server" Text="Submit" OnClick="checkoutBtn_Click" />
            </div>
        </div>

        </div>
    </form>
</asp:Content>
