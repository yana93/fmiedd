using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsCrudAccess.Models;

namespace WebFormsCrudAccess
{
    public partial class Delete : System.Web.UI.Page
    {
        UserRepository repo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
           repo.Delete(Convert.ToInt32(Request.QueryString["id"]));
           Response.Redirect("/?ShowMessageDelete=true");      
        }
    }
}