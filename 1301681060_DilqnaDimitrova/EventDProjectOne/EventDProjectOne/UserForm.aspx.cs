using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventDProjectOne
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                Refresh();
            }
        }
        private void Refresh()
        {
            UserRepository repo = new UserRepository();
            lbUser.Items.Clear();
            foreach (UserEntity user in repo.GetAll())
            {
                ListItem item = new ListItem();
                item.Text = user.ToString();
                item.Value = user.Id.ToString();
                this.lbUser.Items.Add(item);
            }

        }
        protected void lbUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbUser.SelectedItem == null)
            {
                return;
            }

            UserRepository repo = new UserRepository();
            UserEntity user = repo.GetById(Convert.ToInt32(lbUser.SelectedItem.Value));
            repo.Delete(user);

            Response.Redirect("UserForm.aspx");
          
          
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbUser.SelectedItem == null)
            {
                return;
            }
            else
            {
                Response.Redirect("EditUser.aspx?user_id="+lbUser.SelectedItem.Value);
            }
        }
    }
}