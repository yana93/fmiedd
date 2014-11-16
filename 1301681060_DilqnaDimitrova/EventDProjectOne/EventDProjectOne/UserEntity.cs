using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventDProjectOne
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return " USERNAME: " + this.Username.ToString() + " PASSWORD: " + this.Password.ToString() + " EMAIL: " + this.Email.ToString();
        }
    }
}