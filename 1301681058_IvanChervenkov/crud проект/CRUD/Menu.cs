using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class Menu
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Users management:");
                Console.WriteLine("Press G to get all users");
                Console.WriteLine("Press A to add user");
                Console.WriteLine("press U to update");
                Console.WriteLine("Press D to delete User");
                Console.WriteLine("Press X to exit");

                string key = Console.ReadLine();
                switch (key.ToUpper())
                {
                    case "G":
                        {
                            GetAll();
                            break;
                        }
                    case "A":
                        {
                            Add();
                            break;
                        }
                    case "D":
                        {
                            Delete();
                            break;
                        }
                    case "X":
                        {
                            System.Environment.Exit(0);
                            break;
                        }
                    case "U":
                        {
                            Edit();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

   

        private void GetAll()
        {
            Console.Clear();

            UserRepository UserRepository = new UserRepository();
            List<User> users = UserRepository.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine("ID:" + user.ID);
                Console.WriteLine("Username :" + user.Username);
                Console.WriteLine("Full Name :" + user.Full_Name);
                Console.WriteLine("Email :"+user.Email);
                Console.WriteLine("=====================================");
            }

            Console.ReadKey(true);
        }

        private void Add()
        {
            Console.Clear();

            User user = new User();

            Console.WriteLine("Add new User:");
            Console.Write("Username: " );
            user.Username = Console.ReadLine();
            Console.Write("Password: ");
            user.Password = Console.ReadLine();
            Console.Write("Full Name: ");
            user.Full_Name = Console.ReadLine();
            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            UserRepository userRepository = new UserRepository();
            userRepository.Add(user);            
            Console.ReadKey(true);
        }

        private void Delete()
        {
            UserRepository userRepository = new UserRepository();

            Console.Clear();

            Console.WriteLine("Delete User:");
            Console.Write("Username: ");
            string username = Console.ReadLine();

            userRepository.Delete(username);
            Console.ReadKey(true);
        }

        private void Edit()
        {
            User user = new User();
            UserRepository userRepository = new UserRepository();

            Console.Clear();

            Console.WriteLine("Update User:");
            Console.Write("Username: ");
            user.Username = Console.ReadLine();
            Console.Write("Password: ");
            user.Password = Console.ReadLine();
            Console.Write("Full Name: ");
            user.Full_Name = Console.ReadLine();
            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            userRepository.Update(user);
            Console.ReadKey(true);

        }
    }
}
