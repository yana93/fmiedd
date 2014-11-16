using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CRUD_111VasilMinchev1301681102
{
    class Program : User
    {

        static OleDbCommand aCommand;
        static OleDbConnection aConnection;
        public static Check aCheck = new Check();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        static void Main(string[] args)
             
        { 
       
            Console.ForegroundColor = ConsoleColor.Green;
            aConnection =
                new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Vasil\\Documents\\Visual Studio 2012\\Projects\\CRUD_111VasilMinchev1301681102\\CRUD_111VasilMinchev1301681102\\Data\\Users.accdb");
            OleDbCommand aCommand = new OleDbCommand("SELECT * from users", aConnection);
            
            try
            {
                aConnection.Open();
                OleDbDataReader aReader = aCommand.ExecuteReader();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Chose one of the ID`s on this user table datas.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                while (aReader.Read())
                {
                    Console.WriteLine(" ID: {0} \n Username: {1} \n Password: {2} \n Email: {3}", aReader.GetInt32(0).ToString(), aReader.GetString(1), aReader.GetString(2), aReader.GetString(3));
                }
                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
            int input = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;
            while (true)
            {
                Console.WriteLine("***************************Mincheff`s CRUD**************************");
                Console.WriteLine("Menu with Options");
                Console.WriteLine("1. Insert User");
                Console.WriteLine("2. Update Username");
                Console.WriteLine("3. Update  UserPassword");
                Console.WriteLine("4. Update  UserEmail");
                Console.WriteLine("5. Delete User");
                Console.WriteLine("6. Exit from app");
                Console.WriteLine("");
                Console.Write("Select one of options: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                
                
                 
                int menuchoice = int.Parse(Console.ReadLine());
                switch (menuchoice)
                {
                    case 1:
                        Console.WriteLine("1. Insert");
                        Insert(); break;
                    case 2:
                        Console.WriteLine("Insert ID:"); 
                        UpdateUsername(int.Parse(Console.ReadLine())); break;
                    case 3:
                        Console.WriteLine("Insert ID:"); 
                        UpdatePassword(int.Parse(Console.ReadLine())); break;
 
                    case 4:
                        Console.WriteLine("Insert ID:");
                        UpdateEmail(int.Parse(Console.ReadLine())); break;
                    case 5:
                        Console.WriteLine("5. Delete");
                        Delete(int.Parse(Console.ReadLine())); break;
                    case 6:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Chose on of following options:");
                        break;
                }
                input++;
                if (input < 30)
                    continue;
                else
                    break;
            }

        }
        
       
        public static void UpdatePassword(int ID)
        {
            


            try
            {
                aConnection.Open();
                Console.WriteLine("Enter new Password:");
                string password = Console.ReadLine().ToString();
                Console.WriteLine("New password is {0}",password);
                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET `password` = '"+password+"' WHERE ID = @param2", aConnection);
                aCommand.Parameters.AddWithValue("@param2", ID);
                int numAffectedRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("Number of records affected {0} from Update Successfully", numAffectedRows);
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }
        public static void UpdateEmail(int ID)
        {
            
            


           
            try
            {

                aConnection.Open();
                Console.WriteLine("Enter new Email:");
                string email = Console.ReadLine().ToString();
                Console.WriteLine("NewUsername is:{0}", email);
                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET email = 'visualstudio@abv.bg''" + email + "' WHERE ID = @param3", aConnection);
                aCommand.Parameters.AddWithValue("@param3", ID);
                int numAffectedRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("Number of records affected {0} from Update Successfully", numAffectedRows);
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }

        public static void Insert()
        {
            try
            {
                
               
               
                Console.Clear();
                Console.WriteLine("You can add new USERS");
                Console.WriteLine("---------------------------------------");

                aConnection.Open();
                Console.Write("Username: ");
                string username = Console.ReadLine().ToString();
                Console.Write("Password: ");
                string password = Console.ReadLine().ToString();
                Console.Write("Email: ");
                string Email = Console.ReadLine().ToString();
                if (username != "" && password != "")
                {


                    OleDbCommand aCommand = new OleDbCommand("INSERT INTO users (username, `password`, email) VALUES ('"+ username +"', '"+ password +"', '"+Email+"')", aConnection);
                    int numAffectedRows = aCommand.ExecuteNonQuery();
                    aConnection.Close();
                    Console.WriteLine("You successfully added user. Number of affected Insert is{0}!:)", numAffectedRows);

                }
                if (username == "" || password == "")
                {
                    Console.WriteLine("Empty username or password");
                    Console.ReadKey();
                }

                Console.Clear();
                if (username != null)
                {
                    Console.WriteLine("You added new user: {0}", username);
                }
                Console.WriteLine("---------------------");

               
                
                
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }

        public static void UpdateUsername (int ID)
        {

            try
            {
               
                aConnection.Open();
                Console.WriteLine("Enter new user name:");
                string username = Console.ReadLine().ToString();
                Console.WriteLine("NewUsername is:{0}",username);
                

                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET username = '"+username+"' WHERE ID = @param1", aConnection);
                aCommand.Parameters.AddWithValue("@param1", ID);
                int numAffectedRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("Number of records affected {0} from Update", numAffectedRows);
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
                OleDbCommand aCommand = new OleDbCommand("DELETE FROM users WHERE ID = @param4", aConnection);
                aCommand.Parameters.AddWithValue("@param4", ID);
                int numberOfRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("Number of records affected {0} from Delete Successfully", numberOfRows);
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
          
        }
    }
}
