using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1301681006_2010.View
{
    class Admin
    {
        public static void AdminAuthentication(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   L O G I N  S U C C E S S F U L");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(":----------------------------------:");                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("           I N V A L I D");
                Console.WriteLine(" U S E R N A M E or P A S S W O R D");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(":----------------------------------:");
                return;
            }           

        }
    }
}
