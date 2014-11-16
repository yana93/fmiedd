using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Repository;
using WebApplication2.Service;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserRepository repo = new UserRepository();
            string username = tbuser.Text;
            string password = tbpass.Text;

            AuthenticationService.AuthenticateUser(username, password);
            if (AuthenticationService.LoggedUser != null)
            {
                Session["loggedUser"] = AuthenticationService.LoggedUser;
                Response.Redirect("ManageUsers.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Incorrect username or password');", true);
                tbuser.Text = "";
                tbpass.Text = "";
            }
        }

        protected void tbpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}