using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationCRUDApp
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
           string str = WebConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand();
                connection.Open();
              
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM Users WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", TxtID.Text);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            Response.Redirect("~/CRUD.aspx");
        }

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            RequiredFieldValidatorID.Visible = true;
            LblID.Visible = true;
            TxtID.Visible = true;
        } 
      }
    }