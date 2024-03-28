
<%@ Page Title="Cafe Menu" Language="C#" MasterPageFile="~/Navbar_v3.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="MP_CS107L.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form class="container mb-5" runat="server">
        <div class="row mb-3">
            <div class="col mb-2">
                <h3 class="mt-5">Hello, <%: Session["Username"] %>!</h3>
                <h3 class="">Check Out Our Menu</h3>
            </div>
        </div>

                <%-- Dropdown --%>
                <div class="row mb-3">
                    <div class="col">
                        <asp:DropDownList ID="ProductFilter" runat="server" class="form-select btn-group btn btn-outline-success" AutoPostBack="true" OnSelectedIndexChanged="ProductFilter_SelectedIndexChanged">
                            <asp:ListItem Text="All Products" Value=""></asp:ListItem>
                            <asp:ListItem Text="Coffee" Value="coffee"></asp:ListItem>
                            <asp:ListItem Text="Non-Coffee" Value="non-coffee"></asp:ListItem>
                            <asp:ListItem Text="Frappe" Value="frappe"></asp:ListItem>
                            <asp:ListItem Text="Food" Value="food"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>




                <div class="row">
                    <asp:Repeater ID="ProductItemRepeater" runat="server" OnItemDataBound="ProductItemRepeater_ItemDataBound" OnItemCommand="ProductItemRepeater_ItemCommand">
                        <ItemTemplate>
                            <div class="col-sm-6 col-md-4 col-lg-3 mb-3">
                                <div class="card h-100" style="width: 100%;">
                                    <img class="card-img-top" src="images/<%# Eval("Id") %>.png" alt="Card image cap">
                                    <div class="card-body d-flex flex-column">
                                        <div class="card-text flex-grow-1">
                                            <p><%# Eval("Name") %></p>
                                        </div>
                                        <div class="">
                                            <button type="button" class="btn btn-outline-success btn-sm" data-bs-toggle="modal" data-bs-target="#itemProd<%# Container.ItemIndex %>">
                                                View Product
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- Modal -->
                            <div class="modal fade" id="itemProd<%# Container.ItemIndex %>" tabindex="-1" aria-labelledby="itemProdModal<%# Container.ItemIndex %>" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered">
                                    <div class="modal-content">
                                        <div class="modal-header d-flex justify-content-between">
                                            <div>
                                                <h3 class="modal-title" id="itemProdModal<%# Container.ItemIndex %>"><%# Eval("Name") %></h3>
                                                <h5 class="modal-title" id="itemProdModal<%# Container.ItemIndex %>"><%# Eval("Type") %></h5>
                                            </div>
                                        </div>
                                        <div class="modal-body">
                                            <div>
                                                <div>
                                                    <img class="card-img-top mb-3" src="images/<%# Eval("Id") %>.png" alt="Card image cap">
                                                </div>
                                                <h6 class="mb-2">
                                                    <%# Eval("Description") %>
                                                </h6>
                                                <h6 id="itemPrice" class="mb-3">₱ <%# Eval("Price") %>
                                                </h6>
                                                <h6>
                                                    <asp:Label ID="IsItemAvailable" runat="server" Text='<%# (bool)Eval("IsAvailable") ? "Available" : "Not Available" %>'></asp:Label>
                                                </h6>


                                                <%-- item quantity (add validation) --%>
                                                <h6>Enter Quantity:
                                                    <asp:TextBox ID="itemQty" TextMode="Number" runat="server" value="1" min="1"></asp:TextBox>
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="itemQty" ErrorMessage="Input Valid Quanitty" MinimumValue="1" MaximumValue="99"></asp:RangeValidator>
                                                </h6>

                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                            <%--<asp:Button ID="AddToCartButton" class="btn btn-outline-success" runat="server" Text="Add to Cart" OnClick="addToCart_Click" CommandArgument='<%# Eval("Id") %>' OnClientClick="return getValueOfItemQty('<%= itemQty.ClientID %>');" />--%>
                                            <asp:Button ID="AddToCartButton" class="btn btn-outline-success" runat="server" Text="Add to Cart" CommandName="AddToCart" CommandArgument='<%# Eval("Id") %>' />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>


    </form>

</asp:Content>

