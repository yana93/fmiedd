﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_111.Model
{
    public class Users : UserID
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Admin { get; set; }
    }
}
