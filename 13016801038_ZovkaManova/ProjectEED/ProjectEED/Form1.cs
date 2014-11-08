using ProjectEED.Entity;
using ProjectEED.Repository;
using ProjectEED.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEED
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsersRepository repo = new UsersRepository();
            AuthenticationService.AuthenticateUser(txtUsername.Text, txtPassword.Text);
            if (AuthenticationService.LoggedUser != null)
            {
                ManageUsers manageUsersForm = new ManageUsers();
                manageUsersForm.Show();
            }
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
