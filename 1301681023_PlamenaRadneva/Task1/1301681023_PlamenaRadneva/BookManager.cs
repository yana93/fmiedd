using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BookManager
{
    public partial class BookManager : Form
    {
        public BookManager()
        {
            InitializeComponent();
        }

        private void viewAllBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAll viewAllform = new ViewAll();
            viewAllform.Show();
            this.Hide();
        }

        private void editBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindBook findBookform = new FindBook();
            findBookform.Show();
            this.Hide();
        }

        private void addDeleteBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook addBookform = new AddBook();
            addBookform.Show();
            this.Hide();
        }

    }
}
