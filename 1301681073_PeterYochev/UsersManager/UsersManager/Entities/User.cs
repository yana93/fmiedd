using System;

namespace UsersManager.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}", this.Username, this.Password, this.Email);
        }
    }
}
