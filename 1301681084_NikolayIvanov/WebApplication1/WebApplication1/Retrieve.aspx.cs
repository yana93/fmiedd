using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication1
{
    public partial class Retrieve : System.Web.UI.Page
    {

        string connection = "Data Source=C:\\Users\\Nikolay\\Desktop\\Users1.accdb;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlDataAdapter da = new SqlDataAdapter("select * from Users", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lbnno = (Label)GridView1.Rows[e.RowIndex].FindControl("lbnno");
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from Users where ID=@1";
            cmd.Parameters.Add("@1", SqlDbType.Int, 12).Value = lbnno.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Bind();
        }
    }
}