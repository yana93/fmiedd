using WebFormsCrudAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsCrudAccess
{
    public partial class Create : System.Web.UI.Page
    {
        UserRepository repo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var User = new User();
            User.Username = this.TextBoxUsername.Text;
            User.Email = this.TextEmail.Text;
            User.Password = this.TextPassword.Text;
            if (repo.Insert(User) == true)
            {
                Response.Redirect("/?ShowMessage=true");
            }
        }
    }
}