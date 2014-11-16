using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDD_111_1082.Entity;
using EDD_111_1082.Repository;
using EDD_111_1082.Tools;
using System.Threading;

namespace EDD_111_1082.Presentation
{
    class AdminView //CAUTION! DO NOT SEND: ERROR ON EDIT()
    {
        public AdminView() //View and functional methods when logged as admin
        {
            while (true)
            {
                UserManagementEnum choice = RenderMenu();
                switch (choice)
                {
                    case UserManagementEnum.Select: { ViewAllUsers(); break; }
                    case UserManagementEnum.Update: { EditUser(); break; }
                    case UserManagementEnum.Delete: { DeleteUser(); break; }
                    case UserManagementEnum.Exit: { return; }
                }
            }
        }
       
        private UserManagementEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User management:");
                Console.WriteLine("[V]iew all users");
                Console.WriteLine("[E]dit user");
                Console.WriteLine("[D]elete user");
                Console.WriteLine("E[X]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "V":{return UserManagementEnum.Select; }
                    case "E": { return UserManagementEnum.Update; }                        
                    case "D":{ return UserManagementEnum.Delete;}
                    case "X":{return UserManagementEnum.Exit;}
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
        #region MenuMethods
        public void ViewAllUsers()
        {
            UserRepository urepo = new UserRepository();
            try
            {
                 urepo.Retrieve();
                 foreach (User u in urepo.Retrieve())
                 {
                     Console.WriteLine("{0} | {1} | {2} | {3} | {4}", u.ID, u.Firstname, u.Lastname, u.Username, u.Password);
                 }
            }
            catch (Exception)
            {
                throw;
            }
            Console.ReadKey(true);
            
        }
        public void EditUser()
        {

            while (true)
            {
                Console.Clear();
                UserRepository urepo = new UserRepository();
                Console.WriteLine("Please insert user you want to edit.");
                Console.WriteLine("Username:");
                User user1 = new User();
                user1.Username = Console.ReadLine();
                /*user1 = urepo.RetrieveOne(user1.Username);
                if (user1.Username == null)
                {
                    Console.WriteLine("User not found!");
                    Thread.Sleep(1500);
                    Console.ReadKey(true);
                }
                else
                {*/
                Console.WriteLine("New firstname:");
                user1.Firstname = Console.ReadLine();
                Console.WriteLine("New lastname:");
                user1.Lastname = Console.ReadLine();
                int upd = urepo.Update(user1);
                if (upd > 0)
                {
                    Console.WriteLine("Successfully updated contact!");
                    Thread.Sleep(1500);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    Console.ReadKey(true);
                }
            }

        }
        public void DeleteUser()
        {
            Console.Clear();
            UserRepository urepo = new UserRepository();
            User user1 = new User();
            Console.Write("Please insert user you want to delete.");
            Console.WriteLine("Username:");
            user1.Username = Console.ReadLine();
            User tempUser = urepo.RetrieveOne(user1.Username);
            if (tempUser.Username == null)
            {
                Console.WriteLine("User not found!");
                Thread.Sleep(2000);
            }
            else
            {
                urepo.Delete(user1);
                Console.WriteLine("Successfully deleted contact!");
                Thread.Sleep(2000);
            }

        }
        #endregion
    }
}
