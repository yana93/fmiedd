using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace EventDProjectOne
{
    public class UserRepository
    {
       SqlConnection conn;
      SqlCommand comm;

      private void ConnectTo()
      {
          //conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\2 курс\1 трим\С_Прогр\WebPhonebook\DataAccess\bin\Debug\PhoneBookDB.accdb;Persist Security Info=False;");
          conn = new SqlConnection(@"Data Source=DIDI-PC\SQLEXPRESS;Initial Catalog=User;Integrated Security=True");
          comm = conn.CreateCommand();
      }   
      
      public UserRepository()
      {
          ConnectTo();
      }
     
      public void Insert(UserEntity user)
      {   
       
          try
          {
             // comm.CommandText = "INSERT INTO Users([Username], [Password],  [Email])VALUES ('" + user.Username + " ',' " + user.Password + "','" + user.Email + " ' )";
              comm.CommandText = "INSERT INTO Users([Username], [Password],  [Email])VALUES ('" + user.Username + " ',' " + user.Password + "','" + user.Email + " ' )";
              comm.CommandType = CommandType.Text;

             
              conn.Open();
              comm.ExecuteNonQuery();

          }
          finally
          {
                if(conn!=null)
                {
                    conn.Close();
                }
          }
      }

      public List<UserEntity> GetAll()
      {
          List<UserEntity> list = new List<UserEntity>();
          try
          {
              comm.CommandText = "SELECT*FROM [Users]";
              comm.CommandType = CommandType.Text;
             conn.Open();
              SqlDataReader reader = comm.ExecuteReader();
              while (reader.Read())
              {
                  UserEntity user = new UserEntity();
                  //user.Id = Convert.ToInt32(reader["user_id"].ToString());
                  user.Id = int.Parse(reader["user_id"].ToString());
                  user.Username  = reader["Username"].ToString();
                  user.Password = reader["Password"].ToString();
                  user.Email = reader["Email"].ToString();
                

              
              list.Add(user);
          }
          return list;
          }
          finally
          {
              if (conn != null)
              {
                  conn.Close();
              }
          }
      }

  
      public void Update( UserEntity oldUser)
      {
          try
          {
              comm.CommandText = "UPDATE [Users] SET [Username]='" + oldUser.Username + "',[Password]='" + oldUser.Password + "',[Email]='" + oldUser.Email + "'where [user_id]=" + oldUser.Id;
              comm.CommandType = CommandType.Text;
              conn.Open();

              comm.ExecuteNonQuery();
          }
          finally
          {
              if (conn != null)
              {
                  conn.Close();
              }
          }
      }
      public void Delete(UserEntity user)
      {
         try
          {
               comm.CommandText = "DELETE FROM [Users] WHERE[user_id]=" + user.Id;
              comm.CommandType = CommandType.Text;
              conn.Open();

              comm.ExecuteNonQuery();
          }
          finally
          {
               if (conn != null)
              {
                  conn.Close();
              }
          }
      }

      public UserEntity GetById(int Id)
      {
          try
          {
              comm.CommandText = "SELECT*FROM [Users]";
              comm.CommandType = CommandType.Text;
              //PROMENENO
              conn.Open();
              SqlDataReader reader = comm.ExecuteReader();
              while (reader.Read())
              {
                  UserEntity user = new UserEntity();
                  user.Id = int.Parse(reader["user_id"].ToString());
                  user.Username = reader["Username"].ToString();
                  user.Password = reader["Password"].ToString();
                  user.Email = reader["Email"].ToString();
               

                  if (user.Id == Id)
                  {
                      return user;
                  }
              }
                  return null;
              
          }
          finally
          {
              if (conn != null)
              {
                  conn.Close();
              }
          }
      }
      //public UserEntity GetByUsernameAndPassword(string username, string password)
      //{
      //    try
      //    {
      //        comm.CommandText = "SELECT * FROM [Users]";
      //        comm.CommandType = CommandType.Text;
      //        conn.Open();
      //        SqlDataReader reader = comm.ExecuteReader();
      //        while(reader.Read())
      //        {
      //            UserEntity user = new UserEntity();

      //            user.Id = int.Parse(reader["user_id"].ToString());
      //            user.Username = reader["Username"].ToString();
      //            user.Password = reader["Password"].ToString();
      //            user.Email = reader["Email"].ToString();
                  

      //            if(user.Username == username && user.Password == password)
      //            {
      //                return user;
      //            }

      //        }
      //        return null;

      //    }
      //    finally
      //    {
      //        if(conn!= null)
      //        {
      //            conn.Close();
      //        }
      //    }
      //}


    }

    }
