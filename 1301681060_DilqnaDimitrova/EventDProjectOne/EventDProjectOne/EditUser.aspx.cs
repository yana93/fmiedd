using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventDProjectOne
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            if (string.IsNullOrEmpty(Request["user_id"]))
                return;
            
                int Id = Convert.ToInt32(Request["user_id"]);

                UserRepository repo = new UserRepository();
                UserEntity user = repo.GetById(Id);
                tbUsername.Text = user.Username;
                tbPassword.Text = user.Password;
                tbEmail.Text = user.Email;

                ViewState.Add("user_id", Id);
                   
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserForm.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserRepository repo = new UserRepository();
            UserEntity user;
            if (ViewState["user_id"] == null)
            {
                user = new UserEntity();
                user.Username = tbUsername.Text;
                user.Password = tbPassword.Text;
                user.Email = tbEmail.Text;
                repo.Insert(user);
                
            }
            else
            {
                int userId = Convert.ToInt32(ViewState["user_id"]);
                user = repo.GetById(userId);
            }
            user.Username = this.tbUsername.Text;
            user.Password = this.tbPassword.Text;
            user.Email = this.tbEmail.Text;
            //greshka moje bi
            repo.Update(user);
            Response.Redirect("UserForm.aspx");
        }
    }
}