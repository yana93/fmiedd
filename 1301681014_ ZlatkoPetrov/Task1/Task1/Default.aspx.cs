using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Task1.Entities;
using Task1.Repositories;

namespace Task1
{
    public partial class Default : System.Web.UI.Page
    {
        Users Users;
        List<User> UsersList;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Users = new Users();
            UsersList = this.Users.GetAll();
            TableCell td;
            TableRow tr;

            /* Generate data */
            foreach(User u in this.UsersList) 
            {
                tr = new TableRow();

                td = new TableCell();
                td.Text = u.Username;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = u.Password;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = u.Email;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = "<a href='/edit.aspx?id=" + u.ID + "'>Edit</a> <a href='/delete.aspx?id=" + u.ID + "'>Delete</a>";
                tr.Cells.Add(td);

                /* Add row to table */
                UsersTable.Rows.Add(tr);
            }
                        
        }
    }
}