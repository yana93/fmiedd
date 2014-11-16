using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;

namespace BookManager.Controller
{
    class BookController
    {
        //setting all methods to static because they will be called directly from BookManager.Controller.BookController

        public static List<BookEntity> GetBooks()
        {
            List<BookEntity> books = new List<BookEntity>();
            books = BookModel.GetAll();
            return books;
        }

        public static BookEntity GetByTitle(string title)
        {
            BookEntity book = new BookEntity();
            book = BookModel.GetByTitle(title);
            return book;
        }

        public static bool Add(OrderedDictionary parameters)
        {
            //using an ordered dictionary (associative array) to send query parameters

            int affectedRows = 0;
            //if affectedRows isn't 0, then the query has been successfull
            affectedRows = BookModel.Add(parameters);
            if (affectedRows == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Edit(OrderedDictionary parameters)
        {
            //using an ordered dictionary (associative array) to send query parameters

            int affectedRows = 0;
            //if affectedRows isn't 0, then the query has been successfull
            affectedRows = BookModel.Edit(parameters);
            if (affectedRows == 0)
            { 
                return false; 
            }
            else
            {
                return true;
            }
        }

        public static bool Delete(string id)
        {
            int affectedRows = 0;
            //if affectedRows isn't 0, then the query has been successfull
            affectedRows = BookModel.Delete(id);
            if (affectedRows == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
