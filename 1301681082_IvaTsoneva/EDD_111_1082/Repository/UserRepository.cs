using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using EDD_111_1082.Entity;

namespace EDD_111_1082.Repository
{
    class UserRepository //Contains CRUD functionality for User objects
    {
        
        OleDbConnection conn;
        OleDbCommand cmd;

        private void ConnectTo() //Hides connection string in private method
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;Persist Security Info=False;");

            //conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Documents\Visual Studio 2013\Projects\EDD_111_1082\Database.accdb;Persist Security Info=False;");
            cmd = conn.CreateCommand();
        } 

        public UserRepository() //Automatically connect to DB when this constructor is called
        {
            ConnectTo();
        }
        #region CRUD
        public void Insert(User user1) //Adds user to database
        {
            cmd.CommandText = @"INSERT INTO TUsers(Firstname,Lastname,Username,[Passwordd]) VALUES (@firstname,@lastname,@username,@password)";

            cmd.Parameters.AddRange(new OleDbParameter[] {
                    new OleDbParameter("@firstname", user1.Firstname),
                    new OleDbParameter("@lastname", user1.Lastname),
                    new OleDbParameter("@username", user1.Username),
                    new OleDbParameter("@password", user1.Password)
                });
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        } 

        public List<User> Retrieve() //Selects all users
        {
            List<User> resultSet = new List<User>();
            try
            {
                conn.Open();
                cmd.CommandText="SELECT * from TUsers";
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultSet.Add(new User()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Firstname = Convert.ToString(reader["Firstname"]),
                        Lastname = Convert.ToString(reader["Lastname"]),
                        Username = Convert.ToString(reader["Username"]),
                        Password = Convert.ToString(reader["Passwordd"]),
                    });
                }
                reader.Close();
            }
            catch (OleDbException)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultSet;
        }
        public List<User> Retrieve(string username) //Overloading that we use in MailView.ViewUsers();
        {
            List<User> resultSet = new List<User>();
            try
            {
                conn.Open();
                cmd.CommandText = @"SELECT * FROM TUsers WHERE Username not in ('admin',@username)";
                cmd.Parameters.AddWithValue("@username", username);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultSet.Add(new User()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Firstname = Convert.ToString(reader["Firstname"]),
                        Lastname = Convert.ToString(reader["Lastname"]),
                        Username = Convert.ToString(reader["Username"]),
                        Password = Convert.ToString(reader["Passwordd"]),
                    });
                }
                reader.Close();
            }
            catch (OleDbException)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultSet;
        }

        public User RetrieveOne(string username) //Selects a single user by username
        {  
            User user = new User();

            cmd.CommandText = @"Select * FROM TUsers WHERE [Username] = @Username";
            cmd.Parameters.AddWithValue("@Username", username);

            if (username != "")
            {
                try
                {
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        user.ID = Convert.ToInt32(reader["ID"]);
                        user.Firstname = Convert.ToString(reader["Firstname"]);
                        user.Lastname = Convert.ToString(reader["Lastname"]);
                        user.Username = Convert.ToString(reader["Username"]);
                        user.Password = Convert.ToString(reader["Passwordd"]);
                    }
                    
                    reader.Close();                  
                }
                catch (OleDbException)
                {
                    throw;
                }
                finally 
                {
                    conn.Close();
                }
            }
            return user;
        } 
     

        public void Delete(User user1) //Removes user from database
        {
            cmd.CommandText = @"DELETE FROM TUsers WHERE [Username] = @username";
            cmd.Parameters.AddWithValue("@username",user1.Username);
            
            try
            {
                this.conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public int Update(User user1) //Edits user info in database
        {
            int updated=0 ;
            cmd.CommandText = @"UPDATE TUsers SET Firstname = @firstname, Lastname = @lastname WHERE [Username]=@username";
            cmd.CommandType=CommandType.Text;
            cmd.Parameters.AddRange(new OleDbParameter[] {
                    new OleDbParameter("@firstname", user1.Firstname),
                    new OleDbParameter("@lastname", user1.Lastname),
                    new OleDbParameter("@username", user1.Username)
                });
            try
            {
                conn.Open();
                updated=cmd.ExecuteNonQuery();
               // cmd.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Failed updating user info! Error: {0}",e.Errors[0]);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return updated;
        }
        #endregion
    }
}
