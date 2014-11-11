using Project_111.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_111.View;
using Project_111.Model;

namespace Project_111.Controllers
{
    public static class MainController
    {
        public static User logUser { get; private set; }
        public static void Check(string username, string password)
        {
            LogCheck check = new LogCheck();

            MainController.logUser = check.CheckUserAndPassword(username, password);

            if (MainController.logUser != null)
            {
                if (logUser.Admin == 1)
                {
                    Console.WriteLine("Hello admin");
                    Console.ReadKey();

                    AdminView info = new AdminView();
                    info.FullInfo();
                    Actions act = new Actions();
                    act.uAction();
                }
                if (logUser.Admin == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Hello {0}", logUser.Username);                  
                }
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("Wrong UserName or Password");
                //System.Threading.Thread.Sleep(1500);
                Console.ReadKey(true);
                Console.Clear();
                LoginScreen scr = new LoginScreen();
                scr.LogScreen();


            }
        }
    }
}
