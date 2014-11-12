using Project_111.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_111.View
{
    class LoginScreen
    {
        public void LogScreen()
        {
            string password = "";

            Console.WriteLine("Please enter UserName and Password (test&test)&(admin&admin)");
            Console.WriteLine("==============================================================================");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("Username: ");
            string username = Console.ReadLine();

            ConsoleKeyInfo cki;
            Console.Write("Password: ");
            do
            {
                cki = Console.ReadKey(true);
                if (cki.Key != ConsoleKey.Backspace && cki.Key != ConsoleKey.Enter)
                {
                    password += cki.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (cki.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (cki.Key != ConsoleKey.Enter);
          //  password = Console.ReadLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            MainController.Check(username, password);
        }
    }
}
