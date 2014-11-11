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
    public partial class FrmNewStudnet : Form
    {
        DB_Access access = new DB_Access();

        public FrmNewStudnet()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmNewStudnet_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRegNo.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtPhoneNo.Text = "";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            access.addstudent(txtRegNo.Text, txtFname.Text, txtLname.Text, txtPhoneNo.Text);
            MessageBox.Show("Successfully added!");
        }
    }
}
