using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookManager.Controller;

namespace BookManager
{
    public partial class ViewAll : Form
    {
        public ViewAll()
        {
            InitializeComponent();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            this.titlePanel.Controls.Clear();
            this.authorPanel.Controls.Clear();
            this.pricePanel.Controls.Clear();
            this.isbnPanel.Controls.Clear();

            List<BookEntity> books = new List<BookEntity>();
            books = BookController.GetBooks();
            foreach (BookEntity singleBook in books)
            {
                /*create a separate label for every property
                  in each record in books list*/
                ViewLabel titleLabel = new ViewLabel();
                ViewLabel authorLabel = new ViewLabel();
                ViewLabel priceLabel = new ViewLabel();
                ViewLabel isbnLabel = new ViewLabel();

                titleLabel.Text = singleBook.Title;
                authorLabel.Text = singleBook.Author;
                priceLabel.Text = singleBook.Price;
                isbnLabel.Text = singleBook.ISBN;

                //add each label to its separate flow panel
                this.titlePanel.Controls.Add(titleLabel);
                this.authorPanel.Controls.Add(authorLabel);
                this.pricePanel.Controls.Add(priceLabel);
                this.isbnPanel.Controls.Add(isbnLabel);
            }
        }

        private void editBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindBook addBookform = new FindBook();
            addBookform.Show();
            this.Hide();
        }

        private void addDeleteBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook addBookform = new AddBook();
            addBookform.Show();
            this.Hide();
        }

        private void splashPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookManager bookManagerform = new BookManager();
            bookManagerform.Show();
            this.Hide();
        }

    }
}
