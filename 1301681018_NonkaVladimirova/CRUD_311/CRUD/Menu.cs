using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public enum choice
    {
        Insert = 1,
        Delete = 2,
        Update = 3,
        Select = 4,
        Exit = 5
    }
    class Menu
    {
        public void Show()
        {
            while (true)
            {
                choice choice = RenderMenu();

                switch (choice)
                {

                    case choice.Select:
                    {
                        GetAll();
                        break;
                    }
                    case choice.Update:
                    {
                        Edit();
                        break;
                    }
                    case choice.Insert:
                    {
                        Add();
                        break;
                    }
                    case choice.Delete:
                    {
                        Delete();
                        break;
                    }
                    case choice.Exit:
                    {
                        return;
                    }
                }
            }
        }

        private choice RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Users management:");
                Console.WriteLine("[G]et all users");
                Console.WriteLine("[A]dd user");
                Console.WriteLine("[E]dit User");
                Console.WriteLine("[D]elete User");
                Console.WriteLine("E[x]it");

                string key = Console.ReadLine();
                switch (key.ToUpper())
                {
                    case "G":
                        {
                            return choice.Select;
                        }
                    case "A":
                        {
                            return choice.Insert;
                        }
                    case "D":
                        {
                            return choice.Delete;
                        }
                    case "X":
                        {
                            return choice.Exit;
                        }
                    case "E":
                        {
                            return choice.Update;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
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
                Console.WriteLine("______________________________________________");
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

            Console.WriteLine("Edit User:");
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
