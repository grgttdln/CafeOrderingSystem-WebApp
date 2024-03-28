using MP_CS107L.App.Orders;
using MP_CS107L.App.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP_CS107L
{
    public partial class Purchase : System.Web.UI.Page
    {
        protected IEnumerable<App.Orders.Cart> Items { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductData();
            }
        }

        private void BindProductData()
        {
            PurchaseRepository repository = new PurchaseRepository();
            Items = repository.GetPurchases(Request.QueryString["username"]);

            if (Items != null && Items.Any())
            {
                NoProduct.Visible = false;
            }
            else
            {
                NoProduct.Visible = true;   
            }
        }
    }
}
