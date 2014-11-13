using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //access the sql server
using DAL.Model;
using DAL.Persistence;

namespace DAL.Persistance
{
    public class UsersDAL : Connection
    {
        //INSERT into table
        public void INSERT(Users U)
        {
            try
            {
                // Open the connection
                OpenConnection();
                com = new SqlCommand("INSERT INTO USERS (Username,Firstname,Lastname,Email,Address)Values(@v1, @v2, @v3,@v4,@v5)", conn);
                com.Parameters.AddWithValue("@v1", U.Username);
                com.Parameters.AddWithValue("@v2", U.Firstname);
                com.Parameters.AddWithValue("@v3", U.Lastname);
                com.Parameters.AddWithValue("@v4", U.Email);
                com.Parameters.AddWithValue("@v5", U.Address);

                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }

        }
        //UPDATE
        public void UPDATE(Users U)
        {
            try
            {
                OpenConnection();
                com = new SqlCommand("update Users set Username=@v1, Firstname=@v2, Lastname=@v3,Email=@v4,Address=@v5 where ID=@ID", conn);

                com.Parameters.AddWithValue("@v1", U.Username);
                com.Parameters.AddWithValue("@v2", U.Firstname);
                com.Parameters.AddWithValue("@v3", U.Lastname);
                com.Parameters.AddWithValue("@v4", U.Email);
                com.Parameters.AddWithValue("@v5", U.Address);
                com.Parameters.AddWithValue("@ID", U.ID);

                com.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }



        }
        //DELETE
        public void DELETE(int ID)
        {
            try
            {
                OpenConnection();
                com = new SqlCommand("delete from Users where ID=@ID", conn);

                com.Parameters.AddWithValue("@ID", ID);

                com.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();

            }
        }

        //Method for getting user by id
        public Users GetByID(int ID)
        {
            try
            {
                OpenConnection();
                com = new SqlCommand("select * from Users where ID=@v1 ", conn);
                com.Parameters.AddWithValue("@v1", ID);

                Users U = null;

                if (dreader.Read())
                {
                    U = new Users();

                    U.ID = Convert.ToInt32(dreader["ID"]);
                    U.Username = Convert.ToString(dreader["Username"]);
                    U.Firstname = Convert.ToString(dreader["Firstname"]);
                    U.Lastname = Convert.ToString(dreader["Lastname"]);
                    U.Email = Convert.ToString(dreader["Email"]);
                    U.Address = Convert.ToString(dreader["Address"]);

                }
                return U;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();

            }


        }

        //Method to list all users
        public List<Users> List()
        {
            try
            {
                OpenConnection();
                com = new SqlCommand("select * from Users", conn);
                dreader = com.ExecuteReader();

                List<Users> list1 = new List<Users>();

                while (dreader.Read())
                {
                    Users U = new Users();

                    U.ID = Convert.ToInt32(dreader["ID"]);
                    U.Username = Convert.ToString(dreader["Username"]);
                    U.Firstname = Convert.ToString(dreader["Firstname"]);
                    U.Lastname = Convert.ToString(dreader["Lastname"]);
                    U.Email = Convert.ToString(dreader["Email"]);
                    U.Address = Convert.ToString(dreader["Address"]);

                    list1.Add(U);
                }

                return list1;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}



