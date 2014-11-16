using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CRUD_111VasilMinchev1301681102
{
   public class Check
    {
        public void FullInfo()
        {
            OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Vasil\\Documents\\Visual Studio 2012\\Projects\\CRUD_111VasilMinchev1301681102\\CRUD_111VasilMinchev1301681102\\Data\\Users.accdb;");
            OleDbCommand aCommand = new OleDbCommand("select * from users", aConnection);
            try
            {
                aConnection.Open();
                OleDbDataReader reader = aCommand.ExecuteReader();
                
                while (reader.Read())
                {

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("ID: {0} || UserName: {1} || Email: {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(3));
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("-------------------------------------------------------------------------------", Console.ForegroundColor = ConsoleColor.DarkGray);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                aConnection.Close();
                reader.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }
    }
}
