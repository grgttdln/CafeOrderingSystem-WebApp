<%@ Page Title="Your Purchases" Language="C#" MasterPageFile="~/Navbar_v3.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="MP_CS107L.Purchase" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .custom-margin {
            margin-right: 15%;
            margin-left: 15%;
        }
    </style>

    <div class="container mt-4">
        <h2 class="mt-5 mb-3">Your Purchases</h2>

        <%-- No Items in the Cart --%>
        <div id="NoProduct" runat="server">
            <div class="card text-center">
                <div class="card-body">
                    <p class="card-text">You have no items in your cart.</p>
                </div>
            </div>
        </div>

        <div class="row">
            <% string previousOrderID = null;
                for (int i = 0; i < Items.Count(); i++)
                {
                    var item = Items.ElementAt(i);
                    if (item.orderID != previousOrderID)
                    {
                        if (previousOrderID != null)
                        { %>

                     <% } %>
        </div>

    </div>
    </div>
</div> 
    <div>
        <div class="row d-flex justify-content-center align-items-center">
            <div class="card mb-4 col-md-9">
                <div>
                    <div class="card-header" style="display: flex; justify-content: space-between; align-items: center;">
                        <%--<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512" style="width: 24px; height: 24px; margin-right: 8px;">
                            <!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc.-->
                            <path d="M96 64c0-17.7 14.3-32 32-32H448h64c70.7 0 128 57.3 128 128s-57.3 128-128 128H480c0 53-43 96-96 96H192c-53 0-96-43-96-96V64zM480 224h32c35.3 0 64-28.7 64-64s-28.7-64-64-64H480V224zM32 416H544c17.7 0 32 14.3 32 32s-14.3 32-32 32H32c-17.7 0-32-14.3-32-32s14.3-32 32-32z" />
                        </svg>--%>
                        <h5>Order ID: <%= item.orderID %></h5>


                        <div style="margin-left: auto; display: flex; align-items: center;">

                            <%
                                if (item.status == "pending")
                                { %>
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" style="width: 12px; height: 12px;">
                                <!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc.-->
                                <path fill="#FFD43B" d="M12 0A12 12 0 1 0 12 24 12 12 0 0 0 12 0z" />
                            </svg>

                            <% }
                                else if (item.status == "in process")
                                { %>
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" style="width: 12px; height: 12px;">
                                <!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc.-->
                                <path fill="#0055ff" d="M12 0A12 12 0 1 0 12 24 12 12 0 0 0 12 0z" />
                            </svg>

                            <% }
                                else if (item.status == "done")
                                { %>
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" style="width: 12px; height: 12px;">
                                <!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc.-->
                                <path fill="#0fe000" d="M12 0c6.627 0 12 5.373 12 12s-5.373 12-12 12S0 18.627 0 12 5.373 0 12 0z" />
                            </svg>

                            <%}
                                else if (item.status == "cancelled")
                                { %>
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" style="width: 12px; height: 12px;">
                                <!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc.-->
                                <circle cx="256" cy="256" r="256" fill="#ba2121" />
                            </svg>


                            <%}%>

                            <h5 style="margin-left: 8px"><%= item.status %></h5>

                        </div>

                    </div>
                    <div class="card-header" style="display: flex; justify-content: space-between; align-items: center;">
                        <h5>Total Price: <%= item.totalOrder %></h5>
                        <div>
                            <h5>Order Date: <%= item.orderDate.ToString("MMMM dd, yyyy") %></h5>
                            <h5>Order Time: <%= item.orderTime.ToString("h\\:mm\\:ss") %></h5>

                        </div>
                    </div>

                    <div class="card-body">
                        <p class="card-text">Product Name: <%= item.prodName %></p>
                        <p class="card-text">Quantity: <%= item.quantity %></p>
                        <p class="card-text">Price: <%= item.price %></p>
                    </div>


                    <% }
                        else
                        { %>
                    <div class="col-md-12">
                        <div class="mb-4">

                            <br />
                            <div class="card-body">
                                <p class="card-text">Product Name: <%= item.prodName %></p>
                                <p class="card-text">Quantity: <%= item.quantity %></p>
                                <p class="card-text">Price: <%= item.price %></p>
                            </div>

                        </div>
                    </div>
                    <% }
                        previousOrderID = item.orderID; %>

                    <% } %>
                </div>
            </div>
        </div>
</asp:Content>
