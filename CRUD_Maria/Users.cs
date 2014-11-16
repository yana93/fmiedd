using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Maria
{
    class Users
    {
        private int id { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private int identificaton { get; set; }
        private string email { get; set; }
        private static string conn = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Users.mdf;Integrated Security=True";
        private SqlConnection connection = new SqlConnection(conn);
        private SqlCommand command;
        private SqlDataReader reader;

        public Users(string username, string pass, int identification, string email)
            :this()
        {
            this.username = username;
            this.password = pass;
            this.identificaton = identification;
            this.email = email;
        }
        public Users()
        {
        }
        public Users (int id)
            :this()
        {
            this.id = id;
        }
        public void Add()
        {
            command = new SqlCommand("INSERT INTO UserData (Username,Password,Identification,Email) VALUES (@p_name,@p_pass,@p_ident,@p_meil)", connection);
            command.Parameters.AddWithValue("@p_name", username);
            command.Parameters.AddWithValue("@p_pass", password);
            command.Parameters.AddWithValue("@p_meil", email);
            command.Parameters.AddWithValue("@p_ident", identificaton);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("" + e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void Delete()
        {
            command = new SqlCommand("DELETE FROM UserData WHERE ID=@p_id",connection);
            command.Parameters.AddWithValue("@p_id", id);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("" + e);
            }
            finally
            {
                connection.Close();
            }

        }
        public void Update(int id,string username, string pass, int identificaton, string email)
        {
            this.id = id;
            this.username = username;
            this.password = pass;
            this.identificaton = identificaton;
            this.email = email;

            command = new SqlCommand("UPDATE UserData SET Username=@p_name,Password=@p_pass,Email=@p_meil,Identification=@p_ident WHERE ID=@p_id", connection);
            command.Parameters.AddWithValue("@p_name",this.username);
            command.Parameters.AddWithValue("@p_pass",this.password);
            command.Parameters.AddWithValue("@p_meil",this.email);
            command.Parameters.AddWithValue("@p_ident", this.identificaton);
            command.Parameters.AddWithValue("@p_id", this.id);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("" + e);
            }
            finally
            {
                connection.Close();
            }

        }
        
    }
}
