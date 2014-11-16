using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Repository;

namespace WebApplication2.Service
{
    public class AuthenticationService
    {
        public static User LoggedUser { get; private set; }

        public static void AuthenticateUser(string username, string password)
        {
            UserRepository userRepo = new UserRepository();
            AuthenticationService.LoggedUser = userRepo.GetByUsernameAndPassword(username, password);
        }
    }
}