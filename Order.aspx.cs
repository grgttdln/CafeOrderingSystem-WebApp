using MP_CS107L.App;
using MP_CS107L.App.Orders;
using MP_CS107L.App.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MP_CS107L
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public IEnumerable<Product> products = new List<Product>()
        {

        };


        protected void Page_Init(object sender, EventArgs e)
        {
           
        }

        public string currFilter { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            // Retrieve username from query string
            string username = Request.QueryString["username"];

            // Store username in session state
            Session["Username"] = username;

            ProductRepository repository = new ProductRepository();

            string selectedValue = ProductFilter.SelectedValue;


            if (!IsPostBack)
            {
                
                BindProductData();
            }
            else
            {

                currFilter = ProductFilter.SelectedValue;
               
            }

        }

        private void BindProductData()
        {
            ProductRepository repository = new ProductRepository();
            currFilter = ProductFilter.SelectedValue;
            ProductItemRepeater.DataSource = repository.GetAllSpecificProducts(currFilter);
            
            ProductItemRepeater.DataBind();
        }



        protected void ProductItemRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                Button currBtn = (Button)e.CommandSource;
                string productId = (string)e.CommandArgument;

                RepeaterItem item = (RepeaterItem)currBtn.NamingContainer;
                TextBox itemQtyTextBox = (TextBox)item.FindControl("itemQty");

                if (itemQtyTextBox != null)
                {
                    if (int.TryParse(itemQtyTextBox.Text, out int itemQuantity))
                    {
                        if (itemQuantity > 0)
                        {

                            if (itemQuantity > 99)
                            {
                                Response.Write($"<script>alert('Quantity Reached Maximum Value.');</script>");
                                return;
                            }

                            Response.Write($"<script>alert('Item Added to Cart.');</script>");

                            var cartRepository = new CartRepository();
                            var currItem = cartRepository.FindItem(new App.Orders.Cart()
                            {
                                prodID = productId,
                            }, itemQuantity);

                            cartRepository.AddItemToCart(currItem.FirstOrDefault(), Request.QueryString["username"]);
                        }
                        else
                        {
                            Response.Write($"<script>alert('Invalid Quantity.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write($"<script>alert('Invalid Quantity.');</script>");
                    }
                }
                else
                {
                    Response.Write($"<script>alert('TextBox Not Found.');</script>");
                }

                currFilter = ProductFilter.SelectedValue;
            }
        }




        protected void ProductItemRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button addButton = e.Item.FindControl("AddToCartButton") as Button;

                Label isAvail = e.Item.FindControl("IsItemAvailable") as Label;
                TextBox quantityTxt = e.Item.FindControl("itemQty") as TextBox;

                if (isAvail.Text == "Not Available")
                {
                    addButton.Enabled = false;
                    quantityTxt.Enabled = false;
                }
            }
        }



      

        protected void ProductFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            currFilter = ProductFilter.SelectedValue;

            ProductRepository repository = new ProductRepository();

            BindProductData();

            currFilter = ProductFilter.SelectedValue;
        }
    }
}