using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Collections;
using System.Collections.Specialized;

namespace BookManager
{
    class BookModel
    {
        //setting all methods to static because they will be called directly from BookManager.Models.BookModel

       static OleDbConnection connenction = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=library.mdb;Persist Security Info=False;");

        public static List<BookEntity> GetAll()
        {
            List<BookEntity> bookCollection = new List<BookEntity>();

            string commandtext = "SELECT * FROM books";

            OleDbCommand command = new OleDbCommand(commandtext, connenction);

            try
            {
                connenction.Open();
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    //making a new book entity for every record in the DB
                    BookEntity book = new BookEntity();
                    book.ID = dataReader["ID"].ToString();
                    book.Title = dataReader["title"].ToString();
                    book.Author = dataReader["author"].ToString();
                    book.Price = dataReader["price"].ToString();
                    book.ISBN = dataReader["isbn"].ToString();

                    bookCollection.Add(book);

                }
                dataReader.Close();
            }

            catch (Exception e)
            { }

            finally
            {
                connenction.Close();
            }

            return bookCollection;

        }

        public static BookEntity GetByTitle(string title)
        {
            BookEntity book = new BookEntity();

            string commandtext = "SELECT * FROM books WHERE title = @title";

            OleDbCommand command = new OleDbCommand(commandtext, connenction);
            command.Parameters.AddWithValue("@title", title);

            try
            {
                connenction.Open();
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    book.ID = dataReader["id"].ToString();
                    book.Title = dataReader["title"].ToString();
                    book.Author = dataReader["author"].ToString();
                    book.Price = dataReader["price"].ToString();
                    book.ISBN = dataReader["isbn"].ToString();
                }
                dataReader.Close();
            }

            catch (Exception e)
            { }

            finally
            {
                connenction.Close();
            }

            return book;
        }

        public static int Add(OrderedDictionary parameters)
        {
            //using an ordered dictionary (associative array) to send query parameters
            string commandtext = "INSERT INTO books(title, author, price, isbn) VALUES(@title, @author, @price, @isbn)";

            OleDbCommand command = new OleDbCommand(commandtext, connenction);
            command.Parameters.AddWithValue("@title", parameters["title"].ToString());
            command.Parameters.AddWithValue("@author", parameters["author"].ToString());
            command.Parameters.AddWithValue("@price", parameters["price"].ToString());
            command.Parameters.AddWithValue("@isbn", parameters["isbn"].ToString());

            int affectedRows = 0;

            try
            {
                connenction.Open();
                affectedRows = command.ExecuteNonQuery();
                //if affectedRows isn't 0, then the query has been successfull
                return affectedRows;
            }

            catch (Exception e)
            { }

            finally
            {
                connenction.Close();
            }

            return affectedRows;

        }

        public static int Edit(OrderedDictionary parameters)
        {
            //using an ordered dictionary (associative array) to send query parameters
            OleDbCommand command = new OleDbCommand();
            command.Connection = connenction;

            string commandtext = @"UPDATE books SET title = @title, author = @author, price = @price, isbn = @isbn WHERE id = @id";

            command.Parameters.AddWithValue("@title", parameters["title"].ToString());
            command.Parameters.AddWithValue("@author", parameters["author"].ToString());
            command.Parameters.AddWithValue("@price", parameters["price"].ToString());
            command.Parameters.AddWithValue("@isbn", parameters["isbn"].ToString());
            command.Parameters.AddWithValue("@id", parameters["id"].ToString());

            command.CommandText = commandtext;

            int affectedRows = 0;

            try
            {
                connenction.Open();
                affectedRows = command.ExecuteNonQuery();
                //if affectedRows isn't 0, then the query has been successfull
                return affectedRows;
                
            }

            catch (Exception e)
            { }

            finally
            {
                connenction.Close();
            }

            return affectedRows; 

        }

        public static int Delete(string id)
        {
            string commandtext = "DELETE FROM books WHERE id = @id";

            OleDbCommand command = new OleDbCommand(commandtext, connenction);
            command.Parameters.AddWithValue("@id", id);

            int affectedRows = 0;
            try
            {
                connenction.Open();
                affectedRows = command.ExecuteNonQuery();
                //if affectedRows isn't 0, then the query has been successfull
                return affectedRows;
            }

            catch (Exception e)
            { }

            finally
            {
                connenction.Close();
            }

            return affectedRows;
        }

    }
}
