using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StefanCRUDWebApplicationAccess
{
    public partial class Add_page : System.Web.UI.Page
    {
        public static OleDbConnection myConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Stefan\Desktop\StefanCRUDWebApplicationAccess\StefanCRUDWebApplicationAccess\database_access\users.accdb");
        OleDbCommand myCommand = new OleDbCommand("SELECT * FROM users", myConnection);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_button_Click(object sender, EventArgs e)
        {
            
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            OleDbCommand myCommand = new OleDbCommand("INSERT INTO Users (username,`password`,email) VALUES ('" + username_box.Text + "','" + password_box.Text + "','" + email_box.Text + "')", myConnection);

            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}