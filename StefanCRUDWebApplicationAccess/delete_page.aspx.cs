using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StefanCRUDWebApplicationAccess
{
    public partial class delete_page : System.Web.UI.Page
    {
        public static OleDbConnection myConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Stefan\Desktop\StefanCRUDWebApplicationAccess\StefanCRUDWebApplicationAccess\database_access\users.accdb");

        OleDbCommand myCommand = new OleDbCommand("SELECT * from users", myConnection);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            int numb = Int32.Parse(IDDropList.SelectedValue);
            OleDbCommand myCommand = new OleDbCommand("DELETE FROM users WHERE ID = " + numb + ";", myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}