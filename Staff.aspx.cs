using MP_CS107L.App.Orders;
using MP_CS107L.App.Purchase;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP_CS107L
{
    public partial class Staff : System.Web.UI.Page
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

                GetOrderData();
            }
            else
            {
                // initial load
                GetOrderData();
            }
        }


        private void GetOrderData()
        {
            PurchaseRepository repository = new PurchaseRepository();

            IEnumerable<OrderPlaced> orderItems = repository.GetAllPurchase();

            OrderRepeater.DataSource = orderItems;
            OrderRepeater.DataBind();

        }


        protected void OrderRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Find the inner repeater control
                Repeater ProductRepeater = (Repeater)e.Item.FindControl("ProductRepeater");

                // Bind product details to the inner repeater
                OrderPlaced order = (OrderPlaced)e.Item.DataItem;
                ProductRepeater.DataSource = order.Products;
                ProductRepeater.DataBind();


                DropDownList dropDownList = (DropDownList)e.Item.FindControl("drpdwnStatus");
                dropDownList.SelectedValue = order.Status;

            }
        }


        // Update Status of Current Order
        public void updateOrderBtn_Click(object sender, EventArgs e)
        {
            Button btnUpdateStatus = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnUpdateStatus.NamingContainer;
            DropDownList ddlStatus = (DropDownList)item.FindControl("drpdwnStatus");

            Label OrderID_Lbl = (Label)item.FindControl("OrderID_Lbl");

            // update order status
            PurchaseRepository repository = new PurchaseRepository();

            repository.UpdateOrderStatus(OrderID_Lbl.Text, ddlStatus.SelectedValue);

            Response.Redirect(Request.RawUrl);
        }


        protected void GetProductsBound_Repeater(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PurchaseRepository repository = new PurchaseRepository();
            }
        }

    }

}
