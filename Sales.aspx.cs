using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MP_CS107L.App.Sale;
using MP_CS107L.App.Sales;

namespace MP_CS107L
{
    public partial class Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve username from query string
                string username = Request.QueryString["username"];

                // Store username in session state
                Session["Username"] = username;


                BindData();
            }
            else
            {
                BindData();
            }
        }

        protected void BindData()
        {
            SalesRepository repository = new SalesRepository();
            
            // most sold
            var mostSoldProduct = repository.GetMostSold();

            // Bind most sold product to repeater
            TotalMaxSaleRepeater.DataSource = mostSoldProduct;
            TotalMaxSaleRepeater.DataBind();


            // least sold
            var leastSoldProduct = repository.GetLeastSold();

            // Bind least sold product to repeater
            TotalLeastSaleRepeater.DataSource = leastSoldProduct;
            TotalLeastSaleRepeater.DataBind();


            // all in all sold
            var allSoldProduct = repository.GetAllSoldProduct();

            // Bind all products to repeater
            ProductSalesRepeater.DataSource = allSoldProduct;
            ProductSalesRepeater.DataBind();


            if (mostSoldProduct != null && mostSoldProduct.Any())
            {
                infoMostSold.Visible = false;
            } 
            else
            {
                infoMostSold.Visible = true;
            }



            if (leastSoldProduct != null && leastSoldProduct.Any())
            {
                infoLeastSold.Visible = false;
            }
            else
            {
                infoLeastSold.Visible = true;
            }


            if (allSoldProduct != null && allSoldProduct.Any())
            {
                infoRepAll.Visible = false;
            }
            else
            {
                infoRepAll.Visible = true;
            }



            // Calculate the sum of the total products
            int totalProducts = 0;
            foreach (RepeaterItem item in ProductSalesRepeater.Items)
            {
                Label quantityLabel = (Label)item.FindControl("totalPrice");
                if (quantityLabel != null)
                {
                    totalProducts += int.Parse(quantityLabel.Text);
                }
            }


            TotalProductsLabel.Text = $"Total Sales: {totalProducts:C2}";
        }

        protected void ViewReportBtn_Click(object sender, EventArgs e)
        {
            // Get the selected value from the dropdown list
            string selectedValue = ViewReportDDL.SelectedValue;

            SalesRepository repository = new SalesRepository();


            if (selectedValue == "today")
            {
                var getDDLProducts = repository.GetSpecificDateSoldProductToday();

                ProductSalesRepeater.DataSource = getDDLProducts;
                ProductSalesRepeater.DataBind();


                // validation
                if (getDDLProducts != null && getDDLProducts.Any())
                {
                    infoRepAll.Visible = false;
                }
                else
                {
                    infoRepAll.Visible = true;
                }
            }
            else if (selectedValue == "thisweek")
            {
                var getDDLProducts = repository.GetSpecificDateSoldProductThisWeek();

                ProductSalesRepeater.DataSource = getDDLProducts;
                ProductSalesRepeater.DataBind();

                // validation
                if (getDDLProducts != null && getDDLProducts.Any())
                {
                    infoRepAll.Visible = false;
                }
                else
                {
                    infoRepAll.Visible = true;
                }
            }
            else
            {
                infoRepAll.Visible = false;

                var getDDLProducts = repository.GetSpecificDateSoldProductMonth(int.Parse(selectedValue));

                ProductSalesRepeater.DataSource = getDDLProducts;
                ProductSalesRepeater.DataBind();

                // Hide the image if getDDLProducts is null or empty
                if (getDDLProducts == null || !getDDLProducts.Any())
                {
                    bool displayPlaceholder = false;
                    foreach (RepeaterItem item in ProductSalesRepeater.Items)
                    {
                        
                        Image productImage = (Image)item.FindControl("productImage");

                        
                        if (productImage != null)
                        {
                            productImage.Visible = false;
                            displayPlaceholder = true; 
                        }
                    }

                    
                    if (!displayPlaceholder)
                    {
                        
                        getDDLProducts = new List<Sale>
        {
            new Sale
            {
                ProductItem = "No products available for the selected month.",
                MaxQuantity = 0,
                ProductID = "00000",
                Price = 0.0f
            }
        };

                        ProductSalesRepeater.DataSource = getDDLProducts;
                        ProductSalesRepeater.DataBind();

                       
                    }
                }
            }




            // Calculate the sum of the total products
            int totalProducts = 0;
            foreach (RepeaterItem item in ProductSalesRepeater.Items)
            {
                Label quantityLabel = (Label)item.FindControl("totalPrice");
                if (quantityLabel != null)
                {
                    totalProducts += int.Parse(quantityLabel.Text);
                }
            }

            // Set the total products count to the label
            TotalProductsLabel.Text = $"Total Sales: {totalProducts:C2}";




        }



    
    }
}