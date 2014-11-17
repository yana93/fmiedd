using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeletePage : System.Web.UI.Page
{
    public static OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Yana\\Desktop\\YanaCRUD\\UsersDB.accdb");

    OleDbCommand myCommand = new OleDbCommand("SELECT * from users", myConnection);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void delete_btn_Click(object sender, EventArgs e)
    {
        myConnection.Open();
        int numb = Int32.Parse(IDDropList.SelectedValue);
        OleDbCommand myCommand = new OleDbCommand("DELETE FROM users WHERE ID = " + numb + ";", myConnection);
        myCommand.ExecuteNonQuery();
        myConnection.Close();

    }
}