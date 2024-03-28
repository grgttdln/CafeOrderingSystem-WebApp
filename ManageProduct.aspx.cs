using MP_CS107L.App.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP_CS107L
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve username from query string
                string username = Request.QueryString["username"];

                // Store username in session state
                Session["Username"] = username;

                BindProductData();
            }
            else
            {
                // initial load
                BindProductData();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }

        private void BindProductData()
        {
            ProductRepository repository = new ProductRepository();
            ManageProductRepeater.DataSource = repository.GetAllProducts();
            ManageProductRepeater.DataBind();
        }


        protected void ManageProductRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlAvailability = (DropDownList)e.Item.FindControl("AvailabilityDropDown");
                Product product = e.Item.DataItem as Product;

                // Check if the data item is not null
                if (product != null)
                {
                    // Set the selected value of the dropdown list based on the IsAvailable field value
                    ddlAvailability.SelectedValue = product.IsAvailable.ToString();
                }
            }
        }

        protected void updateAvailability_Click(object sender, EventArgs e)
        {
            ProductRepository repository = new ProductRepository();

            List<string> availabilityList = new List<string>();

            // read data 
            foreach (RepeaterItem item in ManageProductRepeater.Items)
            {
                
                DropDownList ddlAvailability = (DropDownList)item.FindControl("AvailabilityDropDown");

                string selectedValue = ddlAvailability.SelectedValue;

                HiddenField hiddenProductId = (HiddenField)item.FindControl("ProductIdHiddenField");

                string productId = hiddenProductId.Value;

                availabilityList.Add(productId + ":" + selectedValue);
            }

            
            // implementation
            foreach (string availability in availabilityList)
            {
                string[] parts = availability.Split(':');
                string productId = parts[0];
                string availabilityStatus = parts[1];

                // update database
                repository.UpdateAvailProducts(productId, availabilityStatus);
            }


            // refresh page
            Response.Redirect(Request.RawUrl);

        }


    }
}