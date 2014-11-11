using Project_111.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_111.Model;

namespace Project_111.Controllers
{
    class MainController
    {
        public static Users logUser { get; private set; }
        public static void AuthenticateUser(string username, string password)
        {
            
            UsersModels userM = new UsersModels();

            MainController.logUser = userM.CheckUserAndPassword(username, password);
            
            if (MainController.logUser != null)
            {
                if (logUser.Admin == 1)
                {
                    Actions act = new Actions();
                    AdminView aView = new AdminView();
                    aView.aView();
                  
                   userM.FullInfo();
                   act.uAction();
                }
                if(logUser.Admin == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Hello {0}", logUser.Username);
                }

            }

  

           else
            {
                Console.WriteLine();
                Console.WriteLine("Wrong UserName or Password");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                LogScreen page = new LogScreen();
                page.Login();


            }
        }
    }
}
