using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCRUDApp
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            LblPass.Visible = false;
            LblEmail.Visible = false;
            TxtPass.Visible = false;
            TxtEmail.Visible = false;
        }
        protected void BtnID_Click(object sender, ImageClickEventArgs e)
        {
           RequiredFieldValidatorID.Visible = true;
           RequiredFieldValidatorPass.Visible = true;
           RequiredFieldValidatorEmail.Visible = true;
           LblID.Visible = true;
           TxtID.Visible = true;
        }
        protected void TxtID_TextChanged(object sender, EventArgs e)
        {
            LblPass.Visible = true;
            LblEmail.Visible = true;
            TxtPass.Visible = true;
            TxtEmail.Visible = true;
            RequiredFieldValidatorEmail.Visible = false;
            RequiredFieldValidatorPass.Visible = false;
           

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
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
                cmd.CommandText = @"UPDATE Users SET Password=@Password, Email=@Email where @ID = ID";
                cmd.Parameters.AddWithValue("@ID", TxtID.Text);
                cmd.Parameters.AddWithValue("@Password", TxtPass.Text);
                cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
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
        }
      }
    