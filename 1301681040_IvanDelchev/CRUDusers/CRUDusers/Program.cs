using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDusers
{
    class Program
    {
        static OleDbConnection aConnection;
        static void Main(string[] args)
        {
            aConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ivan\Source\Repos\fmiedd2\1301681040_IvanDelchev\CRUDusers\CRUDusers\data\users.accdb");
                Console.Write("Username : ");
                string username = Console.ReadLine();
                Console.Write("Password : ");
                string password = Console.ReadLine();
                Console.WriteLine();
                if (login(username, password))
                {
                    Read();
                    while (true)
                    {
                        Console.WriteLine("Choose action: 1-Add 2-Update 3-Delete 0-Exit");
                        int action = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        switch (action)
                        {

                            case 1:
                                Console.WriteLine("Type: user, password and email");
                                try
                                {
                                    Console.Write("Enter username: ");
                                    string userAdd = Console.ReadLine();
                                    Console.Write("Enter password: ");
                                    string passAdd = Console.ReadLine();
                                    Console.Write("Enter email: ");
                                    string emailAdd = Console.ReadLine();
                                    Console.WriteLine();
                                    Add(userAdd, passAdd, emailAdd);
                                    //Read();
                                }
                                catch (OleDbException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;

                            case 2:
                                Console.Write("Wich position you want to update? ");
                                try
                                {
                                    int idUpdate = int.Parse(Console.ReadLine());
                                    Console.Write("New username: ");
                                    string usernameUpdate = Console.ReadLine();
                                    Console.Write("New password: ");
                                    string passUpdate = Console.ReadLine();
                                    Console.Write("New email: ");
                                    string emailUpdate = Console.ReadLine();
                                    Console.WriteLine();
                                    Update(idUpdate, usernameUpdate, passUpdate, emailUpdate);
                                    // Read();
                                }
                                catch (OleDbException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;

                            case 3:
                                Console.WriteLine("Which line do you want to delete? ");
                                try
                                {
                                    int deleteLine = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Delete(deleteLine);
                                    //Read();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                        }

                    }
                    
                }
                else {
                    Console.WriteLine("Wrong username or password");
                }
                Console.ReadKey(true);
            
        }
        public static bool login(string username, string password) { 
            try
            {
                if (username=="admin" && password=="admin")
                {
                    aConnection.Close();
                    return true;
                }
                else
                {
                    aConnection.Close();
                    return false;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            aConnection.Close();
            return false;
        }
        public static void Add(string username, string pass, string email)
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("INSERT INTO users (username, [password], email) VALUES (@par1,@par2,@par3)", aConnection);
                aCommand.Parameters.AddRange(new[] { new OleDbParameter("@par1", username) });
                aCommand.Parameters.AddRange(new[] { new OleDbParameter("@par2", pass) });
                aCommand.Parameters.AddRange(new[] { new OleDbParameter("@par3", email) });
                int numberOfRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("*****Number of rows affected {0} from INSERT*****", numberOfRows);
                Read();
                Console.WriteLine("*****User {0} was successfully inserted!*****",username);
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }

        public static void Update(int ID, string username, string pass, string email)
        {
            try
            {
                aConnection.Open();

                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET username = @par2, [password] = @par3, email = @par4 WHERE ID = @par1", aConnection);
                //("UPDATE users SET username = @par2, [password] = @par3, email = @par4 WHERE ID = @par1", aConnection);
               // ("UPDATE users SET username = @par2 WHERE ID = @par1", aConnection);
                aCommand.Parameters.AddRange(new[] { new OleDbParameter("@par2", username) });
                aCommand.Parameters.AddRange(new[] { new OleDbParameter("@par3", pass) });
                aCommand.Parameters.AddRange(new[] { new OleDbParameter("@par4", email) });
                aCommand.Parameters.AddRange(new[] { new OleDbParameter("@par1", ID) });
                int numberOfRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("*****Number of rows affected {0} from UPDATE*****", numberOfRows);
                Read();
                Console.WriteLine("*****Number {0} was successfully updaed!*****",ID);
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);

            }
        }

        public static void Delete(int ID)
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("DELETE FROM users WHERE ID = @par1", aConnection);
                aCommand.Parameters.AddRange(new[] { new OleDbParameter("@par1", ID) });
                int numberOfRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("*****Number of rows affected {0} from DELETE*****", numberOfRows);
                Read();
                Console.WriteLine("*****Number {0} was successfully deleted*****",ID);

            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);

            }

        }
        public static void Read()
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("SELECT * from users", aConnection);
                OleDbDataReader aReader = aCommand.ExecuteReader();
                Console.WriteLine("Users table:");
                while (aReader.Read())
                {
                    Console.WriteLine("{0} \t {1}", aReader.GetInt32(0).ToString(), aReader.GetString(1));
                }
                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }
    }
}
