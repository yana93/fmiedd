using System.Configuration;
using UsersManager.Entities;
using UsersManager.Repositories;

namespace UsersManager.Services
{
    public static class AuthenticationService
    {
        public static User LoggedUser { get; private set; }

        public static void AuthenticateUser(string username, string password)
        {
            UsersRepository usersRepository = new UsersRepository(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            AuthenticationService.LoggedUser = usersRepository.GetByUsernameAndPassword(username, password);
        }
    }
}
