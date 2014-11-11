using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_SQL
{
    class Program
    {
        static void Menu()
        {
            Console.WriteLine("To read all the contacts please press [R]");
            Console.WriteLine("To add a contact please press [A]");
            Console.WriteLine("To update a contact please press [U]");
            Console.WriteLine("To delete a contact please press [D]");
            Console.Write("Your Choice:  ");
        }
        
        static void Main(string[] args)
        {
            Menu();
            UserRepository userRepo =new UserRepository();
            ConsoleKeyInfo cki;
            
                     
            cki = Console.ReadKey();
            
            if (cki.Key.ToString() == "R" || cki.Key.ToString() == "r")
            {
                Console.WriteLine();
                userRepo.Read();            
            }
            if (cki.Key.ToString() == "U" || cki.Key.ToString() == "u")
            {
                Console.WriteLine("Please enter the ID of the contact: ");
                string id = Console.ReadLine();
               
                userRepo.Read(Convert.ToInt32(id));
                
                var User = new User();
                User.Id = Convert.ToInt32(id);
                
                Console.WriteLine("Username: ");
                User.Username = Console.ReadLine();
                Console.WriteLine("Password: ");
                User.Password = Console.ReadLine();
                Console.WriteLine("Email: ");
                User.Email = Console.ReadLine();

                userRepo.Update(User);
            }

            if (cki.Key.ToString() == "D" || cki.Key.ToString() == "d")
            {
                Console.WriteLine("Please enter the ID of the contact: ");
                string id =  Console.ReadLine();

                userRepo.Delete(Convert.ToInt32(id));
                Console.Clear();
                Console.WriteLine("User is deleted");
                Console.WriteLine();
                Menu();
            }

            if (cki.Key.ToString() == "A" || cki.Key.ToString() == "a")
            {
                var User = new User();
                Console.WriteLine("Username: ");
                User.Username = Console.ReadLine();
                Console.WriteLine("Password: ");
                User.Password = Console.ReadLine();
                Console.WriteLine("Email: ");
                User.Email = Console.ReadLine();
                userRepo.Insert(User);
                Console.Clear();
                Console.WriteLine("User with username "+ User.Username +" was added");
                Console.WriteLine();
                Menu();
            }
            Console.ReadKey(true);
        }
    }
}
