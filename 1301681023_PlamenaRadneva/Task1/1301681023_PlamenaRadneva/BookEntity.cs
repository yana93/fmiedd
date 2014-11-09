using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    class BookEntity
    {
        //this is our data-containing class which will help build the queries

        public string ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public string ISBN { get; set; }
    }
}
