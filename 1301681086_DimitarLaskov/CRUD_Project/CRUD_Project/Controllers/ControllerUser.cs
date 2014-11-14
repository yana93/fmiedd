using CRUD_Project.Models;
using CRUD_Project.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Project.Controllers
{
    class ControllerUser
    {
        private Models.ModelUser user1;

        public ControllerUser(Models.ModelUser user1)
        {
            this.user1 = user1;
        }

        public ControllerUser()
        { }

        public int LoginAuthentication(string username, string pass)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var user = from u in db.Users
                       where u.Username == username && u.Password == pass
                       select u.Id;

            if (user.FirstOrDefault() > 0)
            {
                return user.FirstOrDefault();
            }

            return 0;
        }

        public bool Register(string username, string pass, string email)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var usernames = from un in db.Users
                            select un.Username;

            if (!usernames.Contains(username))
            {
                db.Users.InsertOnSubmit(new User { Username = username, Password = pass, Email = email, IsAdmin = "false" });
                db.SubmitChanges();
                return true;
            }

            return false;
        }

        public Models.ModelUser SetCurrentUser(int userID)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            Models.ModelUser user1 = new Models.ModelUser();

            var user = from u in db.Users
                       where userID == u.Id
                       select new { 
                           Username = u.Username,
                           Password = u.Password,
                           Email = u.Email,
                           Id = u.Id,
                           IsAdmin = u.IsAdmin
                       };

            foreach (var item in user.ToList())
            {
                user1.UserId = item.Id;
                user1.Username = item.Username;
                user1.Password = item.Password;
                user1.Email = item.Email;
                user1.IsAdmin = Convert.ToBoolean(item.IsAdmin);
            }

            return user1;
        }
    }
}
