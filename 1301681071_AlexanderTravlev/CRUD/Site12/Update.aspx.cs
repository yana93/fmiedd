using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Persistence;
using DAL.Persistance;

namespace Site12
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsersDAL d = new UsersDAL();
                gridUsers.DataSource = d.List();
                gridUsers.DataBind();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}