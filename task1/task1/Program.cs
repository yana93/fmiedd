using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;

namespace task1
{
    class Program
    {
        public static SqlCeConnection Connection;
        static void Main(string[] args)
        {
            var appSettings = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            Connection = new SqlCeConnection();
            Connection.ConnectionString = appSettings;

            MainMenu();
             


            Console.ReadKey(true);
        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1.List users");
            Console.WriteLine("2.Add user");
            Console.WriteLine("3.Delete user");
            Console.WriteLine("4.Edit User");

            ConsoleKeyInfo ck = Console.ReadKey(true);

            if (ck.Key == ConsoleKey.D1)
            {
                ListUsers();
            }

            if (ck.Key == ConsoleKey.D2)
            {
                AddUser();
            }

            if (ck.Key == ConsoleKey.D3)
            {
                DeleteUser();
            }

            if (ck.Key == ConsoleKey.D4)
            {
                UpdateUser();
            }
        }

        public static void ListUsers()
        {
            Connection.Open();

            SqlCeCommand command = Connection.CreateCommand();

            command.CommandText = "SELECT * FROM [users]";
            SqlCeDataReader reader = command.ExecuteReader();
            Console.Clear();
            while (reader.Read())
            {
                Console.Write("Id : {0} Username : {1}", reader["id"].ToString(), reader["username"].ToString());
                Console.WriteLine();
            }
            
            Connection.Close();
            Console.WriteLine("Esc to go back");

            ConsoleKeyInfo ck = Console.ReadKey();
            if (ck.Key == ConsoleKey.Escape)
            {
                MainMenu();
            }

           
        }

        public static void AddUser()
        {
            Console.Clear();

            Console.WriteLine("Username : ");
            string username = Console.ReadLine();


            Console.WriteLine("Password : ");
            string password = Console.ReadLine();


            Console.WriteLine("Email : ");
            string email = Console.ReadLine();

            Connection.Open();

            SqlCeCommand command = Connection.CreateCommand();

            command.CommandText = "INSERT INTO [users] (username,password,email) VALUES (@username, @password ,@email)";

            SqlCeParameter param = command.CreateParameter();

            param.ParameterName = "username";
            param.Value = username;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "password";
            param.Value = password;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "email";
            param.Value = email;
            command.Parameters.Add(param);

            int res = command.ExecuteNonQuery();
            Connection.Close();
            if (res > 0)
            {
                Console.WriteLine("User added");
                Console.WriteLine("Esc to go back");

                ConsoleKeyInfo ck = Console.ReadKey();

                if(ck.Key == ConsoleKey.Escape) 
                {
                    MainMenu();
                }
            }

        }

        public static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("Enter user id");
            int id = Convert.ToInt32(Console.ReadLine());

            Connection.Open();

            SqlCeCommand command = Connection.CreateCommand();

            command.CommandText = "DELETE FROM [users] WHERE id = @id";

            SqlCeParameter param = command.CreateParameter();

            param.ParameterName = "id";
            param.Value = id;
            command.Parameters.Add(param);

            int res = command.ExecuteNonQuery();
            Connection.Close();
            if (res > 0)
            {
                Console.WriteLine("User added");

            }
            else
            {
                Console.WriteLine("User not found");
            }
            Console.WriteLine("Esc to go back");

            ConsoleKeyInfo ck = Console.ReadKey();

            if (ck.Key == ConsoleKey.Escape)
            {
                MainMenu();
            }

        }

        public static void UpdateUser()
        {
            Console.Clear();
            Console.WriteLine("Enter user id");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("New Username : ");
            string username = Console.ReadLine();


            Console.WriteLine("New Password : ");
            string password = Console.ReadLine();


            Console.WriteLine("New Email : ");
            string email = Console.ReadLine();

            Connection.Open();

            SqlCeCommand comm = Connection.CreateCommand();

            comm.CommandText = "UPDATE [users] SET username = @username, password=@password, email = @email WHERE id = @id";

            SqlCeParameter param;
            
            param = comm.CreateParameter();
            param.ParameterName = "username";
            param.Value = username;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "password";
            param.Value = password;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "email";
            param.Value = email;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "id";
            param.Value = id;
            comm.Parameters.Add(param);

            int res = comm.ExecuteNonQuery();
            Connection.Close();

            if (res > 0)
            {
                Console.WriteLine("User updated");

            }
            else
            {
                Console.WriteLine("User was not updated");
            }
            Console.WriteLine("Esc to go back");

            ConsoleKeyInfo ck = Console.ReadKey();

            if (ck.Key == ConsoleKey.Escape)
            {
                MainMenu();
            }





        }
    }
}
