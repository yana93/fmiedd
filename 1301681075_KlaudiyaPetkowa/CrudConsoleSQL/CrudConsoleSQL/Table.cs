using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CrudConsoleSQL
{
    class Table
    {
        static SqlConnection connect;

        public void uTable()
        {
            connect = new SqlConnection("Data Source=HP;Integrated Security=SSPI;Initial Catalog=Usersf");

            Console.Clear();

            while (true)
            {
                TRepository.Table();

                Menu choice = RenderMenu();

                switch (choice)
                {

                    case Menu.Insert:
                        {
                            Add();
                            break;
                        }
                    case Menu.Update:
                        {
                            Update();
                            break;
                        }
                    case Menu.Delete:
                        {
                            Delete();
                            break;
                        }
                    case Menu.Exit:
                        {
                            return;
                        }
                }
            }
        }

        private Menu RenderMenu()
        {
            while (true)
            {

                Console.WriteLine("  controls:     A-dd       U-pdate       D-elete   E-xit   ");
                Console.WriteLine("___________________________________________________");
                Console.WriteLine("");
                Console.Write(" Choose contorol: ");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {

                    case "A":
                        {
                            return Menu.Insert;
                        }
                    case "U":
                        {
                            return Menu.Update;
                        }
                    case "D":
                        {
                            return Menu.Delete;
                        }
                    case "X":
                        {
                            return Menu.Exit;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown action.");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                }
            }
        }


        public static void Add()
        {

            Console.Clear();

            TRepository.Table();

            Console.WriteLine(" Add  User: ");
            Console.WriteLine("");
            Console.Write(" ID : ");
            string ID = Console.ReadLine();
            int value;
            while (!int.TryParse(ID, out value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Invalid ID.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                Console.Clear();
                return;
            };

            Console.Write(" Name: ");
            string username = Convert.ToString(Console.ReadLine());

            Console.Write(" Password: ");
            string password = Convert.ToString(Console.ReadLine());

            Console.Write(" Email: ");
            string email = Convert.ToString(Console.ReadLine());

            SqlCommand command = new SqlCommand("Select * From Users where ID = @id", connect);
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@id";
            parameter.Value = ID.ToString();
            command.Parameters.Add(parameter);
            connect.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ID already exists.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                Console.Clear();
                reader.Close();
                connect.Close();
                return;
            }
            else
            {
                try
                {
                    SqlCommand aCommand = new SqlCommand("INSERT INTO [Users] ([ID], [Username], [Password], [Email]) VALUES('" + ID + "','" + username + "','" + password + "','" + email + "')", connect);
                    aCommand.ExecuteNonQuery();
                    connect.Close();

                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error: {0}", e.Errors[0].Message);
                    connect.Close();
                }

                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" User with ID {0} was successfully added to UserTable", ID);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                return;
            }
        }

        public static void Update()
        {
            Console.Clear();

            TRepository.Table();

            Console.WriteLine(" Update  User");
            Console.WriteLine(":________________:");

            Console.WriteLine("");
            Console.Write(" Choose ID to be updated: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Name: ");
            string username = Convert.ToString(Console.ReadLine());

            Console.Write(" Password: ");
            string password = Convert.ToString(Console.ReadLine());

            Console.Write(" Email: ");
            string email = Convert.ToString(Console.ReadLine());

            SqlCommand command = new SqlCommand("Select * From Users where ID = @id", connect);
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@id";
            parameter.Value = ID.ToString();
            command.Parameters.Add(parameter);
            connect.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

                try
                {

                    SqlCommand aCommand = new SqlCommand("Update [Users] SET [Username]='" + username + "',[Password]='" + password + "',[email]='" + email + "'where [id]=" + ID, connect);
                    aCommand.ExecuteNonQuery();
                    connect.Close();

                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error: {0}", e.Errors[0].Message);
                    connect.Close();
                }


                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" User with ID {0} was successfully updated in UserTable", ID);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ID does not exist.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                Console.Clear();
                reader.Close();
                connect.Close();
                return;
            }
        }

        public static void Delete()
        {
            Console.Clear();
            TRepository.Table();

            Console.WriteLine(" Delete  User");
            Console.WriteLine(":________________:");

            Console.WriteLine("");
            Console.Write(" Choose ID to be deleted: ");
            int ID = Convert.ToInt32(Console.ReadLine());

            SqlCommand command = new SqlCommand("Select * From Users where ID = @id", connect);
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@id";
            parameter.Value = ID.ToString();
            command.Parameters.Add(parameter);
            connect.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" You are about to delete user with ID = {0}", ID);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" [Y]es     [N]o");

                string key = Console.ReadLine();
                if (key == "y" || key == "Y")
                {
                    try
                    {
                        SqlCommand aCommand = new SqlCommand("Delete from users where id =  " + ID, connect);
                        aCommand.ExecuteNonQuery();
                        reader.Close();
                        connect.Close();

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error: {0}", e.Errors[0].Message);
                        reader.Close();
                        connect.Close();
                    }

                    Console.Clear();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" User with ID {0} was successfully deleted from UserTable", ID);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    return;

                }
                else
                {
                    Console.Clear();
                    reader.Close();
                    connect.Close();
                    return;
                }

            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ID does not exist.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                Console.Clear();
                reader.Close();
                connect.Close();
                return;
            }
        }
    }
}
