using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDummySQLServerConsole
{
    class Program
    {
        static OleDbConnection aConnection;
        static void Main(string[] args)
        {

            aConnection =
                new OleDbConnection("Provider=SQLNCLI11;Data Source=STELKA\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Users");

            OleDbCommand aCommand = new OleDbCommand("SELECT * from users", aConnection);


            try
            {
                aConnection.Open();

                OleDbDataReader aReader = aCommand.ExecuteReader();
                Console.WriteLine("This is the returned data from emp_test table");
                while (aReader.Read())
                {
                    Console.WriteLine(" ID:{0}\t Fname: {1}\t Lname:{2}\t Password:{3}\t Email:{4}", aReader.GetInt32(0).ToString(), aReader.GetString(1), aReader.GetString(2), aReader.GetString(3), aReader.GetString(4));
                }

                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
                aConnection.Close();
            }
            int input = 0;
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("MENU");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Update fname");
                Console.WriteLine("3. Update lname");
                Console.WriteLine("4. Update password");
                Console.WriteLine("5. Update email");
                Console.WriteLine("6. Delete");
                Console.WriteLine("7. Exit");
                Console.WriteLine("");
                Console.Write("Please consider: ");
                int menuchoice = int.Parse(Console.ReadLine());
                switch (menuchoice)
                {
                    case 1:
                        Console.WriteLine("1. Insert");
                        Insert(); break;
                    case 2:
                        Console.WriteLine("2. Update fname");
                        UpdateFname(28); break;
                    case 3:
                        Console.WriteLine("2. Update lname");
                        UpdateLname(27); break;
                    case 4:
                        Console.WriteLine("4. Update password");
                        UpdatePassword(24); break;
                    case 5:
                        Console.WriteLine("5. Update email");
                        UpdateEmail(19); break;
                    case 6:
                        Console.WriteLine("6. Delete");
                        Delete(20); break;
                    case 7:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select a number");
                        break;
                }
                input++;
                if (input < 20)
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
                OleDbCommand aCommand = new OleDbCommand("INSERT INTO users (fname,lname, `password`, email) VALUES ('Stela', 'Karamanova','nevidima',  'stelsi@abv.bg')", aConnection);
                int numAffectedRows = aCommand.ExecuteNonQuery();
                aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("Number of records affected {0} from Insert", numAffectedRows);
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }
        public static void UpdateFname(int ID)
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET fname = 'silviq' WHERE ID = @param1", aConnection);
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
        public static void UpdateLname(int ID)
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET lname = 'Kostadinova' WHERE ID = @param2", aConnection);
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
        public static void UpdatePassword(int ID)
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET `password` = 'nemoga veche' WHERE ID = @param3", aConnection);
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
        public static void UpdateEmail(int ID)
        {
            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("UPDATE users SET email = 'hristovi@abv.bg.com' WHERE ID = @param4", aConnection);
                aCommand.Parameters.AddRange(new[]{
                     new OleDbParameter("@par4", ID)
                });
                int numberOfRows = aCommand.ExecuteNonQuery();
                aConnection.Close();
                Console.WriteLine("Number of records affected {0} from Update", numberOfRows);
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
                //aCommand.Parameters.AddWithValue("@param4", ID);
                aCommand.Parameters.AddRange(new[] {
                    new OleDbParameter("@par4", ID)
                });
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