using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAccessConsole
{
    class Program
    {
        static OleDbConnection aConnection;
        static void Main(string[] args)
        {
            aConnection = 
                new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SP\\Task1_1301681022_Janeta_Stanilova\\Users.accdb");
            OleDbCommand aCommand = new OleDbCommand("SELECT * from users", aConnection);
            try
            {
                aConnection.Open();
                OleDbDataReader aReader = aCommand.ExecuteReader();
                Console.WriteLine("This is the returned data from users table");
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
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("MENU");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Update username");
                Console.WriteLine("3. Update password");
                Console.WriteLine("4. Update email");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.WriteLine("");
                Console.Write("Please choose wisely: ");
                int menuchoice = int.Parse(Console.ReadLine());
                switch (menuchoice)
                {
                    case 1:
                        Console.WriteLine("1. Insert");
                        Insert(); break;
                    case 2:
                        Console.WriteLine("2. Update username");
                        UpdateUsername(36); break;
                    case 3:
                        Console.WriteLine("3. Update password");
                        UpdatePassword(37); break;
                    case 4:
                        Console.WriteLine("4. Update email");
                        UpdateEmail(38); break;
                    case 5:
                        Console.WriteLine("5. Delete");
                        Delete(44); break;
                    case 6:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please choose a number from 1 to 6!");
                        break;
                }
                input++;
                if (input < 30)
                    continue;
                else
                    break;
            } 
            
            }
        public static void Insert()
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("INSERT INTO users (username, `password`, email) VALUES ('brad', 'pitttt', 'famous@abv.bg')", aConnection);
                int numAffectedRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("Number of records affected {0} from Insert", numAffectedRows);
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }
        public static void UpdateUsername(int ID)
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET username = 'kolio' WHERE ID = @param1", aConnection);
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
        public static void UpdatePassword(int ID)
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET `password` = 'terorista' WHERE ID = @param2", aConnection);
                aCommand.Parameters.AddWithValue("@param2", ID);
                int numAffectedRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("Number of records affected {0} from Update", numAffectedRows);
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
                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET email = 'babaqga@gmail.com' WHERE ID = @param3", aConnection);
                aCommand.Parameters.AddWithValue("@param3", ID);
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
                Console.WriteLine("Number of records affected {0} from Delete", numberOfRows);
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }
    }
}
