using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_Dafinka.Entities;
using Task1_Dafinka.Repositories;

namespace Task1_Dafinka.Service
{
    public class AuthenticationService
    {
        public static User LoggedUser { get; private set; }
        public static void AuthenticateUser(string username, string password)
        {
            UsersRepository usersRepo = new UsersRepository();
            AuthenticationService.LoggedUser = usersRepo.GetByUserNameandPassword(username, password);
        }
    }
}
