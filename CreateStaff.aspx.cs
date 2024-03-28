using MP_CS107L.App.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP_CS107L
{
    public partial class ManageStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve username from query string
                string username = Request.QueryString["username"];

                // Store username in session state
                Session["Username"] = username;
            }

        }

        protected void createStaffBtn_Click(object sender, EventArgs e)
        {
            var repository = new StaffRepository();

            if (registrationValidation())
            {
                string newStaffUsername = staffUsername.Text;

                // Check if staff member already exists
                if (!DoesStaffExists(newStaffUsername))
                {
                    // Create new staff member
                    repository.CreateStaff(new App.Staffs.Staff()
                    {
                        Username = newStaffUsername,
                        UserPass = userPassword.Text,
                        FirstName = staffFName.Text,
                        LastName = staffLName.Text,
                        Address = staffAddress.Text,
                        PhoneNumber = staffNum.Text
                    });

                    Response.Write($"<script>alert('Successful Staff Registration');</script>");
                    ClearTxtboxValues();
                }
                else
                {
                    Response.Write($"<script>alert('Staff {newStaffUsername} already exists');</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Validation failed. Please fill in all required fields.');</script>");
            }
        }


        protected bool registrationValidation()
        {
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        protected void ClearTxtboxValues()
        {
            // clear input fields
            staffUsername.Text = "";
            userPassword.Text = "";
            staffFName.Text = "";
            staffLName.Text = "";
            staffAddress.Text = "";
            staffNum.Text = "";
        }



        protected bool DoesStaffExists(string newStaffUsername)
        {
            StaffRepository repository = new StaffRepository();
            IEnumerable<App.Staffs.Staff> staffMembers = repository.GetAllStaff();


            return staffMembers.Any(staff => staff.Username == newStaffUsername);

        }

    }
}