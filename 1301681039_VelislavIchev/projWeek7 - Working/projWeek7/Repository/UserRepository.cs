using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projWeek7.View;
namespace projWeek7.Repository
{
    public class UserRepository
    {
        public static void AuthenticateUser(string username, string password)
        {
            if(username == "Velko" && password == "velko")
            {
                Console.WriteLine("Влязохте в системата ! ");          
            }
            else
            {
                Console.WriteLine("Невалиден username или password  !");
                return;
            }

        }
        
    }
}
