using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInformationSystemCRUDWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmNewStudnet addfr = new FrmNewStudnet();
            addfr.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            FrmViewStudents viewstd = new FrmViewStudents();
            viewstd.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmUpdateStudent upstd = new FrmUpdateStudent();
            upstd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FrmDeleteStudent delstd = new FrmDeleteStudent();
            delstd.Show();
        }
    }
}
