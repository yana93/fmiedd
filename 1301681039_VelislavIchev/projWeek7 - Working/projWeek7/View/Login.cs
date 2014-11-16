using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projWeek7.Repository;

namespace projWeek7.View
{
    public class Login
    {
       public void Show ()
        {
           while(true)
           {
               Console.Clear();

               Console.Write("Username : ");
               string username = Console.ReadLine();

               Console.Write("Password : ");
               string password = Console.ReadLine();

               UserRepository.AuthenticateUser(username,password);
               Console.WriteLine("Здравей Velko");     
               Console.ReadKey(true);         
               break;



                            
           }
        }
              
    }
}
