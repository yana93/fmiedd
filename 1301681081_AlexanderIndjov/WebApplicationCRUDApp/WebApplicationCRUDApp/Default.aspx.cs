using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCRUDApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CRUD.aspx");
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Create.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Update.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Delete.aspx");
        }
    }
}