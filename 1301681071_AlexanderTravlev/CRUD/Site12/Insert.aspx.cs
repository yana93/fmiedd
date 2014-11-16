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
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                Users U = new Users();
                U.Username = TextBox1.Text;
                U.Firstname = TextBox2.Text;
                U.Lastname = TextBox3.Text;
                U.Email = TextBox4.Text;
                U.Address = TextBox5.Text;

                UsersDAL d = new UsersDAL();

                d.INSERT(U); // Insert user
                Label6.Text = "User created successfully!!!";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}