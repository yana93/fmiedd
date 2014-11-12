using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UsersManager.Entities;

namespace UsersManager
{
    public partial class FormAddEditUser : Form
    {
        public FormAddEditUser()
        {
            InitializeComponent();
        }

        private User user;
        public FormAddEditUser(User user)
        {
            InitializeComponent();
            this.user = user;

            this.textBoxUsername.Text = user.Username;
            this.textBoxPassword.Text = user.Password;
            this.textBoxEmail.Text = user.Email;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Name cannot be empty");
            }
            if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Password cannot be empty");
            }
            if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Email cannot be empty");
            }

            this.user.Username = this.textBoxUsername.Text;
            this.user.Password = this.textBoxPassword.Text;
            this.user.Email = this.textBoxEmail.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
