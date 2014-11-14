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

namespace CRUD_Project.Views
{
    public partial class EditMovies : Form
    {
        private int id;
        private ModelMovie movie;

        public EditMovies(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void EditMovies_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.AddRange(ControllerCategory.LoadAllCategories());
            ControllerMovie ctrlMovie = new ControllerMovie();
            movie = ctrlMovie.GetOneMovie(id);

            textBoxTitle.Text = movie.Title;
            comboBoxCategory.SelectedIndex = Convert.ToInt32(movie.Category)-1;
            textBoxDirector.Text = movie.Director;
            textBoxCast.Text = movie.Cast;
            textBoxCountry.Text = movie.Country;
            dateTimePickerYear.Value = new DateTime(movie.Year, 1, 1); 
            textBoxDescr.Text = movie.Description;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Movy movie = new Movy
            {
                Category = comboBoxCategory.SelectedIndex,
                Title = textBoxTitle.Text,
                Cast = textBoxCast.Text,
                Director = textBoxDirector.Text,
                Year = Convert.ToInt32(dateTimePickerYear.Text),
                Country = textBoxCountry.Text,
                Description = textBoxDescr.Text,
                Id = id
            };

            ControllerMovie ctrlMovie = new ControllerMovie();
            ctrlMovie.EditMovie(movie);

            DialogResult result =
                MessageBox.Show("Movie successfully edited! \n Do you want to exit?", "Successfull operation!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
