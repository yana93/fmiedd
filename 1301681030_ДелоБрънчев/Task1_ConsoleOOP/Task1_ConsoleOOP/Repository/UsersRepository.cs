using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_ConsoleOOP.Entity;

namespace Task1_ConsoleOOP.Repository
{
    public class UsersRepository
    {
        SqlConnection conn = new SqlConnection("Data Source=DEZARO-PC\\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public void Insert(Users users)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "insert into Users(id,fname,lname,password) values ('" + users.Id + "','" + users.FirstName + "','" + users.LastName + "','" + users.Password + "')";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (SqlException)
            {
                throw new InvalidOperationException();
            }
            finally
            {
                conn.Close();
            }
        }
        public void Delete(Users users)
        {
            conn.Open();
            cmd.CommandText = "delete from Users where id = '" + users.Id + "'";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            conn.Close();
        }
        public void Update(Users users)
        {
            conn.Open();
            cmd.CommandText = "update Users set fname='" + users.FirstName + "',lname='" + users.LastName + "', password='" + users.Password + "' where id='" + users.Id + "'";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            conn.Close();
        }
        public List<Users> GetAll()
        {
            List<Users> result = new List<Users>();
            conn.Open();
            cmd.CommandText = "SELECT id, fname, lname, password FROM [dbo].[users]";
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Users user = new Users();
                user.Id = reader.GetInt32(0);
                user.FirstName = reader.GetString(1);
                user.LastName = reader.GetString(2);
                user.Password = reader.GetString(3);
                result.Add(user);
            }
            reader.Close();
            conn.Close();
            return result;
        }
    }
}
