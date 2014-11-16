using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_ConsoleOOP.Entity;
using Task1_ConsoleOOP.Repository;
using Task1_ConsoleOOP.Tools;

namespace Task1_ConsoleOOP.View
{
    public class LoginView
    {
        public void Show()
        {
            while (true)
            {
                UserManagementEnum choice = RenderMenu();

                switch (choice)
                {
                    case UserManagementEnum.Select:
                        {
                            GetAll();
                            break;
                        }
                    case UserManagementEnum.Insert:
                        {
                            Add();
                            break;
                        }
                    case UserManagementEnum.Delete:
                        {
                            Delete();
                            break;
                        }
                    case UserManagementEnum.Update:
                        {
                            Update();
                            break;
                        }
                    case UserManagementEnum.Exit:
                        {
                            return;
                        }
                }
            }
        }
        private UserManagementEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Users management: ");
                Console.WriteLine("[G]et all Users");
                Console.WriteLine("[C]reate User");
                Console.WriteLine("[U]pdate User");
                Console.WriteLine("[D]elete User");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "G":
                        {
                            return UserManagementEnum.Select;
                        }
                    case "C":
                        {
                            return UserManagementEnum.Insert;
                        }
                    case "D":
                        {
                            return UserManagementEnum.Delete;
                        }
                    case "X":
                        {
                            return UserManagementEnum.Exit;
                        }
                    case "U":
                        {
                            return UserManagementEnum.Update;
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
            UsersRepository usersRepository = new UsersRepository();
            List<Users> users = usersRepository.GetAll();

            foreach (Users user in users)
            {
                Console.WriteLine("Id : {0}", user.Id);
                Console.WriteLine("First Name : {0}", user.FirstName);
                Console.WriteLine("Last Name : {0}", user.LastName);
                Console.WriteLine("Password : {0}", user.Password);
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine();
            }

            Console.ReadKey(true);
        }

        private void Add()
        {
            Console.Clear();

            Users user = new Users();
            UsersRepository creatUser = new UsersRepository();

            Console.WriteLine("Add new User:");
            try
            {
                Console.Write("Id=  ");
                user.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("First Name=  ");
                user.FirstName = Console.ReadLine();
                Console.Write("Last Name=  ");
                user.LastName = Console.ReadLine();
                Console.Write("Password=  ");
                user.Password = Console.ReadLine();
                creatUser.Insert(user);

                Console.WriteLine("User created successfully.");
                Console.ReadKey(true);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Id.");
                Console.ReadKey(true);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Already have this ID in DATABASE.");
                Console.ReadKey(true);
            }

        }
        private void Update()
        {
            Console.Clear();

            Users user = new Users();
            UsersRepository updateUser = new UsersRepository();

            Console.WriteLine("Update User:");
            try
            {
                Console.Write("Id=  ");
                user.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("First Name=  ");
                user.FirstName = Console.ReadLine();
                Console.Write("Last Name=  ");
                user.LastName = Console.ReadLine();
                Console.Write("Password=  ");
                user.Password = Console.ReadLine();
                updateUser.Update(user);

                Console.WriteLine("User update successfully.");
                Console.ReadKey(true);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Id.");
                Console.ReadKey(true);
            }
        }
        private void Delete()
        {
            Console.Clear();

            Users user = new Users();
            UsersRepository deleteUser = new UsersRepository();

            Console.WriteLine("Delete User: ");
            try
            {
                Console.Write("User Id= ");
                user.Id = Convert.ToInt32(Console.ReadLine());
                deleteUser.Delete(user);

                Console.WriteLine("User delete successfully.");
                Console.ReadKey(true);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Id.");
                Console.ReadKey(true);
            }
        }
    }
}
