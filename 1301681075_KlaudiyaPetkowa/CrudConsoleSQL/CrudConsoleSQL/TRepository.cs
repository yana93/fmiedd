using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CrudConsoleSQL
{
    class TRepository
    {
        static SqlConnection connect;
        public static void Table()
        {
            connect = new SqlConnection("Data Source=HP;Integrated Security=SSPI;Initial Catalog=Users");


            SqlCommand aCommand = new SqlCommand("Select * From Users", connect);
            try
            {
                connect.Open();

                SqlDataReader aReader = aCommand.ExecuteReader();
                Console.WriteLine("                 U S E R  T A B L E ");
                Console.WriteLine(" _____________________________________________________");
                Console.WriteLine("| id |   Name   |     Password   |        Email      |");
                Console.WriteLine(" ____________________________________________________");
                while (aReader.Read())
                {
                    Console.WriteLine("  {0}      {1}       {2}       {3}  ", aReader.GetInt32(0).ToString(), aReader.GetString(1), aReader.GetString(2), aReader.GetString(3));
                }

                aReader.Close();
                connect.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
                connect.Close();
            }
        }
    }
}
