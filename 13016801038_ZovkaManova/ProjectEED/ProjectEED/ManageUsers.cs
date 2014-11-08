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
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewUser newForm = new NewUser();
            newForm.Show();
            this.Hide();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        private void RefreshUsers()
        {
            lbUsers.Items.Clear();
            UsersRepository usersRepo = new UsersRepository();

            foreach (User user in usersRepo.GetAll())
            {
                lbUsers.Items.Add(user);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            User user = (User)lbUsers.SelectedItem;
            if (lbUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user!");
            }
            else
            {
                EditUser editUser = new EditUser();
                editUser.SetUser(user);
                editUser.Show();
                this.Hide();

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            User user = (User)lbUsers.SelectedItem;

            UsersRepository usersRepo = new UsersRepository();

            if (user == null)
            {
                MessageBox.Show("Please select a user!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you really want to delete this user?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    usersRepo.Delete(user);
                    this.Hide();
                    ManageUsers mngUsers = new ManageUsers();
                    mngUsers.Show();
                }
            }

        }
    }
}
