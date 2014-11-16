using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Task1.Repositories;

namespace Task1
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            Users Users = new Users();
            Users.deleteById(id);
            Response.Redirect("Default.aspx");
            
        }
    }
}