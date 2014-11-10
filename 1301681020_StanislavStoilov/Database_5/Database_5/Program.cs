using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Database_5
{
    class Program
    {

        public static void Main(string[] args)
        {

           Console.Write("This is my SQL Database! Press 'Enter' to see the table!\n");

           SqlConnection scon = new SqlConnection("Server=STANISLAV-PC; Database=PROJECT; Integrated Security=true; Persist Security Info=false;");
            scon.Open(); 

           SqlConnection con = new SqlConnection("Server=STANISLAV-PC; Database=PROJECT; Integrated Security=true; Persist Security Info=false;");
            con.Open();

            SqlConnection sqcon = new SqlConnection("Server=STANISLAV-PC; Database=PROJECT; Integrated Security=true; Persist Security Info=false;");
            sqcon.Open();

            SqlConnection sqlcon = new SqlConnection("Server=STANISLAV-PC; Database=PROJECT; Integrated Security=true; Persist Security Info=false;");
            sqlcon.Open();


            ConsoleKeyInfo sqlcki;
            sqlcki = Console.ReadKey(true);
        
            switch (sqlcki.Key)
            {
                case ConsoleKey.Enter:
                    SqlCommand scom = new SqlCommand("SELECT * " + "FROM [PROJECT].[dbo].[USERS]", scon);

                    SqlDataReader srd = scom.ExecuteReader();


                    while (srd.Read())
                    {
                        Console.WriteLine("ID:{0}\n Username:{1}\n Password:{2}\n Email:{3}\n", srd.GetSqlValue(0), srd.GetString(1), srd.GetSqlValue(2), srd.GetString(3));
                    }

                    srd.Close();

                    break;

            }
 
                SqlCommand com = new SqlCommand("UPDATE [PROJECT].[dbo].[USERS]" + "SET Password='womn94'" + "WHERE USERNAME='Womanizer'", con);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine("ID:{0}\n Username:{1}\n Password:{2}\n Email:{3}\n", dr.GetSqlValue(0), dr.GetString(1), dr.GetSqlValue(2), dr.GetString(3));
                }


                dr.Close();
            
                   
               SqlCommand sqcom = new SqlCommand("DELETE " + "FROM [PROJECT].[dbo].[USERS]" + "WHERE USERNAME='Fucking_Life'", sqcon);
               SqlDataReader sqdr = sqcom.ExecuteReader();


                 while (sqdr.Read())
                 {
                     Console.WriteLine("ID:{0}\n Username:{1}\n Password:{2}\n Email:{3}\n", sqdr.GetSqlValue(0), sqdr.GetString(1), sqdr.GetSqlValue(2), sqdr.GetString(3));
                 }

                   sqdr.Close();

            //SqlCommand sqlcom = new SqlCommand("INSERT INTO [PROJECT].[dbo].[USERS] (ID, USERNAME, PASSWORD, EMAIL)" + "VALUES(25, 'Winner', 'win98', 'winner_baby@abv.bg')", sqlcon);
           // SqlDataReader sqldr = sqlcom.ExecuteReader();

                   /* while (sqldr.Read())
                    {
                        Console.WriteLine("ID:{0}\n Username:{1}\n Password:{2}\n Email:{3}\n", sqldr.GetSqlValue(0), sqldr.GetString(1), sqldr.GetSqlValue(2), sqldr.GetString(3));

                    }

                    sqldr.Close();

                   */

            scon.Close();
            con.Close();
            sqcon.Close();
            sqlcon.Close();


            Console.ReadKey(true);
        }
    }
}
