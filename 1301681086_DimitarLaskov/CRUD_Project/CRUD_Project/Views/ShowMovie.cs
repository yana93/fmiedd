using CRUD_Project.Controllers;
using CRUD_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Project.Views
{
    public partial class ShowMovie : Form
    {
        public ShowMovie()
        {
            InitializeComponent();
        }

        private void ShowMovie_Load(object sender, EventArgs e)
        {
            ControllerMovie ctrlMovie = new ControllerMovie();
            ModelMovie movie = ctrlMovie.GetOneMovie(ModelMovie.MovieID);

            labelMovieTitleValue.Text = movie.Title;
            labelDirectorValue.Text = movie.Director;
            labelCastValue.Text = movie.Cast;
            labelCountryValue.Text = movie.Country;
            labelYearValue.Text = movie.Year.ToString();
            labelDescrValue.Text = movie.Description;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
