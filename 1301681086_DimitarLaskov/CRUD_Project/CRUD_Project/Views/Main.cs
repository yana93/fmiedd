using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_Project.Controllers;
using CRUD_Project.Models;
using CRUD_Project.Views;

namespace CRUD_Project.View
{
    public partial class Main : Form
    {
        private Models.ModelUser currentUser;

        public Main()
        {
            InitializeComponent();
        }

        public void LoggedUser(int userID)
        {
            ControllerUser ctr1 = new ControllerUser();
            currentUser = ctr1.SetCurrentUser(userID);
            toolStripStatusLabelUser.Text = currentUser.Username;
        }

        public Form mainForm { get; set; }

        private void Main_Load(object sender, EventArgs e)
        {
            ControllerMovie ctrlMovie = new ControllerMovie();
            ctrlMovie.LoadMoviesToListView(listView1);
            comboBox1.Items.AddRange(ControllerCategory.LoadAllCategories());
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddMovies addMovies = new AddMovies();
            addMovies.CurrentUser = currentUser;
            addMovies.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMovie a = new ShowMovie();
            ModelMovie.MovieID = Convert.ToInt32(listView1.SelectedItems[0].Text);
            a.Show();
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            comboBox1.Items.Clear();
            ControllerMovie ctrlMovie = new ControllerMovie();
            ctrlMovie.LoadMoviesToListView(listView1);
            comboBox1.Items.AddRange(ControllerCategory.LoadAllCategories());
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageMovies manage = new ManageMovies();
            manage.Show();
        }
    }
}
