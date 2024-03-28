using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP_CS107L
{
    public partial class StaffMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve username from query string
                string username = Request.QueryString["username"];

                // Store username in session state
                Session["Username"] = username;  
            }
        }
    }
}