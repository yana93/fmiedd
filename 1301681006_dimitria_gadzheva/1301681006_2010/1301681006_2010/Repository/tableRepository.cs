using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using _1301681006_2010.Tools;

namespace _1301681006_2010.View
{
    class Table
    {
        static SqlCeConnection conn;

        public void usersTable()
        {
            conn = new SqlCeConnection("Data Source=C:\\Users\\Dimeto\\Desktop\\1301681006_2010\\1301681006_2010\\data\\data.sdf");

            Console.Clear();

            while (true)
            {
                Repository.tableRepository.Table();

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

                Console.WriteLine("  controls:     [A]dd       [U]pdate       [D]elete   ");
                Console.WriteLine(":----------------------------------------------------:");
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

            Repository.tableRepository.Table();

            Console.WriteLine("                   A D D  U S E R: ");
            Console.WriteLine(":----------------------------------------------------:");

            Console.WriteLine("");
            Console.Write(" id : ");
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
            
            Console.Write(" Name : ");
            string username = Convert.ToString(Console.ReadLine());

            Console.Write(" Password : ");
            string password = Convert.ToString(Console.ReadLine());

            Console.Write(" Email : ");
            string email = Convert.ToString(Console.ReadLine());

            SqlCeCommand comm = new SqlCeCommand("select * from users where id = @id", conn);
            SqlCeParameter param = new SqlCeParameter();
            param.ParameterName = "@id";
            param.Value = ID.ToString();
            comm.Parameters.Add(param);
            conn.Open();
            SqlCeDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ID already exists.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                Console.Clear();
                reader.Close();
                conn.Close();
                return;
            }
            else
            {
                try
                {                    
                    SqlCeCommand aCommand = new SqlCeCommand("INSERT INTO [users] ([id], [username], [password], [email]) VALUES('" + ID + "','" + username + "','" + password + "','" + email + "')", conn);
                    aCommand.ExecuteNonQuery();
                    conn.Close();

                }
                catch (SqlCeException e)
                {
                    Console.WriteLine("Error: {0}", e.Errors[0].Message);
                    conn.Close();
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

            Repository.tableRepository.Table();

            Console.WriteLine("                 U P D A T E  U S E R");
            Console.WriteLine(":----------------------------------------------------:");

            Console.WriteLine("");
            Console.Write(" Choose id to be updated: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Name: ");
            string username = Convert.ToString(Console.ReadLine());

            Console.Write(" Password: ");
            string password = Convert.ToString(Console.ReadLine());

            Console.Write(" Email: ");
            string email = Convert.ToString(Console.ReadLine());

            SqlCeCommand comm = new SqlCeCommand("select * from users where id = @id", conn);
            SqlCeParameter param = new SqlCeParameter();
            param.ParameterName = "@id";
            param.Value = ID.ToString();
            comm.Parameters.Add(param);
            conn.Open();
            SqlCeDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {

                try
                {
                    
                    SqlCeCommand aCommand = new SqlCeCommand("UPDATE [users] SET [username]='" + username + "',[password]='" + password + "',[email]='" + email + "'where [id]=" + ID, conn);
                    aCommand.ExecuteNonQuery();
                    conn.Close();

                }
                catch (SqlCeException e)
                {
                    Console.WriteLine("Error: {0}", e.Errors[0].Message);
                    conn.Close();
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
                conn.Close();
                return;
            }
        }

        public static void Delete()
        {
            Console.Clear();
            Repository.tableRepository.Table();

            Console.WriteLine("               D E L E T E  U S E R");
            Console.WriteLine(":----------------------------------------------------:");

            Console.WriteLine("");
            Console.Write(" Choose ID to be deleted: ");
            int ID = Convert.ToInt32(Console.ReadLine());

            SqlCeCommand comm = new SqlCeCommand("select * from users where id = @id", conn);
            SqlCeParameter param = new SqlCeParameter();
            param.ParameterName = "@id";
            param.Value = ID.ToString();
            comm.Parameters.Add(param);
            conn.Open();
            SqlCeDataReader reader = comm.ExecuteReader();           

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
                        SqlCeCommand aCommand = new SqlCeCommand("DELETE FROM users WHERE id =  " + ID, conn);
                        aCommand.ExecuteNonQuery();
                        reader.Close();
                        conn.Close();

                    }
                    catch (SqlCeException e)
                    {
                        Console.WriteLine("Error: {0}", e.Errors[0].Message);
                        reader.Close();
                        conn.Close();
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
                    conn.Close();
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
                conn.Close();
                return;
            }


        }

    }
}
