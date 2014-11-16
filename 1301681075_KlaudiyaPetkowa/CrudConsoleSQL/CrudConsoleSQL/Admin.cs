using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsoleSQL
{
    class Admin
    {
        public static void AdminAuthentication(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Login  Successful!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("________________________");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Invalid Username or Password");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("_____________________________");
                return;
            }
        }
    }
}