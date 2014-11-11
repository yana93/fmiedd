using _1301681006_2010.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _1301681006_2010.View
{
    class Login
    {
        public void SystemLogin()
        {

            while (true)
            {
                Console.Clear();

                Console.WriteLine(":----------------------------------:");
                Console.WriteLine("  L O G  I N  T O  C O N T I N U E");

                Console.WriteLine(":----------------------------------:");
                Console.Write("       Enter username: ");
                string username = Console.ReadLine();

                Console.Write("       Enter password: ");
                string password = Console.ReadLine();
                Console.WriteLine(":----------------------------------:");

                Admin.AdminAuthentication(username, password);

                if (username == "admin")
                {
                    Console.ReadKey(true);
                    break;
                }

                Console.ReadKey(true);

            }
        }
    }
}
