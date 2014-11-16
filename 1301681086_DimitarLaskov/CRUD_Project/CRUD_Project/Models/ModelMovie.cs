using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Project.Models
{
    class ModelMovie
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Cast { get; set; }

        public string Director { get; set; }

        public int Year { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public static int MovieID { get; set; }

    }
}
