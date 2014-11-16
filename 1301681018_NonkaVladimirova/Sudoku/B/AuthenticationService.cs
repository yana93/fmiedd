using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B.DataClass;
namespace B
{
    class AuthenticationService
    {
        public static User LoggedUser { get; private set; }

        public static void AuthenticateUser(string username, string password)
        {
            AuthenticationService.LoggedUser = UserRepository.GetByUsernameAndPassword(username, password);
        }
    }
}
