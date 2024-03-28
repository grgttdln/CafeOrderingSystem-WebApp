using MP_CS107L.App;
using MP_CS107L.App.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP_CS107L
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            var userRepo = new UserRepository();

            // getting user in database       
            var currUser = userRepo.LogInUser(userLogin.Text);


            // validation of existing user
            if (currUser != null && currUser.Any())
            {
                foreach (var user in currUser)
                {
                    if (user.Username != null)
                    {
                        // validation of password
                        if (user.Password == userPassword.Text)
                        {
                            currrentUser onlineUser = new currrentUser
                            {
                                Username = user.Username,
                                Password = user.Password
                            };


                            // check type of user
                            if (userRepo.TypeOfUser(user.Username) == "user")
                            {
                                // redirect page
                                Response.Redirect("Order.aspx?username=" + onlineUser.Username);
                            }
                            else if (userRepo.TypeOfUser(user.Username) == "admin")
                            {
                                // redirect page
                                Response.Redirect("Admin.aspx?username=" + onlineUser.Username);
                            }
                            else if (userRepo.TypeOfUser(user.Username) == "staff")
                            {
                                // redirect page
                                Response.Redirect("StaffMenu.aspx?username=" + onlineUser.Username);
                            }

                            // Response.Redirect("Order.aspx");
                        }
                        else
                        {
                            Response.Write($"<script>alert('Incorrect Password.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write($"<script>alert('User is not Registered.');</script>");
                    }
                }
            }
            else
            {
                Response.Write($"<script>alert('User is not Registered.');</script>");
            }

        }
    }
}