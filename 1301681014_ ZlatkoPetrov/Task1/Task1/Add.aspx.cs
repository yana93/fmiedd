using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Task1.Entities;
using Task1.Repositories;

namespace Task1
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addUser_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (Username.Text == "")
            {
                usernameError.Text = "This field is required";
                error = true;
            }
            else
            {
                usernameError.Text = "";
            }

            if (Password.Text == "")
            {
                passswordError.Text = "This field is required";
                error = true;
            }
            else
            {
                passswordError.Text = "";
            }

            if (Email.Text == "")
            {
                emailError.Text = "This field is required";
                error = true;
            }
            else
            {
                emailError.Text = "";
            }


            if (!error)
            {
                Users Users = new Users();
                if (Users.doesUserExistsByUsername(Username.Text))
                {
                    usernameError.Text = "This username is already taken";
                    error = true;
                }

                if (Users.doesUserExistsByEmail(Email.Text))
                {
                    emailError.Text = "This email is already taken";
                    error = true;
                }

                if (!error)
                {
                    User u = new User()
                    {
                        Username = Username.Text,
                        Password = Password.Text,
                        Email = Email.Text
                    };
                    Users.Add(u);
                    Response.Redirect("Default.aspx");
                }
            }
        }

    }
}