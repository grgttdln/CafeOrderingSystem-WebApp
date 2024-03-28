using MP_CS107L.App.Orders;
using MP_CS107L.App.Product;
using MP_CS107L.App.Purchase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP_CS107L
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve username from query string
            string username = Request.QueryString["username"];

            // Store username in session state
            Session["Username"] = username;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductData();
            }
            else
            {
                // initial load
                BindProductData();
            }
        }


        private void BindProductData()
        {
            CartRepository repository = new CartRepository();
            string cartID = repository.GetCartIDUser(Request.QueryString["username"]);

            // Retrieve items and total from the repository method
            var (items, total) = repository.GetItemsFromCartWithTotal(cartID);

            if (items != null && items.Any())
            {

                NoProduct.Visible = false;

                CartItemRepeater.DataSource = items;
                CartItemRepeater.DataBind();

                CartItemRepeater_Total.DataSource = items;
                CartItemRepeater_Total.DataBind();

                
                CartItemRepeater.Visible = true;
                CartItemRepeater_Total.Visible = true;
                totalSection.Visible = true;

                checkoutBtn.Visible = true;

                // Display the total value
                totalCart.Text = $"{total}";


            }
            else
            {

                NoProduct.Visible = true;


                CartItemRepeater.Visible = false;
                CartItemRepeater_Total.Visible = false;
                totalSection.Visible = false;

                checkoutBtn.Visible = false;

                // Clear the total value
                totalCart.Text = $"";
            }
        }

        protected void deleteItem_Click(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            string productId = currBtn.CommandArgument;

            Response.Write($"<script>alert('{productId}');</script>");


            // remove the item from the database
            CartRepository repository = new CartRepository();
            repository.DeleteItemFromCart(productId);

            Response.Redirect(Request.RawUrl);

        }

        protected void subItem_Click(object sender, EventArgs e)
        {
            Button subItemButton = (Button)sender;

            RepeaterItem item = (RepeaterItem)subItemButton.NamingContainer;
            string productId = subItemButton.CommandArgument;
            TextBox quantityTxt = (TextBox)item.FindControl("quantityTxt");

            // Get the text value of the TextBox
            int quantity = int.Parse(quantityTxt.Text);

            quantity--;

           
            if (quantity == 0)
            {
                subItemButton.Enabled = false;
                Response.Redirect(Request.RawUrl);
            } 
            else
            {
                // Check if the TextBox is found
                if (quantityTxt != null)
                {

                    // update database
                    CartRepository repository = new CartRepository();
                    repository.SubtractQuantity(productId, quantity);

                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write($"<script>alert('Invalid Command');</script>");
                }
            }
        }


        protected void addItem_Click(object sender, EventArgs e)
        {
            Button addItemButton = (Button)sender;

            RepeaterItem item = (RepeaterItem)addItemButton.NamingContainer;
            string productId = addItemButton.CommandArgument;
            TextBox quantityTxt = (TextBox)item.FindControl("quantityTxt");

            // Check if the TextBox is found
            if (quantityTxt != null)
            {
                // Get the text value of the TextBox
                int quantity = int.Parse(quantityTxt.Text);

                // update database
                CartRepository repository = new CartRepository();
                repository.AddQuantity(productId, quantity);


                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Write($"<script>alert('Invalid Command');</script>");
            }
        }

        protected void checkoutBtn_Click(object sender, EventArgs e)
        {


            CartRepository cartRepository = new CartRepository();

            string cartID = cartRepository.GetCartIDUser(Request.QueryString["username"]);

            if (cartID == "")
            {
                cartID = "C-" + Request.QueryString["username"] + "-1";
            }



            PurchaseRepository purchaseRepository = new PurchaseRepository();

            purchaseRepository.InsertPurchase(cartID, Request.QueryString["username"]);

            cartRepository.SubmitOrder(Request.QueryString["username"]);
            cartRepository.CalculateTotal(cartID);

            purchaseRepository.DeleteCartPurchase(cartID);

            Response.Redirect(Request.RawUrl);


            
        }
    }
}