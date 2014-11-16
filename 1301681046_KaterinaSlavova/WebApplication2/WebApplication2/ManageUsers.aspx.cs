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
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.LoggedUser == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                RefreshItems();
            }


        }

        private void RefreshItems()
        {
            UserRepository userRepo = new UserRepository();
            lbUsers.Items.Clear();
            foreach (User user in userRepo.GetAll())
            {
                ListItem item = new ListItem();
                item.Text = user.ToString();
                item.Value = user.ID.ToString();
                lbUsers.Items.Add(item);
            }
        }


        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem == null)
            {
                return;
            }
            else
            {
                Response.Redirect("EditUser.aspx?id="+lbUsers.SelectedItem.Value);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();
            User user = userRepo.GetByID(Convert.ToInt32(lbUsers.SelectedItem.Value));
            if (lbUsers.SelectedItem == null)
            {
                return;
            }
            else
            {
                userRepo.Delete(user);
                RefreshItems();
            }
        }
    }
}