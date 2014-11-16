using System;
using System.Windows.Forms;
using UsersManager.Services;

namespace UsersManager
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            AuthenticationService.AuthenticateUser(textBoxUsername.Text, textBoxPassword.Text);
            if (AuthenticationService.LoggedUser != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
