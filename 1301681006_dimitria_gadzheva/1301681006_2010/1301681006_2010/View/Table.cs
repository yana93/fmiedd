using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace _1301681006_2010.Repository
{
    class tableRepository
    {
        static SqlCeConnection conn;
        public static void Table()
        {
            conn = new SqlCeConnection("Data Source=C:\\Users\\Dimeto\\Desktop\\1301681006_2010\\1301681006_2010\\data\\data.sdf");


            SqlCeCommand aCommand = new SqlCeCommand("SELECT * from users", conn);
            try
            {
                conn.Open();

                SqlCeDataReader aReader = aCommand.ExecuteReader();
                Console.WriteLine(":----------------------------------------------------:");
                Console.WriteLine("                 U S E R  T A B L E ");
                Console.WriteLine(":----------------------------------------------------:");
                Console.WriteLine("| id |   Name   |     Password   |        Email      |");
                Console.WriteLine(":----------------------------------------------------:");
                while (aReader.Read())
                {
                    Console.WriteLine("  {0}      {1}       {2}       {3}  ", aReader.GetInt32(0).ToString(), aReader.GetString(1), aReader.GetString(2), aReader.GetString(3));
                }

                aReader.Close();
                conn.Close();
            }
            catch (SqlCeException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
                conn.Close();
            }

            Console.WriteLine(":----------------------------------------------------:");


        }

    }
}
