using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;

namespace task1
{
    class Program
    {
        public static Repo R;
        static void Main(string[] args)
        {

            R = new Repo();
            MainMenu();
            Console.ReadKey(true);
        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1.List users");
            Console.WriteLine("2.Add user");
            Console.WriteLine("3.Delete user");
            Console.WriteLine("4.Edit User");

            ConsoleKeyInfo ck = Console.ReadKey(true);

            if (ck.Key == ConsoleKey.D1)
            {
                ListUsers();
            }

            if (ck.Key == ConsoleKey.D2)
            {
                AddUser();
            }

            if (ck.Key == ConsoleKey.D3)
            {
                DeleteUser();
            }

            if (ck.Key == ConsoleKey.D4)
            {
                UpdateUser();
            }
        }

        public static void ListUsers()
        {
            foreach(var u in R.ListUsers()) 
            {
                Console.WriteLine("ID : {0}, Username {1}", u.id, u.username);
            }
            Console.WriteLine("Esc to go back");

            ConsoleKeyInfo ck = Console.ReadKey();
            if (ck.Key == ConsoleKey.Escape)
            {
                MainMenu();
            }

           
        }

        public static void AddUser()
        {
            Console.Clear();

            Console.WriteLine("Username : ");
            string username = Console.ReadLine();


            Console.WriteLine("Password : ");
            string password = Console.ReadLine();


            Console.WriteLine("Email : ");
            string email = Console.ReadLine();

            if (R.AddUser(username, password, email) > 0)
            {
                Console.WriteLine("User added");
                Console.WriteLine("Esc to go back");

                ConsoleKeyInfo ck = Console.ReadKey();

                if(ck.Key == ConsoleKey.Escape) 
                {
                    MainMenu();
                }
            }

        }

        public static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("Enter user id");
            int id = Convert.ToInt32(Console.ReadLine());

           
            if (R.DeleteUser(id) > 0)
            {
                Console.WriteLine("User Deleted");

            }
            else
            {
                Console.WriteLine("User not found");
            }
            Console.WriteLine("Esc to go back");

            ConsoleKeyInfo ck = Console.ReadKey();

            if (ck.Key == ConsoleKey.Escape)
            {
                MainMenu();
            }

        }

        public static void UpdateUser()
        {
            Console.Clear();
            Console.WriteLine("Enter user id");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("New Username : ");
            string username = Console.ReadLine();


            Console.WriteLine("New Password : ");
            string password = Console.ReadLine();


            Console.WriteLine("New Email : ");
            string email = Console.ReadLine();

        



            if (R.UpdateUser(id, username, password, email) > 0)
            {
                Console.WriteLine("User updated");

            }
            else
            {
                Console.WriteLine("User was not updated");
            }
            Console.WriteLine("Esc to go back");

            ConsoleKeyInfo ck = Console.ReadKey();

            if (ck.Key == ConsoleKey.Escape)
            {
                MainMenu();
            }





        }
    }
}
