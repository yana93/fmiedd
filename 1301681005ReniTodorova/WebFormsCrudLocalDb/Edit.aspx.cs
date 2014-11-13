using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsCrudAccess.Models;

namespace WebFormsCrudAccess
{
    public partial class Edit : System.Web.UI.Page
    {
        UserRepository repo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = repo.GetById(Convert.ToInt32(Request.QueryString["id"]));
         
            this.ID.Value = Request.QueryString["id"];

            if (User.Id <= 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    TextBoxUsername.Text = User.Username;
                    TextPassword.Text = User.Password;
                    TextEmail.Text = User.Email;
                }
            }
        }

        protected void UpdateUser(object sender, EventArgs e)
        {       
            var User = new User();
            User.Id = Convert.ToInt32(this.ID.Value);
            User.Username = this.TextBoxUsername.Text;
            User.Email = this.TextEmail.Text;
            User.Password = this.TextPassword.Text;
           repo.Update(User);           
            Response.Redirect("/?ShowMessageUdapte=true");           
        }
    }
}
