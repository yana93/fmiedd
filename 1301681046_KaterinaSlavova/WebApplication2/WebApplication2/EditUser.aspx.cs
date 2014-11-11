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
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.LoggedUser == null)
            {
                Response.Redirect("LogIn.aspx");
                return;
            }

            if (Page.IsPostBack)
                return;

            if (string.IsNullOrEmpty(Request["id"]))
                return;

            int id = Convert.ToInt32(Request["id"]);

            UserRepository repo = new UserRepository();
                
            User user = repo.GetByID(id);

            txtbFirstname.Text = user.Firstname;
            txtbEmail.Text = user.Email;
            txtbLastname.Text = user.Lastname;
            txtbPassword.Text = user.Password;
            txtbUserName.Text = user.Username;

            ViewState.Add("id", id);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();
            User user;

            if (ViewState["id"] == null)
            {
                user = new User();
                user.Firstname = txtbFirstname.Text;
                user.Lastname = txtbLastname.Text;
                user.Password = txtbPassword.Text;
                user.Username = txtbUserName.Text;
                user.Email = txtbEmail.Text;

                userRepo.Insert(user);

            }
            else
            {
                int userid = Convert.ToInt32(ViewState["id"]);
                user = userRepo.GetByID(userid);
            }
            user.Firstname = this.txtbFirstname.Text;
            user.Lastname = this.txtbLastname.Text;
            user.Password = this.txtbPassword.Text;
            user.Username = this.txtbUserName.Text;
            user.Email = this.txtbEmail.Text;

            userRepo.Update(user);

            Response.Redirect("ManageUsers.aspx");

            
        }

        protected void txtbUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}