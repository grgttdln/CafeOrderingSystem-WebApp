using MP_CS107L.App.Orders;
using MP_CS107L.App.Product;
using MP_CS107L.App.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP_CS107L
{
    public partial class ManageStaff1 : System.Web.UI.Page
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
            StaffRepository repository = new StaffRepository();
            var allStaff = repository.GetAllStaff();
            AllStaffRepeater.DataSource = allStaff;
            AllStaffRepeater.DataBind();

            if (allStaff != null && allStaff.Any())
            {
                NoStaff.Visible = false;
            }
            else
            {
                NoStaff.Visible = true;
            }
        }

        protected void deleteStaff_Click(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            string staffUsername = currBtn.CommandArgument;

            Response.Write($"<script>alert('{staffUsername}');</script>");

            // remove the staff from the database
            StaffRepository repository = new StaffRepository();
            repository.RemoveStaff(staffUsername);



            Response.Redirect(Request.RawUrl);
        }
    }
}