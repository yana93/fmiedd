using ProjectEED.Entity;
using ProjectEED.Repository;
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
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ManageUsers mngUsers = new ManageUsers();
            UsersRepository repo = new UsersRepository();

            User user = new User();
            user.Username = txtUsername.Text.TrimEnd();
            user.Password = txtPassword.Text.TrimEnd();
            user.Email = txtEmail.Text.TrimEnd();
            user.Firstname = txtFirstname.Text.TrimEnd();
            user.Lastname = txtLastname.Text.TrimEnd();

            repo.Insert(user);

            this.Hide();
           
            mngUsers.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ManageUsers mngUsers = new ManageUsers();
            mngUsers.Show();
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
