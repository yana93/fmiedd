using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site12
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string option = DropDownList1.SelectedValue;

            switch (option)
            {
                case "0":
                    Label1.Text = "Choose an option please !";
                    break;
                case "1":
                    Response.Redirect("~/Insert.aspx");
                    break;
                case "2":
                    Response.Redirect("~/Update.aspx");
                    break;
                case "3":
                    Response.Redirect("~/Delete.aspx");
                    break;
            }

        }
    }
}