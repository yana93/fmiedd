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
using System.Collections;
using System.Collections.Specialized;

namespace BookManager
{
    public partial class FindBook : Form
    {
        public FindBook()
        {
            InitializeComponent();
        }

        //using an ordered dictionary (associative array) to send query parameters
        OrderedDictionary parameters = new OrderedDictionary();

        private void PopulateTextboxes()
        {
            BookEntity book = new BookEntity();
            book = BookController.GetByTitle(tb_input.Text);

            if (book.Title != null)
            {
                parameters.Add("id", book.ID);
                tb_title.Text = book.Title;
                tb_author.Text = book.Author;
                tb_price.Text = book.Price;
                tb_isbn.Text = book.ISBN;

                tb_title.Visible = true;
                tb_price.Visible = true;
                tb_author.Visible = true;
                tb_isbn.Visible = true;
            }
            else
            {
                MessageBox.Show("No records match the input criteria.", "Information");
            }
        }

        private void HideAndClear()
        {
            parameters.Clear();
            tb_title.Visible = false;
            tb_author.Visible = false;
            tb_price.Visible = false;
            tb_isbn.Visible = false;
        }
        
        private void btn_search_Click(object sender, EventArgs e)
        {
            HideAndClear();

            //checking if user has input anything first
            if (tb_input.Text == "")
            {
                MessageBox.Show("You have to input a title.");
                tb_input.Focus();
            }
            else
            {
                PopulateTextboxes();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            parameters.Remove("title");
            parameters.Remove("author");
            parameters.Remove("price");
            parameters.Remove("isbn");
            parameters.Add("title", tb_title.Text);
            parameters.Add("author", tb_author.Text);
            parameters.Add("price", tb_price.Text);
            parameters.Add("isbn", tb_isbn.Text);

            try
            {
                bool success = BookController.Edit(parameters);

                if (success == true)
                {
                    MessageBox.Show("Changes successfully saved.", "Information");
                }
                else
                {
                    MessageBox.Show("Saving shanges failed.", "Information");
                }
            }
            catch(Exception) {}
          
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            HideAndClear();
            PopulateTextboxes();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo);

            if (delete == DialogResult.Yes)
            {
                try
                {
                    bool success = BookController.Delete(parameters["id"].ToString());

                    if (success == true)
                    {
                        MessageBox.Show("Record successfully deleted.");
                    }
                    else
                    {
                        MessageBox.Show("Deleting record failed.");
                    }
                }
                catch (Exception) { }
            }
           
        }

        private void viewAllBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAll viewAllform = new ViewAll();
            viewAllform.Show();
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
