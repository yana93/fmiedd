using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Maria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void view_Click(object sender, EventArgs e)
        {
            View view = new View();
            view.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            UpdateForm upForm = new UpdateForm();
            upForm.Show();
        }
    }
}
