using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationCRUDApp
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void AddNewUser_Click(object sender, ImageClickEventArgs e)
        {
            RequiredFieldValidatorAddedName.Visible = true;
            RequiredFieldValidatorAddedPass.Visible = true;
            RegularExpressionValidatorPassword.Visible = true;
            RequiredFieldValidatorEmail.Visible = true;
            RegularExpressionValidatorEmail.Visible = true;
            RegularExpressionValidatorName.Visible = true;
            LblPass.Visible = true;
            LblEmail.Visible = true;
            LblUser.Visible = true;
            TextBox1.Visible = true;
            TextBox2.Visible= true;
            TextBox3.Visible = true;
            
            
        }
        protected void BtnSave_Click(object sender, EventArgs e)
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
                cmd.CommandText = @"INSERT INTO Users Values (@Username, @Password, @Email)";
                cmd.Parameters.AddWithValue("@Username", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Password", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
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
