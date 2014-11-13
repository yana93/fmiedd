using EDD_111_1082.Entity;
using EDD_111_1082.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDD_111_1082.Presentation
{
    class RegisterView
    {
        public string LoggedUser { get; private set; }
        public RegisterView()
        {
            LoggedUser=Register();
        }
        private  string Register()
        {
            string s_logged = null;
            while (true)
            {
                try
                {
                    Console.Clear();

                    UserRepository urepo = new UserRepository();
                    User user1 = new User();
                    Console.WriteLine("Firstname:");
                    user1.Firstname = Console.ReadLine();

                    Console.WriteLine("Lastname:");
                    user1.Lastname = Console.ReadLine();

                    Console.WriteLine("Username:");
                    user1.Username = Console.ReadLine();

                    Console.WriteLine("Password:");
                    user1.Password = Console.ReadLine();

                    /*if (urepo.RetrieveOne(user1.Username).Username != null)
                    {
                        Console.WriteLine("Username already taken!");
                        Console.ReadKey(true);
                    }
                    else
                    {*/
                        urepo.Insert(user1);
                        s_logged = user1.Username;
                        Console.WriteLine("Congratulations, {0}! You are now part of C-Mail !", user1.Firstname);
                        break;
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid operation.User with this name already exists!");
                    Console.ReadKey(true);
                }                
            }
            return s_logged;
        }        
    }
}
