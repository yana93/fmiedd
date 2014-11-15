using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsoleSQL
{
    class Login
    {
        public void SystemLogin()
        {

            while (true)
            {
                Console.Clear();

                Console.WriteLine("______________________");
                Console.WriteLine("Logein to Continue");

                Console.WriteLine("______________________");
                Console.Write(" Enter username: ");
                string username = Console.ReadLine();

                Console.Write(" Enter password: ");
                string password = Console.ReadLine();
                Console.WriteLine("______________________");

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
