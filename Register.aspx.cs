using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MP_CS107L.App.Staffs;
using MP_CS107L.App.Users;


namespace MP_CS107L
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            // validation
            if (registrationValidation())
            {

                string newUser = username.Text;


                if (!DoesUserExists(newUser))
                {
                    Response.Write($"<script>alert('Successful Registration');</script>");

                    // user creation
                    var userRepo = new UserRepository();

                    userRepo.CreateUser(new App.User()
                    {
                        FirstName = fname.Text,
                        LastName = lname.Text,
                        UserAddress = address.Text,
                        PhoneNumber = telNum.Text,
                        Username = username.Text,
                        UserPass = password.Text,
                        TotalOrders = 0
                    });


                    // clear values
                    ClearTxtboxValues();

                    Response.Write("<script>window.setTimeout(function(){ window.location.href = 'Login.aspx'; }, 1000);</script>");
                    // Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Write($"<script>alert('User {newUser} already exists');</script>");

                    // clear values
                    ClearTxtboxValues();
                }
            } 
            else
            {
                // invalid creation
                Response.Write($"<script>alert('Unsuccessful Registration. Please check your inputted values.');</script>");
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
            fname.Text = "";
            lname.Text = "";
            address.Text = "";
            telNum.Text = "";
            username.Text = "";
            password.Text = "";
        }


        protected bool DoesUserExists(string newUser)
        {
            UserRepository repository = new UserRepository();
            IEnumerable<App.User> userMembers = repository.GetAllUser();

            return userMembers.Any(user => user.Username == newUser);
        }


    }
}